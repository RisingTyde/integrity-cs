using System;

namespace Romax
{
    public class IntegrityException : Exception
    {
        public IntegrityException(string message) : base(message)
        {
        }
    }

    public class Integrity
    {
        public static void Check(bool condition, params object[] mesageArgs)
        {
            if (!condition)
            {
                string text = Integrity.getMessage("Integrity check failed", mesageArgs);
                throw new IntegrityException(text);
            }
        }
        public static void CheckIsBool(bool? test, params object[] mesageArgs)
        {
            if(test == null)
            {
                string text = Integrity.getMessage("Expected bool, was null", mesageArgs);
                throw new NullReferenceException(text);
            }
        }

        private static string getMessage(string defaultMessage, params object[] mesageArgs)
        {
            if(mesageArgs == null || mesageArgs.Length == 0)
            {
                return defaultMessage;
            }

            string s = "";
            for(int i=0; i<mesageArgs.Length; i++)
            {
                object item = mesageArgs[i];
                int braces = s.IndexOf("{}");
                if (braces == -1)
                {
                    if(s.Length == 0)
                    {
                        s += item.ToString();
                    } else
                    {
                        s += ", " + item.ToString();
                    }
                } else
                {
                    s = s.Substring(0, braces) + item.ToString() + s.Substring(braces + 2);
                }
            }

            return s;
        }

        public static void CheckNotNull(object obj, string fieldName)
        {
            if (obj == null)
            {
                throw new NullReferenceException(fieldName);
            }
        }
        public static void CheckStringNotNullOrEmpty(string s, string fieldName)
        {
            if (s == null)
            {
                throw new NullReferenceException(fieldName);
            }
            if (s.Length == 0)
            {
                throw new IntegrityException("Expected non-empty string: " + fieldName);
            }
        }

        public static void CheckValidFloat(double? d, string fieldName)
        {
            if (d == null)
            {
                throw new NullReferenceException(fieldName);
            }
            
            if (Double.IsNaN((double) d)) {
                throw new IntegrityException("Float is NaN: " + fieldName);
            }

            if (Double.IsPositiveInfinity((double) d)) 
            {
                throw new IntegrityException("Float is +infinity: " + fieldName);
            }

            if (Double.IsNegativeInfinity((double) d))
            {
                throw new IntegrityException("Float is -infinity: " + fieldName);
            }
        }

        public static void CheckValidFloatNotZero(double? d, string fieldName)
        {
            CheckValidFloat(d, fieldName);

            if(d == 0) // works for both +0 and -0
            {
                throw new IntegrityException("Expected non-zero value: " + fieldName);
            }
        }
    }
}
