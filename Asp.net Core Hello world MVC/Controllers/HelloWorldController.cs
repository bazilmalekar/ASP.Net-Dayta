using System;
using Microsoft.AspNetCore.Mvc;
using Asp.net_Core_Hello_world_MVC.Models;
using Asp.net_Core_Hello_world_MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Hello_world_MVC.Controllers
{
	public class HelloWorldController : Controller
	{
		public readonly Hello_world_MVCDbContext _db;

        public HelloWorldController(Hello_world_MVCDbContext db)
		{
			_db = db;
			
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Message = "This message is from view";
			ViewData["Viewdata"] = "this message is from data";
			TempData["TDMessage"] = "This message is from temp Data"; //Only for one session.

			var helloWorldList = await _db.Helloworldtb.ToListAsync();
			return View(helloWorldList);
		}

		public IActionResult Create()
		{
			HelloWorld helloWorld = new HelloWorld();
			helloWorld.Name = "Bazil";
			helloWorld.Age = 30;
			return View(helloWorld);
		}

		[HttpPost]
		//The below code is given, the form which is sent to the user, the user should submit the same form, used for security.(The form that is sent is posted)
		[ValidateAntiForgeryToken]
		//Bind -> here we are binding our properties, ie which ever property will be mention in bind, only that will be rendered.
		//This will aviode "over posting", user will not be able to post age porperty if it is not mentioned. This is done for security purpose.
		public async Task<IActionResult> Create([Bind("Name, Age", "DateOfBirth", "Email", "Phone", "Address", "Feedback", "EnumMaritalStatus")] HelloWorld helloWorld, IFormCollection fc)
		{

			string designation = fc["Designation"];

			if(helloWorld.DateOfBirth > DateTime.Today)
			{
				ModelState.AddModelError("DateOfBirth", "DOB must not be greater than today");
			}
			if (ModelState.IsValid)
			{
				ViewBag.Message = "Form is submitted, your name is " + helloWorld.Name + " age is " + helloWorld.Age + " years";
				//If we want to clear the form after submission
				//ModelState.Clear();
				_db.Add(helloWorld);
				_db.SaveChanges();
				ViewBag.message = "data saved successfully";
				//return View();
				return RedirectToAction("Index");
			}
			ViewBag.Message = "There were validation errors";
			return View();
		}


		//Edit action to gets the data in our form
		public IActionResult Edit(int id)
		{
			var helloWorld = _db.Helloworldtb.Find(id);
			return View(helloWorld);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit([Bind("HelloWorldId, Name, Age", "DateOfBirth", "Email", "Phone", "Address", "Feedback", "EnumMaritalStatus")] HelloWorld helloWorld)
        {
			if (ModelState.IsValid)
			{
			_db.Update(helloWorld);
			_db.SaveChanges();
			return RedirectToAction("Index");
			}
			return View(helloWorld);
        }
    }
}

