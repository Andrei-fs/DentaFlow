using System.Collections.Generic;
using AutoMapper;
using DentaFlow.Data;
using DentaFlow.DTOs;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace DentaFlow.Controllers
{
        //[Route("api/authors/{authorId}/courses")]
    [Route ( "api/appointments")]
   // ii pun ruta la fiecare metoda  
    [ApiController]
    public class AppointmentsController : Controller 
    {
        private readonly IPacientRepo _pacientRepository;
        private readonly IDoctorRepo _doctorRepository;
        private readonly IAppointmentRepo _repository;
        private readonly IMapper _mapper;

        public AppointmentsController(IAppointmentRepo repository,IMapper mapper, IDoctorRepo doctorRepo, IPacientRepo pacientRepo)
        {
        _pacientRepository = pacientRepo;
        _doctorRepository =doctorRepo;
        _repository=repository;
        _mapper=mapper;
        }



       // GET api/appointments ---GET appointments
        
        [HttpGet]
       public ActionResult<IEnumerable<AppointmentReadDTO>> GetAllAppointments(
         [FromQuery]  EntityResourceParameters appointmentResourceParameters)
        {
           var appointmentsFromRepo=_repository.GetAllAppointments(appointmentResourceParameters);

           return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(appointmentsFromRepo));

        }
        // GET api/appointments/id ---Get one appointment by id

        [HttpGet("{id}", Name="GetAppointment")]
        
        public ActionResult<AppointmentReadDTO> GetAppointmentById(int id)
        {
            var appointmentsFromRepo=_repository.GetAppointmentById(id);
            if(appointmentsFromRepo!=null)
            {
                return Ok(_mapper.Map<AppointmentReadDTO>(appointmentsFromRepo));
            }
            return NotFound();
        }

        //Get api/appointments/doctors/doctorId

        [HttpGet("doctors/{doctorId}")]
      
        public ActionResult<IEnumerable<AppointmentReadDTO>> GetAppointmentsForDoctor (int doctorId)
        {
            if  (_doctorRepository.GetDoctorById(doctorId)==null)
            {
                return NotFound();
            }

            var appointmentsFromDoctorFromRepo=_doctorRepository.GetAppointments(doctorId);
            return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(appointmentsFromDoctorFromRepo));
        }



        //GET api/appointments/pacients/pacientId

        [HttpGet("pacients/{pacientId}")]

         public ActionResult<IEnumerable<AppointmentReadDTO>> GetAppointmentsForPacient (int pacientId)
         {
             if ( _pacientRepository.GetPacientById(pacientId)==null){
                 return NotFound();
             }

             var appointmentsFromPacientFromRepo = _pacientRepository.GetAppointments(pacientId);
             return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(appointmentsFromPacientFromRepo));
         }

        //api/appointments/ ---POST Create an appointment
        [HttpPost]
        public ActionResult<AppointmentReadDTO> CreateAppointment (AppointmentCreateDTO appointmentCreateDTO)
        {
            //Creating the appointment

            var createAppointment=_mapper.Map<Appointment>(appointmentCreateDTO);
            
            if(createAppointment!=null)
            {
                _repository.CreateAppointment(createAppointment);
            }else{
                return BadRequest(createAppointment);
            }
            _repository.SaveChanges();


            //Returining the appointment
            var appointReadDTO =_mapper.Map<AppointmentReadDTO>(createAppointment);
            return Ok(appointReadDTO);

        }

        //DONT WANT TO UPDATE AN APPOINTMENT

        //api/appointments/id  DELETE an appointment

        [HttpDelete("{id}")]

        public ActionResult DeleteAppointment(int id)
        {
            var appointmentFromRepo=_repository.GetAppointmentById(id);
            if (appointmentFromRepo!=null)
            {
                _repository.DeleteAppointment(appointmentFromRepo);
                _repository.SaveChanges();
                return NoContent();
            }
            else{
                return NotFound();
            }
        } 
    }
}