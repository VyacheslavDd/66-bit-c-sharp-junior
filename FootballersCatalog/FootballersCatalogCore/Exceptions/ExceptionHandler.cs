using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersCatalogCore.Exceptions
{
	public static class ExceptionHandler
	{
		public static void Throw(ExceptionType type, string message)
		{
			throw new Exception($"{type}: {message}");
		}
	}
}
