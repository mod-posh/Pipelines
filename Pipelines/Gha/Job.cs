using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Gha
{
    public class Job
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string If { get; set; } = string.Empty;
        public string RunsOn { get; set; } = string.Empty;
        public List<Step> Steps { get; set; } = new List<Step>();
    }
}