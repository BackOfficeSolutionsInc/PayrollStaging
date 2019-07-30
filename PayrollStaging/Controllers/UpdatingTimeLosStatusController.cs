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
	public class UpdatingTimeLosStatusController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public async Task Get(string tokenCode) {
			var nhts = new NHibernateITokenStore();
			var token = await nhts.FindByTokenAsync(tokenCode);
			if (token != null) {
				var his = new NHibernateITimeLogStore();
				await his.UpdateTimeLogStatus();
			}
		}

		// POST api/<controller>
		public void Post([FromBody]string value) {
		}

		// PUT api/<controller>/5
		//public async Task Put() {
			
		//}

		// DELETE api/<controller>/5
		public void Delete(int id) {
		}
	}
}