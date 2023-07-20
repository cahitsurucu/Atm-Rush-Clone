using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxMovement : MonoBehaviour
{
    float max = 80f, min = -80f;
    public float speed = 20f;
    public float waiter = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (waiter >= 0.2f)
        {
            
            if (UnityEditor.TransformUtils.GetInspectorRotation(transform).z >= max || UnityEditor.TransformUtils.GetInspectorRotation(transform).z <= min)
            {
                speed *= -1;
                waiter = 0f;
            }
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else
        {
            waiter += Time.deltaTime;
        }
    }
}
