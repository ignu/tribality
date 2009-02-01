using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Services;
using Tribality.Models;
using Tribality.Controllers;
using Tribality.Repository;

namespace Tribality.Tests
{
    public class AbandonTransactionOnce : BaseTest
    {
        private RollbackTransaction _Transaction;
        
        public override void establish_context()
        {
            _Transaction = new RollbackTransaction();
            base.because();
        }

        public override void after_last()
        {
            _Transaction.Dispose();
            base.after_last();
        }        
    }
}
