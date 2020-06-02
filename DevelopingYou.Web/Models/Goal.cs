using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevelopingYou.Web.Models
{
    public class Goal
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("User Id")]
        public int UserId { get; set; }

        [Required]
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [Required]
        [JsonPropertyName("Start Value")]
        public decimal StartValue { get; set; }

        [Required]
        [JsonPropertyName("Target Value")]
        public decimal TargetValue { get; set; }

        [JsonPropertyName("Category")]
        public Category Category { get; set; }

        [JsonPropertyName("Instances")]
        public ICollection<Instance> Instances { get; set; }
    }

    public enum Category
    {
        Fitness,
        Financial,
        Nutrition,
        Psychological,
        Technological,
        Work,
        Recreational,
        Other

    }
}
