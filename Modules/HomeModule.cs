using Nancy;
using Address.Objects;
using System.Collections.Generic;
using System;

namespace Address
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                if (Contact.GetContacts().Count == 0)
                {
                    return View["emptyIndex.cshtml"];
                }
                else
                {
                    return View["index.cshtml", Contact.GetContacts()];
                }
            };

            Get["/new"] = _ =>
            {
                return View["NewContact.cshtml"];
            };

            // Get["/contact/{id}"] = parameters =>
            // {
            //
            // }

            Post["/"] = _ =>
            {
                Contact newContact = new Contact(Request.Form["name"], Request.Form["number"], Request.Form["address"]);
                Contact.SaveContact(newContact.GetName(), newContact);
                return View["index.cshtml", Contact.GetContacts()];
            };
        }
    }
}
