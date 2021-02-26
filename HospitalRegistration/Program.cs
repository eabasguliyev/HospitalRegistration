using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using HospitalRegistration.AbstractClasses;
using HospitalRegistration.Departments;
using HospitalRegistration.Entities;
using HospitalRegistration.ExtensionMethods;
using HospitalRegistration.HelperClasses;
using HospitalRegistration.Logger;

namespace HospitalRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = null;


            var file = "departments.json";

            if(File.Exists(file))
            {
                FileHelper.Read(file, ref departments);
            }
            else
            {
                departments = new List<Department>() {
                    new Pediatrics(){ Name = "Pediatrics"},
                    new Traumatology(){ Name = "Traumatology"},
                    new Stamatology(){ Name = "Stamatology"}
                };
                departments[0].Doctors.Add(new Doctor()
                {
                    Name = "Angela",
                    Surname = "Midkiff",
                    WorkYears = 3
                });

                departments[0].Doctors.Add(new Doctor()
                {
                    Name = "Norman",
                    Surname = "Burkholder",
                    WorkYears = 5
                });

                departments[0].Doctors.Add(new Doctor()
                {
                    Name = "Yasmin",
                    Surname = "Borden",
                    WorkYears = 4
                });

                departments[1].Doctors.Add(new Doctor()
                {
                    Name = "Gracie",
                    Surname = "Johnson",
                    WorkYears = 6
                });

                departments[1].Doctors.Add(new Doctor()
                {
                    Name = "Paul",
                    Surname = "Jones",
                    WorkYears = 8
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    Name = "Heather",
                    Surname = "Morton",
                    WorkYears = 5
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    Name = "Pamela",
                    Surname = "Jackson",
                    WorkYears = 4
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    Name = "Anita",
                    Surname = "Winters",
                    WorkYears = 6
                });

                departments[2].Doctors.Add(new Doctor()
                {
                    Name = "Catherine",
                    Surname = "Malone",
                    WorkYears = 8
                });
               
                FileHelper.Write(file, departments);

            }
            
            foreach (var department in departments)
            {
                foreach (var doctor in department.Doctors)
                {
                    doctor.Appointments.Add(new Appointment()
                    {
                        Start = new Time() { Hour = 9, Minute = 0},
                        End = new Time() { Hour = 11, Minute = 0}
                    });

                    doctor.Appointments.Add(new Appointment()
                    {
                        Start = new Time() { Hour = 12, Minute = 0 },
                        End = new Time() { Hour = 14, Minute = 0 }
                    });

                    doctor.Appointments.Add(new Appointment()
                    {
                        Start = new Time() { Hour = 15, Minute = 0 },
                        End = new Time() { Hour = 17, Minute = 0 }
                    });
                }
            }


            while (true)
            {
                var user = new User();

                Console.WriteLine("Name: ");

                user.Name = UserHelper.GetName();

                Console.WriteLine("Surname: ");

                user.Surname = UserHelper.GetName();

                Console.WriteLine("Mail: ");

                user.Mail = UserHelper.GetMail();

                Console.WriteLine("Phone number: ");

                user.Phone = UserHelper.GetPhoneNumber();

                Console.WriteLine(user);

                Console.Clear();
                
                ConsoleScreen.PrintMenu(ConsoleScreen.Departments);

                var mainChoice = ConsoleScreen.Input(ConsoleScreen.Departments.Count) - 1;

                Console.Clear();

                var departmentLoop = true;

                while (departmentLoop)
                {
                   

                    var doctors = departments[mainChoice].Doctors.Select(d => $"{d.Name} {d.Surname}").ToList();
                    doctors.Add("Back");

                    ConsoleScreen.PrintMenu(doctors);

                    var doctorChoice = ConsoleScreen.Input(doctors.Count) - 1;

                    Console.Clear();

                    if (doctorChoice == doctors.Count - 1)
                        break;

                    var doctor = departments[mainChoice].Doctors[doctorChoice];

                    var appointmentLoop = true;

                    while (appointmentLoop)
                    {
                        var appointments = doctor.Appointments
                            .Select(a => $"{a.Start} - {a.End} ({(a.isFull ? "Reserved" : "Not Reserved")})").ToList();
                        appointments.Add("Back");

                        ConsoleScreen.PrintMenu(appointments);

                        var appointmentChoice = ConsoleScreen.Input(appointments.Count) - 1;

                        Console.Clear();

                        if (appointmentChoice == appointments.Count - 1)
                            break;

                        var appointment = doctor.Appointments[appointmentChoice];

                        if (doctor.CheckAppointment(appointmentChoice))
                        {
                            var fullName = $"{user.Name} {user.Surname}";
                            doctor.ReserveAppointment(appointmentChoice, fullName);

                            ConsoleLogger.Info($"Thanks {fullName} you have signed up for the reception of {doctor.Name} {doctor.Surname} doctor at {appointment.Start}");
                            ConsoleScreen.Clear();
                            departmentLoop = false;

                            FileHelper.Write(file, departments);

                            break;
                        }

                        ConsoleLogger.Error("Appointment is full");
                        ConsoleScreen.Clear();
                    }
                }

            }


            //foreach (var department in departments)
            //{
            //    Console.WriteLine("--------------Department Info-----------------");
            //    Console.WriteLine(department);
            //    foreach (var doctor in department.Doctors)
            //    {
            //        Console.WriteLine("--------------Doctor Info-----------------");
            //        Console.WriteLine(doctor);

            //        foreach (var appointmentRange in doctor.AppointmentRanges)
            //        {
            //            Console.WriteLine("------------------");
            //            Console.WriteLine($"{appointmentRange.Start} - {appointmentRange.End}");
            //        }
            //    }
            //}
        }
    }
}
