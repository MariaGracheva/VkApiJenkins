﻿namespace Framework.Extensions
{
    public static class StringExtensions
    {
        public static string ToLowerFirstChar(this string str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            {
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];
            }

            return str;
        }
    }
}
