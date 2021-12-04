using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.Framework.CustomContainerFolder
{
    public class CustomCallContext<T>
    {
        public static ConcurrentDictionary<string, AsyncLocal<T>> callContextData = new ConcurrentDictionary<string, AsyncLocal<T>>();

        public static void SetData(string name, T data)
        {
            callContextData.GetOrAdd(name, o => new AsyncLocal<T>()).Value = data;
        }

        public static T GetData(string name)
        {
            return callContextData.TryGetValue(name, out AsyncLocal<T> data)? data.Value : default(T);
        }


    }
}
