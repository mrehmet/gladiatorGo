using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Answer : MonoBehaviour
{
    TextMeshPro tmp;
    [SerializeField] int id;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    private void OnMouseDown() {
        PitchDriver.instance.Answer(id);
    }
}
