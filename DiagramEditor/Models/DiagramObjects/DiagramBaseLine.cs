using Avalonia;
using Avalonia.Controls.Shapes;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramBaseLine : AbstractNotifyPropertyChanged, DiagramBaseElement, IDisposable
    {
        private Point startPoint;
        private Point endPoint;
        private DiagramElement firstElement;
        private DiagramElement secondElement;
        public string Name { get; set; }
        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }

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

        private void OnFirstElementPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondElementPositionChanged(object? sender, ChangeStartPointEventArgs e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
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
