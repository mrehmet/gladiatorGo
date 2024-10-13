using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarMoveAround : MonoBehaviour
{
    public Vector2 velocity;
    public float scaleTarget = 1;
    public float scaleSpeed = 1;
    Rigidbody2D rigidBody2D;
    private void Start() {
        StartCoroutine(changeScaleTarget());
        velocity = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        velocity.Normalize();
        velocity *= 5;
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3)velocity * Time.deltaTime;
        float currScale = transform.localScale.x;
        float newScale = currScale + scaleSpeed * Time.deltaTime;
        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    const float SCALE_DELAY = 5f;
    IEnumerator changeScaleTarget() {
        scaleTarget = Random.Range(0.1f, 0.5f);
        scaleSpeed = (scaleTarget - transform.localScale.x) / SCALE_DELAY;
        yield return new WaitForSeconds(SCALE_DELAY);
        StartCoroutine(changeScaleTarget());
    }
}
