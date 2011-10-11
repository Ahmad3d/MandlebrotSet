using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MandelbrotSet
{
    public class MandelbrotSet
    {
        public const double DEFAULT_PRECISION = 0.002;
        private const int DEFAULT_ITERATIONS_LIMIT = 100;

        public double Precision { get; set; }
        public int IterationsLimit { get; set; }

        public MandelbrotSet()
        {
            Precision = DEFAULT_PRECISION;
            IterationsLimit = DEFAULT_ITERATIONS_LIMIT;
        }

        public List<XYData> GetPoints(double xStart, double xEnd, double yStart, double yEnd)
        {
            int TestedIterations;
            List<XYData> resultList = new List<XYData>();
            double i;
            double j;
            for (i = xStart; i < xEnd; i += Precision)
            {
                for (j = yStart; j < yEnd; j += Precision)
                {
                    XYData xy = new XYData();
                    xy.IsMandelbrotMember = IsMandelbrotSetMember(i, j, out TestedIterations);
                    xy.XValue = i;
                    xy.YValue = j;
                    xy.Iterations = TestedIterations;
                    resultList.Add(xy);
                }
            }

            return resultList;
        }

        public List<XYData> GetPointsConcurrent(double xStart, double xEnd, double yStart, double yEnd)
        {
            List<Task> taskList = new List<Task>();
            List<XYData> resultList = new List<XYData>();
            double i;
            for (i = xStart; i < xEnd; i += Precision)
            {
                double iArg = i;
                Task<List<XYData>> task = Task<List<XYData>>.Factory.StartNew(() => GetPointsForX(iArg, yStart, yEnd));
                taskList.Add(task);
            }

            Task<List<XYData>>.WaitAll(taskList.ToArray());

            foreach (Task<List<XYData>> finishedTask in taskList)
            {
                resultList.AddRange(finishedTask.Result);
            }

            return resultList;
        }

        /// <summary>
        /// This function gets all the Mandelbrot set's members or ys (imaginary components) for a specific x (real component)
        /// </summary>
        /// <param name="x">Real component</param>
        /// <param name="yStart">The beginning of the y criteria to be tested</param>
        /// <param name="yEnd">The end of the y criteria to be tested</param>
        /// <returns>List of points with the value of x and all corresponding ys indicating the status of each of in terms of Mandelbrot's membership</returns>
        private List<XYData> GetPointsForX(double x, double yStart, double yEnd)
        {
            int TestedIterations;
            List<XYData> resultList = new List<XYData>();
            for (double j = yStart; j < yEnd; j += Precision)
            {
                XYData xy = new XYData();
                xy.IsMandelbrotMember = IsMandelbrotSetMember(x, j, out TestedIterations);
                xy.XValue = x;
                xy.YValue = j;
                xy.Iterations = TestedIterations;
                resultList.Add(xy);
            }
            return resultList;
        }

        public bool IsMandelbrotSetMember(double x, double y, out int TestedIterations)
        {
            int i;
            bool result = true;
            ImaginaryNumber C = new ImaginaryNumber(x, y);
            ImaginaryNumber Z = new ImaginaryNumber(0, 0);
            double distanceFromBase = 0;
            for (i = 0; i < IterationsLimit && result; i++)
            {
                Z = GetNextZ(Z, C);
                distanceFromBase = CalcDistFromBase(Z);
                if (distanceFromBase > 2)
                    result = false;
            }
            TestedIterations = i;
            return result;
        }

        public bool IsCircleSetMemter(double x, double y)
        {
            if ((Math.Pow(x, 2) + Math.Pow(y, 2)) <= 2)
                return true;
            else
                return false;
        }

        private ImaginaryNumber GetNextZ(ImaginaryNumber Z, ImaginaryNumber C)
        {
            ImaginaryNumber resultNumber = Z.PowerOfTwo() + C;
            return resultNumber;
        }

        private double CalcDistFromBase(ImaginaryNumber Z)
        {
            return Math.Sqrt(Math.Pow(Z.RealComponent, 2) + Math.Pow(Z.ImaginaryComponent, 2));
        }
    }
}
