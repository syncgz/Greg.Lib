using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.Lib.CodeSnippet
{
    public class GenericConverter
    {
        public static T TryConvertObject<T>(Object cacheItem)
        {

            if (cacheItem is T)
            {
                return (T)cacheItem;
            }
            else
            {
                try
                {
                    return (T)Convert.ChangeType(cacheItem, typeof(T));
                }
                catch (InvalidCastException)
                {
                    return default(T);
                }
            }
        }

        public static T ConvertObject<T>(Object cacheItem)
        {

            if (cacheItem is T)
            {
                return (T)cacheItem;
            }
            else
            {
                return (T)Convert.ChangeType(cacheItem, typeof(T));
            }
        }
    }
}
