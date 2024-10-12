using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    private void FixedUpdate() {
        CoreStats.dollars += CoreStats.dollarsPerSecond * Time.fixedDeltaTime;
    }
}
