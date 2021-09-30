using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;



namespace pruebaApiTelegram
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new TelegramClient(8356929, "12935d41c3889d0da0ee7b70954e6161"); //create TelegramClient whit ApiId and Apihash
            await client.ConnectAsync(); //Connect to telegram

            //authentication
            /*
            var hash = await client.SendCodeRequestAsync("543442500743");
            var code = "65517"; // you can change code in debugger
            var user = await client.MakeAuthAsync("543442500743", hash, code);*/

            var list = new List<TLInputPhoneContact>
            {
                new TLInputPhoneContact() { Phone = "543442668113", FirstName= "", LastName="", ClientId=0}
            };// create list of contacts to add

            await client.ImportContactsAsync(list);//import the contacts of the list

            var contacts = await client.GetContactsAsync(); //get contacts list

            var user = contacts.Users
                            .OfType<TLUser>()
                            .FirstOrDefault(x => x.Phone == "543442668113"); //Find the user by the phone number

            if (user == null)
            {
                throw new System.Exception("Number was not found in Contacts List of user");//if the user is null throw an exception
            }

            await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "TEST");//send the message
        }

    }
}
