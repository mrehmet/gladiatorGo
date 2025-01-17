using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollable : MonoBehaviour
{
    private float scale = 0.2f;

    void Update() {
        Vector3 pos = transform.position;
        pos.y -= Input.mouseScrollDelta.y * scale;
        transform.position = pos;
    }
}
