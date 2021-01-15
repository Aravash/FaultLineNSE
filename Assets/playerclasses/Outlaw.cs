using System;
using System.Collections;
using System.Collections.Generic;
using guns;
using UnityEngine;

public class Outlaw : PlayerClass
{
    private gun _railgun = new Railgun();
    private ability _flashbang = new Flashbang();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponent<playercontrol>().cam;
    }

    private void Update()
    {
        doGun();

        doAbility();
    }

    private void doGun()
    {
        if (_railgun.is_shooting_disabled()) return;
        
        if (Input.GetButton("Fire1"))
        {
            if (_railgun.get_current_ammo() > 0)
            {
                Debug.Log("shooting");
                _railgun.shoot(cam);
                StartCoroutine(cooldown(_railgun.get_shot_cooldown_time()));
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
        //is the ability off cooldown
        if (_flashbang.getCurrentCooldownTime() > 0)
        {
            _flashbang.setCurrentCooldownTime(_flashbang.getCooldownTime() - Time.deltaTime);
            return;
        }
        //are you currently using the ability
        if (_flashbang.isActive())
        {
            if (_flashbang.getRemainingActiveTime() > 0)
            {
                _flashbang.setRemainingActiveTime(_flashbang.getRemainingActiveTime() - Time.deltaTime);
            }
            else
            {
                _flashbang.setActive(false);
                _flashbang.setCurrentCooldownTime(_flashbang.getCooldownTime());
            }

            return;
        }
        //did you press the ability button
        if (Input.GetButtonDown("Ability"))
        {
            //throw the flashbang
            _flashbang.setActive(true);
            _flashbang.setRemainingActiveTime(_flashbang.getActiveTime());
        }
    }

    private void reloadGun()
    {
        Debug.Log("reloading");
        StartCoroutine(cooldown(_railgun.get_reload_time()));
        _railgun.reload();
    }
    
    /*
    * purpose: provide a delay between actions
    */
    protected IEnumerator cooldown(float time)
    {
        _railgun.set_shooting_disabled(true);
        yield return new WaitForSeconds(time);
        _railgun.set_shooting_disabled(false);
    }
}
