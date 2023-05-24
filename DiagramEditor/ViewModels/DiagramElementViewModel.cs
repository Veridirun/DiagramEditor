using DiagramEditor.Models.DiagramObjects;
using ReactiveUI;
using System;
using System.Reactive;

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
            if (option1Enabled) { return 1; }
            if (option2Enabled) { return 2; }
            if (option3Enabled) { return 3; }
            if (option4Enabled) { return 4; }
            if (option5Enabled) { return 5; }
            if (option6Enabled) { return 6; }
            return 1;
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
