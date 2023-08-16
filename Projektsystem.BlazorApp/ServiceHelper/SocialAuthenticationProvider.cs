using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;
using Projektsystem.Model.SocialModels;

namespace Projektsystem.BlazorApp.ServiceHelper
{
    public class SocialAuthenticationProvider : AuthenticationStateProvider, IDisposable
	{
		private readonly LoginService loginService;
		private readonly IAuditLogRepository auditLog;
        private readonly IUserRepository userService;

        public User? CurrentUser { get; set; } = new();

		public SocialAuthenticationProvider(LoginService loginService, IAuditLogRepository auditLog,
			IUserRepository userService)
		{
			AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
			this.loginService = loginService;
			this.auditLog = auditLog;
			this.userService = userService;

        }


		private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
		{
			var authenticationState = await task;

			if (authenticationState is not null)
			{
				var guid = authenticationState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

                CurrentUser = new()
				{
					FirstName = authenticationState.User.FindFirst(ClaimTypes.Name)?.Value ?? "",
					LastName = authenticationState.User.FindFirst(ClaimTypes.Surname)?.Value ?? "",
					Email = authenticationState.User.FindFirst(ClaimTypes.Email)?.Value ?? "",
					ProfilePicture = authenticationState.User.FindFirst(ClaimTypes.Actor)?.Value ?? "",
					 Id = string.IsNullOrEmpty(guid)? Guid.NewGuid(): Guid.Parse(guid),
					Role = authenticationState.User.FindFirst(ClaimTypes.Role)?.Value ?? ""
				};
			}
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var principal = new ClaimsPrincipal();
			var user = await loginService.GetUserFromBrowserAsync();

			if (user is not null)
			{
				// var authenticatedUser = await loginService.FindUserFromDatabaseAsync(user.Email);
				// CurrentUser = authenticatedUser;
				var authenticatedUser = CurrentUser = user;

				if (authenticatedUser is not null)
				{
					principal = ToClaimsPrincipal(authenticatedUser);
					//NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
				}

			}

			return new(principal);
		}

		public async Task LoginAsync(string email)
		{
			var principal = new ClaimsPrincipal();
			var user = await loginService.FindUserFromDatabaseAsync(email);
			CurrentUser = user;

			if (user is not null)
			{
				principal = ToClaimsPrincipal(user);
				auditLog.Add(new AuditLog() { ForId = user.Id,ForName = user.Name , EventEnum = LogEventType.Login , Source="Login" });
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
		}

		[JSInvokable]
		public void GoogleLogin(GoogleResponse googleResponse)
		{
			var principal = new ClaimsPrincipal();
			var user = FromGoogleJwt(googleResponse.Credential);
			CurrentUser = user;

			if (user is not null)
			{
				principal = ToClaimsPrincipal(user);

				auditLog.Add(new AuditLog() { ForId = user.Id, ForName = user.Name, EventEnum = LogEventType.Login, Source = "Login" });
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
		}

        private ClaimsPrincipal ToClaimsPrincipal(User user)
		{
			return new(new ClaimsIdentity(new Claim[] {
						   new (ClaimTypes.Name, user.FirstName),
						   new (ClaimTypes.Surname, user.LastName),
						   new (ClaimTypes.Email, user.Email),
						   new (ClaimTypes.NameIdentifier, user.Id.ToString()),
						   new (ClaimTypes.Role, user.Role),
						   new (ClaimTypes.Actor, user.ProfilePicture)
					   }, "ProjekSystem"));
		}

		private User? FromGoogleJwt(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();

			if (tokenHandler.CanReadToken(token))
			{
				var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

				var user = new User()
				{
					FirstName = jwtSecurityToken.Claims.First(c => c.Type == "name").Value,
					Email = jwtSecurityToken.Claims.First(c => c.Type == "email").Value,
					ProfilePicture = jwtSecurityToken.Claims.First(c => c.Type == "picture").Value,
				};

				var authenticatedUser = loginService.FindUserFromDatabaseAsync(user.Email).Result;
				if (authenticatedUser == null)
				{
					user.Role = "user";
					user.IsGoogleUser = true;
					userService.Add(user);
              
                    return user;
				}
				return authenticatedUser;
			}

			return null;
		}


		public async Task LogoutAsync()
		{
			await AuditUserLogBeforeLogout();
			await loginService.ClearBrowserUserDataAsync();
			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new())));

		}

		public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

		private async Task AuditUserLogBeforeLogout()
		{
			var user = await loginService.GetUserFromBrowserAsync();

			if (user is not null)
			{
				auditLog.Add(new AuditLog() { ForId = user.Id, ForName = user.Name, EventEnum = LogEventType.Logout , Source = "Logout" });
			}
		}

        [JSInvokable]
        public async Task MicrosoftLoginAsync(MicrosoftResponse microsoftResponse)
        {
            var principal = new ClaimsPrincipal();
            var authenticatedUser = await loginService.FindUserFromDatabaseAsync(microsoftResponse.Email);
            if (authenticatedUser == null)
            {
				authenticatedUser = new User()
				{
					Email = microsoftResponse.Email,
					FirstName = microsoftResponse.Name,
					ProfilePicture = microsoftResponse.Picture,
					Role = "user",
					IsMicrosoftUser = true
				};
                userService.Add(authenticatedUser);
            }

            CurrentUser = authenticatedUser;

            if (authenticatedUser is not null)
            {
                principal = ToClaimsPrincipal(authenticatedUser);

                auditLog.Add(new AuditLog() { ForId = authenticatedUser.Id, ForName = authenticatedUser.Name, EventEnum = LogEventType.Login, Source = "Login" });
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }
    }
}

