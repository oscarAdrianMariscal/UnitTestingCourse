using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingCourse.DNS;

namespace UnitTestingCourse
{
    //This class represents a network testing class, the methods are fake, mostly to serve as a springboard for unit testings
    internal class NetworkTesting
    {
        private readonly IDns _dns;

        public NetworkTesting(IDns dns)
        {
            _dns = dns;
        }

        public string SendPing()
        {
            var result = _dns.SendDns();
            var returnString = "";
            if (result)
            {
                returnString = "Success: ping sent";
            }
            else
            {
                returnString = "Failed: ping not sent";
            }

            return returnString;
        }

        public int TestTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastLogonDateAttempt()
        {
            return DateTime.Now;
        }

    }
}
