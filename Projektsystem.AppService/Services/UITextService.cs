using System;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Projektsystem.AppService.Services
{
	public class UITextService : IUITextRepository
	{
        private readonly AppDbContext _dbContext;

        public UITextService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UIText GetById(string id)
        {
            return _dbContext.UIText.Find(id);
        }

        public IEnumerable<UIText> GetAll()
        {
            return _dbContext.UIText.ToList();
        }

        public void Add(UIText text)
        {
            _dbContext.UIText.Add(text);
            _dbContext.SaveChanges();
        }

        public void Update(UIText text)
        {
            _dbContext.UIText.Update(text);
            _dbContext.SaveChanges();
        }

        public void Delete(UIText text)
        {
            _dbContext.UIText.Remove(text);
            _dbContext.SaveChanges();
        }

        public string GetStringBykeyAndLangId(string key, Guid langid)
        {
           var uiText =  _dbContext.UIText
                .Where(i => i.UIkey == key  && i.LanguageId == langid).FirstOrDefault();
            if (uiText != null)
            {
                return uiText.UIvalue;
            }
            return string.Empty;
        }
    }
}

