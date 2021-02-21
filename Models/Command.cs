namespace CommandKeeper.Models
{
    public class Command
    {
        
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }

        // public Command(int id, string howTo, string line, string platform)
        // {
        //     Id = id;
        //     HowTo = howTo;
        //     Line = line;
        //     Platform = platform;
        // }


    }
}