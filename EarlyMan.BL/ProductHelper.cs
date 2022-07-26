﻿using EarlyMan.DL.Entities;

namespace EarlyMan.BL
{
    public static class ProductHelper
    {
        public static bool ValidPurchaseQuantity(this Product product, int purchaseQuantity)
            
        {
            return product.AvailableUnits > 0 &&
                product.AvailableUnits >= purchaseQuantity && product.IsAvailable;
        }
    }
}
