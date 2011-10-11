using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MandelbrotSet
{
    public class GraphicsHelper
    {
        public const int DEFAULT_SCALE = 240;
        private const int POINT_SCALE = 2;
        private Coordinator m_Coordinator;

        private PictureBox m_PictureBox;

        private Graphics m_MainGraphicsObj;
        private Graphics m_BufferGraphics;
        private Bitmap m_Buffer;
        private SolidBrush m_Brush;
        private SolidBrush m_OuterBrush;

        private Pen m_Pen;

        public double XCenter
        {
            get { return m_Coordinator.XCenter; }
            set { m_Coordinator.XCenter = value; }
        }

        public double YCenter
        {
            get { return m_Coordinator.YCenter; }
            set { m_Coordinator.YCenter = value; }
        }

        public double UnitScale
        {
            get { return m_Coordinator.UnitScale; }
            set { m_Coordinator.UnitScale = value; }
        }

        
        /// <summary>
        /// Determines whether the smoothing should be set to AntiAlias or Default mode
        /// </summary>
        public bool HighQuality
        {
            get 
            {
                return (m_BufferGraphics.SmoothingMode == System.Drawing.Drawing2D.SmoothingMode.AntiAlias);
            }
            set 
            {
                m_BufferGraphics.SmoothingMode = value ? System.Drawing.Drawing2D.SmoothingMode.AntiAlias : System.Drawing.Drawing2D.SmoothingMode.Default; 
            }
        }


        public GraphicsHelper(PictureBox picBox)
        {
            m_PictureBox = picBox;
            m_Coordinator = new Coordinator(picBox.Width / 2, picBox.Height / 2, DEFAULT_SCALE);

            m_Buffer = new Bitmap(m_PictureBox.Width, m_PictureBox.Height);

            m_MainGraphicsObj = m_PictureBox.CreateGraphics();
            m_BufferGraphics = Graphics.FromImage(m_Buffer);
            m_Brush = new SolidBrush(Color.Black);
            m_OuterBrush = new SolidBrush(Color.LightSalmon);

            m_Pen = new Pen(Color.LightGray);

            HighQuality = true;
        }

        public void ClearView()
        {
            m_BufferGraphics.Clear(Color.White);
            m_MainGraphicsObj.Clear(Color.White);
        }

        public void ClearBuffer()
        {
            m_BufferGraphics.Clear(Color.White);
        }

        public void FlushBuffer()
        {
            m_MainGraphicsObj.DrawImage(m_Buffer, 0, 0);
        }

        public void DrawPoint(double x, double y)
        {
            DrawPoint(x, y, Color.Black);
        }

        public void DrawPoint(double x, double y, Color pointColor)
        {
            m_Coordinator.ConvertXY(ref x, ref y);
            m_Brush.Color = pointColor;
            m_BufferGraphics.FillEllipse(m_Brush, (float)(x - POINT_SCALE / 2), (float)(y - POINT_SCALE / 2), POINT_SCALE, POINT_SCALE);
        }

        public void GetField(out double x1, out double y1, out double x2, out double y2)
        {
            //lower left is the logical start in catesian
            x1 = 0;
            y1 = m_PictureBox.Height;

            //upper right is the logical end in catesian
            x2 = m_PictureBox.Width;
            y2 = 0;
            
            m_Coordinator.RevertXY(ref x1, ref y1);
            m_Coordinator.RevertXY(ref x2, ref y2);
        }

        public void DrawGrid()
        {
            double x1, y1;
            double x2, y2;

            GetField(out x1, out y1, out x2, out y2);
            x1 = (int)x1 - 1;
            x2 = (int)x2 + 1;
            y1 = (int)y1 - 1;
            y2 = (int)y2 + 1;

            double tmpX, tmpY;
            for (tmpX = x1; tmpX < x2; tmpX++)
            {
                DrawLine(tmpX, y1, tmpX, y2);
            }

            for (tmpY = y1; tmpY < y2; tmpY++)
            {
                DrawLine(x1, tmpY, x2, tmpY);
            }
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            m_Coordinator.ConvertXY(ref x1, ref y1);
            m_Coordinator.ConvertXY(ref x2, ref y2);
            m_BufferGraphics.DrawLine(m_Pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}
