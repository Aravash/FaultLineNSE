using System.Collections;
using System.Collections.Generic;
using guns;
using UnityEngine;

public class Duality : PlayerClass
{
    private projectileGun shotguns;
    private GameObject barrier;
    
    private int barriers_deployed;
    private float max_barrier_energy;
    private float remaining_barrier_energy;
    
    private GameObject[] barriers = new GameObject[2];

    private void Start()
    {
        shotguns = new projectileGun("projectiles/duality/ShotgunBlast", 8,
                                                        0.4f, 1.8f);
        barrier = Resources.Load("projectiles/duality/BarrierProjector") as GameObject;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<playercontrol>().cam;
        PlayerUI.updateUIAmmo(shotguns.get_current_ammo(), shotguns.get_clip_size());
        PlayerUI.updateUIPortrait(portrait);
        PlayerUI.updateAbilityIcon(abilityIcon);
    }

    private void Update()
    {
        doGun();

        doAbility();
    }

    private void doGun()
    {
        if (shotguns.is_shooting_disabled()) return;
        
        if (Input.GetButton("Fire1"))
        {
            if (shotguns.get_current_ammo() > 0)
            {
                Debug.Log("shooting");
                shotguns.shoot(cam);
                PlayerUI.updateUIAmmo(shotguns.get_current_ammo(), shotguns.get_clip_size());
                StartCoroutine(cooldown(shotguns.get_shot_cooldown_time()));
            }
            else reloadGun();
        }

        if (Input.GetButtonDown("Reload"))
        {
            reloadGun();
        }
    }

    private void doAbility()
    {
        //did you press the ability button
        if (Input.GetButtonDown("Ability"))
        {
            //is barrier 1 active
            if (barriers[0] == null)
            {
                deployBarrier(0);
            }
            else if (barriers[1] == null)
            {
                deployBarrier(1);
            }
        }
    }

    private void deployBarrier(int pos)
    {
        barriers[pos] = Instantiate(barrier, transform.position, Quaternion.Euler(0f, cam.transform.rotation.eulerAngles.y, 0f), null);
        barriers[pos].GetComponent<Rigidbody>().AddForce(cam.transform.forward * 15, ForceMode.VelocityChange);
    }

    private void reloadGun()
    {
        Debug.Log("reloading");
        StartCoroutine(cooldown(shotguns.get_reload_time()));
        shotguns.reload();
        PlayerUI.updateUIAmmo(shotguns.get_current_ammo(), shotguns.get_clip_size());
    }
    
    /*
    * purpose: provide a delay between actions
    */
    protected IEnumerator cooldown(float time)
    {
        shotguns.set_shooting_disabled(true);
        yield return new WaitForSeconds(time);
        shotguns.set_shooting_disabled(false);
    }
}
