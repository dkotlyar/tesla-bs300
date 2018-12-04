using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TESLA_BS300
{
    class AnalysisShape
    {
        public PointF Location { get; set; }
        public float Size = 10;
        public Brush Brush
        {
            get
            {
                return Brushes.Gray;
            }
        }
        public Pen Pen
        {
            get
            {
                return Pens.Gray;
            }
        }

        public AnalysisShape(float x, float y)
        {
            this.Location = new PointF(x, y);
        }
        public AnalysisShape(PointF location)
        {
            Location = location;
        }

        public RectangleF GetRectangle(double h_mmPerPx, double v_mmPerPx)
        {
            return new RectangleF((float)(Location.X / h_mmPerPx) - Size / 2, (float)(Location.Y / v_mmPerPx) - Size / 2, Size, Size);
        }
    }
}
