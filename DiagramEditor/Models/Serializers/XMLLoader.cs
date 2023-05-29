using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
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

            foreach (var element in elements)
            {
                System.Diagnostics.Debug.WriteLine("============================");
                if (element.Name == "DiagramElement")
                {
                    DiagramElement newelement = new DiagramElement();
                    IEnumerable<XElement> elementProperties = element.Elements();
                    foreach (var property in elementProperties)
                    {
                        //System.Diagnostics.Debug.WriteLine("Property.Name={0}, Property.Value={1}",property.Name,property.Value);
                    }

                    newelement.Name = ParseName(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("Name={0}",newelement.Name);

                    newelement.ID = ParseID(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("ID={0}", newelement.ID);

                    newelement.IsInterface = ParseIsInterface(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("IsInterface={0}", newelement.IsInterface);

                    newelement.StartPoint = ParseStartPoint(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("StartPoint={0}", newelement.StartPoint);

                    newelement.Height = ParseHeight(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("Height={0}", newelement.Height);

                    newelement.Width = ParseWidth(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("Width={0}", newelement.Width);

                    newelement.Attributes = ParseAttributes(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("Attributes={0}", newelement.Attributes);

                    newelement.Operations = ParseOperations(elementProperties);
                    //System.Diagnostics.Debug.WriteLine("Operations={0}", newelement.Operations);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramAggregationLine")
                {
                    DiagramAggregationLine newelement = new DiagramAggregationLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramAssociationLine")
                {
                    DiagramAssociationLine newelement = new DiagramAssociationLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramCompositionLine")
                {
                    DiagramCompositionLine newelement = new DiagramCompositionLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramDependencyLine")
                {
                    DiagramDependencyLine newelement = new DiagramDependencyLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramInheritanceLine")
                {
                    DiagramInheritanceLine newelement = new DiagramInheritanceLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }
                if (element.Name == "DiagramRealisationLine")
                {
                    DiagramRealisationLine newelement = new DiagramRealisationLine();
                    IEnumerable<XElement> elementProperties = element.Elements();

                    newelement.Angle = ParseAngle(elementProperties);

                    newelement.StartPoint = ParseStartPoint(elementProperties);

                    newelement.EndPoint = ParseEndPoint(elementProperties);

                    newelement.FirstElementID = ParseFirstElementID(elementProperties);

                    newelement.SecondElementID = ParseSecondElementID(elementProperties);

                    elementList.Add(newelement);
                }

            }
            foreach (DiagramBaseElement element in elementList)
            {
                if (element is DiagramBaseLine line)
                {
                    line.FirstElement = (DiagramElement)elementList.FirstOrDefault(u =>
                    {
                        if (u is DiagramElement f)
                        {
                            if (f.ID == line.FirstElementID)
                            {
                                return true;
                            }
                        }
                        return false;
                    });
                    line.SecondElement = (DiagramElement)elementList.FirstOrDefault(u =>
                    {
                        if (u is DiagramElement f)
                        {
                            if (f.ID == line.SecondElementID)
                            {
                                return true;
                            }
                        }
                        return false;
                    });
                }
            }
            return elementList;
        }
        static string ParseName(IEnumerable<XElement> figureProperties)
        {
            return (from property in figureProperties
                    where property.Name == "Name"
                    select property.Value).First();
        }
        static int ParseID(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                              where property.Name == "ID"
                              select property.Value).First());
        }
        static double ParseAngle(IEnumerable<XElement> figureProperties)
        {
            return Double.Parse((from property in figureProperties
                              where property.Name == "Angle"
                              select property.Value).First(), CultureInfo.InvariantCulture);
        }
        static bool ParseIsInterface(IEnumerable<XElement> figureProperties)
        {
            return Boolean.Parse((from property in figureProperties
                                where property.Name == "IsInterface"
                                select property.Value).First());
        }
        static int ParseFirstElementID(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                                  where property.Name == "FirstElementID"
                              select property.Value).First());
        }
        static int ParseSecondElementID(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                                  where property.Name == "SecondElementID"
                              select property.Value).First());
        }
        static int ParseHeight(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                              where property.Name == "Height"
                              select property.Value).First());
        }
        static int ParseWidth(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                              where property.Name == "Width"
                              select property.Value).First());
        }
        static Point ParseStartPoint(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "StartPoint"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0], CultureInfo.InvariantCulture), double.Parse(substrings[1], CultureInfo.InvariantCulture));
        }
        static Point ParseEndPoint(IEnumerable<XElement> figureProperties)
        {
            foreach (var property in figureProperties)
            {
                System.Diagnostics.Debug.WriteLine("Property.Name={0}, Property.Value={1}",property.Name,property.Value);
            }
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "EndPoint"
                           select property.Value).First();

            System.Diagnostics.Debug.WriteLine($"pointString={pointString}");
            substrings = pointString.Split(',');
            return new Point(double.Parse(substrings[0], CultureInfo.InvariantCulture), double.Parse(substrings[1], CultureInfo.InvariantCulture));
        }
        static ObservableCollection<DiagramElementAttribute> ParseAttributes(IEnumerable<XElement> elementProperties)
        {
            string nameString=string.Empty;
            string typeString= string.Empty;
            string visibilityString= string.Empty;
            string? stereotypeString= string.Empty;

            XElement pointsElementTree = (from property in elementProperties
                                          where property.Name == "Attributes"
                                          select property).First();
            IEnumerable<XElement> attributesElement = from el in pointsElementTree.Elements()
                                                  where el.Name == "Attribute"
                                                  select el;
            /*
            foreach (XElement attrib in attributesElement)
            {
                System.Diagnostics.Debug.WriteLine("attrib.Name={0}, attrib.Value={1}", attrib.Name, attrib.Value);
            }
            */
            ObservableCollection<DiagramElementAttribute> attributes = new ObservableCollection<DiagramElementAttribute>();
            foreach (XElement element in attributesElement)
            {
                IEnumerable<XElement> attributeElement = element.Elements();
                foreach(XElement att in attributeElement) {
                    System.Diagnostics.Debug.WriteLine("attrib.Name={0}, attrib.Value={1}", att.Name, att.Value);
                    if (att.Name == "Name")
                        nameString = att.Value;
                    if (att.Name == "Type")
                        typeString = att.Value;
                    if (att.Name == "Visibility")
                        visibilityString = att.Value;
                    if (att.Name == "Stereotype")
                        stereotypeString = att.Value;
                    attributes.Add(new DiagramElementAttribute
                    {
                        Name=nameString,
                        Type=typeString,
                        Visibility=visibilityString,
                        Stereotype=stereotypeString
                    });
                }
            }
            return attributes;
        }
        static ObservableCollection<DiagramElementOperation> ParseOperations(IEnumerable<XElement> elementProperties)
        {
            string nameString = string.Empty;
            string typeString = string.Empty;
            string visibilityString = string.Empty;
            XElement pointsElementTree = (from property in elementProperties
                                          where property.Name == "Operations"
                                          select property).First();
            IEnumerable<XElement> attributesElement = from el in pointsElementTree.Elements()
                                                      where el.Name == "Operation"
                                                      select el;
            ObservableCollection<DiagramElementOperation> attributes = new ObservableCollection<DiagramElementOperation>();
            foreach (XElement element in attributesElement)
            {
                IEnumerable<XElement> attirubeElement = element.Elements();
                foreach (XElement att in attirubeElement)
                {
                    if (att.Name == "Name")
                        nameString = att.Value;
                    if (att.Name == "Type")
                        typeString = att.Value;
                    if (att.Name == "Visibility")
                        visibilityString = att.Value;
                    attributes.Add(new DiagramElementOperation
                    {
                        Name = nameString,
                        Type = typeString,
                        Visibility = visibilityString
                    });
                }
            }
            return attributes;
        }

    }
}
