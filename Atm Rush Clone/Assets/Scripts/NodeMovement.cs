using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NodeMovement : MonoBehaviour
{

    public Transform connectedNode;
    private List<GameObject> knife = new List<GameObject>();

    double size;

    private void Start()
    {
        if(connectedNode.tag == "Collected")
        {
            size = 0.1;
        }
        else
        {
            size = 0.5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(connectedNode != null)
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 30),
                connectedNode.position.y,
                (connectedNode.position.z + (float)size)
            );
        }
    }

    public void Throw(Vector3 position,float value)
    {
        StartCoroutine(ThrowRoutine(position,value));
    }
    private IEnumerator ThrowRoutine(Vector3 position,float value)
    {
        transform.DOMove(position + new Vector3(value,0,2), 0.75f).SetEase(Ease.OutBounce);

        yield return new WaitForSeconds(0.2501f);
        leaveStack();
    }

    public void leaveStack()
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        this.gameObject.tag = "Collect";
        Destroy(this.gameObject.GetComponent<CollectManager>());
        Destroy(this.gameObject.GetComponent<NodeMovement>());
    }
}
