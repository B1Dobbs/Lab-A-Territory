using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class beginTimer : MonoBehaviour
{
    public TextMeshPro textMesh;
    public float time = 4;
    int ConvertedTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        time -= Time.deltaTime;
        if(ConvertedTime == 1) {
            Destroy(gameObject);
        }
        ConvertedTime = (int)time;
        textMesh.text = ConvertedTime.ToString();
        */
    }
    void FixedUpdate() {
        time -= 1f;
        if(ConvertedTime <= 1) {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
        ConvertedTime = (int)time;
        textMesh.text = ConvertedTime.ToString();
    }
}
