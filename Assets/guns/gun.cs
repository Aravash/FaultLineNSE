using System.Collections;
using UnityEngine;

namespace guns
{
    public class gun
    {
        protected int current_ammo = 0;
        protected int clip_size = 0;
        protected bool shooting_disabled = false;
        protected float shot_cooldown_time = 0f;
        protected float reload_time = 0f;

        public gun()
        {
        }
    
        public virtual void shoot(Camera cam)
        {
            Debug.Log("this is the virtual shoot function, it should be overwritten" +
                      " in child classes");
        }

        public virtual void reload()
        {
            Debug.Log("this is the virtual reload function, it should be overwritten" +
                      " in child classes");
        }

        public int get_current_ammo()
        {
            return current_ammo;
        }

        public void set_current_ammo(int change)
        {
            current_ammo = change;
        }
        
        public int get_clip_size()
        {
            return current_ammo;
        }

        public void set_clip_size(int change)
        {
            clip_size = change;
        }

        public bool is_shooting_disabled()
        {
            return shooting_disabled;
        }

        public void set_shooting_disabled(bool change)
        {
            shooting_disabled = change;
        }
        
        public float get_shot_cooldown_time()
        {
            return shot_cooldown_time;
        }

        public void set_shot_cooldown_time(float change)
        {
            shot_cooldown_time = change;
        }
        
        public float get_reload_time()
        {
            return reload_time;
        }

        public void set_reload_time(float change)
        {
            reload_time = change;
        }
    }
}
