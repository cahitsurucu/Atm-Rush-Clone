using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepositController : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    float dolar = 100f, gold = 1000f, diamond = 3000f;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Money"))
        {
            manager.increaseDepositMoney(dolar);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.name.Contains("Gold"))
        {
            manager.increaseDepositMoney(gold);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.name.Contains("Diamond"))
        {
            manager.increaseDepositMoney(diamond);
            Destroy(other.gameObject);
        }
    }

}
