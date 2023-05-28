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
                .WithTagMapping("!DiagramAggregationLine", typeof(DiagramAggregationLine))
                .WithTagMapping("!DiagramAssociationLine", typeof(DiagramAssociationLine))
                .WithTagMapping("!DiagramCompositionLine", typeof(DiagramCompositionLine))
                .WithTagMapping("!DiagramDependencyLine", typeof(DiagramDependencyLine))
                .WithTagMapping("!DiagramInheritanceLine", typeof(DiagramInheritanceLine))
                .WithTagMapping("!DiagramRealisationLine", typeof(DiagramRealisationLine))
                .WithTagMapping("!DiagramElement", typeof(DiagramElement))
                .WithTagMapping("!DiagramElementAttribute", typeof(DiagramElementAttribute))
                .WithTagMapping("!DiagramElementOperation", typeof(DiagramElementOperation))
            .WithNamingConvention(PascalCaseNamingConvention.Instance)
            .Build();

            ObservableCollection<DiagramBaseElement> result = deserializer.Deserialize<ObservableCollection<DiagramBaseElement>>(yaml);
            return result;
        }
    }
}
