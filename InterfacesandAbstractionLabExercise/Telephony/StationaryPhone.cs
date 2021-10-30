using System;
using System.Linq;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        private const string message = "Dialing... {0}";
        private const string invalidMessage = "Invalid number!";
        public void Calling(string phoneNumber)
        {
            if (IsPhoneValid(phoneNumber))
            {
                Console.WriteLine(string.Format(message, phoneNumber));
            }
            else
            {
                Console.WriteLine(invalidMessage);
            }
        }
        private bool IsPhoneValid(string phoneNumber)
        {
            if (phoneNumber.Any(char.IsLetter))
            {
                return false;
            }
            return true;
        }
    }
}
