using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        target.SetActive(true);
    }
}