using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 10;
    public float upSpeed;
    public Transform enemyLocation;
    public Text scoreText;
     private int score = 0;
   // public Text timerText;
   // private float timeLeft = 20;
    private bool countScoreState = false; 
//[SerializeField]
    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public bool gameState = true; 



    
    // Start is called before the first frame update
    //void awake() //set something before start 
    //{
    //}

    void Start()
    {
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>(); //return marioBody object store in private virable
        //GetCompnent: can get any component under this object
        //for flip
        marioSprite = GetComponent<SpriteRenderer>();
    }

    // collider, need state virable
     //called when cube hits floor
    private bool onGroundState = true;
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Ground")) {
            onGroundState = true;
            countScoreState = false;
            scoreText.text = "Score:" + score.ToString();
        }
    }


    void  FixedUpdate() //called everytime with physics engine 
    {
	    float moveHorizontal = Input.GetAxis("Horizontal"); //how much pressed
	    //Vector2 movement = new Vector2(moveHorizontal, 0); //new vector: movement of body
	    //marioBody.AddForce(movement * speed);
        // dynamic rigidbody

        //prevent sliding
        if (Mathf.Abs(moveHorizontal) > 0){
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < maxSpeed) 
                    marioBody.AddForce(movement * speed);
      }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d")){
            // add a "stop" motion, decelerate"
            Vector2 stopForce = new Vector2(moveHorizontal, 0);
            marioBody.AddForce(stopForce * (-1)*speed);
            marioBody.velocity = Vector2.zero;    
      }
      //make a jump
        if (Input.GetKeyDown("space") && onGroundState){
            //add a upSpeed to adjust the "feel"
            upSpeed = 14;
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            countScoreState = true; //check if Gomba is underneath
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        // flipping put here, cause not Physics Engiene 
        if (Input.GetKeyDown("a") && faceRightState){
            faceRightState = false;
            marioSprite.flipX = true;
        }
        if (Input.GetKeyDown("d") && !faceRightState){
            faceRightState = true;
            marioSprite.flipX = false;
        }
        if (!onGroundState && countScoreState){
            if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f){
                countScoreState = false;
                score++;
                Debug.Log(score);
            }
        }
        //timeLeft -= Time.deltaTime;
       // if (timeLeft<0.1f){
          //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
      
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy")){
            Debug.Log("Collided with Gomba!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } 
}

