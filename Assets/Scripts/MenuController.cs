using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //Awake() game not start, appear 
    void Awake() {
        Time.timeScale = 0.0f;
    }
    /* public void StartButtonClciked(){
        foreach (Transform eachChild in transform){
            if (eachChild.name != "ScoreText"){             //only score remain
                Debug.Log("Child found. Name:" + eachChild.name);
                //disable them
                eachChild.gameObject.SetActive(false);
                Time.timeScale = 1.0f; //when press, set time to 1
            }
        }
    } */
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
