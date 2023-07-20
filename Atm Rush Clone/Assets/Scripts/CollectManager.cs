using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectManager : MonoBehaviour
{
    public GameManager manager;

    float dolar = 100f, gold = 1000f, diamond = 3000f;
    public float forceMagnitude = 0.05f;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
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
                changeTag(this.gameObject); // ERRORRRRRRR
            }
            else
            {
                Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 forceDirection = transform.position - other.transform.position;
                    rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                }
            }
        }
    }

    private void changeTag(GameObject destroy)
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
            manager.setLastObject(destroy.GetComponent<NodeMovement>().connectedNode.gameObject);
            while(obj != destroy)
            {
                if(obj.GetComponent<NodeMovement>().connectedNode.gameObject != null)
                {
                    GameObject temp = obj.GetComponent<NodeMovement>().connectedNode.gameObject;
                    obj.GetComponent<CollectManager>().decreaseMoney(obj.name);
                    obj.GetComponent<NodeMovement>().Throw(obj.transform.position, Random.Range(-0.5f, 0.5f));
                    obj = temp;
                }
            }
            decreaseMoney(this.gameObject.name);
            Destroy(this.gameObject);
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
}
