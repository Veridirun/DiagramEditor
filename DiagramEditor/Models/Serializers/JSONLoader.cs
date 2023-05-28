using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramEditor.Models.DiagramObjects;

namespace DiagramEditor.Models.Serializers
{
    public class JSONLoader : IElementLoader
    {
        public ObservableCollection<DiagramBaseElement> Load(ObservableCollection<DiagramBaseElement> elements, string path)
        {
            var figuresJsontext = File.ReadAllText(path);

            var objects = JsonConvert.DeserializeObject<List<DiagramBaseElement>>(figuresJsontext,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    });
            ObservableCollection <DiagramBaseElement> elementList =
                new ObservableCollection<DiagramBaseElement>(objects);

            foreach(DiagramBaseElement element in elementList)
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

        
    }
}
