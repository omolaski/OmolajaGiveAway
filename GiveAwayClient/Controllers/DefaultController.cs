using GiveAwayClient.Models;
using LastAssignment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GiveAwayClient.Controllers
{
    public class DefaultController : Controller
    {
        Rootobject Rootobject = new Rootobject();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Create(string firstName, string middleName, string lastName, string DOB, string email,
            string phone, string gender, string occupation, string address, string city, string state, string country,
            string password, string confirmPassword, string username)
        {
            GithubInfo githubInfo = new GithubInfo();
            githubInfo.httpMethod = httpVerb.POST;

            Email emaill = new Email();
            emaill.Email1 = email;

            Phone phoneTemp = new Phone();
            phoneTemp.Phone1 = phone;

            Occupation occupationTemp = new Occupation();
            occupationTemp.JobTitle = occupation;

            Address addressTemp = new Address();
            addressTemp.Address1 = address;
            addressTemp.City = city;
            addressTemp.State = state;
            addressTemp.Country = country;


            if (password != confirmPassword)
            {

            }

            Rootobject rootobject = new Rootobject();

            rootobject.FirstName = firstName;
            rootobject.MiddleName = middleName;
            rootobject.LastName = lastName;
            rootobject.Username = username;
            rootobject.Password = password;
            rootobject.CreatedDate = DateTime.Now;
            //rootobject.DOB = DOB.ToString();


            rootobject.Emails.Add(emaill);


            rootobject.Phones.Add(phoneTemp);

            ////rootobject.Gender = gender;


            rootobject.Occupations.Add(occupationTemp);


            rootobject.Addresses.Add(addressTemp);







            githubInfo.endPoint = "http://api.power-supreme.com/api/Default/PostUser";

            int returnValue = githubInfo.PostRequest(rootobject);



        }
        [HttpGet]
        public ActionResult LoginUser()
        {

            return View();


        }
        [Authorize]
        public ActionResult Profile()
        {
            string username = User.Identity.Name;

            Rootobject rootobject = new Rootobject();

            var message = TempData["returnValues"] as string;

            rootobject = JsonConvert.DeserializeObject<Rootobject>(message);

            return View(rootobject);
        }


        [HttpPost]
        public ActionResult LoginValidate(string username, string password)
        {
            

            GithubInfo githubInfo = new GithubInfo();
            githubInfo.httpMethod = httpVerb.GET;
            githubInfo.endPoint = "http://api.power-supreme.com/api/Default/get";
            var returnValue = githubInfo.MakeRequest(username, password);
            Rootobject = JsonConvert.DeserializeObject<Rootobject>(returnValue);

            
            if (Rootobject.Username != null)
            {
                TempData["returnValues"] = returnValue;
                FormsAuthentication.SetAuthCookie(username, false);
                ViewBag.Value = 1;
                return Redirect("Profile");

            }
            else
            {
                ViewBag.Value = 0;
            }


            return View(Rootobject);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Default/Index");
        }


    }
}