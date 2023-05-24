using Avalonia;
using DiagramEditor.Models.DiagramObjects;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace DiagramEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private ObservableCollection<DiagramBaseElement> elementCollection;
        public ObservableCollection<DiagramBaseElement> ElementCollection
        {
            get => elementCollection;
            set
            {
                this.RaiseAndSetIfChanged(ref elementCollection, value);
            }
        }
        private ObservableCollection<DiagramElementAttribute> testAttributes;
        public ObservableCollection<DiagramElementAttribute> TestAttributes
        {
            get => testAttributes;
            set
            {
                this.RaiseAndSetIfChanged(ref testAttributes, value);
            }
        }
        public ReactiveCommand<Unit, DiagramElement> buttonAdd { get; }

        private DiagramElementViewModel content;
        public DiagramElementViewModel Content
        {
            get => content;
        }
        public int GetLineType()
        {
            return content.GetOption();
        }
        public MainWindowViewModel()
        {
            content = new DiagramElementViewModel();
            buttonAdd = ReactiveCommand.Create<Unit, DiagramElement>(_ =>
            {
                ElementCollection.Add(new DiagramElement
                {
                    StartPoint = new Avalonia.Point(100, 100),
                    Name = "test",
                    IsInterface = true,
                    Attributes = TestAttributes,
                    Height = 200,
                    Width = 200
                });
                return null;
            });
            TestAttributes = new ObservableCollection<DiagramElementAttribute>();
            TestAttributes.Add(new DiagramElementAttribute
            {
                Name = "test1",
                Visibility = "public",
                Type = "int",
                Stereotype = "event"
            });
            TestAttributes.Add(new DiagramElementAttribute
            {
                Name = "test2",
                Visibility = "package",
                Type = "string",
                Stereotype = ""
            });
            TestAttributes.Add(new DiagramElementAttribute
            {
                Name = "test3",
                Visibility = "private",
                Type = "decimal",
                Stereotype = "property"
            });

            elementCollection = new ObservableCollection<DiagramBaseElement>();
            ElementCollection.Add(new DiagramElement
            {
                StartPoint = new Avalonia.Point(100, 100),
                Name = "test",
                IsInterface = true,
                Attributes = TestAttributes,
                Height = 200,
                Width = 200
            });
        }

        public void CreateLine(DiagramElement diagram, Point pointPointerPressed)
        {
            int lineType = GetLineType();

            switch (lineType)
            {
                case 1:
                    ElementCollection.Add(new DiagramInheritanceLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "InheritanceLine",
                        FirstElement = diagram
                    });
                    break;
                case 2:
                    ElementCollection.Add(new DiagramRealisationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "RealisationLine",
                        FirstElement = diagram
                    });
                    break;
                case 3:
                    ElementCollection.Add(new DiagramDependencyLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "DependencyLine",
                        FirstElement = diagram
                    });
                    break;
                case 4:
                    ElementCollection.Add(new DiagramAggregationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "AggregationLine",
                        FirstElement = diagram
                    });
                    break;
                case 5:
                    ElementCollection.Add(new DiagramCompositionLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "CompositionLine",
                        FirstElement = diagram
                    });
                    break;
                case 6:
                    ElementCollection.Add(new DiagramAssociationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "AssociationLine",
                        FirstElement = diagram
                    });
                    break;
                default:
                    break;
            }
        }
    }

}
