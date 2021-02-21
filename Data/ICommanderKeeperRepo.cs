using System.Collections.Generic;
using CommandKeeper.Models;

namespace CommandKeeper.Data
{
    public interface ICommandKeeperRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}