using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PhoneBookRESTJSONService
{
   public class PhoneBookRESTJSONService : IPhoneBookRESTJSONService
   {
      // create a dbcontext object to access PhoneBook database
      private PhoneBookEntities dbcontext = new PhoneBookEntities();

      // add an entry to the phone book database
      public void AddEntry(string lastName, string firstName, string phoneNumber)
      {
         // create PhoneBook entry to be inserted in database
         PhoneBookEntry entry = new PhoneBookEntry();

          entry.LastName = lastName;
          entry.FirstName = firstName;
          entry.PhoneNumber = phoneNumber;
       
         // insert PhoneBook entry in database
          PhoneBook book = new PhoneBook();
          book.LastName = entry.LastName;     
          book.FirstName = entry.FirstName;
          book.PhoneNumber = entry.PhoneNumber;

          dbcontext.PhoneBooks.Add(book);
          dbcontext.SaveChanges();
      } // end method AddEntry

      // retrieve phone book entries with a given last name
      public PhoneBookEntry[] GetEntries(string lastName)
      {
          List<PhoneBookEntry> entries = new List<PhoneBookEntry>();

          var phoneBook =
              from book in dbcontext.PhoneBooks
              where book.LastName == lastName
              orderby book.FirstName
              select new
              {
                  book.LastName,
                  book.FirstName,
                  book.PhoneNumber
              };


          foreach (var element in phoneBook) {
              PhoneBookEntry retrieved = new PhoneBookEntry();
              retrieved.LastName = element.LastName;
              retrieved.FirstName = element.FirstName;
              retrieved.PhoneNumber = element.PhoneNumber;
              entries.Add(retrieved);
          }
          return entries.ToArray();
             
      } // end method GetEntries
   }
}

