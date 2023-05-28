using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiagramEditor.Models.Serializers
{
    internal class XMLSaverLoaderFactory : ISaverLoaderFactory
    {
        public IElementLoader CreateLoader()
        {
            return new XMLLoader();
        }

        public IElementSaver CreateSaver()
        {
            return new XMLSaver();
        }

        public bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
