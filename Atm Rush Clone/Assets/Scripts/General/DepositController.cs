using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepositController : MonoBehaviour
{
    [SerializeField] private GameManager manager;
    float dolar = 100f, gold = 400f, diamond = 800f;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(manager.getCanDestroy() && !other.gameObject.CompareTag("Player"))
        {
            manager.setCanDestroy(false);
            changeLastObject(other.gameObject);
            if (other.gameObject.name.Contains("Money"))
            {
                manager.increaseDepositMoney(dolar);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Gold"))
            {
                manager.increaseDepositMoney(gold);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Diamond"))
            {
                manager.increaseDepositMoney(diamond);
                Destroy(other.gameObject);
            }
            manager.setCanDestroy(true);
        }
    }

    private void changeLastObject(GameObject other) // HATA
    {
        GameObject obj = manager.getLastObject();
        if (obj == other)
        {
            manager.setLastObject(other.GetComponent<NodeMovement>().connectedNode.gameObject);
        }
        else
        {
            if (other != null & other.GetComponent<NodeMovement>().connectedNode != null)
                manager.setLastObject(other.GetComponent<NodeMovement>().connectedNode.gameObject);
            while (obj != null & obj.GetComponent<NodeMovement>() != null & obj != other)
            {
                if (obj.GetComponent<NodeMovement>().connectedNode.gameObject != null)
                {
                    GameObject temp = obj.GetComponent<NodeMovement>().connectedNode.gameObject;
                    obj.GetComponent<NodeMovement>().Throw(obj.transform.position, Random.Range(-0.5f, 0.5f));
                    obj = temp;
                }
            }
        }
        manager.setCanDestroy(true);
    }

}
