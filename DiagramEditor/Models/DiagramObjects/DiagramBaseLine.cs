using Avalonia;
using DynamicData.Binding;
using System;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramBaseLine : AbstractNotifyPropertyChanged, DiagramBaseElement, IDisposable
    {
        public DiagramBaseLine()
        {
            Angle = 90;
        }
        
        private DiagramElement firstElement;
        private DiagramElement secondElement;

        private double angle;
        public double Angle
        {
            get => angle;
            set => SetAndRaise(ref angle, value);
        }
        private Point midPoint;
        public Point MidPoint
        {
            get => midPoint;
            set => SetAndRaise(ref midPoint, value);
        }
        public void UpdateMidPoint()
        {
            midPoint = new Point((endPoint.X + startPoint.X) / 2, (endPoint.Y + endPoint.X) / 2);
            //System.Diagnostics.Debug.WriteLine("MidPoint.X={0} MidPoint.X={1}\n", MidPoint.X, MidPoint.Y);
        }
        public void UpdateAngle()
        {
            double cos = (endPoint.X - startPoint.X) / Math.Sqrt(Math.Pow(endPoint.Y - startPoint.Y, 2) + Math.Pow(endPoint.X - startPoint.X, 2));

            Angle = Math.Acos(cos)*180/Math.PI;

            if (endPoint.Y < startPoint.Y)
                Angle = -Angle;

            UpdateMidPoint();
            //System.Diagnostics.Debug.WriteLine("Angle={0}\n",Angle);
        }
        public string Name { get; set; }

        private Point startPoint;
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }

        private Point endPoint;
        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }

        public DiagramElement FirstElement
        {
            get => firstElement;
            set
            {
                if (firstElement != null)
                {
                    firstElement.ChangeStartPoint -= OnFirstElementPositionChanged;
                }

                firstElement = value;

                if (firstElement != null)
                {
                    firstElement.ChangeStartPoint += OnFirstElementPositionChanged;
                }
            }
        }

        public DiagramElement SecondElement
        {
            get => secondElement;
            set
            {
                if (secondElement != null)
                {
                    secondElement.ChangeStartPoint -= OnSecondElementPositionChanged;
                }

                secondElement = value;

                if (secondElement != null)
                {
                    secondElement.ChangeStartPoint += OnSecondElementPositionChanged;
                }
            }
        }

        private int firstElementID;
        public int FirstElementID
        {
            get => firstElementID;
            set
            {
                firstElementID = value;
            }
        }
        private int secondElementID;
        public int SecondElementID
        {
            get => secondElementID;
            set
            {
                secondElementID = value;
            }
        }

        private void OnFirstElementPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
            UpdateAngle();
        }

        private void OnSecondElementPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
            UpdateAngle();
        }

        public void Dispose()
        {
            if (FirstElement != null)
            {
                FirstElement.ChangeStartPoint -= OnFirstElementPositionChanged;
            }

            if (SecondElement != null)
            {
                SecondElement.ChangeStartPoint -= OnSecondElementPositionChanged;
            }
        }
    }
}
