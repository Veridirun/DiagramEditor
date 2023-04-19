using Avalonia.Controls;
using DiagramEditor.Models.DiagramObjects;
using System;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.ViewModels
{
    public class DiagramElementViewModel : DiagramBaseViewModel
    {
        public override string ViewName => "Элемент";

        bool option1Enabled;
        public bool Option1Enabled
        {
            get => option1Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option1Enabled, value);
            }
        }
        bool option2Enabled;
        public bool Option2Enabled
        {
            get => option2Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option2Enabled, value);
            }
        }
        bool option3Enabled;
        public bool Option3Enabled
        {
            get => option1Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option3Enabled, value);
            }
        }
        public override Unit ClearElement()
        {
            throw new NotImplementedException();
        }

        public override DiagramBaseElement? GetElement()
        {
            throw new NotImplementedException();
        }
    }
}
