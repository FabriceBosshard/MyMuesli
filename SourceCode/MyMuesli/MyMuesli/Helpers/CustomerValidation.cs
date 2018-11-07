using System.Text.RegularExpressions;
using MyMuesli.Model;

namespace MyMuesli.Helpers
{
    public class CustomerValidation {
        public static string WrongField;

        public static bool ValidateCustomer(CustomerDetails customer)
        {
            return ValidateName(customer.Name) &&
                   ValidateAddress(customer.Address) &&
                   ValidateZip(customer.Zip) &&
                   ValidateCity(customer.City) &&
                   ValidatePhone(customer.Phone) &&
                   ValidateEmail(customer.Email);
        }

        private static bool ValidateEmail(string email)
        {
            if (ValidateRegex(
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)
                |(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                email))
            {
                return true;
            }

            WrongField = "The Email must fulfill a valid Pattern" +
                         " (x@y.z - x: min 1 Char, y: min 3 Char, z: 2-3 Char only A-Z.)";
            return false;
        }

        private static bool ValidatePhone(string phone)
        {
            if (ValidateLength(10, phone) && ValidateRegex("", phone))
            {
                return true;
            }
            WrongField = "The Phone must be 10 character long and only numeric, blanks or '+'";
            return false;
        }

        private static bool ValidateCity(string city)
        {
            if (ValidateLength(2, city))
            {
                return true;
            }
            WrongField = "The City must be 2 character long";
            return false;
        }

        private static bool ValidateZip(string zip)
        {
            if (ValidateLength(4, zip) && ValidateRegex("^(0|[1-9][0-9]*)$", zip))
            {
                return true;
            }
            WrongField = "The Zip must be 4 characters long and contain only numeric values";
            return false;
        }

        private static bool ValidateRegex(string regex, string word)
        {
            return word != null && Regex.IsMatch(word, regex);
        }

        private static bool ValidateAddress(string address)
        {
            if (ValidateLength(5, address))
            {
                return true;
            }
            WrongField = "The Address must be 5 character long";
            return false;
        }

        private static bool ValidateName(string name)
        {
            if (ValidateLength(5, name))
            {
                return true;
            }
            WrongField = "The Name must be 5 character long";
            return false;
        }

        private static bool ValidateLength(int length, string word)
        {
            return length <= word?.Length;
        }
    }
}