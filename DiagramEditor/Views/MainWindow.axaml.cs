using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using DiagramEditor.Models.DiagramObjects;
using DiagramEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            if (pointerPressedEventArgs.ClickCount == 2)
            {
                if (pointerPressedEventArgs.Source is Control control) //двойной клик
                {
                    if (control.DataContext is DiagramElement diagram) //по элементу диаграммы
                    {
                        var newWindow = new DiagramElementEditView();
                        var newWindowViewModel = new DiagramElementEditViewModel();
                        newWindowViewModel.EditableDiagram = diagram;
                        if(this.DataContext is MainWindowViewModel viewModel)
                            newWindowViewModel.DiagramCollection = viewModel.ElementCollection;
                        newWindow.DataContext = newWindowViewModel;
                        newWindow.Show();
                    }
                    if (control.DataContext is DiagramBaseLine line) //по линии
                    {
                        if(this.DataContext is MainWindowViewModel viewModel)
                        {
                            viewModel.DeleteLine(line);
                        }
                    }
                }
            }
            else
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
                        currentPointerPosition.X-2*Math.Cos(connector.Angle*Math.PI/180),
                        currentPointerPosition.Y-2*Math.Sin(connector.Angle * Math.PI / 180));
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
            
            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            var element = canvas.InputHitTest(coords);
            if (element is Ellipse ellipse)
            {
                if (ellipse.DataContext is DiagramElement diagram)
                {
                    DiagramBaseLine connector = viewModel.ElementCollection[viewModel.ElementCollection.Count - 1] as DiagramBaseLine;
                    connector.SecondElement = diagram;
                    return;
                }
            }

            viewModel.ElementCollection.RemoveAt(viewModel.ElementCollection.Count - 1);
        }
        private async void OnExportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveCollection(path);
                }
            }
        }
        private async void OnImportMenuClickXML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadCollection(path[0]);
                }
            }
        }
        private async void OnExportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveCollection(path);
                }
            }
        }
        private async void OnImportMenuClickJSON(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadCollection(path[0]);
                }
            }
        }
        private async void OnExportMenuClickYAML(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "YAML files",
                    Extensions = new string[] { "yaml" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.SaveCollection(path);
                }
            }
        }
        private async void OnImportMenuClickYAML(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "YAML files",
                    Extensions = new string[] { "yaml" }.ToList()
                });

            string[]? path = await openFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.LoadCollection(path[0]);
                }
            }
        }
        private async void SaveFileDialogMenuPngClick(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "PNG files",
                    Extensions = new string[] { "png" }.ToList()
                });

            string? path = await saveFileDialog.ShowAsync(this);

            var canvas = this.GetVisualDescendants().OfType<Canvas>().Where(canvas => canvas.Name.Equals("canvas")).FirstOrDefault();
            if (path != null)
            {
                var pixelSize = new PixelSize((int)canvas.Bounds.Width, (int)canvas.Bounds.Height);
                var size = new Size(canvas.Bounds.Width, canvas.Bounds.Height);
                using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pixelSize, new Avalonia.Vector(96, 96)))
                {
                    canvas.Measure(size);
                    canvas.Arrange(new Rect(size));
                    bitmap.Render(canvas);
                    bitmap.Save(path);
                }
            }
        }
    }
}
