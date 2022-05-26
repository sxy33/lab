using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private float originalX;
    private float maxOffset = 5.0f; //left&right, when reach, change direction
    private float enemyPatrolTime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;


    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset / enemyPatrolTime, 0); //distance/time
    }
    void MoveGomba(){
        enemyBody.MovePosition(enemyBody.position + velocity *Time.fixedDeltaTime); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs (enemyBody.position.x - originalX) < maxOffset){ //move in direction if not reach maxoffset
        MoveGomba();
        } 
        else{
        moveRight *= -1; //change direction
        ComputeVelocity(); //need to call cause velocity contain direction
        MoveGomba();
        }  
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")){
            Debug.Log("Collided with Gomba!");
        }
    }
}
