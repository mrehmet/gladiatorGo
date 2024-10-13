using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPitch : MonoBehaviour
{
    private void OnMouseDown() {
        PitchDriver.instance.StartPitch();
    }
}
