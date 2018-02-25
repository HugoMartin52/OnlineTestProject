using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript2 : MonoBehaviour {

    // Test damage modifier

    Stats stats;

    public GameObject Target;
    [HideInInspector]
    public Stats targetStats;
    bool isTarget;

    public int damage;

    void Start()
    {

        Debug.Log("TESTSCRIPT2 - Test interraction with damage modifier");
        stats = GetComponent<Stats>();


        SetTargetStats();
        // Everytime you change target, you must use set target Stats
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            stats.EnhanceDamage(damage, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && isTarget)
        {
            targetStats.RemoveHealth(stats.physicalDamage);
        }
    }



    void SetTargetStats()
    {
        if (Target != null)
        {
            if (Target.GetComponent<Stats>() != null)
            {
                targetStats = Target.GetComponent<Stats>();
            }
            else { Debug.Log("TESTSCRIPT2 - No Stats detected!"); }

            isTarget = true;
        }
        else
        {
            Debug.Log("TESTSCRIPT2 - No target detected!");
            isTarget = false;
        }
    }

}
