using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static List<Customer> customerList = null;

        public Service1()
        {
            customerList = new List<Customer>();

            // Currently, it is statically loaded with dummy values.
            // However, it can be extended to populate from a data source (e.g. SQL).
            customerList.Add(new Customer
            {
                Id = "1111",
                FirstName = "John",
                LastName = "Doe",
                SSN = "451234590"
            });
            customerList.Add(new Customer
            {
                Id = "1112",
                FirstName = "Jason",
                LastName = "Rudd",
                SSN = "451234592"
            });
            customerList.Add(new Customer
            {
                Id = "1113",
                FirstName = "Daniel",
                LastName = "Cheng",
                SSN = "451234596"
            });
        }

        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Customer> AddData(Customer value)
        {
            customerList.Add(value);

            return customerList;
        }

        public Customer GetCustomer(string customerId)
        {
            //TODO: query your repo and pull customer details
            return customerList.Find(t => t.Id == customerId);
        }

        public List<Customer> UpdateCustomer(Customer customer)
        {
            //TODO: update customer information in your repo
            var targetCustomer = customerList.Where(t => t.Id == customer.Id).FirstOrDefault();

            if (targetCustomer != null)
            {
                // no need to update cutomerId
                targetCustomer.FirstName = customer.FirstName;
                targetCustomer.LastName = customer.LastName;
                targetCustomer.SSN = customer.SSN;
            }

            return customerList;
        }
    }
}
