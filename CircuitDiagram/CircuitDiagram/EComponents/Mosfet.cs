﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CircuitDiagram.EComponents
{
    public class Mosfet : EComponent
    {
        public override double MinimumWidth
        {
            get
            {
                return 64.0f;
            }
        }

        public override Rect BoundingBox
        {
            get
            {
                if (Horizontal)
                    return new Rect(new Point(StartLocation.X, StartLocation.Y - 30), new Size(EndLocation.X - StartLocation.X, 60));
                else
                    return new Rect(new Point(StartLocation.X - 40, StartLocation.Y), new Size(54, EndLocation.Y - StartLocation.Y));
            }
        }

        public Mosfet()
        {
        }

        public override void Render(IRenderer dc, Color color)
        {
            if (!Horizontal)
            {
                Point startPos = Point.Add(StartLocation, new Vector((EndLocation.X - StartLocation.X) / 2, (EndLocation.Y - StartLocation.Y) / 2 - 30f));
                if (startPos.Y % 10 != 0)
                    startPos.Y = startPos.Y + 5d;
                dc.DrawLine(color, 2f, StartLocation, startPos);
                dc.DrawPath(null, color, 2.0f, String.Format("M {0} l 0,16 l -16,0 m -8,0 l 0,24 l -16,0 m 24,0 l 16,0 l 0,8 l 12,0 l 0,-20 l -28,0 m 16,20 L {1}", startPos, EndLocation));
                dc.DrawPath(null, color, 4.0f, String.Format("M {0} m -18,12 l 0,8 m 0,4 l 0,8 m 0,4 l 0,8", startPos));
                dc.DrawPath(color, color, 2.0f, String.Format("M {0} m -15,28 l 4,3 l 0,-6 l -4,3 l 2,2", startPos));
                dc.DrawEllipse(color, color, 1f, Point.Add(startPos, new Vector(0d, 48d)), 3f, 3f);
            }
            else
            {
                dc.DrawRectangle(Colors.Transparent, color, 1d, BoundingBox);
                dc.DrawText("This component can only be displayed vertically.", "Arial", 10d, color, Point.Add(StartLocation, new Vector(2d, -5d)));
            }
        }
    }
}