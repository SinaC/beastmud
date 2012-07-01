﻿
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Beast.Net;

namespace Beast.Security
{
	public class UserManager
	{
		[ImportMany(typeof(ILoginValidator), AllowRecomposition = true)]
		public IEnumerable<ILoginValidator> LoginValidators { get; set; }

		internal UserManager()
		{
		}

		public bool TryGetUser(IInput input, out User user)
		{
			var username = input.Get<string>("username");

			if (string.IsNullOrEmpty(username))
			{
				user = null;
				return false;
			}

			user = Game.Current.Repository.GetUser(username);
			if (user != null)
			{
				var login = user.Logins.FirstOrDefault(l => l.UserName.ToLower() == username.ToLower());
				if (login != null)
				{
					return (from validator in LoginValidators where validator.CanValidateLogin(login) select validator.ValidateLogin(input, login)).FirstOrDefault();
				}
			}
			return false;
		}

		public bool TryAddLogin(IInput input, out Login login)
		{
			login = null;
			foreach (var validator in LoginValidators)
			{
				login = validator.CreateLogin(input);
				if (login != null)
					return true;
			}
			return true;
		}
	}
}
