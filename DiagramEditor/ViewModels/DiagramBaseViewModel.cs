using DiagramEditor.Models.DiagramObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.ViewModels
{
    public abstract class DiagramBaseViewModel : ViewModelBase
    {
        public abstract string ViewName { get; }
        public abstract DiagramBaseElement? GetElement();
        public abstract Unit ClearElement();
    }
}
