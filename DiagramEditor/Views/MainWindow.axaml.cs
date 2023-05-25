using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.LogicalTree;
using Avalonia.VisualTree;
using DiagramEditor.Models.DiagramObjects;
using DiagramEditor.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Point = Avalonia.Point;

namespace DiagramEditor.Views
{
    public partial class MainWindow : Window
    {
        private Point pointPointerPressed;
        private Point pointerPositionIntoShape;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnPointerPressed(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            if (pointerPressedEventArgs.Source is Control control)
            {
                if (control.DataContext is DiagramElement diagram)
                {
                    //Get pressed coordinates
                    pointPointerPressed = pointerPressedEventArgs
                        .GetPosition(
                        this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("highLevelCanvas")));

                    if (pointerPressedEventArgs.Source is not Ellipse)
                    {
                        pointerPositionIntoShape = pointerPressedEventArgs.GetPosition(control);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerPressedReleasedDragShape;
                    }
                    else
                    {
                        if (this.DataContext is MainWindowViewModel viewModel) //if ellipse
                        {

                            viewModel.CreateLine(diagram, pointPointerPressed);

                            this.PointerMoved += PointerMoveDrawLine;
                            this.PointerReleased += PointerPressedReleasedDrawLine;
                        }
                    }
                }
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Control control)
            {
                if (control.DataContext is DiagramElement element)
                {
                    Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());

                    element.StartPoint = new Point(
                        currentPointerPosition.X - pointerPositionIntoShape.X,
                        currentPointerPosition.Y - pointerPositionIntoShape.Y);
                    
                }
            }
        }

        private void PointerPressedReleasedDragShape(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerPressedReleasedDragShape;
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (this.DataContext is MainWindowViewModel viewModel)
            {
                Debug.WriteLine(sender);
                DiagramBaseLine connector = viewModel.ElementCollection[viewModel.ElementCollection.Count - 1] as DiagramBaseLine;
                Point currentPointerPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
                
                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
                connector.UpdateAngle();
            }
        }

        private void PointerPressedReleasedDrawLine(object? sender,
            PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants()
                        .OfType<Canvas>()
                        .FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false &&
                        canvas.Name.Equals("highLevelCanvas"));

            var coords = pointerReleasedEventArgs.GetPosition(canvas);
            

            List <Ellipse> ellipses = this.GetVisualDescendants().OfType<Ellipse>().ToList();
            System.Diagnostics.Debug.WriteLine("amount of ellipses={0}", ellipses.Count());

            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;
            foreach (Ellipse ellipse in ellipses)
            {
                if (ellipse.Bounds.Contains(coords))
                {
                    System.Diagnostics.Debug.WriteLine("Cursor on ellipse");
                    if (ellipse.DataContext is DiagramElement diagram)
                    {
                        DiagramBaseLine connector = viewModel.ElementCollection[viewModel.ElementCollection.Count - 1] as DiagramBaseLine;
                        connector.SecondElement = diagram;
                        return;
                    }
                }
            }
            //var element = canvas.InputHitTest(coords);
            //if (element is Ellipse ellipse)
            //{
            //    if (ellipse.DataContext is DiagramElement diagram)
            //    {
            //        DiagramBaseLine connector = viewModel.ElementCollection[viewModel.ElementCollection.Count - 1] as DiagramBaseLine;
            //        connector.SecondElement = diagram;
            //        return;
            //    }
            //}

            viewModel.ElementCollection.RemoveAt(viewModel.ElementCollection.Count - 1);
        }
    }
}
