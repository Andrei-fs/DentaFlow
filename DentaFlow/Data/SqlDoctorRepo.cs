using System;
using System.Collections.Generic;
using System.Linq;
using DentaFlow.Models;
using DentaFlow.ResourceParameters;

namespace DentaFlow.Data{
    public class SqlDoctorRepo : IDoctorRepo
    {
        private readonly DentalDbContext _context;

        public SqlDoctorRepo(DentalDbContext context)
        {
            
            _context=context;
        }





        public void CreateDoctor(Doctor doctor)
        {
             if(doctor==null)
            {
                 throw new ArgumentNullException(nameof(doctor));
            }
            _context.Doctors.Add(doctor);
        }



        public void DeleteDoctor(Doctor doctor)
        {
            if(doctor==null)
            {
                 throw new ArgumentNullException(nameof(doctor));
            }
            _context.Doctors.Remove(doctor);
        }





        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }



        public IEnumerable<Appointment> GetAppointments(int doctorId)
        {
            if (doctorId==0)
            {
                throw new ArgumentNullException(nameof(doctorId));
            }
            var pacient=_context.Pacients.ToList();

            return _context.Appointments
                .Where(a => a.DoctorId == doctorId);
       

        }
        public Appointment GetAppointmentById(int appointmentId, int doctorId)
        {
            if (doctorId==0)
            {
                throw new ArgumentNullException(nameof(doctorId));
            }

              if (appointmentId==0)
            {
                throw new ArgumentNullException(nameof(appointmentId));
            }

            
             var pacient=_context.Pacients.ToList();

             var doctor=_context.Doctors.ToList();

            return _context.Appointments.Where(p=>p.AppointmentId==appointmentId && p.DoctorId==doctorId ).FirstOrDefault();
        }


        public Doctor GetDoctorById(int id)
        {

            return _context.Doctors.FirstOrDefault(p=>p.DoctorId==id);

        }

        public bool SaveChanges()
        {
            return( _context.SaveChanges()>=0);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            //nothing
        }

        public bool DoctorExists(int doctorId)
        {
             if (doctorId == 0)
            {
                throw new ArgumentNullException(nameof(doctorId));
            }

            return _context.Doctors.Any(d => d.DoctorId == doctorId);
        }
    
        public IEnumerable<Doctor> GetAllDoctors(EntityResourceParameters doctorResourceParameters)
        {
            if (doctorResourceParameters==null)
            {
                throw new ArgumentNullException(nameof(doctorResourceParameters));
            }
 

            if  (string.IsNullOrWhiteSpace(doctorResourceParameters.Location) 
            && string.IsNullOrWhiteSpace(doctorResourceParameters.SearchQuery))
            {
                return GetAllDoctors(); 
            }
             var collection = _context.Doctors as IQueryable<Doctor>;

            if(!string.IsNullOrWhiteSpace(doctorResourceParameters.Location))
        //   &&(doctorResourceParameters.Rating <=5 && doctorResourceParameters.Rating>=0))
            {

                var location=doctorResourceParameters.Location.Trim();
                collection=collection.Where(d=>d.Location == location);
            
            }

            if(!string.IsNullOrWhiteSpace(doctorResourceParameters.SearchQuery))
            {
                var searchQuery=doctorResourceParameters.SearchQuery.Trim();
                collection=collection.Where(d=>d.Location.Contains(searchQuery)
                || d.FirstName.Contains(searchQuery)
                || d.LastName.Contains(searchQuery));
            }
            return collection.ToList();

        }
      

     


         public IEnumerable<DoctorPacient> GetPacients(int doctorId)
         {
            if (doctorId == 0)
            {
                throw new ArgumentNullException(nameof(doctorId));
            }

            var pacientsForDoctor = _context.DoctorsPacients.Where(p => p.DoctorId == doctorId);
            var pacients = _context.Pacients.ToList();

            //     return pacientsForDoctor;
            return pacientsForDoctor;
         }

       
    }

}







   
  
