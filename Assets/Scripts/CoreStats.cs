using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreStats : MonoBehaviour
{
    public static double dollars;
    public static double dollarsPerSecond;
    public static List<int> itemCounts;
    public static List<int> itemPrices;
    public static List<int> itemEffectiveness;
    public static Dictionary<Upgrades, bool> upgrades;

    const double PRICE_SCALE_FACTOR = 1.1;

    public static void CoreInit() {
        itemCounts = new List<int>();
        itemPrices = new List<int>();
        itemEffectiveness = new List<int>();
        dollars = 0;
        dollarsPerSecond = 0;
    }

    public static bool BuyItem(int index) {
        if (dollars >= itemPrices[index]) {
            itemCounts[index]++;
            dollars -= itemPrices[index];
            dollarsPerSecond += itemEffectiveness[index];
            itemPrices[index] = Mathf.Min(itemPrices[index]+1, (int)(itemPrices[index] * PRICE_SCALE_FACTOR));
            return true;
        }
        return false;
    }

    public static void BuyUpgrade(Upgrades u) {
    
    }
}

public enum Upgrades {
    u1_1,
    u1_2,
    u1_3,
    u1_4,
    u2_1,
    u2_2,
    u2_3,
    u2_4,
    u3_1,
    u3_2,
    u3_3,
    u3_4,
    u4_1,
    u4_2,
    u4_3,
    u4_4,
    u5_1,
    u5_2,
    u5_3,
    u5_4,
    u6_1,
    u6_2,
    u6_3,
    u6_4,
    u7_1,
    u7_2,
    u7_3,
    u7_4,
    u8_1,
    u8_2,
    u8_3,
    u8_4,
    u9_1,
    u9_2,
    u9_3,
    u9_4,
    u10_1,
    u10_2,
    u10_3,
    u10_4
}
