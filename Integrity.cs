using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace IntegrityCheck
{
    public class Integrity
    {
        public static int truncationLength = 100;
        public static int depthLimit = 10;
        public string VERSION = "1.3.3";

        /// <summary>
        /// General default message. This can be changed if you want a different message.
        /// </summary>
        public static string defaultMessage = "Integrity test failed";

        /// <summary>
        /// Default message for null pointer exceptions. This can be changed if you want a different message.
        /// </summary>
        public static string nullPointerDefaultMessage = "Integrity test failed: Null encountered";

        /// <summary>
        /// Empty string default message. This can be changed if you want a different message.
        /// </summary>
        public static string emptyStringDefaultMessage = "Empty string";

        /// <summary>
        /// NaN default message. This can be changed if you want a different message.
        /// </summary>
        public static string nanDefaultMessage = "NaN";

        /// <summary>
        /// Positive Infinity default message. This can be changed if you want a different message.
        /// </summary>
        public static string pInfinityDefaultMessage = "+Infinity";

        /// <summary>
        /// Negative Infinity default message. This can be changed if you want a different message.
        /// </summary>
        public static string nInfinityDefaultMessage = "-Infinity";


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
                string text = Integrity.getMessage(defaultMessage, mesageArgs);
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
            string text = Integrity.getMessage(defaultMessage, mesageArgs);
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
                string text = Integrity.getMessage(emptyStringDefaultMessage, mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        public static void CheckIsValidNumber<T>(T d, params object[] mesageArgs)
        {
            if(d == null)
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
                string text = Integrity.getMessage(nanDefaultMessage, mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (float.IsPositiveInfinity(d))
            {
                string text = Integrity.getMessage(pInfinityDefaultMessage, mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (float.IsNegativeInfinity(d))
            {
                string text = Integrity.getMessage(nInfinityDefaultMessage, mesageArgs);
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
                throw new InvalidOperationException(Integrity.getMessage(nanDefaultMessage, mesageArgs));
            }

            if (float.IsPositiveInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage(pInfinityDefaultMessage, mesageArgs));
            }

            if (float.IsNegativeInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage(nInfinityDefaultMessage, mesageArgs));
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
                throw new InvalidOperationException(Integrity.getMessage(nanDefaultMessage, mesageArgs));
            }

            if (Double.IsPositiveInfinity(d))
            {
                throw new InvalidOperationException(Integrity.getMessage(pInfinityDefaultMessage, mesageArgs));
            }

            if (Double.IsNegativeInfinity(d))
            {
                throw new InvalidOperationException(Integrity.getMessage(nInfinityDefaultMessage, mesageArgs));
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
                throw new InvalidOperationException(Integrity.getMessage(nanDefaultMessage, mesageArgs));
            }

            if (Double.IsPositiveInfinity(nonNullD)) 
            {
                throw new InvalidOperationException(Integrity.getMessage(pInfinityDefaultMessage, mesageArgs));
            }

            if (Double.IsNegativeInfinity(nonNullD))
            {
                throw new InvalidOperationException(Integrity.getMessage(nInfinityDefaultMessage, mesageArgs));
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
            CheckIsValidNumber(d, mesageArgs);
        }

        public static void CheckIsValidNumberOrNull<T>(T d, params object[] mesageArgs)
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
        /// deferredStringbuilder("{}", [1, 2]) returns "[1,2]"
        /// 
        /// arrays & collections are broken out into their parts and surround by []
        /// for example ["a string", 1, 1.1]
        /// 
        /// an object which is not a primitive, does not implement IEnumberable, and appears to not override toString will be formated in json style 
        /// {field1: "a value",anArray: [ 1, 2]}
        /// note that only public fields and properties are represented
        /// 
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
                    string itemAsString = itemAsStringValue(item, i != 0);
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
                    s = s.Substring(0, braces) + itemAsStringValue(item) + s.Substring(braces + 2);
                }
            }

            return s;
        }

        private static string itemAsStringValue(object item, Boolean surroundStringInQuotes = false)
        {
            string rawItem = objAsString(item, true, 0);

            bool truncated = false;

            if(rawItem.Length > truncationLength)
            {
                rawItem = rawItem.Substring(0, truncationLength);
                truncated = true;
            }

            if (item.GetType() == typeof(string) && surroundStringInQuotes)
            {
                if (truncated)
                {
                    return "\"" + rawItem + "\"...";
                } 
                else
                {
                    return "\"" + rawItem + "\"";
                }
            }

            if(truncated)
            {
                return rawItem + "...";
            }

            return rawItem;
        }

        private static Boolean hasSensibleToString(object obj)
        {
            Type type = obj.GetType();

            if (type.IsPrimitive)
            {
                return true;
            }

            if (type == typeof(string))
            {
                return true;
            }

            if(obj is IEnumerable)
            {
                return false;
            }

            // use a rule of thumb which is if the toString returns the same as the classname then
            // it is most likely an object which has not overriden toString

            string toStr = obj.ToString();
            string typeName = obj.GetType().FullName;
            return !toStr.Equals(typeName);
        }

        private static string getBasicToStringRep(object obj, Boolean rawString)
        {
            if (obj.GetType() == typeof(string) && !rawString)
            {
                return "\"" + obj.ToString() + "\"";
            }
            return obj.ToString();
        }

        private static string objAsString(object obj, bool rawString, int depth)
        {
            /*
             * There is a possibility that an object will contain circular references which are hard to detect. If the depth
             * exceeds the depthLimit then pull the plug so we don't end up with a stack overflow
             */
            if(depth > depthLimit)
            {
                return "<<depth " + depth + " exceeded>>";
            }

            Type type = obj.GetType();

            if(hasSensibleToString(obj))
            {
                return getBasicToStringRep(obj, rawString);
            }

            bool isEnumerable = obj is IEnumerable; // note string is enumerable but wont get here as string will be already returned
            string json = "";

            if (isEnumerable)
            {
                json = "[";

                var asArr = obj as IEnumerable;

                bool first = true;
                foreach(var item in asArr)
                {
                    if (!first)
                    {
                        json = json + ",";
                    } 
                    else
                    {
                        first = false;
                    }
                    json += objAsString(item, false, depth+1);
                }

                json += "]";
            }
            else // assume it is a class or struct with fields/properties (i.e. not a primitive)
            {
                json = "{";

                FieldInfo[] fieldInfo = type.GetFields();
                PropertyInfo[] properties = type.GetProperties();
                List<(string, string)> list = new List<(string, string)>();
                for (int i = 0; i < fieldInfo.Length; i++)
                {
                    FieldInfo f = fieldInfo[i];
                    object value = f.GetValue(obj);
                    if(value.GetType() != obj.GetType()) // try and avoid infinite recursion
                    {
                        list.Add((f.Name, objAsString(value, rawString, depth+1)));
                    } 
                    else
                    {
                        list.Add((f.Name, "<" + value.GetType().Name + ">"));
                    }
                }
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo p = properties[i];
                    object value = p.GetValue(obj);

                    if (value.GetType() != obj.GetType()) // try and avoid infinite recursion
                    {
                        list.Add((p.Name, objAsString(value, rawString, depth+1)));
                    }
                    else
                    {
                        list.Add((p.Name, "<" + value.GetType().Name + ">"));
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (i != 0)
                    {
                        json = json + ",";
                    }
                    json += "\"" + list[i].Item1 + "\":" + list[i].Item2;
                }

                json += "}";
            }
            return json;
        }
    }
}
