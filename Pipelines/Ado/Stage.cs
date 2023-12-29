﻿using ModPosh.Pipelines.Serializers;
using System.Text;

namespace ModPosh.Pipelines.Ado
{
    public class Stage
    {
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty; 
        public string[] DependsOn { get;set; } = Array.Empty<string>();
        public string Condition { get; set; } = string.Empty;
        public Dictionary<string,string> Variables { get; set; } = new Dictionary<string, string>();
        public List<Job> Jobs { get; set; } = new List<Job>();
        public Stage() { }
        public Stage(string name)
        {
            Name = name;
        }
        public Stage(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }
        public Stage(string name, string displayName, string[] dependsOn)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition, Dictionary<string,string> variables)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
            Variables = variables;
        }
        public Stage(string name, string displayName, string[] dependsOn, string condition, Dictionary<string,string> variables, List<Job> jobs)
        {
            Name = name;
            DisplayName = displayName;
            DependsOn = dependsOn;
            Condition = condition;
            Variables = variables;
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