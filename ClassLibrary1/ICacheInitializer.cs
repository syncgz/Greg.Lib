using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Lib.Cache.MemoryCache
{
    public interface ICacheInitializer<T>
    {
        T GetObject();

        string GetName();
    }
}
