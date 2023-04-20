using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using DiagramEditor.Models.DiagramObjects;
using System.Collections.ObjectModel;
using ReactiveUI;
using DynamicData.Diagnostics;

namespace DiagramEditor.Views
{
    public class DiagramElementControl : TemplatedControl
    {
        public static readonly StyledProperty<ObservableCollection<DiagramElementAttribute>> AttributesProperty =
            AvaloniaProperty.Register<DiagramElementControl, ObservableCollection<DiagramElementAttribute>>("Attributes");

        public ObservableCollection<DiagramElementAttribute> Attributes
        {
            get => GetValue(AttributesProperty);
            set => SetValue(AttributesProperty, value);
        }

        public static readonly StyledProperty<bool> IsInterfaceProperty =
            AvaloniaProperty.Register<DiagramElementControl, bool>("IsInterface");
        public bool IsInterface
        {
            get => GetValue(IsInterfaceProperty);
            set => SetValue(IsInterfaceProperty, value);
        }

        public static readonly StyledProperty<Point> StartPointProperty =
            AvaloniaProperty.Register<DiagramElementControl, Point>("StartPoint");

        public Point StartPoint
        {
            get => GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);   
        }
        public DiagramElementControl()
        {
            
        }

    }
}
