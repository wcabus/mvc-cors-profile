using System.ComponentModel;
using System.Configuration;

namespace Cors.ConfigProfiles.Configuration
{
    internal static class ValidatorsAndConverters
    {
        private static WhiteSpaceTrimStringConverter _whiteSpaceTrimStringConverter;
        private static StringValidator _nonEmptyStringValidator;

        internal static TypeConverter WhiteSpaceTrimStringConverter
        {
            get {
                return _whiteSpaceTrimStringConverter ??
                       (_whiteSpaceTrimStringConverter = new WhiteSpaceTrimStringConverter());
            }
        }

        internal static ConfigurationValidatorBase NonEmptyStringValidator
        {
            get
            {
                return _nonEmptyStringValidator ?? 
                    (_nonEmptyStringValidator = new StringValidator(1));
            }
        }
    }
}