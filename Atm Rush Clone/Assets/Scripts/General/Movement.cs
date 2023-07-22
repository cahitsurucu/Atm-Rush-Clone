using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private float speedHorizontal;
    public float max, min;
    float horizontal;
    private bool canMove = true;


    public void setMove(bool value)
    {
        anim.SetBool("canMove", false);
        canMove = value;
    }

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        anim.SetBool("canMove",true);
    }

    private void Update()
    {
        if(canMove)
        {
            horizontal = Input.GetAxis("Horizontal");
            float xPos = transform.position.x + horizontal * speedHorizontal * Time.deltaTime;
            xPos = Mathf.Clamp(xPos, min, max);
            transform.position = new Vector3(xPos, 0, transform.position.z + speed * Time.deltaTime);
        }
    }
}
