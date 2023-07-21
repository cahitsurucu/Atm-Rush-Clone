using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RankCubeMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalPlayer"))
        {
            transform.DOMoveZ(transform.position.z - 3f, 2f);
        }
    }
}
