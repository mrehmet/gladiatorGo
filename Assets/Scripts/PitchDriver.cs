using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PitchDriver : MonoBehaviour
{
    [SerializeField] List<string> eventDescriptions;
    [SerializeField] List<string> eventOptions;
    [SerializeField] List<GameObject> stuffToDisable;
    public static PitchDriver instance;

    public int slot1Opt;
    public int slot2Opt;
    public int slot3Opt;
    public int slot4Opt;
    [SerializeField] TextMeshPro qt;
    [SerializeField] TextMeshPro a1;
    [SerializeField] TextMeshPro a2;
    [SerializeField] TextMeshPro a3;
    [SerializeField] TextMeshPro a4;
    private void Awake() {
        instance = this;
    }

    int currPitchInd = 0;
    const int PICTCH_LENGTH = 4;

    public void StartPitch() {
        currPitchInd = 1;
        StartOption();
        foreach (GameObject g in stuffToDisable) {
            g.SetActive(false);
        }
        Banner.UpdateBanner("You are presenting a pitch deck to Venture Capital to get rich quick. The idea was revealed to you in a dream.");
    }

    public void StartOption() {
        qt.text = eventDescriptions[Random.Range(0, eventDescriptions.Count)];
        int a1C = Random.Range(0, eventOptions.Count);
        a1.text = eventOptions[a1C];
        slot1Opt = a1C;
        int a2C = Random.Range(0, eventOptions.Count);
        while (a2C == a1C) {
            a2C = Random.Range(0, eventOptions.Count);
        }
        a2.text = eventOptions[a2C];
        slot2Opt = a2C;
        int a3C = Random.Range(0, eventOptions.Count);
        while (a3C == a1C || a3C == a2C) {
            a3C = Random.Range(0, eventOptions.Count);
        }
        a3.text = eventOptions[a3C];
        slot3Opt = a3C;
        int a4C = Random.Range(0, eventOptions.Count);
        while (a4C == a1C || a4C == a2C || a4C == a3C) {
            a4C = Random.Range(0, eventOptions.Count);
        }
        a4.text = eventOptions[a4C];
        slot4Opt = a4C;
        
    }

    public void Answer(int index) {
        int selected = -1;
        switch (index) {
            case 1: selected = slot1Opt; break;
            case 2: selected = slot2Opt; break;
            case 3: selected = slot3Opt; break;
            case 4: selected = slot4Opt; break;
            default: Debug.LogError("Invalid index"); break;
        }
        string message = "";
        double amount = 0;
        switch (selected) {
            case 0: 
            message = "VC agrees with you that dot-com is the economy of the future. They gave you $";
            amount = Random.Range(5, 20) * CoreStats.dollarsPerSecond;
            message += amount.ToString().Split('.')[0] + ".";
            CoreStats.dollars += amount;
            Banner.UpdateBanner(message); 
            break;
            case 1: 
            message = "Turns out VC businessdude techbro doesn't know what a \"Lunix\" is. Your therapy costed you $";
            amount = Random.Range(5, 20) * CoreStats.dollarsPerSecond;
            message += amount.ToString().Split('.')[0] + ".";
            CoreStats.dollars -= amount;
            Banner.UpdateBanner(message); 
            break;
            case 2: 
            message = "VC is very happy that the CEO did not die. You later sold his kidney on the black market for $";
            amount = Random.Range(10, 30) * CoreStats.dollarsPerSecond;
            message += amount.ToString().Split('.')[0] + ".";
            CoreStats.dollars += amount;
            Banner.UpdateBanner(message); 
            break;
            case 3: 
            message = "VC found you kind of sus, so they didn't do anything.";
            Banner.UpdateBanner(message); 
            break;
            case 4: 
            message = "VC was impressed by your math skills and funded you ";
            int pencilCnt = Random.Range(100, 500);
            message += pencilCnt.ToString() + " pencils for free.";
            CoreStats.itemCounts[0] += pencilCnt;
            CoreStats.dollarsPerSecond += pencilCnt * CoreStats.itemEffectiveness[0];
            Banner.UpdateBanner(message); 
            buyItem.UpdateAll();
            break;
            case 5: 
            message = "Since you sounded believable, VC members sold all of their current-gen cards. GPU prices fell by ";
            float discount = Random.Range(0.05f, 0.50f);
            CoreStats.itemPrices[3] = CoreStats.itemPrices[3] * (1 - discount);
            discount *= 100;
            message += discount.ToString() + "%.";
            Banner.UpdateBanner(message); 
            buyItem.UpdateAll();
            break;
            case 6: 
            message = "VC was moved by your story... just kidding they didn't really care.";
            Banner.UpdateBanner(message); 
            break;
            case 7: 
            message = "There was a lawyer from a famous franchise in the room who sued you for copyright infringement. You paid $";
            amount = Random.Range(120, 360) * CoreStats.dollarsPerSecond;
            message += amount.ToString().Split('.')[0] + ".";
            CoreStats.dollars -= amount;
            Banner.UpdateBanner(message); 
            break;
            default: Debug.LogError("Invalid index"); break;
        }
        if (currPitchInd < PICTCH_LENGTH) {
            currPitchInd++;
            StartOption();
        } else {
            EndPitch();
        }
    }

    public void EndPitch() {
        bool negative = Random.Range(0, 4) == 1;
        string result;
        if (negative) {
            result = "Venture Capital hated your pitch deck. They hired people to beat you up - your hospital bill is $";
        } else {
            result = "Venture Capital loved your pitch deck. They funded you $";
        }
        double bonus = Random.Range(60, 240) * CoreStats.dollarsPerSecond * (negative ? -1 : 1); 
        result += bonus.ToString().Split('.')[0] + ".";
        CoreStats.dollars += bonus;
        foreach (GameObject g in stuffToDisable) {
            g.SetActive(true);
        }
        Banner.UpdateBanner(result);
        gameObject.SetActive(false);
    }
}
