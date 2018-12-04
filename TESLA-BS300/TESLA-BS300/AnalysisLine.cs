using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TESLA_BS300
{
    class AnalysisLine : AnalysisShape
    {
        public AnalysisLine(float x, float y, float x1, float y1) : base(x, y)
        {
            this.Finish = new PointF(x1, y1);
        }

        public AnalysisLine(PointF location, PointF finish) : base(location)
        {
            Finish = finish;
        }

        public PointF Finish { get; set; }
        public new Brush Brush
        {
            get
            {
                return Brushes.Tomato;
            }
        }
        public new Pen Pen
        {
            get
            {
                return new Pen(Brush, 2);
            }
        }

        public PointF GetStartLocation(double h_mmPerPx, double v_mmPerPx)
        {
            return new PointF((float)(Location.X / h_mmPerPx), (float)(Location.Y / v_mmPerPx));
        }

        public PointF GetFinishLocation(double h_mmPerPx, double v_mmPerPx)
        {
            return new PointF((float)(Finish.X / h_mmPerPx), (float)(Finish.Y / v_mmPerPx));
        }

        public RectangleF GetStartRectangle(double h_mmPerPx, double v_mmPerPx)
        {
            return new RectangleF((float)(Location.X / h_mmPerPx) - Size / 2, (float)(Location.Y / v_mmPerPx) - Size / 2, Size, Size);
        }

        public RectangleF GetFinishRectangle(double h_mmPerPx, double v_mmPerPx)
        {
            return new RectangleF((float)(Finish.X / h_mmPerPx) - Size / 2, (float)(Finish.Y / v_mmPerPx) - Size / 2, Size, Size);
        }

        public double GetDistance()
        {
            float dX_mm = Finish.X - Location.X;
            float dY_mm = Finish.Y - Location.Y;
            return Math.Sqrt(Math.Pow(dX_mm, 2) + Math.Pow(dY_mm, 2));
        }

        public Point GetCenter(double h_mmPerPx, double v_mmPerPx)
        {
            return new Point((int)((Location.X + Finish.X) / 2 / h_mmPerPx), (int)((Location.Y + Finish.Y) / 2 / v_mmPerPx));
        }
    }
}
