﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAssignment7.Models;


namespace MVCAssignment7.Controllers
{
    public class PersonnelController : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();
        // GET: Personnel
        public ActionResult Index()
        {
            var peeps = from p in db.People
                        from pa in p.PersonAddresses
                        from c in p.Contacts
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonKey,
                            p.PersonLastName,
                            p.PersonFirstName,
                            p.PersonEmail,
                            pa.PersonAddressApt,
                            pa.PersonAddressStreet,
                            pa.PersonAddressCity,
                            pa.PersonAddressState,
                            pa.PersonAddressZip,
                            c.ContactNumber
                        };
            List<PersonLite> peepsList = new List<PersonLite>();
            foreach(var p in peeps)
            {
                PersonLite pl = new Models.PersonLite();
                pl.PersonKey = (int)p.PersonKey;
                pl.LastName = p.PersonLastName;
                pl.FirstName = p.PersonFirstName;
                pl.Email = p.PersonEmail;
                pl.Apartment = p.PersonAddressApt;
                pl.Street = p.PersonAddressStreet;
                pl.State = p.PersonAddressState;
                pl.Zipcode = p.PersonAddressZip;
                peepsList.Add(pl);

            }

            return View(peepsList);
        }
    }
}