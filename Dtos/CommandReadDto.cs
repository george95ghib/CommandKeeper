using System.ComponentModel.DataAnnotations;

namespace CommandKeeper.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        
    }
}