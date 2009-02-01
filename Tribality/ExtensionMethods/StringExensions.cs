using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Tribality
{
    
    public static class StringExensions
    {
        
        public static string ToUrl(this string input)
        {
            input = Regex.Replace(input,
              @"[^A-Z0-9\040] #match any non-alphanumeric non-space char (\040 is space, didn't want to use \s because I want to remove tabs and CRLFs)
						| \b a \b #\b something \b matches word (must be at the start/end of string or on a word boundary) (whitespace around \b is not significant)
						| \b the \b 
						| \b for \b 
						| \b of \b
						| \b on \b
						| \b at \b
						| \b an \b
						",
              " ", //replace with a space so words don't end up running together
              RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
            input = input.Trim().ToLower(); //Trim off any leading/trailing whitespace, convert to lower case
            input = Regex.Replace(input, @"\s+", "-", RegexOptions.None); //replace spaces (grouping multiple spaces)
            return input;
        }
    }
}
