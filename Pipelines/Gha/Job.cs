using ModPosh.Pipelines.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModPosh.Pipelines.Gha
{
    public class Job
    {
        private static readonly Regex NameRegex = new Regex(@"^[A-Za-z0-9_\$\(\)]+$", RegexOptions.Compiled);
        private string _id = string.Empty;
        private string _name = string.Empty;
        public string Id
        {
            get => _id;
            set
            {
                if (!NameRegex.IsMatch(value))
                {
                    throw new ArgumentException("Id can only contain A-Z, a-z, 0-9, and underscore.");
                }
                _id = value;
            }
        }
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
        public string If { get; set; } = string.Empty;
        public string RunsOn { get; set; } = string.Empty;
        public List<Step> Steps { get; set; } = new List<Step>();
        public Job() { }
        public Job(string id)
        {
            Id = id;
        }
        public Job(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public Job(string id, string name, string runsOn)
        {
            Id = id;
            Name = name;
            RunsOn = runsOn;
        }
        public Job(string id, string name, string runsOn, string @if)
        {
            Id = id;
            Name = name;
            RunsOn = runsOn;
            If = @if;
        }
        public Job(string id, string name, string runsOn, string @if, List<Step> steps)
        {
            Id = id;
            Name = name;
            If = @if;
            RunsOn = runsOn;
            Steps = steps;
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