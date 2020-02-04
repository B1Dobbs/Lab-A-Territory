using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        EndScreen = GameObject.FindGameObjectWithTag("EndScreen");
        //EndScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
