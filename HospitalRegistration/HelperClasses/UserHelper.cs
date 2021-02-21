using System;
using HospitalRegistration.Logger;

namespace HospitalRegistration.HelperClasses
{
    public class UserHelper
    {
        public static string GetName()
        {
            while (true)
            {
                Console.Write(">> ");
                var name = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(name))
                    return name;

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        public static string GetMail()
        {
            while (true)
            {
                Console.Write(">> ");
                var mail = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(mail))
                {
                    if (mail.Split('@').Length == 2)
                        return mail;
                    ConsoleLogger.Error("Mail format is not valid!");
                    continue;
                }

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        public static string GetPhoneNumber()
        {
            while (true)
            {
                Console.Write(">> ");
                var phoneNumber = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(phoneNumber))
                {
                    if (CheckPhoneNumber(phoneNumber))
                        return phoneNumber;
                    ConsoleLogger.Error("Phone number does not contain any non-numeric value!");
                    continue;
                }

                ConsoleLogger.Error("Enter non-empty value!");
            }
        }

        private static bool CheckPhoneNumber(string phoneNumber)
        {
            for (var i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                    return false;
            }

            return true;
        }
    }
}