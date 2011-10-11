using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MandelbrotSet
{
    public partial class frmMain : Form
    {
        GraphicsHelper m_GraphicsHelper;
        MandelbrotSet m_MandelbrotSetCreator;

        public frmMain()
        {
            InitializeComponent();
            m_GraphicsHelper = new GraphicsHelper(picField);
            m_GraphicsHelper.XCenter += 140;
            m_MandelbrotSetCreator = new MandelbrotSet();
            trkIterations.Value = m_MandelbrotSetCreator.IterationsLimit;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawField();
        }

        private void DrawField()
        {
            m_GraphicsHelper.ClearBuffer();
            double x1;
            double y1;
            double x2;
            double y2;
            int intColor = 0;
            int intRed = 0;
            int intGreen = 0;
            int intBlue = 0;

            if (chkAutoPrecision.Checked)
                //m_MandelbrotSetCreator.Precision = MandelbrotSet.DEFAULT_PRECISION * GraphicsHelper.DEFAULT_SCALE / m_GraphicsHelper.UnitScale;
                m_MandelbrotSetCreator.Precision = 0.1 * GraphicsHelper.DEFAULT_SCALE / (m_GraphicsHelper.UnitScale * trkPrecision.Value);
            else
                m_MandelbrotSetCreator.Precision = 0.1 / trkPrecision.Value;

            m_MandelbrotSetCreator.IterationsLimit = trkIterations.Value;

            m_GraphicsHelper.GetField(out x1, out y1, out x2, out y2);
            //List<XYData> points = m_MandelbrotSetCreator.GetPoints(x1, x2, y1, y2);
            List<XYData> points = m_MandelbrotSetCreator.GetPointsConcurrent(x1, x2, y1, y2);
            m_GraphicsHelper.DrawGrid();
            foreach (XYData xy in points)
            {
                if (xy.IsMandelbrotMember)
                    m_GraphicsHelper.DrawPoint(xy.XValue, xy.YValue);
                else
                {
                    intColor = (int)(xy.Iterations * 765 / m_MandelbrotSetCreator.IterationsLimit);
                    intGreen = Math.Min(intColor, 255);
                    intColor = intColor > 255 ? intColor - 255 : 0;
                    intRed = Math.Min(intColor, 255);
                    intColor = intColor > 255 ? intColor - 255 : 0;
                    intBlue = Math.Min(intColor, 255);
                    m_GraphicsHelper.DrawPoint(xy.XValue, xy.YValue, Color.FromArgb(intRed - (intBlue/2), intGreen - (intRed/2), intBlue));
                }
            }

            m_GraphicsHelper.FlushBuffer();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            m_GraphicsHelper.FlushBuffer();
        }

        private void picField_MouseClick(object sender, MouseEventArgs e)
        {
            double x = e.X;
            double y = e.Y;
            m_GraphicsHelper.XCenter += (m_GraphicsHelper.XCenter - x);
            m_GraphicsHelper.YCenter += (m_GraphicsHelper.YCenter - y);
            
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
                m_GraphicsHelper.UnitScale *= 2;
            else
                m_GraphicsHelper.UnitScale /= 2;

            DrawField();
        }

        private void chkAutoPrecision_CheckedChanged(object sender, EventArgs e)
        {
            //trkPrecision.Enabled = lblPrecision.Enabled = !chkAutoPrecision.Checked;
        }
    }
}
