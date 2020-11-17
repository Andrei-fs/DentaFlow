using System.Collections.Generic;
using AutoMapper;
using DentaFlow.Data;
using DentaFlow.DTOs;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DentaFlow.Controllers{


    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController :Controller{
        private readonly IDoctorRepo _repository;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepo repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        } 

        //GET api/Doctors
        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDTO>> GetAllDoctors( 
            [FromQuery] EntityResourceParameters doctorResourceParameters)
        {
            if(doctorResourceParameters==null)
            {
                return NotFound();
            }
            var doctorsFromRepo=_repository.GetAllDoctors(doctorResourceParameters);
            return Ok(_mapper.Map<IEnumerable<DoctorReadDTO>>(doctorsFromRepo));
        }




        // GET api/Doctors/id
        [HttpGet("{id}")]
        public ActionResult<DoctorReadDTO> GetDoctorById(int id)
        {
            var doctor=_repository.GetDoctorById(id);

            if(doctor!=null){
            return Ok(_mapper.Map<DoctorReadDTO>(doctor));
            }
            return NotFound();

        }
        //GET  api/doctors/doctorId/Pacients

        [HttpGet("{id}/pacients")]
        public ActionResult<PacientReadDTO> GetPacientsForDoctor(int id)
        {
            if (_repository.GetDoctorById(id)==null)
            {
                return NotFound();
            }
            var pacientsForDoctorFromRepo = _repository.GetPacients(id);
            return Ok(_mapper.Map<IEnumerable<PacientReadDTO>>(pacientsForDoctorFromRepo));

        }

 
        //GET api/Doctors/id/Appointments

        [HttpGet("{id}/appointments")]

        public ActionResult<AppointmentReadDTO> GetAppointmentsForDoctor(int id)
        {
             if  (_repository.GetDoctorById(id)==null)
            {
                return NotFound();
            }

            var appointmentsForDoctorFromRepo=_repository.GetAppointments(id);
            return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(appointmentsForDoctorFromRepo));
        }


        //GET api/Doctors/id/Appointments/appId

        [HttpGet("{doctorId}/appointments/{appointmentId}")]

        public ActionResult<AppointmentReadDTO> GetAppointmentForDoctor(int doctorId, int appointmentId)
        {
           
        if(!_repository.DoctorExists(doctorId))           //foloseste asta mai tarziu
        {
            return NotFound();
        }        
            var appointmentForDoctorFromRepo=_repository.GetAppointmentById(appointmentId,doctorId);

            if(appointmentForDoctorFromRepo==null)
            {
                return NotFound();
            }

          return Ok(_mapper.Map<AppointmentReadDTO>(appointmentForDoctorFromRepo));

        }

        
        // POST api/Doctors
        [HttpPost]
        public ActionResult<DoctorReadDTO> CreateDoctor(DoctorCreateDTO doctorCreateDTO)
        {
            var createDoctor=_mapper.Map<Doctor>(doctorCreateDTO);
            //for creating the doctor
            if(createDoctor!=null)
            {
                _repository.CreateDoctor(createDoctor);
            }else{
                return BadRequest(createDoctor);
            }
            _repository.SaveChanges();

            //for returining the doctor that was just created

            var doctorReadDTO=_mapper.Map<DoctorReadDTO>(createDoctor);

            return Ok(doctorReadDTO);
           
        }

        //PUT api/Doctors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDoctor(int id, DoctorUpdateDTO doctorUpdateDTO)
        {
            var doctorFromRepo=_repository.GetDoctorById(id);

            if(doctorFromRepo==null)
            {
                return NotFound();
            }
            
            _mapper.Map(doctorUpdateDTO, doctorFromRepo);

            _repository.UpdateDoctor(doctorFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateDoctor(int id, JsonPatchDocument<DoctorUpdateDTO> patchDocument)
        {
              var doctorFromRepo=_repository.GetDoctorById(id);

            if(doctorFromRepo==null)
            {
                return NotFound();
            }
            
            var doctorToPatch=_mapper.Map<DoctorUpdateDTO>(doctorFromRepo);

            patchDocument.ApplyTo(doctorToPatch, ModelState);

            if(!TryValidateModel(doctorToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(doctorToPatch,doctorFromRepo);
            _repository.UpdateDoctor(doctorFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id)
        {
              var doctorFromRepo=_repository.GetDoctorById(id);

            if(doctorFromRepo==null)
            {
                return NotFound();
            }
            _repository.DeleteDoctor(doctorFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}