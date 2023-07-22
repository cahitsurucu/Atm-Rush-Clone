using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] int followSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * followSpeed);
    }


    public void changeTarget(Transform newTarget)
    {
        target = newTarget;
        offset = new Vector3(0, 1f, -1.9f);
        followSpeed = 15;
    }
}
