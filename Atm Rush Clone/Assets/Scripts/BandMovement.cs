using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandMovement : MonoBehaviour
{
    public float speed = 2f;
    private Renderer Renderer;

    // Start is called before the first frame update
    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float offset = Time.time * speed;
        Renderer.material.SetTextureOffset("_BaseMap", new Vector2(0, -offset));
    }
}
