using Capgemini.EMS.Entities;
using System;
using System.Collections.Generic;

namespace Capgemini.EMS.DataAccessLayer
{
    public class EmployeeDAL
    {
        static List<Employee> list = new List<Employee>();
         public static bool Add( Employee emp)

        {
            list.Add(emp);
            return true;
        }
        public static List<Employee> GetList()
        {
            return list;
        }
    }
}
