using HospitalRegistration.Entities;

namespace HospitalRegistration.ExtensionMethods
{
    public static class DoctorExtensions
    {
        public static bool CheckAppoinment(this Doctor doctor, int appointmentIndex)
        {
            if (doctor.Appointments[appointmentIndex].isFull)
                return false;
            return true;
        }
    }
}