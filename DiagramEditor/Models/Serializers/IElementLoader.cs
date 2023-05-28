using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramEditor.Models.DiagramObjects;

namespace DiagramEditor.Models.Serializers
{
    public interface IElementLoader
    {
        ObservableCollection<DiagramBaseElement> Load(ObservableCollection<DiagramBaseElement> elements, string path);
    }
}
