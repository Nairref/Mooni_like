using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2D_Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float Xmove;
    public float Ymove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CanBePickedUp"))
        {
           Item hitObject = other.gameObject.GetComponent<Consumable>().item;
            if(hitObject!= null)
            {
                Debug.Log("Picked up " + hitObject.name);
                other.gameObject.SetActive(false);
            }
        }
    }



    private void Move()
    {
        Xmove = Input.GetAxis("Horizontal");
        Ymove = Input.GetAxis("Vertical");
        if (Xmove != 0 || Ymove != 0)
        {
            rb.velocity = new Vector2(Xmove * speed, Ymove * speed);
        }
    }

}
