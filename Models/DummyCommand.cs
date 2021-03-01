using System;
using System.Text.Json.Serialization;

namespace CommandKeeper.Models
{
    public class DummyCommand
    {
        
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

        public string Platform { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}