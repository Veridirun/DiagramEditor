using DiagramEditor.Models.DiagramObjects;
using System.Reactive;

namespace DiagramEditor.ViewModels
{
    public abstract class DiagramBaseViewModel : ViewModelBase
    {
        public abstract string ViewName { get; }
        public abstract DiagramBaseElement? GetElement();
        public abstract Unit ClearElement();
    }
}
