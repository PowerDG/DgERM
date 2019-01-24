using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace RQCore.Localization
{
    public static class RQCoreLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {

            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england"));
            localizationConfiguration.Languages.Add(new LanguageInfo("zh-Hans", "简体中文", "famfamfam-flag-cn", true));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(RQCoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(RQCoreLocalizationConfigurer).GetAssembly(),
                        "RQCore.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
