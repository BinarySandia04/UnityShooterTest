﻿using UnityEngine;
using UnityEngine.Networking;

public class PlayerPropieties : NetworkBehaviour {

    public const float maxHealth = 100;
    public const float maxShield = 100; // ?

    [SyncVar]
    public float health = maxHealth;
    [SyncVar]
    public float shield = maxShield;

    public float totalAmmo = 200;

    public int weaponNumber = 0;

    public int GetNewMagazineOf(int bullets, int currentMagazine)
    {
        int i, a;
        a = currentMagazine;
        for(i = a; i < bullets; i++)
        {
            if (totalAmmo != 0)
            {
                a++;
                totalAmmo--;
            }
        }
           
        
        return a;
    }

}
