using System.Collections.Generic;

namespace HospitalRegistration.Entities
{
    public class Department
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; private set; }
        protected Department()
        {
            Doctors = new List<Doctor>();
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}