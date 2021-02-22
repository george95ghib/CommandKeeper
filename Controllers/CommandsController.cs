using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommandKeeper.Data;
using CommandKeeper.Dtos;
using CommandKeeper.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandKeeper.Controllers
{
    
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandKeeperRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandKeeperRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            
            if(commandItems.Count() > 0)
            {
                return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            }

            return NotFound();
            
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            
            return NotFound();
            
        }

        // POST api/commands
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }
    }
}