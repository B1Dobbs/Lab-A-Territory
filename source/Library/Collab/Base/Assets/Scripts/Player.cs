using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isFixer = true;

    float horizontalMove = 0f;

    float verticalMove = 0f;

    public int points = 0;

    public int territoriesClaimed = 0;

    public GameObject meshObject;

    public Animator animator;

    public bool animationDone = true;

    // Start is called before the first frame update

    void Start()
    {
        if(isFixer){

        } else {
            //gameObject
        }

        //meshObject = transform.GetChild(0).gameObject;
        Debug.Log(meshObject.transform.rotation);
        //animator.Play("Action", 0, 0.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFixer){
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");

        } else {
            horizontalMove = Input.GetAxisRaw("BreakerHorizontal");
            verticalMove = Input.GetAxisRaw("BreakerVertical");
        } 
        
    }

    void FixedUpdate (){
        move();

    }

    public void takeAction(Item item){
        
        //if( !animator.GetCurrentAnimatorStateInfo(0).IsName("Action")){
            animationDone = false;
            animator.SetTrigger("Action");
        //}

        if(isFixer){
            //item.addHealth(40);
            item.fixItem();
            points++;
        } else{
            //item.reduceHealth(40);
            item.breakItem();
            points++;
        }
    }

    public void move(){
       
        Rigidbody rb = GetComponent<Rigidbody>();

        if(horizontalMove != 0){
            verticalMove = 0;
        } else if (verticalMove != 0){
            horizontalMove = 0;
        }

        Vector3 hMove = (transform.right * horizontalMove * 12.0f) * Time.fixedDeltaTime;
        Vector3 vMove = (transform.up * verticalMove * -12.0f) * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + hMove + vMove);

        //0, 180, 0 = LEFT
        //0, 0, 0 = RIGHT
        //0, 90, 0 = DOWN
        //0, -90, 0 = UP
        // Debug.Log(verticalMove);
        if(verticalMove == 1){
            Debug.Log("Rotating");
            meshObject.transform.eulerAngles = new Vector3(0, -90, 0);
        } else if (verticalMove == -1){
             meshObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }

        if(horizontalMove == 1){
             meshObject.transform.eulerAngles = new Vector3(0, 0, 0); 
        } else if (horizontalMove == -1){
             meshObject.transform.eulerAngles = new Vector3(0, 180, 0); 
        }

        if(horizontalMove == 0 && verticalMove == 0){
            rb.velocity = Vector3.zero;
        }

    }

    void setAnimationDone(){
        //Debug.Log("Setting Animation Done");
        animationDone = true;
    }

}
