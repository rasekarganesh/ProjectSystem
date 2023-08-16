using System;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using Projektsystem.AppService.Repository;
using Projektsystem.AppService.Services;
using Projektsystem.Model;

namespace Projektsystem.BlazorApp.ServiceHelper
{
	public class LoginService
	{
		private readonly ProtectedLocalStorage protectedLocalStorage;
		private readonly string StroageIdentityKey = "userIdentity";

        private readonly IUserRepository userService;
        public LoginService(ProtectedLocalStorage protectedLocalStorage, IUserRepository userRepository)
		{
			this.protectedLocalStorage = protectedLocalStorage;
            userService = userRepository;
        }

        public async Task<User?> FindUserFromDatabaseAsync(string email)
        {

            var userInDatabase = userService.GetByEmail(email);

            if (userInDatabase is not null)
            {
                await PersistUserToBrowserAsync(userInDatabase);
            }

            return userInDatabase;
        }



        public async Task PersistUserToBrowserAsync(User user)
		{
            string userJson = JsonConvert.SerializeObject(user);
            await protectedLocalStorage.SetAsync(StroageIdentityKey, userJson);
		}

		public async Task<User?> GetUserFromBrowserAsync()
		{
			try
			{
				var fetchresult = await protectedLocalStorage.GetAsync<string>(StroageIdentityKey);
                if (fetchresult.Success && !string.IsNullOrEmpty(fetchresult.Value))
                {

                    var user = JsonConvert.DeserializeObject<User>(fetchresult.Value);
                    return user;
                }
            }
			catch (Exception)
			{

			}
			return null;
		}

		public async Task ClearBrowserUserDataAsync() =>
			await protectedLocalStorage.DeleteAsync(StroageIdentityKey);
	}
}

