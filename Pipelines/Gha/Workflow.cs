using ModPosh.Pipelines.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Gha
{
    public class Workflow
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Za-z0-9_\$\(\)]+$", RegexOptions.Compiled);
        private string _name = string.Empty;
        private string _runName = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (!NameRegex.IsMatch(value))
                {
                    throw new ArgumentException("Name can only contain A-Z, a-z, 0-9, and underscore.");
                }
                _name = value;
            }
        }
        public string RunName
        {
            get => _runName;
            set
            {
                if (!NameRegex.IsMatch(value))
                {
                    throw new ArgumentException("Run-Name can only contain A-Z, a-z, 0-9, and underscore.");
                }
                _runName = value;
            }
        }
        public List<Gha.Job> Jobs { get; set; } = new List<Job>();
        public Workflow() { }
        public Workflow(string name)
        {
            Name = name;
        }
        public Workflow(string name, string runName)
        {
            Name = name;
            RunName = runName;
        }
        public Workflow(string name, string runName, List<Job> jobs)
        {
            Name = name;
            RunName = runName;
            Jobs = jobs;
        }
        public override string ToString()
        {
            ISerializer serializer = new YamlSerializer();
            try
            {
                return serializer.Serialize(this);
            }
            catch (Exception ex)
            {
                return $"Error during serialization: {ex.Message}";
            }
        }
    }
}