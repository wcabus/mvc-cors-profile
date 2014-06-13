using System;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using Cors.ConfigProfiles.Configuration;

namespace Cors.ConfigProfiles
{
    /// <summary>
    /// This class defines an attribute that can be applied to an action or a controller to enable CORS.
    /// By default, it allows all origins, methods and headers.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class EnableCorsAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly System.Web.Http.Cors.EnableCorsAttribute _internalAttribute;
        
        // First, we'll add the same constructors as the original EnableCorsAttribute supports.

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableCorsAttribute" /> class.
        /// </summary>
        /// <param name="origins">Comma-separated list of origins that are allowed to access the resource. Use "*" to allow all.</param>
        /// <param name="headers">Comma-separated list of headers that are supported by the resource. Use "*" to allow all. Use null or empty string to allow none.</param>
        /// <param name="methods">Comma-separated list of methods that are supported by the resource. Use "*" to allow all. Use null or empty string to allow none.</param>
        
        public EnableCorsAttribute(string origins, string headers, string methods) : this(origins, headers, methods, null)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableCorsAttribute" /> class.
        /// </summary>
        /// <param name="origins">Comma-separated list of origins that are allowed to access the resource. Use "*" to allow all.</param>
        /// <param name="headers">Comma-separated list of headers that are supported by the resource. Use "*" to allow all. Use null or empty string to allow none.</param>
        /// <param name="methods">Comma-separated list of methods that are supported by the resource. Use "*" to allow all. Use null or empty string to allow none.</param>
        /// <param name="exposedHeaders">Comma-separated list of headers that the resource might use and can be exposed. Use null or empty string to expose none.</param>
        public EnableCorsAttribute(string origins, string headers, string methods, string exposedHeaders)
        {
            _internalAttribute = new System.Web.Http.Cors.EnableCorsAttribute(origins, headers, methods, exposedHeaders);
        }

        // And now, we add a new constructor that accepts a profile name

        /// <summary>
        /// Initializes a new instance of the <see cref="EnableCorsAttribute" /> class.
        /// </summary>
        /// <param name="corsProfile">Name of the profile.</param>
        public EnableCorsAttribute(string corsProfile)
        {
            if (string.IsNullOrEmpty(corsProfile))
            {
                throw new ArgumentException(StringResources.ArgumentCannotBeNullOrEmpty, "corsProfile");
            }

            //Look up the CorsProfile
            var corsSettings = GetProfile(corsProfile);
            if (corsSettings == null)
            {
                throw new ConfigurationErrorsException(string.Format(StringResources.ErrNoCorsProfileFoundMatchingName, corsProfile));
            }

            _internalAttribute = new System.Web.Http.Cors.EnableCorsAttribute(
                corsSettings.Origins,
                corsSettings.Headers,
                corsSettings.Methods,
                corsSettings.ExposedHeaders
            );

            if (corsSettings.PreflightMaxAge > -1)
            {
                _internalAttribute.PreflightMaxAge = corsSettings.PreflightMaxAge;
            }

            _internalAttribute.SupportsCredentials = corsSettings.SupportsCredentials;
        }

        public bool SupportsCredentials
        {
            get
            {
                return _internalAttribute.SupportsCredentials;
            }
            set
            {
                _internalAttribute.SupportsCredentials = value;
            }
        }

        public long PreflightMaxAge
        {
            get
            {
                return _internalAttribute.PreflightMaxAge;
            }
            set
            {
                _internalAttribute.PreflightMaxAge = value;
            }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _internalAttribute.GetCorsPolicyAsync(request, cancellationToken);
        }

        internal CorsProfile GetProfile(string profileName)
        {
            var config = Config.DefaultInstance.CorsSection;
            return config.CorsProfiles[profileName];
        }
    }
}
