using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Tribality.Models
{
    public class Entity<T>
    {
        public virtual T ID { get; set; }
    }
}
