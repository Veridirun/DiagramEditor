using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.ObjectModel;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramElement : AbstractNotifyPropertyChanged, DiagramBaseElement
    {
        public DiagramElement()
        {
            width = 100;
            height = 100;
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetAndRaise(ref name, value);
        }
        private int id;
        public int ID
        {
            get => id;
            set => id = value;
        }

        private bool isInterface;
        public bool IsInterface
        {
            get => isInterface;
            set => SetAndRaise(ref isInterface, value);
        }

        private ObservableCollection<DiagramElementAttribute> attributes;
        public ObservableCollection<DiagramElementAttribute> Attributes
        {
            get => attributes;
            set
            {
                SetAndRaise(ref attributes, value);
            }
        }
        private ObservableCollection<DiagramElementOperation> operations;
        public ObservableCollection<DiagramElementOperation> Operations
        {
            get => operations;
            set => SetAndRaise(ref operations, value);
        }

        public event EventHandler<ChangeStartPointEventArgs> ChangeStartPoint;

        private Point startPoint;
        public Point StartPoint
        {
            get => startPoint;
            set
            {
                Point oldPoint = StartPoint;

                SetAndRaise(ref startPoint, value);

                if (ChangeStartPoint != null)
                {
                    ChangeStartPointEventArgs args = new ChangeStartPointEventArgs
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = StartPoint
                    };

                    ChangeStartPoint(this, args);
                }
            }
        }
        private int height;
        public int Height
        {
            get => height;
            set => SetAndRaise(ref height, value);
        }
        private int width;
        public int Width
        {
            get => width;
            set => SetAndRaise(ref width, value);
        }

    }
}
