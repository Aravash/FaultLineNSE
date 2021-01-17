using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashbang : projectileAbility
{

    public Flashbang()
    {
        projectile = Resources.Load("projectiles/outlaw/GasGrenade") as GameObject;
        cooldown_time = 8f; 
        active_time = 0.3f;
        is_active = false;
    }

    public override void activate()
    {
        
    }

    public override void deployProjectile(Transform point)
    {
        GameObject proj = GameObject.Instantiate(projectile, point.position, Quaternion.identity, null);
        proj.GetComponent<Rigidbody>().AddForce(point.forward * 30, ForceMode.Acceleration);
    }
}
