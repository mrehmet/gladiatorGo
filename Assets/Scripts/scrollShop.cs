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
        transform.position = pos;
    }
}
