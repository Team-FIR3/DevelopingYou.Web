using System.Text.Json.Serialization;

namespace DevelopingYou.Web.Models
{
    public class Instance
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("goalId")]
        public int GoalId { get; set; }

        // public string Date { get; set; }

        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public string EndTime { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
