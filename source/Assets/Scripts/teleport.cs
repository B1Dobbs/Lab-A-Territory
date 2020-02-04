using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject otherPortal;
    void OnTriggerEnter(Collider other) {
        other.transform.position = otherPortal.transform.position;
    }
}
