using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hybridview.Rest.Models;

namespace Hybridview.Rest.Controllers
{
    public class UserController : ApiController
    {
        DataContext db = new DataContext();

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        /*[HttpPost]
        public void Post([FromBody]string value)
        {
            SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.CommandText = "SELECT * FROM users WHERE username = `" +  +"`";

        }*/

        [HttpPost]
        //POST: api/user/login
        public loginResponse login(login login)
        {
            var lr = new loginResponse();
            lr.errorCode = 1;
            lr.message = "Error! wrong username or password!";
            lr.data = null;


            if (login.username == "test" && login.password == "test")
            {
                lr.data = new ClsUser();
                lr.data.id = 1;
                lr.data.name = "test";
                lr.data.lastname = "test";
                lr.data.username = "test";
                lr.data.email = "test@gmail.com";
                lr.data.date_created = DateTime.Now;
                lr.data.date_modified = DateTime.Now;
                lr.message = "User logged in successfully.";
                lr.errorCode = 0;
            }

            /*if (user != null)
            {
                lr.data = (ClsUser)user;
                lr.message = "User logged in successfully.";
            }*/

            return lr;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
