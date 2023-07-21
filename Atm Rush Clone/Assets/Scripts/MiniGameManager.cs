using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{

    public GameObject MiniGameBlocks;
    public GameObject FinalPlayerSitting;
    public GameObject Player;

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
}
