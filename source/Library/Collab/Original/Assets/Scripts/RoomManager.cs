using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject itemPrefabSphere;
    public string tagName;
    GameObject[] floors;
    public List<Transform> map = new List<Transform>();
    List<GameObject> itemList = new List<GameObject>();
    GameObject item;
    public Material matRed;
    public Material matBlue;
    public Material gray;
    public GameObject Fixer;
    public GameObject Breaker;
    float rand;

    Timer timer = new Timer();

    public GameObject lockdownGui;

    // Start is called before the first frame update
    void Start()
    {
        floors = GameObject.FindGameObjectsWithTag(tagName);
        setRandItems();
    }

    // Update is called once per frame
    void Update()
    {
        capture();
    }
    void setRandItems() {
        foreach(Transform transObj in map) {
            if(Random.value > 0.7f) {
                    item = Instantiate(itemPrefabSphere, transObj.position, Quaternion.identity);
                    itemList.Add(item);
            }
        }

        foreach(GameObject itm in itemList) {
            if(Random.value > .5f) {
                Debug.Log("brokenRoom : status");
                itm.GetComponent<Item>().isBroken = true;
            }
            else {
                Debug.Log("fixedRoom : status");
                itm.GetComponent<Item>().isBroken = false;
            }
        }
            itemList[itemList.Count].GetComponent<Item>().setIsBroken(true);
            itemList[itemList.Count - 1].GetComponent<Item>().setIsBroken(false);
    }
    void capture() {
        if(checkListFixed()) {
            foreach(GameObject floor in floors){
                floor.GetComponent<Renderer>().material = matRed;
                Breaker.GetComponent<Player>().territoriesClaimed += 1;

            }
        }
        else if(checkListDestroyed()) {
            foreach(GameObject floor in floors){
                floor.GetComponent<Renderer>().material = matBlue;
                Fixer.GetComponent<Player>().territoriesClaimed += 1;
            }
        }
        else {
            foreach(GameObject floor in floors){
                floor.GetComponent<Renderer>().material = gray;
            }
        }
    }
    bool checkListDestroyed() {
        foreach(GameObject itm in itemList) {
            if(itm.GetComponent<Item>().isBroken) {
                return false;
            }
        }
        return true;
    }
    bool checkListFixed() {
        foreach(GameObject itm in itemList) {
            if(!itm.GetComponent<Item>().isBroken) {
                return false;
            }
        }
        return true;
    }
    bool checkList(List<GameObject> items) {
        foreach(GameObject item in items) {
            if(item.GetComponent<Item>().isBroken)
                return false;
        }
        return true;
    }

}
