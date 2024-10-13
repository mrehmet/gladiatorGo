using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicate : MonoBehaviour
{
    private double dupMoney = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CoreStats.dollars >= dupMoney) {
            dupMoney = dupMoney * 100;
            GameObject dup = Instantiate(gameObject, new Vector3(0,0,0), Quaternion.identity);
            Destroy(dup.GetComponent<duplicate>());
        }
    }
}
