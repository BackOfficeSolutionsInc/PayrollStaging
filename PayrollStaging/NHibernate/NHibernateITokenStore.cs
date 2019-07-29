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
	public class NHibernateITokenStore {
		public async Task CreateToken(TokenModel token) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					db.Save(token);
					tx.Commit();
					db.Flush();
				}
			}
		}

		public async Task<TokenModel> FindByTokenAsync(string token) {
			using (var db = HibernateSession.GetCurrentSession()) {
				using (var tx = db.BeginTransaction()) {
					return db.QueryOver<TokenModel>().Where(x => x.Status == StatusType.Active && x.Token==token).SingleOrDefault();
				}
			}
		}

	}
}
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously