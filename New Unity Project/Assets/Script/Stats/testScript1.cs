using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript1 : MonoBehaviour {

    // Test to access a target health

    public GameObject Target;
    [HideInInspector]
    public Stats targetStats;
    bool isTarget;

    [Header("Press 1 to damage")]
    public int damageHealth = 50;
    [Header("Press 2 to heal")]
    public int healHealth = 35;
   
	void Start () {

        Debug.Log("TESTSCRIPT1 - Test interraction with target health");

        SetTargetStats();
        // Everytime you change target, you must use set target Stats
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isTarget && !targetStats.isDead)
        {
            targetStats.RemoveHealth(damageHealth);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isTarget)
        {
            targetStats.AddHealth(healHealth);
        }
    }
    
    void SetTargetStats()
    {
        if (Target != null)
        {
            if (Target.GetComponent<Stats>() != null)
            { 
            targetStats = Target.GetComponent<Stats>();
            } else { Debug.Log("TESTSCRIPT1 - No Stats detected!"); }

            isTarget = true;
        }
        else
        {
            Debug.Log("TESTSCRIPT1 - No target detected!");
            isTarget = false;
        }
    }

}
