using DiagramEditor.Models.DiagramObjects;
using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using Microsoft.CodeAnalysis;

namespace DiagramEditor.ViewModels
{
    public class DiagramElementEditViewModel : ViewModelBase
    {
        public DiagramElementEditViewModel()
        {
            buttonAttributeRemove = ReactiveCommand.Create<DiagramElementAttribute, Unit>(attribute =>
            {
                DiagramAttributes.Remove(attribute);
                return Unit.Default;
            });
            buttonOperationRemove = ReactiveCommand.Create<DiagramElementOperation, Unit>(operation =>
            {
                DiagramOperations.Remove(operation);
                return Unit.Default;
            });
            buttonElementRemove = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                DiagramCollection.Remove(EditableDiagram);
                return Unit.Default;
            });
            buttonAttributeAdd = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                string visibilityString;
                switch (OperationVisibility)
                {
                    case 0:
                        visibilityString = "public";
                        break;
                    case 1:
                        visibilityString = "protected";
                        break;
                    case 2:
                        visibilityString = "private";
                        break;
                    case 3:
                        visibilityString = "package";
                        break;
                    default:
                        visibilityString = " ";
                        break;
                }
                DiagramAttributes.Add(new DiagramElementAttribute
                {
                    Name = AttributeName,
                    Type = AttributeType,
                    Visibility = visibilityString,
                    Stereotype = AttributeStereotype
                });
                return Unit.Default;
            });
            buttonOperationAdd = ReactiveCommand.Create<Unit, Unit>(_ =>
            {
                string visibilityString;
                switch (OperationVisibility)
                {
                    case 0:
                        visibilityString = "public";
                        break;
                    case 1:
                        visibilityString = "protected";
                        break;
                    case 2:
                        visibilityString = "private";
                        break;
                    case 3:
                        visibilityString = "package";
                        break;
                    default:
                        visibilityString = " ";
                        break;
                }
                DiagramOperations.Add(new DiagramElementOperation
                {
                    Name=OperationName,
                    Type=OperationType,
                    Visibility= visibilityString
                });
                return Unit.Default;
            });

        }
        public ReactiveCommand<Unit, Unit> buttonElementRemove { get; }
        public ReactiveCommand<DiagramElementAttribute, Unit> buttonAttributeRemove { get; }
        public ReactiveCommand<DiagramElementOperation, Unit> buttonOperationRemove { get; }
        public ReactiveCommand<Unit, Unit> buttonOperationAdd { get; }
        public ReactiveCommand<Unit, Unit> buttonAttributeAdd { get; }

        private DiagramElement editableDiagram;
        public DiagramElement EditableDiagram
        {
            get => editableDiagram;
            set => this.RaiseAndSetIfChanged(ref editableDiagram, value);
        }
        private ObservableCollection<DiagramBaseElement> diagramCollection;
        public ObservableCollection<DiagramBaseElement> DiagramCollection
        {
            get => diagramCollection;
            set => this.RaiseAndSetIfChanged(ref diagramCollection, value);
        }
        public ObservableCollection<DiagramElementAttribute> DiagramAttributes
        {
            get => EditableDiagram.Attributes;
        }
        public ObservableCollection<DiagramElementOperation> DiagramOperations
        {
            get => EditableDiagram.Operations;
        }
        public int Height
        {
            get => EditableDiagram.Height;
            set => EditableDiagram.Height = value;
        }
        public int Width
        {
            get => EditableDiagram.Width;
            set => EditableDiagram.Width = value;
        }
        public string DiagramName
        {
            get => EditableDiagram.Name;
            set => EditableDiagram.Name = value;
        }
        public bool DiagramIsInterface
        {
            get => EditableDiagram.IsInterface;
            set => EditableDiagram.IsInterface = value;
        }

        private string operationName;
        public string OperationName
        {
            get => operationName;
            set => this.RaiseAndSetIfChanged(ref operationName, value);
        }
        private string operationType;
        public string OperationType
        {
            get => operationType;
            set => this.RaiseAndSetIfChanged(ref operationType, value);
        }
        private int operationVisibility;
        public int OperationVisibility
        {
            get => operationVisibility;
            set
            {
                this.RaiseAndSetIfChanged(ref operationVisibility, value);
            }
        }
        private string attributeName;
        public string AttributeName
        {
            get => attributeName;
            set => this.RaiseAndSetIfChanged(ref attributeName, value);
        }
        private string attributeType;
        public string AttributeType
        {
            get => attributeType;
            set => this.RaiseAndSetIfChanged(ref attributeType, value);
        }
        private string? attributeStereotype;
        public string? AttributeStereotype
        {
            get => attributeStereotype;
            set => this.RaiseAndSetIfChanged(ref attributeStereotype, value);
        }
        private int attributeVisibility;
        public int AttributeVisibility
        {
            get => attributeVisibility;
            set
            {
                this.RaiseAndSetIfChanged(ref attributeVisibility, value);
            }
        }

    }
}
