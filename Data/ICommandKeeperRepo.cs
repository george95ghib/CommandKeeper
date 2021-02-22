using System.Collections.Generic;
using CommandKeeper.Models;

namespace CommandKeeper.Data
{
    public interface ICommandKeeperRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
    }
}