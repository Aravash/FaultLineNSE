using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashbang : ability
{
    public Flashbang()
    { 
        cooldown_time = 8f; 
        active_time = 0.1f;
        is_active = false;
    }
    
    public override void activate()
    {
        
    }
}
