using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.Serializers
{
    internal class YAMLSaverLoaderFactory : ISaverLoaderFactory
    {
        public IElementLoader CreateLoader()
        {
            return new YAMLLoader();
        }

        public IElementSaver CreateSaver()
        {
            return new YAMLSaver();
        }

        public bool IsMatch(string path)
        {
            return ".yaml".Equals(Path.GetExtension(path));
        }
    }
}
