using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner.Chain
{
    public class ChainHandler
    {
        public static void RunSample(DesingPatterns pattern)
        {
            var interfaceType = typeof(ISampleRunner);
            var sampleClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToList();
            foreach (var sampleClass in sampleClasses)
            {
                var instance = (ISampleRunner)Activator.CreateInstance(sampleClass);
                instance.RunSample(pattern);
            }
        }
    }
}
