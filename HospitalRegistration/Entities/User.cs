using HospitalRegistration.AbstractClasses;

namespace HospitalRegistration.Entities
{
    public class User : Human
    {
        public string Mail { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nMail: {Mail}\nPhone: {Phone}";
        }
    }
}