using PayrollStaging.Models;
using PayrollStaging.Utilities;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PayrollStaging.NHibernate {


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public class NHibernateITimeLogStore {
		public async Task<IList<TimeLogs>> ReturnTimeLogsForUploadinAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var logs= db.QueryOver<TimeLogs>().Where(x=>x.Status=="ForUploading");
					return logs.List();
				} 
			}
		}
		
	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously