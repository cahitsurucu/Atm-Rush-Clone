using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MiniGamePlayerMovement : MonoBehaviour
{
    private GameManager manager;
    private CameraFollow cameraFollow;
    private MiniGameManager miniManager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        miniManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();
        cameraFollow.changeTarget(this.transform);
        MovePlayer();
    }

    private void MovePlayer()
    {
        float score = manager.getMoney() / 3000f;
        float yPos = Mathf.Clamp(score, 0.5f, 10.2f);
        transform.DOMoveY(yPos, yPos / 4 + 0.5f).SetDelay(1.5f).SetEase(Ease.Linear).OnComplete(() => {

            miniManager.finishCanvas();
        });
    }
}
