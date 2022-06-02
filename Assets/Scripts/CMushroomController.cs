using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMushroomController : MonoBehaviour
{
    // Start is called before the first frame update

    public  Rigidbody2D rigidBody; 
    private float velocity = 2.0f; 
    private bool isMoving = true;
    private int direction; //need for collide pipe and change direction

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {     
    }
    void FixedUpdate(){
        if (isMoving){
            rigidBody.velocity = new Vector2(velocity * direction, rigidBody.velocity.y);
        }
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void  OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") ){
            isMoving = false;
        }
    }
    
}
