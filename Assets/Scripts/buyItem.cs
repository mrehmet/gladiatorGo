using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buyItem : MonoBehaviour
{
    public static List<buyItem> buyLists;

    public int id;
    TMP_Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        if (buyLists == null) {
            buyLists = new List<buyItem>();
        }
        buyLists.Add(this);
        UpdateCosts();
    }

    public static void UpdateAll() {
        foreach (buyItem b in buyLists) {
            b.UpdateCosts();
        }
    }

    public void UpdateCosts() {
        texts = GetComponentsInChildren<TMP_Text>();
        texts[0].SetText((CoreStats.itemCounts[id]).ToString());
        texts[1].SetText((CoreStats.itemPrices[id]).ToString().Split('.')[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("Button Clicked " + id);
        CoreStats.BuyItem(id);
        texts[0].SetText((CoreStats.itemCounts[id]).ToString());
        texts[1].SetText((CoreStats.itemPrices[id]).ToString().Split('.')[0]);
        string message = "";
        switch (id) {
            case 0:
            message = "You emulate a GPU by doing linear algebra on pencil and paper.";
            break;
            case 1:
            message = "You bought a elementary school calculator! It now does arithmetic for you.";
            break;
            case 2:
            message = "You bought a CPU to tap into single-core computations. You can now raytrace at more than 0.01 frames per minute.";
            break;
            case 3:
            message = "A GPU! The pinnacle of modern technology - video games, big data, crypto, AI, what can this not do?";
            break;
            case 4:
            message = "Singular GPUs can no longer satiate your demand for meaningless computation? Look no further than GPU farms.";
            break;
            case 5:
            message = "Everyone knows that LLMs can do anything, so you leveraged it to act as a GPU! How disruptive!";
            break;
            case 6:
            message = "You now have enough money to hire ex-VC analysts to calculate for you. They're really good at math!";
            break;
            case 7:
            message = "You achieved the pinnacle of parallelism by offshoring your computations to K12 schools world wide.";
            break;
            case 8:
            message = "Money makes the world go round, and that includes building a dyson sphere to harvest electricity from the sun - for running GPUs.";
            break;
            case 9:
            message = "We now know that cosmic background radiation is really just aliens doing linear algebra. You were able to tap into their results.";
            break;
        }
        Banner.UpdateBanner(message);
    }
}
