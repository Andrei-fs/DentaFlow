using System;
using System.Collections.Generic;
using System.Linq;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;

namespace DentaFlow.Data
{
    public class SqlAppointmentRepo : IAppointmentRepo
    {
        private readonly DentalDbContext _context;

        public SqlAppointmentRepo(DentalDbContext context)
        {
            _context=context;
        }

        public void CreateAppointment(Appointment appointment)
        {
            if(appointment==null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            _context.Pacients.ToList();
            _context.Doctors.ToList();
            _context.Appointments.Add(appointment);

           
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if(appointment==null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            _context.Appointments.Remove(appointment);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            
            var doctors =_context.Doctors.ToList();
            var pacients=_context.Pacients.ToList();
            return _context.Appointments.ToList();
        }

        public IEnumerable<Appointment> GetAllAppointments(EntityResourceParameters appointmentResourceParameters)
        {
            var doctors =_context.Doctors.ToList();
            var pacients=_context.Pacients.ToList();
           if(appointmentResourceParameters==null){
               throw new ArgumentNullException(nameof(appointmentResourceParameters));
           }
            
            if  (string.IsNullOrWhiteSpace(appointmentResourceParameters.Location) 
            && string.IsNullOrWhiteSpace(appointmentResourceParameters.SearchQuery))
            {
                return GetAllAppointments(); 
            }
             var collection = _context.Appointments as IQueryable<Appointment>;

            if(!string.IsNullOrWhiteSpace(appointmentResourceParameters.Location))
      
            {

                var location=appointmentResourceParameters.Location.Trim();
                collection=collection.Where(d=>d.Doctor.Location == location);
            
            }

            if(!string.IsNullOrWhiteSpace(appointmentResourceParameters.SearchQuery))
            {
                var searchQuery=appointmentResourceParameters.SearchQuery.Trim();
                collection=collection.Where(a=>a.AppointmentHour.Contains(searchQuery));
               
            }
            return collection.ToList();

        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(p=>p.AppointmentId==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        // public void UpdateAppointment(Appointment appointment)
        // {
        //     //nothing
        // }
    }
}