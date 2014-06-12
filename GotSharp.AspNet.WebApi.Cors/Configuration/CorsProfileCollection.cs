using System;
using System.Configuration;
using System.Linq;

namespace GotSharp.AspNet.WebApi.Cors.Configuration
{
    [ConfigurationCollection(typeof(CorsProfile))]
    public sealed class CorsProfileCollection : ConfigurationElementCollection
    {
        // ReSharper disable once InconsistentNaming
        private readonly static ConfigurationPropertyCollection _properties;

        static CorsProfileCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorsProfileCollection" /> class.
        /// </summary>
        public CorsProfileCollection() : base(StringComparer.OrdinalIgnoreCase)
        {
            
        }

        /// <summary>
        /// Gets the <see cref="CorsProfileCollection" /> keys.
        /// </summary>
        /// <returns>The string array containing the collection keys.</returns>
        public string[] AllKeys
        {
            get
            {
                return BaseGetAllKeys().Cast<string>().ToArray();
            }
        }

        /// <summary>
        /// Gets the <see cref="CorsProfile" /> with the specified name.
        /// </summary>
        /// <returns>The <see cref="CorsProfile" /> with the specified name.</returns>
        /// <param name="name">The name of the <see cref="CorsProfile" /> object.</param>
        public new CorsProfile this[string name]
        {
            get
            {
                return (CorsProfile)BaseGet(name);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="CorsProfile" /> object at the specified index.
        /// </summary>
        /// <returns>The <see cref="CorsProfile" /> at the specified index.</returns>
        /// <param name="index">The collection index of the <see cref="CorsProfile" /> object </param>
        public CorsProfile this[int index]
        {
            get
            {
                return (CorsProfile)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        /// <summary>
        /// Adds a <see cref="CorsProfile" /> object to the collection.
        /// </summary>
        /// <param name="profile">The <see cref="CorsProfile" /> object to add to the collection.</param>
        /// <exception cref="ConfigurationErrorsException">
        /// The <see cref="CorsProfile" /> object already exists in the collection or the collection is read only.
        /// </exception>
        public void Add(CorsProfile profile)
        {
            BaseAdd(profile);
        }

        /// <summary>
        /// Removes all the <see cref="CorsProfile"/> objects from the collection.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">The collection is read only.</exception>
        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CorsProfile();
        }

        /// <summary>
        /// Gets the <see cref="CorsProfile" /> element at the specified index.
        /// </summary>
        /// <returns>The <see cref="CorsProfile" /> element at the specified index.</returns>
        /// <param name="index">The index of the <see cref="CorsProfile" /> element. </param>
        public CorsProfile Get(int index)
        {
            return (CorsProfile)BaseGet(index);
        }

        /// <summary>
        /// Gets the <see cref="CorsProfile" /> element with the specified name.
        /// </summary>
        /// <returns>The <see cref="CorsProfile" /> element with the specified name.</returns>
        /// <param name="name">The name of the <see cref="CorsProfile" /> element. </param>
        public CorsProfile Get(string name)
        {
            return (CorsProfile)BaseGet(name);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CorsProfile)element).Name;
        }

        /// <summary>
        /// Gets the key at the specified index.
        /// </summary>
        /// <returns>The key with the specified index.</returns>
        /// <param name="index">The index of the key.</param>
        public string GetKey(int index)
        {
            return (string)BaseGetKey(index);
        }

        /// <summary>
        /// Removes the <see cref="CorsProfile" /> object with the specified name from the collection.
        /// </summary>
        /// <param name="name">The name of the <see cref="CorsProfile" /> element to remove from the collection. </param>
        /// <exception cref="ConfigurationErrorsException">There is no <see cref="CorsProfile" /> object with the specified name in the collection, the element has already been removed, or the collection is read-only.</exception>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// Removes the <see cref="CorsProfile" /> object at the specified index from the collection.
        /// </summary>
        /// <param name="index">The index of the <see cref="CorsProfile" /> element to remove from the collection. </param>
        /// <exception cref="ConfigurationErrorsException">There is no <see cref="CorsProfile" /> object at the specified index in the collection or the collection is read-only.</exception>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Sets the specified <see cref="CorsProfile" /> object.
        /// </summary>
        /// <param name="profile">The <see cref="CorsProfile" /> element to set.</param>
        /// <exception cref="ConfigurationErrorsException">The <see cref="CorsProfileCollection" /> is read-only.</exception>
        public void Set(CorsProfile profile)
        {
            BaseAdd(profile, false);
        }
    }
}