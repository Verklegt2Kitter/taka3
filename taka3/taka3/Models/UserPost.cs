﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taka3.Models
{
	public class UserPost
	{
		public int ID { get; set; }
		public string UserID { get; set; }
		public int GroupID { get; set; }
		public string PostBody { get; set; }
		public DateTime DateAndTime { get; set; }
	}
}