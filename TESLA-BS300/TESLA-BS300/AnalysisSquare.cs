using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TESLA_BS300
{
    class AnalysisSquare : AnalysisShape
    {
        public AnalysisSquare(float x, float y, float width, float height) : base(x, y)
        {
            Size = new SizeF(width, height);
        }
        public AnalysisSquare(PointF location, SizeF size) : base(location)
        {
            Size = size;
        }

        public new SizeF Size { get; set; }
        public new Brush Brush
        {
            get
            {
                return Brushes.BlueViolet;
            }
        }
        public new Pen Pen
        {
            get
            {
                return new Pen(Brush, 2);
            }
        }

        public new RectangleF GetRectangle(double h_mmPerPx, double v_mmPerPx)
        {
            return new RectangleF((float)(Location.X / h_mmPerPx), (float)(Location.Y / v_mmPerPx), (float)(Size.Width / h_mmPerPx), (float)(Size.Height / v_mmPerPx));
        }

        public double GetSquareArea()
        {
            return Math.Abs(Size.Width * Size.Height);
        }

        public Rectangle GetTextRectangle(double h_mmPerPx, double v_mmPerPx, Size textSize)
        {
            return new Rectangle((int)((Location.X + Size.Width / 2) / h_mmPerPx - textSize.Width / 2), (int)((Location.Y + Size.Height / 2) / v_mmPerPx - textSize.Height / 2), textSize.Width, textSize.Height);
        }
    }
}
