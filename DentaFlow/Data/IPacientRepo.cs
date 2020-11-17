using System.Collections.Generic;
using DentaFlow.Models;

namespace DentaFlow.Data
{
    public interface IPacientRepo
    {
        //Get all pacients ---GET
        IEnumerable<Pacient> GetAllPacients();
        
        //Get one specific pacient ---GET/{id}
        Pacient GetPacientById(int id);

        //Create a pacient ---POST
        void CreatePacient (Pacient pacient);
        
        //Update a pacient ---PUT/PATCH
        void UpdatePacient (Pacient pacient);
        //Delete a pacient ---DELETE
        void DeletePacient (Pacient pacient);

        //Save Changes

        bool SaveChanges();

        IEnumerable<Appointment> GetAppointments(int pacientId);

        Appointment GetAppointmentById(int pacientId, int appointmentId);
        bool PacientExists(int pacientId);
    }
}