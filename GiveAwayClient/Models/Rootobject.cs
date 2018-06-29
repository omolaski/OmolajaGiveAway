using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiveAwayClient.Models
{

    public class Rootobject
    {
        public List<Winner> Winners = new List<Winner>();
        public List<Phone> Phones = new List<Phone>();
        public List<Occupation> Occupations = new List<Occupation>();
         
        public List<Email> Emails = new List<Email>();
        public List<Address> Addresses = new List<Address>();
        public List<Account> Accounts = new List<Account>();
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public DateTime DOB { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Winner
    {
        public int ID { get; set; }
        public string ItemWon { get; set; }
        public Nullable<decimal> ItemAmoutWorth { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public int UserID { get; set; }

       
    }
    public class Phone
    {
        public int ID { get; set; }
        public string Phone1 { get; set; }
        public object CreatedDate { get; set; }
        public object Status { get; set; }
        public int UserID { get; set; }
    }

    public class Occupation
    {
        public int ID { get; set; }
        public string WorkPlaceName { get; set; }
        public string JobTitle { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
    }

    public class Email
    {
        public int ID { get; set; }
        public string Email1 { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
    }

    public class Address
    {
        public int ID { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
    }

    public class Account
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }
    }

}