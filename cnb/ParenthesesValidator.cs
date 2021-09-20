using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace cnb
{
    public class ParenthesesValidator
    {
        #region public methods
        public bool Validate(string curly)
        {
            ValidateParameter(curly);
            var isValid = false;

            do
            {
                var first2 = AreFirst2CharactersValid(curly);
                curly = first2.curly;
                isValid = first2.found;
                if (!first2.found)
                {
                    var flResutl = AreFirstAndLastValid(curly);
                    isValid = flResutl.found;
                    curly = flResutl.curly;
                    if(!flResutl.found) curly = String.Empty;
                }
            } while (!string.IsNullOrWhiteSpace(curly));

            return isValid;
            
        }
        #endregion

        #region private static methods
        private static (bool found,string curly) AreFirstAndLastValid(string curly)
        {
            var patterns = new string[] { @"^{+({}|\[\]|\(\))+\}+$", @"^\[+({}|\[\]|\(\))+\]+$", @"^\(+({}|\[\]|\(\))+\)+$" };
            var isValid = false;
            patterns.ToList().ForEach(pattern =>
            {
                if(string.IsNullOrWhiteSpace(curly)) return;
                var match = Regex.Match(curly, pattern);
                if(!match.Success) return;
                curly = curly.Remove(0, 1);
                curly = curly.Substring(0, curly.Length - 1);
                isValid = true;
            });

            return (isValid, curly);
        }

        private static (bool found,string curly) AreFirst2CharactersValid(string curly)
        {
            //  This pattern try to match the first group of characters '{}','[]' and '()'
            var pattern = "^({}|\\[\\]|\\(\\))";
            
            var matchFirstChar = Regex.Match(curly, pattern);
            if (!matchFirstChar.Success) return (false, curly);
            curly = curly.Remove(0, 2);
            
            return (true, curly);
        }

        private static void ValidateParameter(string curly)
        {
            if (string.IsNullOrWhiteSpace(curly) || curly.Length > 10000)
            {
                throw new Exception("Input parameter must not be empty or not more that 10000 characters");
            }

            var regResult = Regex.Match(curly, "^[{}\\[\\]()]+$");
            if (!regResult.Success)
                throw new Exception("Invalid input parameter");
        }
        #endregion
    }
}