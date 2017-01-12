using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kundbolaget.Enums
{
    public enum InvoiceStatus
    {
        Created = 0,
        NotPaid = 100,
        Paid = 200,
        Debased = 300,
        Cancelled = 10000      
    }
}