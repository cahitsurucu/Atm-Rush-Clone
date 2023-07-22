using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameManager : MonoBehaviour
{

    public GameObject MiniGameBlocks;
    public GameObject FinalPlayerSitting;
    public GameObject Player;
    public Button nexLevel;

    public void gameFinished()
    {
        Invoke("startMiniGame", 1.5f);
    }

    private void startMiniGame()
    {
        Player.SetActive(false);
        MiniGameBlocks.SetActive(true);
        FinalPlayerSitting.SetActive(true);
    }

    public void finishCanvas()
    {
        nexLevel.gameObject.SetActive(true);
    }
}
