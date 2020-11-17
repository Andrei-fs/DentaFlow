using System.Collections.Generic;
using AutoMapper;
using DentaFlow.Data;
using DentaFlow.DTOs;
using DentaFlow.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DentaFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientsController : Controller
    {
        private readonly IPacientRepo _repository;
        private readonly IMapper _mapper;

        public PacientsController(IPacientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //   api/pacients/ ---GET all pacients
        [HttpGet]
        public ActionResult<IEnumerable<PacientReadDTO>> GetAllPacients()
        {
            var pacientsfromRepo = _repository.GetAllPacients();
            return Ok(_mapper.Map<IEnumerable<PacientReadDTO>>(pacientsfromRepo));
        }

        //   api/pacients/{id} ---GET one pacient by id
        [HttpGet("{id}")]
        public ActionResult<PacientReadDTO> GetPacientById(int id)
        {
            var pacientFromRepo = _repository.GetPacientById(id);
            if (pacientFromRepo != null)
            {
                return Ok(_mapper.Map<PacientReadDTO>(pacientFromRepo));
            }
            return NotFound();

        }

        // api/pacients/{id}/appointments
        [HttpGet("{id}/appointments")]

        public ActionResult<AppointmentReadDTO> GetAppointmentsForPacient(int id)
        {
              if  (_repository.GetPacientById(id)==null)
            {
                return NotFound();
            }

            var appointmentsForPacientFromRepo=_repository.GetAppointments(id);
            return Ok(_mapper.Map<IEnumerable<AppointmentReadDTO>>(appointmentsForPacientFromRepo));

        }
        // api/pacients/{id}/appointments/id

  [HttpGet("{pacientId}/appointments/{appointmentId}")]

        public ActionResult<AppointmentReadDTO> GetAppointmentForPacient(int pacientId, int appointmentId)
        {
           
        if(!_repository.PacientExists(pacientId)) 
        {     
            return NotFound();
        }        
            var appointmentForPacientFromRepo=_repository.GetAppointmentById(appointmentId,pacientId);

            if(appointmentForPacientFromRepo==null)
            {
                return NotFound();
            }

          return Ok(_mapper.Map<AppointmentReadDTO>(appointmentForPacientFromRepo));

        }







        //   api/pacients/ ---POST Create a pacient

        [HttpPost]
        public ActionResult<PacientReadDTO> CreatePacient(PacientCreateDTO pacientCreateDTO)
        {
            //creating the pacient
            var createPacient = _mapper.Map<Pacient>(pacientCreateDTO);

            if (createPacient != null)
            {
                _repository.CreatePacient(createPacient);
            }
            else
            {
                return BadRequest(createPacient);
            }
            _repository.SaveChanges();

            //returining the pacient that was just created

            var pacientReadDTO = _mapper.Map<PacientReadDTO>(createPacient);
            return Ok(pacientReadDTO);

        }
        //   api/Pacients/{id} ---PUT Updating one specific pacient
        [HttpPut("{id}")]

        public ActionResult<PacientReadDTO> UpdatePacient(int id, PacientUpdateDTO pacientUpdateDTO)
        {
            var pacientFromRepo = _repository.GetPacientById(id);
            if (pacientFromRepo != null)
            {
                _mapper.Map(pacientUpdateDTO, pacientFromRepo);
                _repository.UpdatePacient(pacientFromRepo);
                _repository.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }
        //   api/Pacients/{id} ---PATCH partial updating the pacient
        [HttpPatch("{id}")]
        public ActionResult<PacientReadDTO> PartialUpdatePacient(int id, JsonPatchDocument<PacientUpdateDTO> patchDocument)
        {
            var pacientFromRepo = _repository.GetPacientById(id);

            if (pacientFromRepo == null)
            {
                return NotFound();
            }

            var pacientToPatch = _mapper.Map<PacientUpdateDTO>(pacientFromRepo);
            patchDocument.ApplyTo(pacientToPatch,ModelState);
            
            if (!TryValidateModel(pacientToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(pacientToPatch, pacientFromRepo);
            _repository.UpdatePacient(pacientFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //    api/Pacients/{id} ---DELETE a pacient

        [HttpDelete("{id}")]

        public  ActionResult DeletePacient(int id)
        {
            var pacientFromRepo=_repository.GetPacientById(id);
            if(pacientFromRepo !=null)
            {
                _repository.DeletePacient(pacientFromRepo);
                _repository.SaveChanges();
                return NoContent();
            }else
            {
                return NotFound();
            }
        }
    }
}