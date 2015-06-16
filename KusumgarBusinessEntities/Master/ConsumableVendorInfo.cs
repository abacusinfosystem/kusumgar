﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class ConsumableVendorInfo
    {
        public ConsumableVendorInfo()
        {
            Consumable_Vendor_Entity = new M_Consumable_Vendors();

            Vendor_Entity = new VendorInfo();

        }

    public M_Consumable_Vendors Consumable_Vendor_Entity { get; set; }

    public VendorInfo Vendor_Entity { get; set; }


    }
}
