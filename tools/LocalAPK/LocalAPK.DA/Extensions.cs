﻿using System;

namespace LocalAPK.DA
{
	public static class Extensions
	{
		public static string Substring(this string @this, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
		{
			var fromLength = (from ?? string.Empty).Length;
			var startIndex = !string.IsNullOrEmpty(from)
				? @this.IndexOf(from, comparison) + fromLength
				: 0;

			if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

			var endIndex = !string.IsNullOrEmpty(until)
			? @this.IndexOf(until, startIndex, comparison)
			: @this.Length;

			if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

			var subString = @this.Substring(startIndex, endIndex - startIndex);
			return subString;
		}

	    public static string ToRelativeTimeString(this DateTime dt)
	    {
            var ts = new TimeSpan(DateTime.Now.Ticks - dt.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 60)
            {
                if (ts.Seconds == 0)
                {
                    return "now";
                }
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
	}
}
