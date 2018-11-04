# WebApiExample
Web Api Example for technical test

To Test the API you have to clone the repo and open the solution WebApiExample.sln with Visual Studio.
I have developed it with Visual Studio Community 2017, which is free, and .NET Framework 4.6.1.

Once you have cloned the repo and opened the solution you just have to run the project.
It will open a window in your default Internet Browser, that window will show an error message, that is normal as this
is a WebApi not a Web Application so it doesn't have a view or user interface.
Then, you can test the API by your Internet Browser or by some web testing tool, I recommend Postman as it is my favourite.

We have three endpoints:

1. Get all phone numbers: Make a Get request to the uri http://localhost:61280/api/customer/

2. Get all phone numbers of a single customer: Make a Get request to the uri http://localhost:61280/api/customer/{id} 
being {id} the id of the customer you want to consult. In our database we have just 5 customers.

3. Activate a phone number: Make a Put request to the uri http://localhost:61280/api/customer/{id} 
being {id} the id of the customer you want to activate the new number. In the body of the request you must send
a JSON with the type and telephone number. Example:
{type:"office",number:"+34 912735477"}
In this case we return the list of customers to verify the phone number has been added as we don't have a persistent database

On the other hand, there are some Unit Tests in the solution which you can run inside Visual Studio in order to test the API in a simple and automatized way.
