using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;
using System.Collections;
using System.Resources;

namespace Projektsystem.BlazorApp.ServiceHelper
{
    public class ProjektsystemStringLocalizer<TComponent> : IStringLocalizer<TComponent>
    {

        private readonly IOptions<LocalizationOptions> _localizationOptions;
        private readonly LanguageNotifierService _languageNotifier;
        private readonly IUILanguageRepository _uILanguage;
        private readonly IUITextRepository _UItext;

        public LocalizedString this[string name] => FindLocalziedString(name);
        public LocalizedString this[string name, params object[] arguments] => FindLocalziedString(name, arguments);

        public ProjektsystemStringLocalizer(IOptions<LocalizationOptions> localizationOptions,
            LanguageNotifierService languageNotifier, IUILanguageRepository uILanguage, IUITextRepository uIText )
        {
            _localizationOptions = localizationOptions;
            _languageNotifier = languageNotifier;
            this._uILanguage = uILanguage;
            this._UItext = uIText;
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var result = new List<LocalizedString>();
            return result;
        }

        private LocalizedString FindLocalziedString(string key, object[]? arguments = default)
        {
            LocalizedString result;
            var lang = _uILanguage.GetByCultureName(_languageNotifier.CurrentCulture.Name);


            try
            {
                 string value = _UItext.GetStringBykeyAndLangId(key, lang.Id);

                if (arguments is not null)
                {
                    value = string.Format(value, arguments);
                }

                result = new(key, value, false, null);
            }
            catch
            {
                result = new(key, "", true, null);
            }

            return result;
        }
    }
}
