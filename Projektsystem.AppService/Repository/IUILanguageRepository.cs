using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IUILanguageRepository
	{
        public UILanguage GetById(string id);
        public UILanguage GetByCultureName(string langName);
        public IEnumerable<UILanguage> GetAll();
      //  public Task<IEnumerable<UILanguage>> GetAllAsync();
        public void Add(UILanguage language);
        public void Update(UILanguage language);
        public void Delete(UILanguage language);
    }
}

