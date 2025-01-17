using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalLeaderboard : MonoBehaviour
{
    List<TextMeshPro> entries = new List<TextMeshPro>();
    public static LocalLeaderboard instance;
    [SerializeField] GameObject entryPrefab;
    static float nextY = 0;
    const float yOffset = -1f;

    private void Awake() {
        instance = this;
    }

    public static void AddEntry(string name, double money) {
        GameObject newEntry = Instantiate(instance.entryPrefab, instance.transform);
        newEntry.transform.position += new Vector3(0, nextY, 0);
        nextY += yOffset;
        newEntry.GetComponent<TextMeshPro>().text = name + ": " + money;
    }
}
