using Projektsystem.Model;
using Projektsystem.AppService.Repository;
using Projektsystem.AppService.Context;

namespace Projektsystem.AppService.Services
{
    public class UILanguageService : IUILanguageRepository
    {

        private readonly AppDbContext _dbContext;

        public UILanguageService(AppDbContext dbContext, IUITextRepository uIText)
        {
            _dbContext = dbContext;
            if (_dbContext.UILanguage.Count() == 0)
            {
                Add(new UILanguage()
                {
                    CreatedTime = DateTime.Now,
                    CultureName = "en-GB",
                    Name = "English",
                    CountryCode = "GB"
                });
                Add(new UILanguage()
                {
                    CreatedTime = DateTime.Now,
                    CultureName = "sv-SE",
                    Name = "Swedish",
                    CountryCode = "SE"
                });
                var en = GetByCultureName("en-GB").Id;
                var se = GetByCultureName("sv-SE").Id;
                // English
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Home", UIvalue = "Home" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Projects", UIvalue = "Projects" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Users", UIvalue = "Users" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Logs", UIvalue = "Logs" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Help", UIvalue = "Help" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Logout", UIvalue = "Logout" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Language", UIvalue = "Language" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Create new Project", UIvalue = "Create new Project" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Project Name", UIvalue = "Project Name" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "For Company", UIvalue = "For Company" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "By Company", UIvalue = "By Company" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "IsOpen", UIvalue = "Is Open" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Status", UIvalue = "Status" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Save", UIvalue = "Save" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "ProCreateMsg", UIvalue = "Project Created Successfully." });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Picture", UIvalue = "Picture" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "User", UIvalue = "User" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Source", UIvalue = "Source" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Event On", UIvalue = "Event On" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Action", UIvalue = "Action" });

                uIText.Add(new UIText() { LanguageId = en, UIkey = "Open Projects", UIvalue = "Open Projects" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "New Projects", UIvalue = "New Projects" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Closed Projects", UIvalue = "Closed Projects" });
                uIText.Add(new UIText() { LanguageId = en, UIkey = "Hold Projects", UIvalue = "Hold Projects" });
                //"Project Created Successfully."
                // Swedish
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Home", UIvalue = "Hem" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Projects", UIvalue = "Projekt" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Users", UIvalue = "Användare" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Logs", UIvalue = "Loggar" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Help", UIvalue = "Hjälp" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Logout", UIvalue = "Logga ut" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Language", UIvalue = "Språk" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Create new Project", UIvalue = "Skapa nytt projekt" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Project Name", UIvalue = "Projektnamn" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "For Company", UIvalue = "För företag" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "By Company", UIvalue = "Efter företag" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "IsOpen", UIvalue = "är öppen" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Status", UIvalue = "Status" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Save", UIvalue = "Spara" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "ProCreateMsg", UIvalue = "Projektet har skapats framgångsrikt." });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Picture", UIvalue = "bild" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "User", UIvalue = "Användare" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Source", UIvalue = "Källa" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Event On", UIvalue = "Händelse på" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Action", UIvalue = "Handling" });

                uIText.Add(new UIText() { LanguageId = se, UIkey = "Open Projects", UIvalue = "Öppna projekt" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "New Projects", UIvalue = "Nya projekt" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Closed Projects", UIvalue = "Stängt projekt" });
                uIText.Add(new UIText() { LanguageId = se, UIkey = "Hold Projects", UIvalue = "Håll projekt" });
            }
        }

        public UILanguage GetById(string id)
        {
            return _dbContext.UILanguage.Find(id);
        }

        public IEnumerable<UILanguage> GetAll()
        {
            return _dbContext.UILanguage.ToList();
        }

        public void Add(UILanguage project)
        {
            _dbContext.UILanguage.Add(project);
            _dbContext.SaveChanges();
        }

        public void Update(UILanguage project)
        {
            _dbContext.UILanguage.Update(project);
            _dbContext.SaveChanges();
        }

        public void Delete(UILanguage project)
        {
            _dbContext.UILanguage.Remove(project);
            _dbContext.SaveChanges();
        }

        public UILanguage GetByCultureName(string langName)
        {
            if (langName == null)
            {

            }
            return _dbContext.UILanguage.Where(i => i.CultureName == langName).FirstOrDefault();
        }
    }
}