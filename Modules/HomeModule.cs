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

            Get["/contact/{name}"] = parameters =>
            {
                Contact currentContact = Contact.GetOneContact(parameters.name);
                return View["contact.cshtml", currentContact];
            };

            Post["/"] = _ =>
            {
                Contact newContact = new Contact(Request.Form["name"], Request.Form["number"], Request.Form["address"]);
                Contact.SaveContact(newContact.GetName(), newContact);
                return View["confirm.cshtml", newContact];
            };

            Post["/contact/{name}/delete"] = parameters =>
            {
                Contact.ClearOneContact(parameters.name);
                return View["delete.cshtml"];
            };

            Post["/contacts/clear"] = _ =>
            {
                Contact.ClearContacts();
                return View["ConfirmClear.cshtml"];
            };
        }
    }
}
