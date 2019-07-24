
using System.Diagnostics;
using FluentNHibernate.Mapping;
using PayrollStaging.Models.Enums;
using System;
//using Microsoft.AspNet.Identity.EntityFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollStaging.Models {
	[DebuggerDisplay("{FirstName} {LastName}")]
	public class TimeLogs  {
		public virtual long TimeLogID { get; set; }
		public virtual string Reference { get; set; }
		public virtual DateTime ActualTime { get; set; }
		public virtual string RawType { get; set; }
		public virtual string Status { get; set; }
		
		
	

		public class TimeLogsMap : ClassMap<TimeLogs> {
			public TimeLogsMap() {
				Id(x => x.TimeLogID);
				Map(x => x.Reference);
				Map(x => x.ActualTime);
				Map(x => x.RawType);
				Map(x => x.Status);
			}
		}



		
	}

}
