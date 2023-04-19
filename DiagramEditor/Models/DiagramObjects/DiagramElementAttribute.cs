using Avalonia.Controls;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramElementAttribute : AbstractNotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                this.SetAndRaise(ref name, value);
            }
        }
        private string type;
        public string Type
        {
            get => type;
            set
            {
                this.SetAndRaise(ref type, value);
            }
        }
        private string visibility;
        public string Visibility
        {
            get => visibility;
            set
            {
                this.SetAndRaise(ref visibility, value);
            }
        }
        private string? stereotype;
        public string? Stereotype
        {
            get => stereotype;
            set
            {
                this.SetAndRaise(ref stereotype, value);
            }
        }
    }
}
