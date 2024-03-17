using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballersCatalogCore.Helpers
{
	public static class DateHelper
	{
		public static bool BeEnoughTimeSpan(DateTime date)
		{
			var delta = DateTime.Now.Year - date.Year;
			return delta >= 15;
		}
	}
}
