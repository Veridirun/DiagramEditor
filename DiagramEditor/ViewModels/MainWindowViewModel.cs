using Avalonia;
using DiagramEditor.Models.DiagramObjects;
using DiagramEditor.Models.Serializers;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<DiagramElementOperation> testOperations;
        public ObservableCollection<DiagramElementOperation> TestOperations
        {
            get => testOperations;
            set
            {
                this.RaiseAndSetIfChanged(ref testOperations, value);
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
                TestOperations = new ObservableCollection<DiagramElementOperation>();
                TestAttributes = new ObservableCollection<DiagramElementAttribute>();
                /*
                TestOperations.Add(new DiagramElementOperation
                {
                    Name = "test1",
                    Visibility = "public",
                    Type = "int"
                });
                TestOperations.Add(new DiagramElementOperation
                {
                    Name = "test2",
                    Visibility = "package",
                    Type = "string"
                });
                TestOperations.Add(new DiagramElementOperation
                {
                    Name = "test3",
                    Visibility = "private",
                    Type = "decimal"
                });
                
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
                */
                ElementCollection.Add(new DiagramElement
                {

                    ID = FindMaxID()+1,
                    StartPoint = new Avalonia.Point(100, 100),
                    Name = "Name",
                    IsInterface = true,
                    Attributes = TestAttributes,
                    Operations = TestOperations,
                    Height = 200,
                    Width = 200
                });
                //System.Diagnostics.Debug.WriteLine("ID={0}\n", FindMaxID());
                return null;
            });

            

            elementCollection = new ObservableCollection<DiagramBaseElement>();
        }
        public void DeleteLine(DiagramBaseLine line)
        {
            ElementCollection.Remove(line);
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
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                case 2:
                    ElementCollection.Add(new DiagramRealisationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "RealisationLine",
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                case 3:
                    ElementCollection.Add(new DiagramDependencyLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "DependencyLine",
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                case 4:
                    ElementCollection.Add(new DiagramAggregationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "AggregationLine",
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                case 5:
                    ElementCollection.Add(new DiagramCompositionLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "CompositionLine",
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                case 6:
                    ElementCollection.Add(new DiagramAssociationLine
                    {
                        StartPoint = pointPointerPressed,
                        EndPoint = pointPointerPressed,
                        Name = "AssociationLine",
                        FirstElement = diagram,
                        FirstElementID = diagram.ID
                    });
                    break;
                default:
                    break;
            }
        }
        private int FindMaxID()
        {
            int max = -1;
            foreach(var element in ElementCollection)
            {
                if(element is DiagramElement diagram)
                    if (diagram.ID > max)
                        max = diagram.ID;
            }
            return max;
        }

        public IEnumerable<ISaverLoaderFactory> SaverLoaderFactoryCollection { get; set; }
        public void SaveCollection(string path)
        {
            IElementSaver? figureSaver = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateSaver();
            if (figureSaver != null)
            {
                figureSaver.Save(ElementCollection, path);
            }
        }
        public void LoadCollection(string path)
        {
            elementCollection = null;
            elementCollection = new ObservableCollection<DiagramBaseElement>();


            IElementLoader? figureLoader = SaverLoaderFactoryCollection
                .FirstOrDefault(factory => factory.IsMatch(path) == true)?
                .CreateLoader();
            if (figureLoader != null)
            {
                ElementCollection = figureLoader.Load(ElementCollection, path);
            }
        }
    }

}
