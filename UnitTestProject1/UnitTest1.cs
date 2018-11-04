using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiExample.Models;
using WebApiExample.Controllers;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllNumbers_Test()
        {
            var controller = new CustomerController();
            var listCustomersTest = controller.ListCustomers();
            
            var result = controller.GetAllNumbers() as List<Customer>;
            Assert.IsNotNull(result);
            //as we don't implement Compare in Customer class we have to use ToString
            Assert.AreEqual(listCustomersTest.ToString(), result.ToString());


        }
        [TestMethod]
        public void GetNumbersByCust_Test()
        {
            var controller = new CustomerController();
            var listCustomersTest = controller.ListCustomers();
            var result = controller.GetNumbersByCust(3) as OkNegotiatedContentResult<Customer>;
            Assert.IsNotNull(result);
            Assert.AreEqual(listCustomersTest[2].ToString(), result.Content.ToString());

        }

        [TestMethod]
        public void PutAddNumberToCust_Test()
        {
            var controller = new CustomerController();
            var listCustomersTest = controller.ListCustomers();
            var result = controller.PutAddNumberToCust(5, new PhoneNumber { type = "office", number = "+34 912735477" }) as OkNegotiatedContentResult<List<Customer>>;
            listCustomersTest[4].listPhoneNumbers.Add(new PhoneNumber { type = "office", number = "+34 912735477" });
            Assert.IsNotNull(result);
            Assert.AreEqual(listCustomersTest.ToString(), result.Content.ToString());


        }

       
    }
}
