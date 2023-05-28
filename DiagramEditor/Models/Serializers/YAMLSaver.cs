using DiagramEditor.Models.DiagramObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;

namespace DiagramEditor.Models.Serializers
{

    internal class YAMLSaver : IElementSaver
    {
        public void Save(IEnumerable<DiagramBaseElement> elements, string path)
        {
            var serializer = new SerializerBuilder()
                
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

            string yaml = serializer.Serialize(elements);
            File.WriteAllText(path, yaml);
        }
    }
}
