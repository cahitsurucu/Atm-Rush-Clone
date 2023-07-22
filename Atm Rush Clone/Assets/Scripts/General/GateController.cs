using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    [SerializeField] List<Mesh> coinMesh;
    [SerializeField] List<Material> goldMat, diamondMat;

    private GameManager manager;

    float gold = 400f, diamond = 800f;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Money"))
        {
            other.gameObject.name = "Gold";
            other.gameObject.GetComponent<MeshFilter>().mesh = coinMesh[0];
            other.gameObject.GetComponent<MeshRenderer>().SetMaterials(goldMat);
            manager.increaseMoney(gold);
        }
        else if(other.gameObject.name.Contains("Gold"))
        {
            other.gameObject.name = "Diamond";
            other.gameObject.GetComponent<MeshFilter>().mesh = coinMesh[1];
            other.gameObject.GetComponent<MeshRenderer>().SetMaterials(diamondMat);
            manager.increaseMoney(diamond);
        }
    }

}
