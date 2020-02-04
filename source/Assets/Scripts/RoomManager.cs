using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    float timer = 11f;
    bool captured = false;
    public TextMeshPro textMesh;
    public GameObject lockdownGui;

    public int numberOfItems = 3;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        floors = GameObject.FindGameObjectsWithTag(tagName);
        setRandItems();
        lockdownGui.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!captured)
            capture();


        if(captured){
            lockDown();
        }
    }
    void setRandItems() {

        //Set two: one broken and one fixed
        // itemList.Add(Instantiate(itemPrefabSphere, map[0].position, Quaternion.identity));
        // itemList.Add(Instantiate(itemPrefabSphere, map[1].position, Quaternion.identity));
        // itemList[0].GetComponent<Item>().isBroken = true;
        // itemList[1].GetComponent<Item>().isBroken = false;

        //Set the rest
        //List<Transform> smallMap = map.GetRange(2, map.Count - 2);
        bool isBroken;
        int randBrokenStart = Random.Range(0, 2);
        if(randBrokenStart == 0){
            isBroken = true;
        } else {
            isBroken = false;
        }

        List<int> usedNumbers = new List<int>();
        for (int i = 0; i < numberOfItems; i++) {
            int transformNum = Random.Range(0, map.Count - 1);
            while(usedNumbers.Contains(transformNum)){
                transformNum = Random.Range(0, map.Count - 1);
            }
            usedNumbers.Add(transformNum);
            Debug.Log("RANDOM: " + transformNum);

            GameObject itemRef = Instantiate(itemPrefabSphere, map[transformNum].position, Quaternion.identity);
            itemRef.GetComponent<Item>().isBroken = isBroken;
            itemList.Add(itemRef);
            isBroken = !isBroken;
        

        }
    }

    void capture() {
        if(checkListFixed()) {
            foreach(GameObject floor in floors)
                floor.GetComponent<Renderer>().material = matRed;
            Breaker.GetComponent<Player>().territoriesClaimed += 1;
            captured = true;
            clearRoom();
        }
        else if(checkListDestroyed()) {
            foreach(GameObject floor in floors)
                floor.GetComponent<Renderer>().material = matBlue;
            Fixer.GetComponent<Player>().territoriesClaimed += 1;
            captured = true;
            clearRoom();
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

    void lockDown(){
        lockdownGui.SetActive(true);


        timer -= Time.deltaTime;
        //set timer text to timer
        int convertedTime = (int)timer;
        textMesh.text = convertedTime.ToString();
        if(timer <= 1){
            captured = false;
            lockdownGui.SetActive(false);
            timer =  11.0f;
            setRandItems();
        }

        if(timer >= 10.0f){
            audioManager.playLockdown();
        }

    }

    void clearRoom(){
        Debug.Log("CLEARING: " + itemList.Count);
        foreach (GameObject spawnedItem in itemList){
            Debug.Log("Destroying: " + spawnedItem.name);
            spawnedItem.GetComponent<Item>().destroy();
            Destroy(spawnedItem);
        }

        itemList.Clear();

    }

}
