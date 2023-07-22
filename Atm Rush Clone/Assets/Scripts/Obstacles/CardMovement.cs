using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    float max = 9.2f, min = -9.2f;
    public float speed = 1.5f;
    public float waiter = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(waiter >= 0.5f)
        {
            if (transform.localPosition.x > max || transform.localPosition.x < min)
            {
                speed *= -1;
                waiter = 0f;
            }
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            waiter += Time.deltaTime;
        }
    }
}
