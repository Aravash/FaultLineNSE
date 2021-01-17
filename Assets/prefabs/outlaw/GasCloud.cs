using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCloud : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 6f;

    private void Update()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        else lifetime -= Time.deltaTime;
    }
}
