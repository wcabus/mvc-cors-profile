using System.Configuration;
using GotSharp.AspNet.WebApi.Cors.Configuration;

namespace GotSharp.AspNet.WebApi.Cors
{
    internal class Config
    {
        private const string CorsSectionName = "cors";

        // ReSharper disable once InconsistentNaming
        private static readonly Config _defaultInstance = new Config();
        
        private readonly CorsSection _corsSection;

        public Config(System.Configuration.Configuration configuration)
            : this((CorsSection)configuration.GetSection(CorsSectionName))
        {
            
        }

        private Config()
            : this((CorsSection)ConfigurationManager.GetSection(CorsSectionName))
        {
            
        }

        internal Config(CorsSection corsSection)
        {
            _corsSection = corsSection ?? new CorsSection();
        }

        public static Config DefaultInstance
        {
            get
            {
                return _defaultInstance;
            }
        }

        public CorsSection CorsSection
        {
            get
            {
                return _corsSection;
            }
        }
    }
}