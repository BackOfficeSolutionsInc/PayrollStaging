
using PayrollStaging.Models;
using PayrollStaging.Models.Enums;
using PayrollStaging.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PayrollStaging.Controllers {
	[EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
	public class UploadingTimeLogsController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public async Task<IList<TimeLogs>> Get(string tokenCode) {
			var creaToken = false; //for token manual creation
			var nhts = new NHibernateITokenStore();
			if (creaToken) {
				var tkn = Guid.NewGuid().ToString();
				var token = new TokenModel() {
					UserName = "Ramco",
					Token = tkn,
					Status = StatusType.Active
				};
				
				await nhts.CreateToken(token);
			} else {
				var token = await nhts.FindByTokenAsync(tokenCode);
				if (token == null) {
					return null;
				}
			}
			NHibernateITimeLogStore his = new NHibernateITimeLogStore();
			var search = await his.ReturnTimeLogsForUploadinAsync();
			//foreach (var timelog in search) {
			//	var log = (TimeLogs)timelog;
			//	log.Status = StatusType.Uploaded;
			//	await his.UpdateTimeLogs(log);
			//}
			
			return search;
		}

		// POST api/<controller>
		public void Post([FromBody]string value) {
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}