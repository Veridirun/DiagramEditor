using DiagramEditor.Models.DiagramObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiagramEditor.Models.Serializers
{
    public interface IElementSaver
    {
        void Save(IEnumerable<DiagramBaseElement> elements, string path);
    }
}
