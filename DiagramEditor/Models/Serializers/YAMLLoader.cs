using DiagramEditor.Models.DiagramObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.Serializers
{
    internal class YAMLLoader : IElementLoader
    {
        public ObservableCollection<DiagramBaseElement> Load(ObservableCollection<DiagramBaseElement> elements, string path)
        {
            throw new NotImplementedException();
        }
    }
}
