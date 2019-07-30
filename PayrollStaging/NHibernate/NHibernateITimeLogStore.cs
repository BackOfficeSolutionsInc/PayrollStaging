using PayrollStaging.Models;
using PayrollStaging.Utilities;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PayrollStaging.Models.Enums;

namespace PayrollStaging.NHibernate {


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public class NHibernateITimeLogStore {
		public async Task<IList<TimeLogs>> ReturnTimeLogsForUploadinAsync() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					var logs= db.QueryOver<TimeLogs>().Where(x=>x.Status==StatusType.ForUploading);
					return logs.List();
				} 
			}
		}

		public async Task UpdateTimeLogs(TimeLogs timelogs) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					db.Update(timelogs);
					tx.Commit();
					db.Flush();
				}
			}
		}
		public async Task UpdateTimeLogStatus() {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					//db.CreateSQLQuery("exec UpdateTimeLogsStatus").ExecuteUpdate();
					db.CreateSQLQuery("UPDATE TimeLogs set Status='Uploaded'" +
									"WHERE Status='ForUploading'").ExecuteUpdate();
					tx.Commit();
					db.Flush();
				}
			}
		}

	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously