using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IUITextRepository
	{
        public UIText GetById(string id);
        public IEnumerable<UIText> GetAll();
        public void Add(UIText text);
        public void Update(UIText text);
        public void Delete(UIText text);
        public string GetStringBykeyAndLangId(string key,Guid langid);
    }
}

