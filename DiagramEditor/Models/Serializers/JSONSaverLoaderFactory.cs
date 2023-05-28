using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.Serializers
{
    public class JSONSaverLoaderFactory : ISaverLoaderFactory
    {
        public IElementLoader CreateLoader()
        {
            return new JSONLoader();
        }

        public IElementSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
