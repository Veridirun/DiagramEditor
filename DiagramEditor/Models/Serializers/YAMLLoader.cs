using DiagramEditor.Models.DiagramObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.IO;

namespace DiagramEditor.Models.Serializers
{
    internal class YAMLLoader : IElementLoader
    {
        public ObservableCollection<DiagramBaseElement> Load(ObservableCollection<DiagramBaseElement> elements, string path)
        {
            string yaml = File.ReadAllText(path);
            var deserializer = new DeserializerBuilder()
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

            ObservableCollection<DiagramBaseElement> result = deserializer.Deserialize<ObservableCollection<DiagramBaseElement>>(yaml);
            return result;
        }
    }
}
