using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMana;    
    public int maxMana = 30;
    public int[] manaLvlBonus;
    public int strength;
    public int defense;
    public int weaponDPS;
    public int armorRating;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;

    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.09f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddEXP(500);
        }
    }

    public void AddEXP(int expToAdd)
    {
        currentEXP += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentEXP > expToNextLevel[playerLevel] && playerLevel < maxLevel)
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                // Determine whether to add strength or defense based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMana = maxMana + manaLvlBonus[playerLevel];
                currentMana = maxMana;
            }
        }        

        if (playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }
}
