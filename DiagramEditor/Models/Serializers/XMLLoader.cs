using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DiagramEditor.Models.DiagramObjects;
using Color = Avalonia.Media.Color;
using Point = Avalonia.Point;

namespace DiagramEditor.Models.Serializers
{
    public class XMLLoader : IElementLoader
    {
        public ObservableCollection<DiagramBaseElement> Load(ObservableCollection<DiagramBaseElement> elementListTemp, string path)
        {
            XElement xelement = XElement.Load(path);

            IEnumerable<XElement> elements = xelement.Elements();

            ObservableCollection<DiagramBaseElement> elementList = new ObservableCollection<DiagramBaseElement>();

            return null;
        }

    }
}
