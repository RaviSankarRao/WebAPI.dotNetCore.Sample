using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.DataAccessLayer
{
    public class EmployeeDALExceptions : Exception
    {
        public EmployeeDALExceptions(string message)
            : base(message)
        {

        }
    }
}
