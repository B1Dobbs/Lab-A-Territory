using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshPro textMesh;
    public float time = 120;
    int ConvertedTime;
    int minutes;
    int seconds;
    string timerString;
    public GameObject endScreen;
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 1) {
                Destroy(textMesh);
                endScreen.SetActive(true);
            }
        ConvertedTime = (int)time;
        if(ConvertedTime > 59) {
            minutes = ConvertedTime / 60;
            Debug.Log(minutes);
            seconds = ConvertedTime % 60;
            if(seconds < 10) {
                timerString = minutes.ToString() + ":0" + seconds.ToString(); 
            }
            else {
                timerString = minutes.ToString() + ":" + seconds.ToString();
            }
            
            textMesh.text = timerString;
        }
        else {
            seconds = ConvertedTime;
            textMesh.text = seconds.ToString();
        }   
    }
}
