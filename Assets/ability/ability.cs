using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability
{
    protected float cooldown_time; //time between uses of the ability
    protected float current_cooldown_time;
    protected float active_time; //time the ability is active for when used
    protected float remaining_active_time;
    protected bool is_active; //whether the ability is currently active or not

    public virtual void activate()
    {
        Debug.Log("this is the virtual ability usage function, it should be overwritten" +
                  " in child classes");
    }

    public float getCooldownTime()
    {
        return cooldown_time;
    }
    
    public void setCooldownTime(float change)
    {
        cooldown_time =  change;
    }
    
    public float getCurrentCooldownTime()
    {
        return current_cooldown_time;
    }
    
    public void setCurrentCooldownTime(float change)
    {
        current_cooldown_time =  change;
    }
    
    public float getActiveTime()
    {
        return active_time;
    }
    
    public void setActiveTime(float change)
    {
        active_time =  change;
    }
    
    public float getRemainingActiveTime()
    {
        return remaining_active_time;
    }
    
    public void setRemainingActiveTime(float change)
    {
        remaining_active_time =  change;
    }
    
    public bool isActive()
    {
        return is_active;
    }
    
    public void setActive(bool change)
    {
        is_active =  change;
    }
    
    
}
