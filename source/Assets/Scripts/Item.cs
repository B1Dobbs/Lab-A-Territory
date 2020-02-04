using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isBroken;
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

    public ParticleSystem breakEffect;
    public ParticleSystem fixEffect;

    // Start is called before the first frame update
    void Start()
    {
        setMeshes();
        if(isBroken){
            currItem = Instantiate(currBroken, transform.position, Quaternion.identity);
        } else {
            currItem = Instantiate(currFixed, transform.position, Quaternion.identity);
        }
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
            timer =  1.0f;
        }
        
    }

    public void breakItem(){
        //Insert item animation
        isBroken = true;
        Destroy(currItem);
        currItem = Instantiate(currBroken, transform.position, Quaternion.identity);
        audioManager.playBreaking();
        breakEffect.Play();
    }

    public void fixItem(){
        //Insert item animation
        isBroken = false;
        Destroy(currItem);
        currItem = Instantiate(currFixed, transform.position, Quaternion.identity);
        audioManager.playFixing();
        fixEffect.Play();
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
        }
    }
 
     void OnTriggerExit(Collider col) {
        
         if(col.gameObject.tag == "Player"){
            Player player = col.gameObject.GetComponent<Player>();
            // Remove the GameObject collided with from the list.
            currentCollisions.Remove (player);

            if(currentCollisions.Count == 0){
                actingPlayer = null;
            } else {
                actingPlayer = currentCollisions[0];
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


     public void destroy(){
         Destroy(currItem);
     }

}
