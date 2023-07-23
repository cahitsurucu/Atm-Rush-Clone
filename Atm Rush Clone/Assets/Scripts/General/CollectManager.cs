using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectManager : MonoBehaviour
{
    public GameManager manager;
    public FinalAtmManager finalManager;
    public MiniGameManager miniManager;

    float dolar = 100f, gold = 400f, diamond = 800f;
    public float forceMagnitude = 0.05f;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        finalManager = GameObject.Find("FinalAtm").GetComponent<FinalAtmManager>();
        miniManager = GameObject.Find("MiniGameManager").GetComponent<MiniGameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.transform.position = transform.position + Vector3.forward;
            other.gameObject.AddComponent<CollectManager>();
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NodeMovement>();
            GameObject obj = manager.getLastObject();
            if(obj != null)
            {
                other.gameObject.GetComponent<NodeMovement>().connectedNode = obj.transform;
            }
            else
            {
                other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
            }
            manager.setLastObject(other.gameObject);
            other.gameObject.tag = "Collected";
            if(other.gameObject.name.Contains("Money"))
            {
                manager.increaseMoney(dolar);
            }
            else if(other.gameObject.name.Contains("Gold"))
            {
                manager.increaseMoney(gold);
            }
            else
            {
                manager.increaseMoney(diamond);
            }
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            if(!this.gameObject.CompareTag("Player"))
            {
                if(manager.getCanDestroy())
                {
                    manager.setCanDestroy(false);
                    changeTag(this.gameObject); // ERRORRRRRRR
                    manager.setCanDestroy(true);
                } 
            }
            else
            {
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    removeStack();
                    Vector3 forceDirection = transform.position - other.transform.position;
                    rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                }
            }
        }
        else if(other.gameObject.CompareTag("FinishBand"))
        {
            if(this.gameObject.CompareTag("Collected"))
            {
                this.gameObject.transform.position = new Vector3(transform.position.x, .1f, transform.position.z);
                this.gameObject.GetComponent<NodeMovement>().setMove(false);
                finalManager.destroyMoney(this.gameObject);
            }
            else
            {
                this.gameObject.GetComponent<Movement>().setMove(false);
                miniManager.gameFinished();
            }
        }
    }

    private void changeTag(GameObject destroy) // HATA
    {
        GameObject obj = manager.getLastObject();
        if(obj == destroy)
        {
            manager.setLastObject(obj.GetComponent<NodeMovement>().connectedNode.gameObject);
            decreaseMoney(obj.name);
            Destroy(destroy);
        }
        else
        {
            if(destroy != null & destroy.GetComponent<NodeMovement>().connectedNode != null)
                manager.setLastObject(destroy.GetComponent<NodeMovement>().connectedNode.gameObject);
            decreaseMoney(destroy.name);
            Destroy(destroy);
            while (obj != null & obj.GetComponent<NodeMovement>() != null & obj != destroy)
            {
                if(obj.GetComponent<NodeMovement>().connectedNode != null)
                {
                    GameObject temp = obj.GetComponent<NodeMovement>().connectedNode.gameObject;
                    obj.GetComponent<CollectManager>().decreaseMoney(obj.name);
                    obj.GetComponent<NodeMovement>().Throw(obj.transform.position, Random.Range(-0.5f, 0.5f));
                    obj = temp;
                }
                else
                {
                    break;
                }

            }
        }

    }

    public void decreaseMoney(string name)
    {
        if(name.Contains("Money"))
        {
            manager.decreaseMoney(dolar);
        }
        else if(name.Contains("Gold"))
        {
            manager.decreaseMoney(gold+dolar);

        }
        else
        {
            manager.decreaseMoney(diamond+gold+dolar);
        }
    }

    private void removeStack()
    {
        GameObject obj = manager.getLastObject();
        manager.setLastObject(this.gameObject);

        if(obj != null && !obj.CompareTag("Player"))
        {
            while(!obj.CompareTag("Player"))
            {
                GameObject temp = obj.GetComponent<NodeMovement>().connectedNode.gameObject;
                obj.GetComponent<CollectManager>().decreaseMoney(obj.name);
                obj.GetComponent<NodeMovement>().Throw(obj.transform.position, Random.Range(-0.5f, 0.5f));
                obj = temp;
            }
        }
    }
}
