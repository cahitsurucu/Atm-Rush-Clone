using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiniGamePlayerMovement : MonoBehaviour
{
    private GameManager manager;
    private CameraFollow cameraFollow;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        cameraFollow.changeTarget(this.transform);
        MovePlayer();
    }

    private void MovePlayer()
    {
        float score = manager.getMoney();
        float yPos = score / 600f; // HATAAAA -> Mini Game Collider Düzenlenecek, yPos Düzenlenecek
        yPos = Mathf.Clamp(yPos, 0.5f, 10.2f);
        transform.DOMoveY(yPos, 2f).SetDelay(1.5f).SetEase(Ease.Linear);
    }
}
