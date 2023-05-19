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
            get => option3Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option3Enabled, value);
            }
        }


        bool option4Enabled;
        public bool Option4Enabled
        {
            get => option4Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option4Enabled, value);
            }
        }
        bool option5Enabled;
        public bool Option5Enabled
        {
            get => option5Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option5Enabled, value);
            }
        }
        bool option6Enabled;
        public bool Option6Enabled
        {
            get => option6Enabled;
            set
            {
                this.RaiseAndSetIfChanged(ref option6Enabled, value);
            }
        }
        public int GetOption()
        {
            if (option1Enabled) {  return 0; }
            if (option2Enabled) {  return 1; }
            if (option3Enabled) {  return 1; }
            if (option4Enabled) {  return 0; }
            if (option5Enabled) {  return 0; }
            if (option6Enabled) {  return 0; }
            return 0;
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
