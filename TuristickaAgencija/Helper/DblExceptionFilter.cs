using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using TuristickaAgencija.Data.Models;
using TuristickaAgencija.Data.Repositories;

namespace TuristickaAgencija.Helper
{
	public class DblExceptionFilter:ExceptionFilterAttribute
	{
		private readonly ILoggingRepository _loggingRepository;
		public DblExceptionFilter(ILoggingRepository loggingRepository)
		{
			_loggingRepository = loggingRepository;
		}

		public override void OnException(ExceptionContext exception)
		{
			var log = new ExceptionLogger
			{
				TimeStamp = DateTime.UtcNow,
				ActionDescriptor = exception.ActionDescriptor.DisplayName,
				IpAddress = exception.HttpContext.Connection.RemoteIpAddress.ToString(),
				Message = exception.Exception.Message,
				RequestId = Activity.Current?.Id ?? exception.HttpContext.TraceIdentifier,
				RequestPath = exception.HttpContext.Request.Path,
				Source = exception.Exception.Source,
				StackTrace = exception.Exception.StackTrace,
				Type = exception.Exception.GetType().ToString(),
				User = exception.HttpContext.User.Identity.Name
			};
			_loggingRepository.Add(log);
		}
    }
}
