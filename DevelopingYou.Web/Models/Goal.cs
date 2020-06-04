﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevelopingYou.Web.Models
{
    public class Goal
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userid")]
        public int UserId { get; set; }

        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Required]
        [JsonPropertyName("startValue")]
        public decimal StartValue { get; set; }

        [Required]
        [JsonPropertyName("targetValue")]
        public decimal TargetValue { get; set; }

        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("instances")]
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
