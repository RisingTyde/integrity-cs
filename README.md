# Integrity check

## Installation

The package is published on nuget.org here:
https://www.nuget.org/packages/integrity-check/

## Integrity API

The full set of functions is:

```JavaScript
    Integrity.Check(condition, *msg)
    Integrity.CheckNotNull(object obj, params object[] mesageArgs)
    Integrity.CheckStringNotNullOrEmpty(string s, params object[] mesageArgs)
    Integrity.CheckIsValidNumber(variousOverloadedTypes d, params object[] mesageArgs)
    Integrity.CheckIsValidNumberOrNull(variousOverloadedTypes d, params object[] mesageArgs)

    Integrity.fail((params object[] mesageArgs)
```
### Exceptions

The following exceptions are thrown:
* NullReferenceException - when the parameter being tested is null (and it is not allowed to be)
* InvalidOperationException - to indicate a check failed

## Examples

```c#
using IntegrityCheck;

namespace Example
{
    class MyClass
    {
        int someCondition = 0;

        /// <summary>
        /// Calculates something really clever
        /// </summary>
        /// <param name="f">Must not be NaN, or +- Infinity</param>
        /// <exception cref="InvalidOperationException"></exception>
        public float computeSomeNum(float f)
        {
            Integrity.CheckIsValidNumber(f);

            float retValue = 0;

            switch(someCondition)
            {
                case 1:
                    // do some complicated stuff...
                    break;
                case 2:
                    // do some complicated stuff...
                    break;
                default:
                    Integrity.Fail("Should never get here, switch value was {}", someCondition);
                    break;
            }

            Integrity.CheckIsValidNumber(retValue, "Strange, should not be possible... retValue is {}", retValue);

            return retValue;
        }
    }
}
```