using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia;
using DiagramEditor.Models.DiagramObjects;

namespace DiagramEditor.Models.Serializers
{
    public class XMLSaver : IElementSaver
    {
        public void Save(IEnumerable<DiagramBaseElement> elements, string path)
        {
            var xDocument = new XDocument();
            var elementsTree=new XElement("ElementsTree");
            


            xDocument.Add(elementsTree);
            xDocument.Save(path);
        }
    }
}
