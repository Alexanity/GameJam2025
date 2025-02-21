using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDisableOnEntryVolume : MonoBehaviour
{
    public string tagCompare;
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagCompare) && targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagCompare) && targetObject != null) 
        {
            gameObject.SetActive(false);
        }
    }
}
