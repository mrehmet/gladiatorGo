using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Banner : MonoBehaviour
{
    static TextMeshPro banner;
    // Start is called before the first frame update
    void Start()
    {
        banner = GetComponent<TextMeshPro>();
    }

    public static void UpdateBanner(string content) {
        banner.text = content;
    }
}
