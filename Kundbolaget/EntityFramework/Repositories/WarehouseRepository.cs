using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Kundbolaget.EntityFramework.Contexts;
using Kundbolaget.Models.EntityModels;

namespace Kundbolaget.EntityFramework.Repositories
{
    public class WarehouseRepository : DataRepository<Warehouse> 
    {
        

    }
}