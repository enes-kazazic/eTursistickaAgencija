﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.Data.Models
{
	public class ExceptionLogger
	{
		public int Id { get; set; }
		public DateTime TimeStamp { get; set; }
		public string RequestId { get; set; }
		public string Message { get; set; }
		public string Type { get; set; }
		public string Source { get; set; }
		public string StackTrace { get; set; }
		public string RequestPath { get; set; }
		public string User { get; set; }
		public string ActionDescriptor { get; set; }
		public string IpAddress { get; set; }
    }
}
