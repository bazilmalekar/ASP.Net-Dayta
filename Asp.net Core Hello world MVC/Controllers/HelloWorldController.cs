﻿using System;
using Microsoft.AspNetCore.Mvc;
using Asp.net_Core_Hello_world_MVC.Models;

namespace Asp.net_Core_Hello_world_MVC.Controllers
{
	public class HelloWorldController : Controller
	{
		public HelloWorldController()
		{
			
		}

		public IActionResult Index()
		{
			ViewBag.Message = "This message is from view";
			ViewData["Viewdata"] = "this message is from data";
			TempData["TDMessage"] = "This message is from temp Data"; //Only for one session.
			return View();
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
		public IActionResult Create([Bind("Name, Age", "DateOfBirth", "Email")] HelloWorld helloWorld)
		{
			if(helloWorld.DateOfBirth > DateTime.Today)
			{
				ModelState.AddModelError("DateOfBirth", "DOB must not be greater than today");
			}
			if (ModelState.IsValid)
			{
				ViewBag.Message = "Form is submitted, your name is " + helloWorld.Name + " age is " + helloWorld.Age + " years";
				return View();
			}
			ViewBag.Message = "There were validation errors";
			return View();
		}
	}
}
