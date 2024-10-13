using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPitch : MonoBehaviour
{
    [SerializeField] GameObject po;
    private void OnMouseDown() {
        po.SetActive(true);
        PitchDriver.instance.StartPitch();
    }
}
