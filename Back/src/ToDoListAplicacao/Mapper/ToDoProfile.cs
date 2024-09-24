using AutoMapper;
using ToDoListAplicacao.Dto;
using ToDoListDominio;

namespace ToDoListAplicacao.Mapper
{
    public class ToDoProfile:Profile

    {
        public ToDoProfile()
        {
             CreateMap<ToDo, ToDoDto>().ReverseMap();
        }
    }
}