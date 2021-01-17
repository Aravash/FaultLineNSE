using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    [SerializeField] private GameObject gas_cloud;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Floor")) return;

        Instantiate(gas_cloud, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided with " + other.gameObject.name);
    }
}
