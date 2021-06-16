using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.BusinessLayer
{
    public class EmployeeBLException : Exception
    {
        public EmployeeBLException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
