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
            var elementTree=new XElement("ElementTree");

            foreach (DiagramBaseElement element in elements)
            {
                if (element is DiagramElement)
                {
                    var tmpel = element as DiagramElement;
                    if (tmpel != null)
                    {
                        XElement attributesTree = new XElement("Attributes");
                        foreach (DiagramElementAttribute attribute in tmpel.Attributes)
                        {
                            attributesTree.Add(new XElement("Attribute",
                                new XElement("Name", attribute.Name),
                                new XElement("Type", attribute.Type),
                                new XElement("Visibility", attribute.Visibility),
                                new XElement("Stereotype", attribute.Stereotype)
                                ));
                        }
                        XElement operationsTree = new XElement("Operations");
                        foreach (DiagramElementAttribute attribute in tmpel.Attributes)
                        {
                            operationsTree.Add(new XElement("Operation",
                                new XElement("Name", attribute.Name),
                                new XElement("Type", attribute.Type),
                                new XElement("Visibility", attribute.Visibility)
                                ));
                        }

                        elementTree.Add(new XElement("DiagramElement",
                            new XElement("Name", tmpel.Name),
                            new XElement("ID", tmpel.ID),
                            new XElement("IsInterface", tmpel.IsInterface),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("Height", tmpel.Height),
                            new XElement("Width", tmpel.Width),
                            attributesTree,
                            operationsTree
                        ));
                    }
                }

                if (element is DiagramAggregationLine)
                {
                    var tmpel = element as DiagramAggregationLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramAggregationLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
                if (element is DiagramAssociationLine)
                {
                    var tmpel = element as DiagramAssociationLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramAssociationLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
                if (element is DiagramCompositionLine)
                {
                    var tmpel = element as DiagramCompositionLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramCompositionLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
                if (element is DiagramDependencyLine)
                {
                    var tmpel = element as DiagramDependencyLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramDependencyLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
                if (element is DiagramInheritanceLine)
                {
                    var tmpel = element as DiagramInheritanceLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramInheritanceLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
                if (element is DiagramRealisationLine)
                {
                    var tmpel = element as DiagramRealisationLine;
                    if (tmpel != null)
                    {
                        elementTree.Add(new XElement("DiagramRealisationLine",
                            new XElement("Angle", tmpel.Angle),
                            new XElement("StartPoint", tmpel.StartPoint),
                            new XElement("EndPoint", tmpel.EndPoint),
                            new XElement("FirstElementID", tmpel.FirstElementID),
                            new XElement("SecondElementID", tmpel.SecondElementID)
                        ));
                    }
                }
            }

                xDocument.Add(elementTree);
            xDocument.Save(path);
        }
    }
}
