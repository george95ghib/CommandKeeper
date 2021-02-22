using AutoMapper;
using CommandKeeper.Dtos;
using CommandKeeper.Models;

namespace CommandKeeper.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
        }
    }
}