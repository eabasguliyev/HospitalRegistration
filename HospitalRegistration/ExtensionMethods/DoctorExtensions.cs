using HospitalRegistration.Entities;

namespace HospitalRegistration.ExtensionMethods
{
    public static class DoctorExtensions
    {
        public static bool CheckAppointment(this Doctor doctor, int appointmentIndex)
        {
            return !doctor.Appointments[appointmentIndex].isFull;
        }
    }
}