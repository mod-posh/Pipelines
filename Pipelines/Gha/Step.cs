using ModPosh.Pipelines.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModPosh.Pipelines.Gha
{
    public class Step
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
        public string If { get; set; } = string.Empty;
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
        public string Uses { get; set; } = string.Empty;
        public string Run { get; set; } = string.Empty;
        public Dictionary<string, string> With { get; set; } = new Dictionary<string, string>();
        public Step() { }
        public Step(string id)
        {
            Id = id;
        }
        public Step(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public Step(string id, string name, string uses)
        {
            Id = id;
            Name = name;
            Uses = uses;
        }
        public Step(string id, string name, string uses, string run)
        {
            Id = id;
            Name = name;
            Uses = uses;
            Run = run;
        }
        public Step(string id, string name, string uses, string run, Dictionary<string, string> with)
        {
            Id = id;
            Name = name;
            Uses = uses;
            Run = run;
            With = with;
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