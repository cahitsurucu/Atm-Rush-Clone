using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    float min = 1.14f, max = 2.9f;

    float speed = 1f;
    float waiter = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (waiter >= 0.5f)
        {
            if (transform.position.x > max || transform.position.x < min)
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
