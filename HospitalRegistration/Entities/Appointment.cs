using System;

namespace HospitalRegistration.Entities
{
    public class Appointment
    {
        public string PatientName { get; set; }
        public Time Start { get; set; }
        public Time End { get; set; }
        public bool isFull { get; set; }
    }
}