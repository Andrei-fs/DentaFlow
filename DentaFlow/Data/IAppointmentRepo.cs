using System.Collections.Generic;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;

namespace DentaFlow.Data
{
    public interface IAppointmentRepo
    {

        //save changes 

        bool SaveChanges();

        //get a list of appointmnets

        IEnumerable<Appointment> GetAllAppointments();

        IEnumerable<Appointment> GetAllAppointments(EntityResourceParameters appointmentResourceParameters);

        //get an appointment 

        Appointment GetAppointmentById(int id);
        
        //create an appointment

        void CreateAppointment(Appointment appointment);

         //update appointment
         // void UpdateAppointment(Appointment appointment);

        //delete appointment 

        void DeleteAppointment(Appointment appointment);






    }
}