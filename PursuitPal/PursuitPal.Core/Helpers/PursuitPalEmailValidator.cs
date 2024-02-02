using System.Text.RegularExpressions;

namespace PursuitPal.Core.Helpers
{
    public static class PursuitPalEmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)[a-zA-Z0-9._%+-]+@(?!-)[a-zA-Z0-9-]+(\.[a-zA-Z]{2,}){1,2}(?<!\.)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}
