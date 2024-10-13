using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Banner : MonoBehaviour
{
    static TextMeshPro banner;
    static Coroutine pendingCoroutine;
    static bool hasPendingCoroutine = false;
    // Start is called before the first frame update
    void Start()
    {
        banner = GetComponent<TextMeshPro>();
    }

    public static void UpdateBanner(string content) {
        if (hasPendingCoroutine) {
            banner.StopCoroutine(pendingCoroutine);
            hasPendingCoroutine = false;
        }
        banner.text = content;
        QueueBanner("Wow! Tech == Money!", 10f);
    }

    public static void QueueBanner(string content, float delay) {
        if (hasPendingCoroutine) {
            banner.StopCoroutine(pendingCoroutine);
        }
        hasPendingCoroutine = true;
        pendingCoroutine = banner.StartCoroutine(ShowBannerQueue(content, delay));
    }

    static IEnumerator ShowBannerQueue(string content, float delay) {
        //Debug.Log("Start with delay " + delay);
        yield return new WaitForSeconds(delay);
        //Debug.Log("Updating");
        banner.text = content;
        hasPendingCoroutine = false;
    }
}
