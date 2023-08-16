using System.Security.Claims;
//using System.IdentityModel.Token.Jwt;

namespace Projektsystem.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string OfficeNumber { get; set; } = string.Empty;
        public string HomeNumber { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string SocialMediaUrl { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }
        public string AuthenticationUrl { get; set; } = string.Empty;
        public bool IsGoogleUser { get; set; }
        public bool IsMicrosoftUser { get; set; }
        public bool IsFacebookUser { get; set; }
        public string MarkdownText { get; set; } = string.Empty;
        public decimal MonthlySalary { get; set; } 
        public decimal HourlySalary { get; set; }
        public string Role { get; set; } = string.Empty;

        public string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }
         public virtual Project Project { get; set; }
    }
}