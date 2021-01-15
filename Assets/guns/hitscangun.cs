using UnityEngine;

namespace guns
{
    public class hitscangun : gun
    {
        protected int damage;
        
        public override void shoot(Camera cam)
        {
            current_ammo--;
            Transform camtrans = cam.transform;
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(camtrans.position, camtrans.forward, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(camtrans.position, camtrans.forward * hit.distance, Color.blue, 5f);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(camtrans.position, camtrans.forward * hit.distance, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        public override void reload()
        {
            current_ammo = clip_size;
        }
    }
}
