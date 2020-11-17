using AutoMapper;
using DentaFlow.DTOs;
using DentaFlow.Models;

namespace DentaFlow.Profiles
{
    public class DoctorsProfile :Profile
    {
        public DoctorsProfile()
        {
            CreateMap<Doctor, DoctorReadDTO>(); //mapping for reading (GET)

            CreateMap<DoctorCreateDTO, Doctor>();//mapping for create (POST) 
            CreateMap<DoctorUpdateDTO,Doctor>();//mapping for update (UPDATE / PUT)
            CreateMap<Doctor,DoctorUpdateDTO>();//mapping for update (UPDATE / PATCH)
        }

    }
}