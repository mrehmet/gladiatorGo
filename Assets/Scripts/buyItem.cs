using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buyItem : MonoBehaviour
{
    public int id;
    TMP_Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = GetComponentsInChildren<TMP_Text>();
        texts[0].SetText((CoreStats.itemCounts[id]).ToString());
        texts[1].SetText((CoreStats.itemPrices[id]).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("Button Clicked " + id);
        CoreStats.BuyItem(id);
        texts[0].SetText((CoreStats.itemCounts[id]).ToString());
        texts[1].SetText((CoreStats.itemPrices[id]).ToString());
    }
}
