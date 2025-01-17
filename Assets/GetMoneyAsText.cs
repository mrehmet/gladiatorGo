using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetMoneyAsText : MonoBehaviour
{
    TextMeshProUGUI text;
    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Start() {
        text.text = "Your final money is $" + CoreStats.dollars.ToString().Split(".")[0];
    }
}
