using System;

namespace AdventOfCode2022
{
    internal static class Output
    {
        internal static void Out(OutType type, string identifier)
        {
            switch (type)
            {
                case OutType.Header:
                    Console.WriteLine(String.Format(ResourceStrings.StartOutput, identifier));
                    break;
                case OutType.Footer:
                    Console.WriteLine(String.Format(ResourceStrings.EndOutput, identifier));
                    break;
            }

        }
    }

    internal enum OutType
    {
        Header,
        Footer
    }

}
