using NewsAPI.Models;
using Newtonsoft.Json;
using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NewsAPI.Controllers
{
    public class UserController : Controller
    {

        DBModel dbContext = new DBModel();
        ScryptEncoder encoder = new ScryptEncoder();
        Response response = new Response();

        [HttpGet]
        public string SignUp()
        {
            return "Success";
        }

        [HttpPost]
        public string SignUp(User personModel)
        {
            string output;
            // Checking if the user is already registered
            var isRegisteredUser = (from c in dbContext.Users
                                    where c.Email.Equals(personModel.Email)
                                    select c).FirstOrDefault();
            if (isRegisteredUser != null)
            {
                response.Message = "Username already registered!";
                response.Status = false;
                output = JsonConvert.SerializeObject(response);
                return output;
            }

            // Hashing the user password
            personModel.Password = encoder.Encode(personModel.Password);

            // Adding the user to the database
            using (DBModel dbModel = new DBModel())
            {
                dbModel.Users.Add(personModel);
                dbModel.SaveChanges();

                response.Status = true;
                output = JsonConvert.SerializeObject(response);
            }
            ModelState.Clear();

            output = JsonConvert.SerializeObject(response);



            return output;

        }

        [HttpGet]
        public string LogIn()
        {
            return "Success";


        }

        [HttpPost]
        public string LogIn(User personModel)
        {
            string output;

            // Checking if the user information is correct
            var isRegisteredUser = (from c in dbContext.Users
                                    where c.Email.Equals(personModel.Email)
                                    select c).SingleOrDefault();


            if (isRegisteredUser == null)
            {
                response.Message = "Email Or Password Not valid";
                response.Status = false;
                output = JsonConvert.SerializeObject(response);
                return output;

            }

            bool isCorrectPassword = encoder.Compare(personModel.Password, isRegisteredUser.Password);
            if (!isCorrectPassword)
            {
                response.Message = "Email Or Password Not valid";

                output = JsonConvert.SerializeObject(response);
                return output;
            }

            response.Status = true;
            output = JsonConvert.SerializeObject(response);

            return output;
        }

        public string UserNewsList(User userModel)
        {
            string output = "";

            List<int> newsId = new List<int>();
            List<string> newsTypes = new List<string>();

            // Getting the user ID 
            var user = dbContext.Users
                .Where(x => x.Email == userModel.Email)
                .FirstOrDefault();
            var news = dbContext.News.ToList();


            var userNews = dbContext.User_News.ToList().Where(x => x.User_ID == user.ID).ToList();
            for (int i = 0; i < userNews.Count; i++)
            {
                newsId.Add(userNews[i].News_ID);

                for (int k = 0; k < news.Count; k++)
                {
                    if(news[k].ID == userNews[i].News_ID)
                    {
                        newsTypes.Add(news[k].TypeName);
                    }
                }
            }

            output = JsonConvert.SerializeObject(newsTypes);

            return output;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}