using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeItem : MonoBehaviour
{
    public Mesh brokenItem;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshFilter>().mesh = brokenItem;
        gameObject.transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
