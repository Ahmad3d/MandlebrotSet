using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandelbrotSet
{
    public class Coordinator
    {
        public double XCenter { get; set; }
        public double YCenter { get; set; }

        private double m_UnitScale;

        public Coordinator(double centerX, double centerY, double unitScale)
        {
            XCenter = centerX;
            YCenter = centerY;
            m_UnitScale = unitScale;
        }


        public void ConvertXY(ref double x, ref double y)
        {
            x = XCenter + x * m_UnitScale;
            y = YCenter - y * m_UnitScale;
        }

        public void RevertXY(ref double x, ref double y)
        {
            x = (x - XCenter) / m_UnitScale;
            y = (YCenter - y) / m_UnitScale;
        }

        public double UnitScale
        {
            get { return m_UnitScale; }
            set { m_UnitScale = value; }
        }
    }

    public class XYData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
        public int Iterations { get; set; }
        public bool IsMandelbrotMember { get; set; }
    }
}
