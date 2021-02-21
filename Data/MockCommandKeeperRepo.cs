using System.Collections.Generic;
using CommandKeeper.Models;

namespace CommandKeeper.Data
{
    public class MockCommandKeeperRepo : ICommandKeeperRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{ Id = 0, HowTo = "sare", Line = "piper", Platform = "oala" },
                new Command{ Id = 1, HowTo = "condimente", Line = "zahar", Platform = "ceasca" },
                new Command{ Id = 2, HowTo = "nisip", Line = "pamant", Platform = "lopata" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{ Id = 0, HowTo = "sare", Line = "piper", Platform = "oala" };
        }
    }
}