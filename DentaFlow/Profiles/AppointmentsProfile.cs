using AutoMapper;
using DentaFlow.Models;
using DentaFlow.DTOs;

namespace DentaFlow.Profiles
{
    public class AppointmentsProfile : Profile
    {
        public AppointmentsProfile()
        {
            //some changes here



            CreateMap<Appointment, AppointmentReadDTO>()
            .ForMember(
                dest => dest.DoctorName,
                opt => opt.MapFrom(src => $"{src.Doctor.FirstName} {src.Doctor.LastName}"))
            .ForMember(
                dest => dest.PacientName,
                opt => opt.MapFrom(src => $"{src.Pacient.FirstName} {src.Pacient.LastName}"))
            .ForMember(
                dest => dest.DoctorPhoneNumber,
                opt => opt.MapFrom(src => src.Doctor.Mobile));

            CreateMap<AppointmentCreateDTO, Appointment>();

         }
    }
}
// // .ForMember(
// //     //do i need this ?
// //     dest=>dest.AppointmentHour,
// //     opt=>opt.MapFrom(src=>src.AppointmentHour)
// // )
// .ForMember(
//     dest=>dest.Doctor.FirstName,
//     opt=>opt.MapFrom(src=>src.DoctorFirstName)
// )
//  .ForMember(
//     dest=>dest.Doctor.LastName,
//     opt=>opt.MapFrom(src=>src.DoctorLastName)
// )
//  .ForMember(
//     dest=>dest.Pacient.FirstName,
//     opt=>opt.MapFrom(src=>src.PacientFirstName)
// )
//  .ForMember(
//     dest=>dest.Pacient.LastName,
//     opt=>opt.MapFrom(src=>src.PacientLastName)
// );


// //no good shit  
// ;;asd






///mapare de la ex appointment create la pacient pt nume




// CreateMap<Appointment, AppointmentCreateDTO>()
// .ForMember(
//     dest => dest.DoctorFirstName,
//     opt => opt.MapFrom(src => src.Doctor.FirstName))
// .ForMember(
//     dest => dest.DoctorLastName,
//     opt => opt.MapFrom(src => src.Doctor.LastName))
// .ForMember(
//     dest => dest.PacientFirstName,
//     opt => opt.MapFrom(src => src.Pacient.FirstName))
// .ForMember(
//     dest => dest.PacientLastName,
//     opt => opt.MapFrom(src => src.Pacient.LastName));
//mapping for reading (GET)





// CreateMap<AppointmentCreateDTO, Appointment>();//mapping for create (POST)

// CreateMap<AppointmentUpdateDTO,Appointment>();//mapping for update (UPDATE / PUT)

// CreateMap<Appointment,AppointmentUpdateDTO>();//mapping for update (UPDATE / PATCH)

