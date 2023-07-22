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
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x,-12f,this.transform.rotation.z);
        offset = new Vector3(0.71f, 0.85f, -2.2f);
        followSpeed = 15;
    }
}
