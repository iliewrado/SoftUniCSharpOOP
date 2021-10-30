using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsing, ICalling
    {
        private const string callMessage = "Calling... {0}";
        private const string browseMessage = "Browsing: {0}!";
        private const string invalidMessage = "Invalid number!";
        private const string invalidUrl = "Invalid URL!";
        public void Browsing(string url)
        {
            if (!IsURLValid(url))
            {
                Console.WriteLine(string.Format(browseMessage, url));
            }
            else
            {
                Console.WriteLine(invalidUrl);
            }
        }

        public void Calling(string phoneNumber)
        {
            if (!IsPhoneValid(phoneNumber))
            {
                Console.WriteLine(string.Format(callMessage, phoneNumber));
            }
            else
            {
                Console.WriteLine(invalidMessage);
            }
        }
        private bool IsPhoneValid(string phoneNumber)
        {
            return phoneNumber.Any(char.IsLetter);
        }
        private bool IsURLValid(string url)
        {
            return url.Any(char.IsDigit);
        }
    }
}
