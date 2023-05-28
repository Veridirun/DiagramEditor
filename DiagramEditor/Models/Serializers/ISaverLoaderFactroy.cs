using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramEditor.Models.Serializers
{
    public interface ISaverLoaderFactory
    {
        IElementLoader CreateLoader();
        IElementSaver CreateSaver();

        bool IsMatch(string path);
    }
}
