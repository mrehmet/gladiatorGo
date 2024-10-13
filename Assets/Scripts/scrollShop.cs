using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollShop : MonoBehaviour
{
    private float scale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        Vector3 pos = transform.position;
        pos.y += Input.mouseScrollDelta.y * scale;
        if (pos.y > 0.95 && pos.y < 10.93) {
            transform.position = pos;
        } else if (pos.y <= 0.95) {
            pos.y = 0.95f;
            transform.position = pos;
        } else {
            pos.y = 10.93f;
            transform.position = pos;
        }
    }
}
