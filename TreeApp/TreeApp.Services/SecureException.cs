using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeApp.Services
{
    public class SecureException : Exception
    {
        public SecureException(string message) : base(message) { }
    }
}
