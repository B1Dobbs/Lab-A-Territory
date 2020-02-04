using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    public float transitionSpeed = .3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(transitionSpeed, transitionSpeed, transitionSpeed);
    }
}
