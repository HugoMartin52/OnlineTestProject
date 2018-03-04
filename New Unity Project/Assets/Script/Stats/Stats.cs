using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public StatsScript stats;
    [HideInInspector]
    public new string name;

    [Header("Health Settings")]
    public int health;
    public int overHealth;
    [HideInInspector]
    public int maxOverHealth;
    public int shield;
    public int maxShield;
    [Space]
    public bool ReviveOnDeath = false;
    public bool boolOverHeal = false;

    [Header("Damage Settings")]
    public int physicalDamage;
    public int magicalDamage;

    [Header("Other Settings")]
    public float speed;

    [HideInInspector]
    public bool isDead = false;


    void Start()
    {
        name = gameObject.name;

        if (stats != null)
            InitializeStats();
        else
        { 
            Debug.LogWarning("STATS - Not able to initialize stats", gameObject);
        }
    }




    // Complete - Revive if needed
    public void RemoveHealth(int h)
    {
        if(overHealth == 0)
        {
            health -= h;
        } else if (overHealth > 0 && h > overHealth)
        {
            health = health - (h - overHealth);
            overHealth = 0;
        } else if (overHealth > 0 && h <= overHealth)
        {
            overHealth -= h;
        }

        //Check if dead
        if(health <= 0)
        {
            // Declare death of the character
            if (!isDead)
            {
                Debug.Log("STATS - " + name + " - The character died", gameObject);
            }
            isDead = true;

            //Reset health or not
            if (ReviveOnDeath)
            {
                Revive();
            } else
            {
                health = 0;
                // Make shit happen!
            }
        }

    }
    // Complete - Excess health converted in overheal
    public void AddHealth(int h)
    {
        if (health <= stats.maxHealth - h) 
        {
            health += h;
        } else if (overHealth == 0 && health > stats.maxHealth - h)
        {
            overHealth = h - (stats.maxHealth - health);
            health = stats.maxHealth;

        } else if (health == stats.maxHealth)
        {
            overHealth += h;
        }

        if (!boolOverHeal)
        {
            overHealth = 0;
        }

        if (overHealth > maxOverHealth)
        {
            overHealth = maxOverHealth;
        }
    }

    // Complete - Use negative values to decrease stats
    public void EnhanceDamage(int physical, int magical)
    {
        physicalDamage += physical;
        magicalDamage += magical;
    }
   
    void Revive()
    {
        Debug.Log("STATS - " + name + " - The Character revived", gameObject);

        health = stats.maxHealth;

        isDead = false;
    }
    void InitializeStats()
    {
        health = stats.maxHealth;
        physicalDamage = stats.maxPhysicalDamage;
        speed = stats.maxSpeed;
        magicalDamage = stats.maxMagicalDamage;
        maxShield = stats.maxShield;
        maxOverHealth = stats.maxOverHealth;


    }


































}
