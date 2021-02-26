using System.Collections.Generic;
using System.Data;
using HospitalRegistration.AbstractClasses;

namespace HospitalRegistration.Entities
{
    public class Doctor:Human
    {
        public int WorkYears { get; set; }
        public List<Appointment> Appointments { get; private set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nWork Years: {WorkYears}";
        }

        public void ReserveAppointment(int appointmentIndex, string patientName)
        {
            Appointments[appointmentIndex].isFull = true;
            Appointments[appointmentIndex].PatientName = patientName;
        }
    }
}