namespace HospitalRegistration.AbstractClasses
{
    public abstract class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}";
        }
    }
}