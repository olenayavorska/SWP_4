using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SWP_4.Models;

namespace SWP_4
{
   

    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }

        // ApplicationContext db;
    //    public void SignUp(string email, string password)
    //    {
    //        //    User adminUser1 = new User { Id = 1, Email = "admin@mail.com", Password = "123456"};
    //        User newUser = new User { Email = email, Password = password };
    //        Console.WriteLine("got it");
    //        //User user = new User();
    //        //user.Email = email;
    //        //user.Password = password;
    //        //db.Users.Add(user);
    //        //db.SaveChanges();
    //    }
    //    //[Authorize(Roles = "admin")]
    //    //public async Task Notify(string message, string userName)
    //    //{
    //    //    await Clients.All.SendAsync("Receive", message, userName);
    //    //}
    }

}