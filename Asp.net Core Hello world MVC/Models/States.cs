using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Hello_world_MVC.Models
{
	public class States
	{
		[Key]
		public int StateId { get; set; }

		public int StateCode { get; set; }

        public int StateName { get; set; }
    }
}

