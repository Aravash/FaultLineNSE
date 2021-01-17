using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject barrierField;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.gameObject.name);
        if (other.CompareTag("Floor"))
        {
            Destroy(GetComponent<Rigidbody>());
            barrierField.SetActive(true);
        }
    }
}
