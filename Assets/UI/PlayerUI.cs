using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    
    private static PlayerUI _instance;

    public static PlayerUI Instance { get { return _instance; } }
    
    [SerializeField]
    private Text ammo;
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private Image abilityIcon;

    [SerializeField] private Image abilityBox;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public static void updateUIAmmo(int current_ammo, int max_ammo)
    {
        _instance.ammo.text = current_ammo + " / " + max_ammo;
    }
    
    public static void updateAbilityIcon(Sprite image)
    {
        _instance.abilityIcon.sprite = image;
    }
    
    public static void updateUIPortrait(Sprite image)
    { 
        _instance.portrait.sprite = image;
    }

    public static void UIShowAbilityBeingUsed(bool option)
    {
        Debug.Log("called with variable " + option);
        if (option)
        {
            _instance.abilityBox.color = Color.yellow;
        }
        else _instance.abilityBox.color = Color.black;
    }
}
