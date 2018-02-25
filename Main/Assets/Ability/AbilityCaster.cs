using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCaster : MonoBehaviour {

    public AbilityScript abilityQ;

    float cdLeft;

    void Start () {

        // Set initial Timers
        cdLeft = 0.0f;

    }
	
	void Update () {

        // Timers
        cdLeft -= Time.deltaTime;

        // Check input keys et timer
        if (Input.GetKeyDown(KeyCode.Q) && cdLeft <= 0)
        {
            abilityQ.TriggerAbility();
            cdLeft = abilityQ.cooldown;
        }
    }
}
