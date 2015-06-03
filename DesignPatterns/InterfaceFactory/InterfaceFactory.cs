using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceFactory
{
    public class InterfaceFactory<T> 
    {
        public static T GetInstance()
        {
            var interfaceType = typeof(T);
            var firstClass = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .FirstOrDefault();
            if (firstClass != null)
            {
                return (T)Activator.CreateInstance(firstClass);
            }
            return default(T);
        }
    }
}