using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DentaFlow.Models;

namespace DentaFlow.DTOs
{
    public class DoctorReadDTO{
      
        public int DoctorId { get; set; } 
        public int Rating { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Location { get; set; } 
        
        public string Cabinet { get; set; }      
        public string Email { get; set; } 
        public string Mobile { get; set; }    
        public string Description { get; set; } 
        public string Availability { get; set; } 

        
    }
}