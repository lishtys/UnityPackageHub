using System;
using UnityEngine;

namespace Codes.Util.FluentExt.CSharp
{
    public static class SystemFloatExtensions 
    {
        /// <summary>
        ///  This specifier is not culture-sensitive. It takes the form [-][d'.']hh':'mm':'ss['.'fffffff].
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string FormattedSeconds(this float second)
        {
           return TimeSpan.FromSeconds(second).ToString(@"mm\:ss");
        }
    }
}