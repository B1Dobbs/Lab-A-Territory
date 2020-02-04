using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isBroken;
    int health;
    int minHealth = 0;
    int maxHealth = 40;
    public GameObject healthBar;
    RoomManager myRoom;
    GameObject currFixed;
    GameObject currBroken;
    public GameObject flaskBroken;
    public GameObject flaskFixed;
    public GameObject compBroken;
    public GameObject compFixed;
    public GameObject microBroken;
    public GameObject microFixed;
    
    GameObject currItem;

    private Player actingPlayer = null;

     List <Player> currentCollisions = new List <Player> ();

    float timer = 5.0f;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        setMeshes();
        if(isBroken){
            health = minHealth;
            currItem = Instantiate(currBroken, transform.position, Quaternion.identity);
        } else {
            health = maxHealth;
            currItem = Instantiate(currFixed, transform.position, Quaternion.identity);
        }
        
        //healthBar = gameObject.transform.GetChild(0).gameObject;
        healthBar.SetActive(false);
        //currItem = Instantiate(currBroken, transform.position, Quaternion.identity);

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Will reduce or add Health if the player is currently not breaking an object

        if(timer <= 0){
            if(actingPlayer != null){
                 actingPlayer.takeAction(this);
            } 
            // else {
            //     if(isBroken){
            //         reduceHealth(5);
            //     } else {
            //         addHealth(5);
            //     }
            // }
            timer =  1.0f;
        }
        
    }

    public void breakItem(){
        //Insert item animation
        isBroken = true;
  //      GetComponent<Renderer>().material.color = Color.blue;
        //myRoom.checkList(actingPlayer);
        Destroy(currItem);
        currItem = Instantiate(currBroken, transform.position, Quaternion.identity);
        audioManager.playBreaking();
    }

    public void fixItem(){
        //Insert item animation
        isBroken = false;
//        GetComponent<Renderer>().material.color = Color.gray;
        //myRoom.checkList(actingPlayer);

        Destroy(currItem);
        currItem = Instantiate(currFixed, transform.position, Quaternion.identity);
        audioManager.playFixing();
    }

    public void addHealth(int diff){
        //healthBar.SetActive(true);

        if(health >= maxHealth){
            if(isBroken){
                fixItem();
            }
            health = maxHealth;
            healthBar.SetActive(false);
        } else {
            health += diff;
            Debug.Log(health);
            healthBar.transform.localScale = new Vector3((float) health / (float) maxHealth, 1, 1);
            //healthBar.SetActive(true);
        }
    }

    public void reduceHealth(int diff){

        if(health <= minHealth){
            if(!isBroken){
                breakItem();
            }
            health = minHealth;
            healthBar.SetActive(false);
        } else {
            health -= diff;
            Debug.Log(health);
            healthBar.transform.localScale = new Vector3((float) health / (float) maxHealth, 1, 1);
            //healthBar.SetActive(true);
        }
    }

    public Player getActingPlayer(){
        return actingPlayer;
    }

    public void setActingPlayer(Player player){
        if(actingPlayer == null){
            actingPlayer = player;
        }
    }

    void OnTriggerEnter (Collider col) {

        if(col.gameObject.tag == "Player"){
            Player player = col.gameObject.GetComponent<Player>();
            // Add the GameObject collided with to the list.
            currentCollisions.Add(player);

            if(actingPlayer == null){
                setActingPlayer(player);
            }

            //healthBar.SetActive(true);
    
            // Print the entire list to the console.
            foreach (Player gObject in currentCollisions) {
                print (gObject.isFixer);
            }
        }
    }
 
     void OnTriggerExit(Collider col) {
        
         if(col.gameObject.tag == "Player"){
            Player player = col.gameObject.GetComponent<Player>();
            // Remove the GameObject collided with from the list.
            currentCollisions.Remove (player);

            if(currentCollisions.Count == 0){
                actingPlayer = null;
                healthBar.SetActive(false);
            } else {
                actingPlayer = currentCollisions[0];
            }
    
            // Print the entire list to the console.
            foreach (Player gObject in currentCollisions) {
                print (gObject.isFixer);
            }
         }
     } 

     void setMeshes(){
         int meshNum = Random.Range(0, 3);

         if(meshNum == 0){
            currFixed = flaskFixed;
            currBroken = flaskBroken;
         } else if (meshNum == 1){
             currBroken = microBroken;
             currFixed = microFixed;
         } else {
            currBroken = compBroken;
            currFixed = compFixed;
         }
     }

     public void setIsBroken(bool isBroken){
        this.isBroken = isBroken;

        if(isBroken){
            Debug.Log("broken : status");
            currItem = Instantiate(currBroken, transform.position, Quaternion.identity);
        } else {
            Debug.Log("fixed : status");
            currItem = Instantiate(currFixed, transform.position, Quaternion.identity);
        }
     }

     public bool isBetweenStates(){
         if(health != maxHealth || health != minHealth){
             return false;
         }

         return true;
     }

     public void destroy(){
         Destroy(currItem);
     }

}
