namespace HospitalRegistration.Entities
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public override string ToString()
        {
            return $"{((Hour > 9) ? "" : "0")}{Hour}:{((Minute > 9) ? "" : "0")}{Minute}";
        }
    }
}