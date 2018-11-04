using System.Collections.Generic;


namespace WebApiExample.Models
{
    public class Customer
    {
        //for each customer we have an id and a list of numbers (PhoneNumber class actually)
        public int id { get; set; }
        public List<PhoneNumber> listPhoneNumbers { get; set; }
    }
}