using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramDottedLine : DiagramBaseLine
    {
        private List<Line> dottedLineList;
        public List<Line> DottedLineList
        {
            get
            {
                
                return dottedLineList;
            }
            set => SetAndRaise(ref dottedLineList, value);
        }

        public void UpdateLineList()
        {
            System.Diagnostics.Debug.WriteLine("getting lines");
            dottedLineList = new List<Line>();
            double length = Math.Sqrt(Math.Pow(EndPoint.X - StartPoint.X, 2) + Math.Pow(EndPoint.Y - StartPoint.Y, 2));
            double angle = (EndPoint.X - StartPoint.X) / (EndPoint.Y - StartPoint.Y);
            for (double coveredLength = 0; coveredLength < length; coveredLength += length / 8)
            {
                Point dotLineStart = new Point();
                Point dotLineEnd = new Point();

                dotLineStart = dotLineStart.WithX(StartPoint.X + coveredLength * Math.Cos(angle));
                dotLineStart = dotLineStart.WithY(StartPoint.Y + coveredLength * Math.Sin(angle));
                dotLineEnd = dotLineEnd.WithX(StartPoint.X + (coveredLength + length / 16) * Math.Cos(angle));
                dotLineEnd = dotLineEnd.WithY(StartPoint.Y + (coveredLength + length / 16) * Math.Sin(angle));

                dottedLineList.Add(new Line
                {
                    StartPoint = dotLineStart,
                    EndPoint = dotLineEnd,
                    //Stroke = new SolidColorBrush(Colors.Black),
                    //StrokeThickness = 2
                });
            }
        }

    }
}
