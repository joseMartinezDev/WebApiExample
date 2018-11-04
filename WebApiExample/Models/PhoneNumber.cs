
namespace WebApiExample.Models
{
    public class PhoneNumber
    {
        //we can specify the type of telephone and the number itself
        //we define the number as string because it can be very long 
        //and this way we can have international numbers like +44 ....
        public string type { get; set; }
        public string number { get; set; }
    }
}