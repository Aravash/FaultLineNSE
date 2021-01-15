using UnityEngine;

namespace guns
{
   public class Railgun : hitscangun
   {
      public Railgun()
      { 
         clip_size = 6;
         current_ammo = clip_size;
         shooting_disabled = false;
         shot_cooldown_time = 0.5f;
         reload_time = 1.4f;
         damage = 70;
      }
   }
}
