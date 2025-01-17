using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{
    Dictionary<Upgrades, UpgradeStatus> upgrades;
    public List<int> initItemCounts;
    public List<double> initItemPrices;
    public List<double> initItemEffectiveness;
    //const float GAME_DURATION = 180.0f;
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
        //StartCoroutine(EndGameAfterTime());
    }

    
    /* IEnumerator EndGameAfterTime() {
        yield return new WaitForSeconds(GAME_DURATION);
        SceneManager.LoadScene("Leaderboard");
    } */
}
