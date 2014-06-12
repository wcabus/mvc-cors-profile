﻿using System.ComponentModel;
using System.Configuration;

namespace GotSharp.AspNet.WebApi.Cors.Configuration
{
    public sealed class CorsProfile : ConfigurationElement
    {
        // ReSharper disable InconsistentNaming
        private readonly static ConfigurationPropertyCollection _properties;
        private static readonly ConfigurationProperty _propName;
        private static readonly ConfigurationProperty _propOrigins;
        private static readonly ConfigurationProperty _propHeaders;
        private static readonly ConfigurationProperty _propMethods;
        private static readonly ConfigurationProperty _propExposedHeaders;
        // ReSharper restore InconsistentNaming

        static CorsProfile()
        {
            _properties = new ConfigurationPropertyCollection();
            _propName = new ConfigurationProperty("name", typeof(string), null, ValidatorsAndConverters.WhiteSpaceTrimStringConverter, ValidatorsAndConverters.NonEmptyStringValidator, ConfigurationPropertyOptions.IsRequired | ConfigurationPropertyOptions.IsKey);
            _propOrigins = new ConfigurationProperty("origins", typeof(string), "*", ValidatorsAndConverters.WhiteSpaceTrimStringConverter, ValidatorsAndConverters.NonEmptyStringValidator, ConfigurationPropertyOptions.IsRequired);
            _propHeaders = new ConfigurationProperty("headers", typeof(string), "*", ValidatorsAndConverters.WhiteSpaceTrimStringConverter, ValidatorsAndConverters.NonEmptyStringValidator, ConfigurationPropertyOptions.None);
            _propMethods = new ConfigurationProperty("methods", typeof(string), "*", ValidatorsAndConverters.WhiteSpaceTrimStringConverter, ValidatorsAndConverters.NonEmptyStringValidator, ConfigurationPropertyOptions.None);
            _propExposedHeaders = new ConfigurationProperty("exposedHeaders", typeof(string), null, ValidatorsAndConverters.WhiteSpaceTrimStringConverter, ValidatorsAndConverters.NonEmptyStringValidator, ConfigurationPropertyOptions.None);
            _properties.Add(_propName);
            _properties.Add(_propOrigins);
            _properties.Add(_propHeaders);
            _properties.Add(_propMethods);
            _properties.Add(_propExposedHeaders);
        }

        internal CorsProfile()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorsProfile" /> class.
        /// </summary>
        /// <param name="name">The name value to use.</param>
        public CorsProfile(string name)
        {
            Name = name;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <returns>The name.</returns>
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = ""), StringValidator(MinLength = 1)]
        public string Name
        {
            get
            {
                return (string)base[_propName];
            }
            set
            {
                base[_propName] = value;
            }
        }

        /// <summary>
        /// Gets or sets the origins.
        /// </summary>
        /// <returns>The origins.</returns>
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        [ConfigurationProperty("origins", IsRequired = true, DefaultValue = "*")]
        public string Origins
        {
            get
            {
                return (string)base[_propOrigins];
            }
            set
            {
                base[_propOrigins] = value;
            }
        }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <returns>The headers.</returns>
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        [ConfigurationProperty("headers", DefaultValue = "*")]
        public string Headers
        {
            get
            {
                return (string)base[_propHeaders];
            }
            set
            {
                base[_propHeaders] = value;
            }
        }

        /// <summary>
        /// Gets or sets the methods.
        /// </summary>
        /// <returns>The methods.</returns>
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        [ConfigurationProperty("methods", DefaultValue = "*")]
        public string Methods
        {
            get
            {
                return (string)base[_propMethods];
            }
            set
            {
                base[_propMethods] = value;
            }
        }

        /// <summary>
        /// Gets or sets the exposed headers.
        /// </summary>
        /// <returns>The exposed headers.</returns>
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        [ConfigurationProperty("exposedHeaders", DefaultValue = null)]
        public string ExposedHeaders
        {
            get
            {
                return (string)base[_propExposedHeaders];
            }
            set
            {
                base[_propExposedHeaders] = value;
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