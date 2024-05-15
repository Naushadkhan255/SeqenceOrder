using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Models
{
    public class CompanyDetails
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int Number { get; set; }
        public DateTime? InsDT { get; set; }
    }
}