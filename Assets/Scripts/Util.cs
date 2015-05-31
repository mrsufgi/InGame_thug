using UnityEngine;
using System.Collections;
using Soomla.Store;
using Soomla.Levelup;

public static class Util  {

    public static double GetVirtualItemPriceByID(string i_ItemID) {
        VirtualItem item = StoreInfo.GetItemByItemId(i_ItemID);
        double amount = -1;
        //    PurchasableVirtualItem item = StoreInfo.GetPurchasableItemWithProductId(pg.AssociatedItemId);
        if (item is PurchasableVirtualItem)
        {
            PurchasableVirtualItem purchasableItem = (PurchasableVirtualItem)item;
            PurchaseWithVirtualItem pt = (PurchaseWithVirtualItem)purchasableItem.PurchaseType;

            if (pt is PurchaseWithVirtualItem)
            {
                PurchaseWithVirtualItem pvi = (PurchaseWithVirtualItem)pt;
                amount = (double)pvi.Amount;
            }
        }
        return amount;
    }

    public static PurchasableGate GetPurchasableGateInORList(GatesListOR i_ORList)
    {
        PurchasableGate returnGate = null;
        GatesListOR m = i_ORList as GatesListOR;
        //Gate g = m.GateList[0];
        foreach(Gate g in m.GateList)
        {
            if (g is PurchasableGate)
            {
                returnGate = g as PurchasableGate;
            }
        }

        return returnGate;
    }

    public static void CloseLockedPanel()
    {
        GameObject o = GameObject.FindGameObjectWithTag("LockedLevelPanel");
        o.SetActive(false);
    }

    public static void ClosePlayGamePanel()
    {
        GameObject o = GameObject.FindGameObjectWithTag("PlayGamePanel");
        o.SetActive(false);
    }
}
