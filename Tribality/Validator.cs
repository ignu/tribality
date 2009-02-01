using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Collections.Generic;

namespace Tribality
{
    public class Validator
    {
        private List<string> _Errors = new List<string>();
        public List<string> Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }

        public Validator ShouldBeSame(object first, object second, string errorMessage)
        {
            if (!first.Equals(second))
                _Errors.Add(errorMessage);

            return this;
        }

        public Validator Required(string parameter, string errorMessage)
        {
            if (string.IsNullOrEmpty(parameter))
                _Errors.Add(errorMessage);

            return this;
        }
    }
}
