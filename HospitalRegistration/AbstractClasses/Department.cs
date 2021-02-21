using System.Collections.Generic;
using HospitalRegistration.Entities;

namespace HospitalRegistration.AbstractClasses
{
    public abstract class Department
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