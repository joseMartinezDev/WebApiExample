using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    public class CustomerController : ApiController
    {
        //this is our imaginary database, a list of Customer class
        public List<Customer> listCustomers;

        public CustomerController()
        {
            listCustomers = ListCustomers();
          

        }

        public List<Customer> ListCustomers()
        {
            //initialize of our test database
            var listCustomers = new List<Customer>();

            Customer cust1 = new Customer { id = 1, listPhoneNumbers = new List<PhoneNumber> { new PhoneNumber { type = "mobile", number = "660022876" }, new PhoneNumber { type = "home", number = "968424380" } } };
            Customer cust2 = new Customer { id = 2, listPhoneNumbers = new List<PhoneNumber> { new PhoneNumber { type = "mobile", number = "+44 1182554907" } } };
            Customer cust3 = new Customer { id = 3, listPhoneNumbers = new List<PhoneNumber> { new PhoneNumber { type = "office", number = "+35 3879872345" }, new PhoneNumber { type = "home", number = "968654321" } } };
            Customer cust4 = new Customer { id = 4, listPhoneNumbers = new List<PhoneNumber> { new PhoneNumber { type = "mobile", number = "+35 3879872345" }, new PhoneNumber { type = "mobile work", number = "+35 4579842123" } } };
            Customer cust5 = new Customer { id = 5, listPhoneNumbers = new List<PhoneNumber> { new PhoneNumber { type = "home", number = "967254712" } } };

            listCustomers.Add(cust1);
            listCustomers.Add(cust2);
            listCustomers.Add(cust3);
            listCustomers.Add(cust4);
            listCustomers.Add(cust5);

            return listCustomers;


        }

        public IEnumerable<Customer> GetAllNumbers()
        {
            //we return IEnumerable because it's less derived than List, so it gives us more flexibility 
            //to change the underlying implementation and it's more efficient to the compiler
            return this.listCustomers;
        }

        public IHttpActionResult GetNumbersByCust(int id)
        {
            //we return IHttpActionResult so we can return 404 if the customer doesn't exist
            var customer = this.listCustomers.FirstOrDefault(c => c.id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else{
                return Ok(customer);
            }
        }


        public IHttpActionResult PutAddNumberToCust(int id,[FromBody] PhoneNumber number)
        {
            //in the body of the request we receive a JSON which is a PhoneNumber object
            var customer = this.listCustomers.FirstOrDefault(c => c.id == id);
            if (customer == null)
            {
                //if the customer doesn't existe we return 404
                return NotFound();
            }
            else
            {
                //if the customer exists we add the number to its list
                //we return the whole list to verify that the number has been added
                //because we don't have a persistent database
                customer.listPhoneNumbers.Add(number);
                return Ok(this.listCustomers);
            }
        }
    }
}
