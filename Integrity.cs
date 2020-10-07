using System;

namespace IntegrityCheck
{
    public class Integrity
    {
        /// <summary>
        /// Default message for null pointer exceptions. This can be changed if you want a different message.
        /// </summary>
        public static string nullPointerDefaultMessage = "Encountered Null pointer";

        /// <summary>
        /// Checks whether a condition is true, if not raises an InvalidOperationException, whose message is either a default message, or built from passed in message params
        /// </summary>
        /// <param name="condition">The condition to check is true.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if condition is false</exception>
        public static void Check(bool condition, params object[] mesageArgs)
        {
            if (!condition)
            {
                string text = Integrity.getMessage("Integrity check failed", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        /// <summary>
        /// Raises an InvalidOperationException, whose message is either a default message, or built from passed in message params
        /// </summary>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Fail(params object[] mesageArgs)
        {
            string text = Integrity.getMessage("Integrity check failed", mesageArgs);
            throw new InvalidOperationException(text);
        }

        /// <summary>
        /// Checks whether an object is null, and if so raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="obj">The object to check for nullness.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if obj is null</exception>
        public static void CheckNotNull(object obj, params object[] mesageArgs)
        {
            if (obj == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        /// <summary>
        /// Checks whether a string is null or zero length. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="s">The string to check for nullness or zero length.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if s is null</exception>
        /// <exception cref="InvalidOperationException">Raised if s is exactly 0 characters long</exception>
        /// <remarks>
        /// Note that an exception is only raised if the string has exactly zero length; a string with a single space (for example) would be fine
        /// </remarks>
        public static void CheckStringNotNullOrEmpty(string s, params object[] mesageArgs)
        {
            if (s == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
            if (s.Length == 0)
            {
                string text = Integrity.getMessage("Expected non-empty string", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers.
        /// </summary>
        /// <param name="d">Ignored.</param>
        /// <param name="mesageArgs">Ignored</param>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(int d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers. Dose, however, ensure the number is not null.
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(int? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers.
        /// </summary>
        /// <param name="d">Ignored.</param>
        /// <param name="mesageArgs">Ignored</param>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(uint d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers. Dose, however, ensure the number is not null.
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>

        public static void CheckIsValidNumber(uint? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }
        /// <summary>
        /// Should not be used for a non-floating point numbers.
        /// </summary>
        /// <param name="d">Ignored.</param>
        /// <param name="mesageArgs">Ignored</param>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(long d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting 
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers. Dose, however, ensure the number is not null.
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(long? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers.
        /// </summary>
        /// <param name="d">Ignored.</param>
        /// <param name="mesageArgs">Ignored</param>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(ulong d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting 
        }

        /// <summary>
        /// Should not be used for a non-floating point numbers. Dose, however, ensure the number is not null.
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <remarks>
        /// This only exists because the variants for floating point numbers exist (where it makes sense to check for NaN etc.). Having this overload avoids a conversion to a floating number and some pointless checks. 
        /// </remarks>
        public static void CheckIsValidNumber(ulong? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumber(float d, params object[] mesageArgs)
        {
            if (float.IsNaN(d))
            {
                string text = Integrity.getMessage("NaN", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (float.IsPositiveInfinity(d))
            {
                string text = Integrity.getMessage("+Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (float.IsNegativeInfinity(d))
            {
                string text = Integrity.getMessage("-Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }
        
        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity or null. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumber(float? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }

            float nonNullD = (float) d;

            if (float.IsNaN(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage("NaN", mesageArgs));
            }

            if (float.IsPositiveInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage("+Infinity", mesageArgs));
            }

            if (float.IsNegativeInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage("-Infinity", mesageArgs));
            }
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumber(double d, params object[] mesageArgs)
        {
            if (Double.IsNaN(d))
            {
                throw new InvalidOperationException(Integrity.getMessage("NaN", mesageArgs));
            }

            if (Double.IsPositiveInfinity(d))
            {
                throw new InvalidOperationException(Integrity.getMessage("+Infinity", mesageArgs));
            }

            if (Double.IsNegativeInfinity(d))
            {
                throw new InvalidOperationException(Integrity.getMessage("-Infinity", mesageArgs));
            }
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity or null. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, null, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="NullReferenceException">Raised if d is null</exception>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumber(double? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }

            double nonNullD = (double)d;
            if (Double.IsNaN(nonNullD)) {
                throw new InvalidOperationException(Integrity.getMessage("NaN", mesageArgs));
            }

            if (Double.IsPositiveInfinity(nonNullD)) 
            {
                throw new InvalidOperationException(Integrity.getMessage("+Infinity", mesageArgs));
            }

            if (Double.IsNegativeInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage("-Infinity", mesageArgs));
            }
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumberOrNull(double? d, params object[] mesageArgs)
        {
            if(d == null)
            {
                return;
            }
            CheckIsValidNumber(d, mesageArgs);
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumberOrNull(double d, params object[] mesageArgs)
        {
            if (d == null)
            {
                return;
            }
            CheckIsValidNumber(d, mesageArgs);
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumberOrNull(float? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                return;
            }
            CheckIsValidNumber(d, mesageArgs);
        }

        /// <summary>
        /// Checks whether a number is NaN, +Infinity, -Infinity. If so, raises an exception with a default message or one built from passed in message params
        /// </summary>
        /// <param name="d">The number to check for NaN, or +/-Infinity.</param>
        /// <param name="mesageArgs">See the documentation for deferredStringBuilder to see how the message is built.</param>
        /// <exception cref="InvalidOperationException">Raised if d is NaN, +/-Infinity</exception>
        public static void CheckIsValidNumberOrNull(float d, params object[] mesageArgs)
        {
            if (d == null)
            {
                return;
            }
            CheckIsValidNumber(d, mesageArgs);
        }

        public static void CheckIsValidNumberOrNull(int d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(int? d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(uint d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(uint? d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(long d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(long? d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(ulong d, params object[] mesageArgs)
        {
        }
        public static void CheckIsValidNumberOrNull(ulong? d, params object[] mesageArgs)
        {
        }
        /// <summary>
        /// Concatenates and substitutes passed in arguments to form a string.
        /// Builds a string either by replacing {} in the string being built with the string representation of the next argumnt, or by concatenating ", " plus the string representation.
        /// Note: if strings are substituted into {} they are substituted in as-is. If they are concatenated then they are surrounded by single quotes to indicate that they are strings.
        /// </summary>
        /// <param name="messageArgs">None or many arguments, of any type.</param>
        /// <returns>
        /// A string built from the passed in arguments.
        /// </returns>
        /// <remarks>
        /// Examples:
        /// deferredStringbuilder("this is {}", 1) returns "This is 1"
        /// deferredStringbuilder("this is", 1) returns "This is, 1"
        /// deferredStringbuilder(1, 2, 3) returns "1, 2, 3"
        /// deferredStringbuilder(1, 2, 3) returns "1, 2, 3"
        /// deferredStringbuilder(true, "str", 1.1) returns "True, 'str', 1.1"
        /// deferredStringbuilder("This is {}", "weird {} {}", 1, 2) returns "This is weird 1 2"
        /// deferredStringbuilder("{} {}", 1, 2, 3) returns "1 2, 3"
        /// </remarks>
        public static string deferredStringbuilder(params object[] messageArgs)
        {
            return getMessage("", messageArgs);
        }
        private static string getMessage(string defaultMessage, params object[] mesageArgs)
        {
            if (mesageArgs == null || mesageArgs.Length == 0)
            {
                return defaultMessage;
            }

            string s = "";
            for (int i = 0; i < mesageArgs.Length; i++)
            {
                object item = mesageArgs[i];
                int braces = s.IndexOf("{}");
                if (braces == -1)
                {
                    string itemAsString = null;
                    if(item.GetType() == typeof(string))
                    {
                        itemAsString = "'" + item + "'";
                    } else
                    {
                        itemAsString = item.ToString();
                    }
                    if (s.Length == 0)
                    {
                        s += itemAsString;
                    }
                    else
                    {
                        s += ", " + itemAsString;
                    }
                }
                else
                {
                    s = s.Substring(0, braces) + item.ToString() + s.Substring(braces + 2);
                }
            }

            return s;
        }
    }
}
