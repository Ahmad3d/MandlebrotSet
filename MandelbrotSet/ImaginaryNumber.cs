using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandelbrotSet
{
    class ImaginaryNumber
    {
        public double RealComponent { get; set; }
        public double ImaginaryComponent { get; set; }

        public ImaginaryNumber()
        {
            RealComponent = 0;
            ImaginaryComponent = 0;
        }

        public ImaginaryNumber(double realComponent, double imaginaryComponent)
        {
            RealComponent = realComponent;
            ImaginaryComponent = imaginaryComponent;
        }

        public ImaginaryNumber PowerOfTwo()
        {
            double tmpRealComponent;
            double tmpImaginaryComponent;
            tmpRealComponent = Math.Pow(RealComponent, 2) - Math.Pow(ImaginaryComponent, 2);
            tmpImaginaryComponent = 2 * RealComponent * ImaginaryComponent;
            return new ImaginaryNumber(tmpRealComponent, tmpImaginaryComponent);
        }

        public static ImaginaryNumber operator +(ImaginaryNumber imaginaryNum1, ImaginaryNumber imaginaryNum2)
        {
            ImaginaryNumber newImaginaryNum = new ImaginaryNumber();
            newImaginaryNum.RealComponent = imaginaryNum1.RealComponent + imaginaryNum2.RealComponent;
            newImaginaryNum.ImaginaryComponent = imaginaryNum1.ImaginaryComponent + imaginaryNum2.ImaginaryComponent;
            return newImaginaryNum;
        }
    }
}
