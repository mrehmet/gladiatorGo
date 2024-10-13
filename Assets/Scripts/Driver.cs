using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    Dictionary<Upgrades, UpgradeStatus> upgrades;
    public List<int> initItemCounts;
    public List<double> initItemPrices;
    public List<double> initItemEffectiveness;
    private void FixedUpdate() {
        CoreStats.dollars += CoreStats.dollarsPerSecond * Time.fixedDeltaTime;
    }

    private void Awake() {
        CoreStats.itemCounts = initItemCounts;
        CoreStats.itemPrices = initItemPrices;
        CoreStats.itemEffectiveness = initItemEffectiveness;
        CoreStats.dollarsPerSecond = initItemEffectiveness[0];
        CoreStats.dollars = 0;
        CoreStats.upgrades = upgrades;
        Debug.Log(initItemCounts[0]);
        Debug.Log(CoreStats.itemCounts[0]);
    }}
