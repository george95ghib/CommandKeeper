using AutoMapper;
using CommandKeeper.Dtos;
using CommandKeeper.Models;

namespace CommandKeeper.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
        }
    }
}