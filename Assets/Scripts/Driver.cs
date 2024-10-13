using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] Dictionary<Upgrades, UpgradeStatus> upgrades;
    private void FixedUpdate() {
        CoreStats.dollars += CoreStats.dollarsPerSecond * Time.fixedDeltaTime;
    }

    private void Start() {
        CoreStats.CoreInit();
        CoreStats.upgrades = upgrades;
    }
}
