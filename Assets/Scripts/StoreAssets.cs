using UnityEngine;
using System.Collections;
using Soomla.Store;
using System.Collections.Generic;

public class StoreAssets : IStoreAssets
{
    public int GetVersion()
    {
        return 4;
    }

    // NOTE: Even if you have no use in one of these functions, you still need to
    // implement them all and just return an empty array.

    public VirtualCurrency[] GetCurrencies()
    {
        return new VirtualCurrency[] { COIN_CURRENCY };
    }

    public VirtualGood[] GetGoods()
    {
        return new VirtualGood[] { WORLD_ONE_LOCK_LEVEL_01, WORLD_ONE_LOCK_LEVEL_02, WORLD_ONE_LOCK_LEVEL_03, WORLD_ONE_LOCK_LEVEL_04, WORLD_ONE_LOCK_LEVEL_05, WORLD_ONE_LOCK_LEVEL_06,
        WORLD_ONE_LOCK_LEVEL_07, WORLD_ONE_LOCK_LEVEL_08, WORLD_ONE_LOCK_LEVEL_09, WORLD_ONE_LOCK_LEVEL_10, WORLD_ONE_LOCK_LEVEL_11, WORLD_ONE_LOCK_LEVEL_12
        };
    }

    public VirtualCurrencyPack[] GetCurrencyPacks()
    {
        return new VirtualCurrencyPack[] { HUND_COIN_PACK };
    }

    public VirtualCategory[] GetCategories()
    {
        return new VirtualCategory[] { GENERAL_CATEGORY };
    }

    /** Virtual Currencies **/

    public static VirtualCurrency COIN_CURRENCY = new VirtualCurrency(
      "Coin",                               // Name
      "Coin currency",                      // Description
      "coin_currency_ID"                    // Item ID
    );

    /** Virtual Currency Packs **/

    public static VirtualCurrencyPack HUND_COIN_PACK = new VirtualCurrencyPack(
      "100 Coins",                          // Name
      "100 coin currency units",            // Description
      "coins_100_ID",                       // Item ID
      100,                                  // Number of currencies in the pack
      "coin_currency_ID",                   // ID of the currency associated with this pack
      new PurchaseWithMarket(               // Purchase type (with real money $)
        "coins_100_PROD_ID",                   // Product ID
        1.99                                   // Price (in real money $)
      )
    );

    /** LEVEL LOCKS **/

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_01 = new LifetimeVG(
      "LevelLock",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L1_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        1000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_02 = new LifetimeVG(
      "LevelLock02",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L2_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        2000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_03 = new LifetimeVG(
      "LevelLock03",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L3_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        3000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_04 = new LifetimeVG(
  "LevelLock04",                             // Name
  "open level gate",      // Description
  "LevelLock_W1_L4_ID",                          // Item ID
  new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
   "coin_currency_ID",                     // ID of the item used to pay with
    1000                                    // Price (amount of coins)
  )
);

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_05 = new LifetimeVG(
      "LevelLock05",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L5_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        2000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_06= new LifetimeVG(
      "LevelLock06",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L6_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        3500                                    // Price (amount of coins)
      )
    );


    public static VirtualGood WORLD_ONE_LOCK_LEVEL_07 = new LifetimeVG(
   "LevelLock",                             // Name
   "open level gate",      // Description
   "LevelLock_W1_L7_ID",                          // Item ID
   new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
    "coin_currency_ID",                     // ID of the item used to pay with
     1000                                    // Price (amount of coins)
   )
 );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_08 = new LifetimeVG(
      "LevelLock02",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L8_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        2000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_09 = new LifetimeVG(
      "LevelLock03",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L9_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        3000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_10 = new LifetimeVG(
  "LevelLock04",                             // Name
  "open level gate",      // Description
  "LevelLock_W1_L10_ID",                          // Item ID
  new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
   "coin_currency_ID",                     // ID of the item used to pay with
    1000                                    // Price (amount of coins)
  )
);

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_11 = new LifetimeVG(
      "LevelLock05",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L11_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        2000                                    // Price (amount of coins)
      )
    );

    public static VirtualGood WORLD_ONE_LOCK_LEVEL_12 = new LifetimeVG(
      "LevelLock06",                             // Name
      "open level gate",      // Description
      "LevelLock_W1_L12_ID",                          // Item ID
      new PurchaseWithVirtualItem(          // Purchase type (with virtual currency)
       "coin_currency_ID",                     // ID of the item used to pay with
        3500                                    // Price (amount of coins)
      )
    );

    // NOTE: Create non-consumable items using LifeTimeVG with PurchaseType of PurchaseWithMarket.
    public static VirtualGood NO_ADS_LTVG = new LifetimeVG(
      "No Ads",                             // Name
      "No More Ads!",                       // Description
      "no_ads_ID",                          // Item ID
      new PurchaseWithMarket(               // Purchase type (with real money $)
        "no_ads_PROD_ID",                      // Product ID
        0.99                                   // Price (in real money $)
      )
    );

    /** Virtual Categories **/

    public static VirtualCategory GENERAL_CATEGORY = new VirtualCategory(
      "General", new List<string>(new string[] { WORLD_ONE_LOCK_LEVEL_01.ID, WORLD_ONE_LOCK_LEVEL_02.ID, WORLD_ONE_LOCK_LEVEL_03.ID })
    );

    public static VirtualCategory WORLD_LOCKS = new VirtualCategory(
        "Cakes and Sweets",                         // Name
    new List<string>(new string[]               // List of item IDs
        { WORLD_ONE_LOCK_LEVEL_01.ID, WORLD_ONE_LOCK_LEVEL_02.ID, WORLD_ONE_LOCK_LEVEL_03.ID, WORLD_ONE_LOCK_LEVEL_04.ID, WORLD_ONE_LOCK_LEVEL_05.ID, WORLD_ONE_LOCK_LEVEL_06.ID,
        WORLD_ONE_LOCK_LEVEL_07.ID, WORLD_ONE_LOCK_LEVEL_08.ID, WORLD_ONE_LOCK_LEVEL_09.ID, WORLD_ONE_LOCK_LEVEL_10.ID, WORLD_ONE_LOCK_LEVEL_11.ID, WORLD_ONE_LOCK_LEVEL_12.ID})
    );

}