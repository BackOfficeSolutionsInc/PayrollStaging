
using System.Diagnostics;
using FluentNHibernate.Mapping;
using PayrollStaging.Models.Enums;
using System;
//using Microsoft.AspNet.Identity.EntityFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollStaging.Models {
	
	public class TokenModel {
		public virtual long Id { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Token { get; set; }
		public virtual DateTime CreateTime { get; set; }
		public virtual StatusType Status { get; set; }

		public TokenModel() {

			CreateTime = DateTime.UtcNow;
		}
		public class TokenModelMap : ClassMap<TokenModel> {
			public TokenModelMap() {
				Id(x => x.Id);
				Map(x => x.UserName);
				Map(x => x.Token);
				Map(x => x.CreateTime);
				Map(x => x.Status);
			}
		}



		
	}

}
