using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity;

namespace PhoneBookRESTXMLService
{
    public class PhoneBookRESTXMLService : IPhoneBookRESTXMLService
    {
        // create a dbcontext object to access PhoneBook database
        private PhoneBookEntities dbcontext = new PhoneBookEntities();

        // add an entry to the phone book database
        public void AddEntry(string lastName, string firstName, string phoneNumber)
        {
            // create PhoneBook entry to be inserted in database
            PhoneBookEntry entry = new PhoneBookEntry();
            entry.FirstName = firstName;
            entry.LastName = lastName;
            entry.PhoneNumber = phoneNumber;

            // insert PhoneBook entry in database

            PhoneBook book = new PhoneBook();
            book.FirstName = entry.FirstName;
            book.LastName = entry.LastName;
            book.PhoneNumber = entry.PhoneNumber;

            dbcontext.PhoneBooks.Add(book);
            dbcontext.SaveChanges();

           
        } // end method AddEntry

        // retrieve phone book entries with a given last name
       public PhoneBookEntry[] GetEntries (string lastName)
        {
            List<PhoneBookEntry> book = new List<PhoneBookEntry>();

            var phoneBook =
                    from pBook in dbcontext.PhoneBooks 
                    where pBook.LastName.Contains(lastName)
                    orderby pBook.FirstName 
                    select new
                    {
                        pBook.LastName,
                        pBook.FirstName,
                        pBook.PhoneNumber
                    };


            foreach (var result in phoneBook)
            {
                PhoneBookEntry retrieved = new PhoneBookEntry();
                
                retrieved.LastName  = result.LastName;
                retrieved.FirstName = result.FirstName;
                retrieved.PhoneNumber = result.PhoneNumber;    
                book.Add(retrieved);
            }


            return book.ToArray();
        }
    }
}

