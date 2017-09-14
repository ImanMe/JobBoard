using System;
using System.Threading;

namespace JobBoard.Core.Extensions
{
    public static class Extension
    {
        public static string ToStringFormat(this DateTime source)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            return source.ToString("MM/dd/yyyy", currentCulture);
        }
    }
}
