
using PayrollStaging.Models;
using PayrollStaging.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PayrollStaging.Controllers {
	public class UploadingTimeLogsController : ApiController {
		// GET api/<controller>
		public IEnumerable<string> Get() {
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public async Task<IList<TimeLogs>> Get(string token) {
			NHibernateITimeLogStore his = new NHibernateITimeLogStore();
			var search = await his.ReturnTimeLogsForUploadinAsync();
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