using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace guns
{
    public class projectileGun : gun
    {
        private GameObject projectile;
        
        public projectileGun(string path, int clip_size, float cooldown_time, float reload_time_passed)
        {
            projectile = Resources.Load(path) as GameObject;
            clip_size = 6;
            current_ammo = clip_size;
            shooting_disabled = false;
            shot_cooldown_time = cooldown_time;
            reload_time = reload_time_passed;
        }
        
        public virtual void shoot(Transform point)
        {
            GameObject.Instantiate(projectile, point.position, Quaternion.identity, null);
        }
    }
}
