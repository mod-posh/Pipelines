using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Gha
{
    public class Step
    {
        public string Id { get; set; } = string.Empty;
        public string If { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Uses { get; set; } = string.Empty;
        public string Run { get; set; } = string.Empty;
        public Dictionary<string, string> With { get; set; } = new Dictionary<string, string>();
    }
}