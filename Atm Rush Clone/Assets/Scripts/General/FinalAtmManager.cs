using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalAtmManager : MonoBehaviour
{
    public void destroyMoney(GameObject other)
    {
        other.transform.DOMoveX(-1.6f, 1).OnComplete(() =>
        {
            Destroy(other);
        });
    }
}
