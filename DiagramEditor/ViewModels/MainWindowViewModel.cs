using DiagramEditor.Models.DiagramObjects;
using DiagramEditor.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

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
        public MainWindowViewModel()
        {

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
            });
        }
    }

}