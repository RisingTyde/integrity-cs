using System;

namespace IntegrityCheck
{
    public class Integrity
    {
        public static string nullPointerDefaultMessage = "Encountered Null pointer";

        public static void Check(bool condition, params object[] mesageArgs)
        {
            if (!condition)
            {
                string text = Integrity.getMessage("Integrity check failed", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        public static void CheckIsBool(bool test, params object[] mesageArgs)
        {
            /* This is just here so that the compiler will chose this version when the argument is not a bool?
             * This will avoid an auto-boxing conversion from bool to bool?
             */
        }

        public static void CheckIsBool(bool? test, params object[] mesageArgs)
        {
            if(test == null)
            {
                string text = Integrity.getMessage("Expected bool, was null", mesageArgs);
                throw new NullReferenceException(text);
            }
        }

        public static void CheckNotNull(object obj, params object[] mesageArgs)
        {
            if (obj == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

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

        public static void CheckIsValidNumber(int d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting
        }


        public static void CheckIsValidNumber(int? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }
        public static void CheckIsValidNumber(uint d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting
        }

        public static void CheckIsValidNumber(uint? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        public static void CheckIsValidNumber(long d, params object[] mesageArgs)
        {
            // speedy shortcut so compiler doesn't waste time converting 
        }

        public static void CheckIsValidNumber(long? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
        }

        public static void CheckIsValidNumber(float d, params object[] mesageArgs)
        {
            if (Double.IsNaN(d))
            {
                string text = Integrity.getMessage("NaN", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsPositiveInfinity(d))
            {
                string text = Integrity.getMessage("+Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsNegativeInfinity(d))
            {
                string text = Integrity.getMessage("-Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }
        public static void CheckIsValidNumber(float? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }

            if (Double.IsNaN((double)d))
            {
                string text = Integrity.getMessage("NaN", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsPositiveInfinity((double)d))
            {
                string text = Integrity.getMessage("+Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsNegativeInfinity((double)d))
            {
                string text = Integrity.getMessage("-Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        public static void CheckIsValidNumber(double d, params object[] mesageArgs)
        {
            if (Double.IsNaN(d))
            {
                string text = Integrity.getMessage("NaN", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsPositiveInfinity(d))
            {
                string text = Integrity.getMessage("+Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsNegativeInfinity(d))
            {
                string text = Integrity.getMessage("-Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        public static void CheckIsValidNumber(double? d, params object[] mesageArgs)
        {
            if (d == null)
            {
                throw new NullReferenceException(Integrity.getMessage(nullPointerDefaultMessage, mesageArgs));
            }
            
            if (Double.IsNaN((double) d)) {
                string text = Integrity.getMessage("NaN", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsPositiveInfinity((double) d)) 
            {
                string text = Integrity.getMessage("+Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }

            if (Double.IsNegativeInfinity((double) d))
            {
                string text = Integrity.getMessage("-Infinity", mesageArgs);
                throw new InvalidOperationException(text);
            }
        }

        public static void CheckIsValidNumberOrNull(double? d, params object[] mesageArgs)
        {
            if(d == null)
            {
                return;
            }
            CheckIsValidNumber(d, mesageArgs);
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
                    if (s.Length == 0)
                    {
                        s += item.ToString();
                    }
                    else
                    {
                        s += ", " + item.ToString();
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
