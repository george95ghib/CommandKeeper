using System.Collections.Generic;
using CommandKeeper.Data;
using CommandKeeper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandKeeper.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandKeeperRepo _repository;

        public CommandsController(ICommandKeeperRepo repository)
        {
            _repository = repository;
        }
        
        // private readonly MockCommandKeeperRepo _repository = new MockCommandKeeperRepo();

        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        // GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}