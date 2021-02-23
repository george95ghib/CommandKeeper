using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommandKeeper.Data;
using CommandKeeper.Dtos;
using CommandKeeper.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromDb = _repository.GetCommandById(id);

            if(commandModelFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromDb);

            _repository.UpdateCommand(commandModelFromDb);
            _repository.SaveChanges();

            return NoContent();

        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromDb = _repository.GetCommandById(id);

            if(commandModelFromDb == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromDb);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromDb);

            _repository.UpdateCommand(commandModelFromDb);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommandById(int id)
        {
            var commandModelFromDb = _repository.GetCommandById(id);

            if(commandModelFromDb == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromDb);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}