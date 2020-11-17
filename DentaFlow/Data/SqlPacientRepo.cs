using System;
using System.Collections.Generic;
using System.Linq;
using DentaFlow.Models;

namespace DentaFlow.Data
{
    public class SqlPacientRepo : IPacientRepo
    {
        private readonly DentalDbContext _context;

        public SqlPacientRepo(DentalDbContext context)
        {
            _context=context;
        }


        public void CreatePacient(Pacient pacient)
        {
            if(pacient==null)
            {
                 throw new ArgumentNullException(nameof(pacient));
            }
            _context.Pacients.Add(pacient);
        }

        public void DeletePacient(Pacient pacient)
        {
            if(pacient ==null)
            {
               throw new ArgumentNullException(nameof(pacient));
            }
            _context.Pacients.Remove(pacient);
        }

        public IEnumerable<Pacient> GetAllPacients()
        {
            return _context.Pacients.ToList();
        }

        public Appointment GetAppointmentById(int appointmentId, int pacientId)
        {
           if (pacientId==0)
            {
                throw new ArgumentNullException(nameof(pacientId));
            }

              if (appointmentId==0)
            {
                throw new ArgumentNullException(nameof(appointmentId));
            }

            
             var pacient=_context.Pacients.ToList();

             var doctor=_context.Doctors.ToList();

            return _context.Appointments.Where(p=>p.AppointmentId==appointmentId && p.PacientId==pacientId ).FirstOrDefault();
        }

        public IEnumerable<Appointment> GetAppointments(int pacientId)
        {
            if(pacientId==0)
            {
                throw new ArgumentNullException(nameof(pacientId));
            }
             var doctor =_context.Doctors.ToList();
            return _context.Appointments
            .Where(a=>a.PacientId==pacientId);
        }

        public Pacient GetPacientById(int id)
        {
            return _context.Pacients.FirstOrDefault(p=>p.PacientId==id);
        }

        public bool PacientExists(int pacientId)
        {
             if (pacientId == 0)
            {
                throw new ArgumentNullException(nameof(pacientId));
            }

            return _context.Pacients.Any(a => a.PacientId == pacientId);
        }

        public bool SaveChanges()
        {
            return( _context.SaveChanges()>=0);
        }

        public void UpdatePacient(Pacient pacient)
        {
            //nothing here
        }
    }
}