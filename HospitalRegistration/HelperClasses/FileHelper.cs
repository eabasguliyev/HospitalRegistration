using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalRegistration.AbstractClasses;
using HospitalRegistration.Entities;
using Newtonsoft.Json;

namespace HospitalRegistration.HelperClasses
{
    public static class FileHelper
    {
        public static bool Changes { get; set; }

        public static void Write(string filePath, List<Department> departments)
        {
            var serializer = new JsonSerializer();

            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        serializer.Formatting = Formatting.Indented;

                        serializer.Serialize(jw, departments);
                    }
                }
            }
        }

        public static void Read(string filePath, ref List<Department> departments)
        {
            var serializer = new JsonSerializer();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        using (var jr = new JsonTextReader(sr))
                        {

                            departments = serializer.Deserialize<List<Department>>(jr);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
