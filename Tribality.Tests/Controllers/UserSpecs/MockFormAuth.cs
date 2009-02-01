using System;
using Tribality.Controllers;

namespace Tribality.Tests.UserSpecs
{
    public class MockFormAuth : IFormsAuthentication
    {
        public bool SignedIn { get; set; }
        public bool SignedOut { get; set; }

        void IFormsAuthentication.SignIn(string userName, bool createPersistentCookie)
        {
            SignedIn = true;
        }

        void IFormsAuthentication.SignOut()
        {
            SignedOut = true;
        }

        #region IFormsAuthentication Members

        public int Identity
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
