using AutoMapper;
using DentaFlow.DTOs;
using DentaFlow.Models;

namespace DentaFlow.Profiles
{
    public class PacientsProfile : Profile
    {
        public PacientsProfile()
        {
            CreateMap<Pacient,PacientReadDTO>(); //mapping for reading (GET)
            CreateMap<PacientCreateDTO, Pacient>();//mapping for create (POST) 
            CreateMap<PacientUpdateDTO,Pacient>(); //mapping for update (UPDATE / PUT)
            CreateMap<Pacient,PacientUpdateDTO>(); //mapping for update (UPDATE / PATCH)
            CreateMap<DoctorPacient, PacientReadDTO>()
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Pacient.FirstName))
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.Pacient.LastName))
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Pacient.Email))
            .ForMember(
                dest => dest.Mobile,
                opt => opt.MapFrom(src => src.Pacient.Mobile)); 
        }

    }
}