using System;

namespace HospitalRegistration.Entities
{
    public class Appointment
    {
        public Time Start { get; set; }
        public Time End { get; set; }
        public bool isFull { get; set; }
    }
}