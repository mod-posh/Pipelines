using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModPosh.Pipelines.Ado;

namespace ModPosh.Pipelines.Serializers
{
    public class YamlSerializer : ISerializer
    {
        public string Serialize<T>(T obj)
        {
            if (obj is Stage stage)
            {
                return SerializeTemplate(stage);
            }
            if (obj is Job job)
            {
                return SerializeTemplate(job);
            }
            if (obj is Template template)
            {
                return SerializeTemplate(template);
            }
            if (obj is Pool pool)
            {
                return SerializeTemplate(pool);
            }
            if (obj is Pipeline pipeline)
            {
                return SerializeTemplate(pipeline);
            }

            throw new ArgumentException("Object type is not supported", nameof(obj));
        }

        private string SerializeTemplate(Stage stage)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Job job)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Template template)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Pool pool)
        {
            // Serialization logic here
        }
        private string SerializeTemplate(Pipeline pipeline)
        {
            // Serialization logic here
        }
    }
}
