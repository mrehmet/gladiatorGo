using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchDriver : MonoBehaviour
{
    [SerializeField] List<string> eventDescriptions;
    [SerializeField] List<string> eventOptions;
    public static PitchDriver instance;

    public int slot1Opt;
    public int slot2Opt;
    public int slot3Opt;
    public int slot4Opt;
    private void Start() {
        instance = this;
    }

    public void TriggerEvent(int index) {
        int selected = -1;
        switch (index) {
            case 1: selected = slot1Opt; break;
            case 2: selected = slot2Opt; break;
            case 3: selected = slot3Opt; break;
            case 4: selected = slot4Opt; break;
            default: Debug.LogError("Invalid index"); break;
        }
        switch (selected) {

        }
    }
}
