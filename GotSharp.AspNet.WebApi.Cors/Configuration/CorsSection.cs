using System.Configuration;

namespace GotSharp.AspNet.WebApi.Cors.Configuration
{
    public sealed class CorsSection : ConfigurationSection
    {
        //Resharper disable InconsistentNaming
        private static readonly ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propCorsProfiles;
        //Resharper restore InconsistentNaming

        static CorsSection()
        {
            _properties = new ConfigurationPropertyCollection();
            _propCorsProfiles = new ConfigurationProperty("corsProfiles", typeof(CorsProfileCollection), null, ConfigurationPropertyOptions.None);
            _properties.Add(_propCorsProfiles);
        }

        [ConfigurationProperty("corsProfiles")]
        public CorsProfileCollection CorsProfiles
        {
            get
            {
                return (CorsProfileCollection)base[_propCorsProfiles];
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}