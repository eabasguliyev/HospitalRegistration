using System;

namespace HospitalRegistration.Exceptions
{
    public class NoDoctorException:ApplicationException
    {
        public NoDoctorException():base("There is no doctor!")
        {
            
        }

        public NoDoctorException(string message):base(message)
        {
            
        }
    }
}