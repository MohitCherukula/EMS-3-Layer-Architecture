using Capgemini.EMS.DataAccessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;
using System.Collections.Generic;

namespace Capgemini.EMS.BusinessLayer
{
    public class EmployeeBL
    {
        // add //update // delete //display
        public static bool Add(Employee emp)
        {
            //business validation
            // if error throw UDE
            if (emp.Id <= 0)
            {
                throw new EmsException("Employee ID should be greater than zeroo");
            }

            //call DAL method
            bool isAdded = EmployeeDAL.Add(emp);
            return isAdded;
           

        }
        public static List<Employee> GetList()
        {
            var list = EmployeeDAL.GetList();
            return list;
        }
    }
}
