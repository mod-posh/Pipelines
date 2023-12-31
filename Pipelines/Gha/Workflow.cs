using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Gha
{
    public class Workflow
    {
        public string Name { get; set; } = string.Empty;
        public string RunName { get; set; } = string.Empty;
        public List<Gha.Job> Jobs { get; set; } = new List<Job>();
    }
}