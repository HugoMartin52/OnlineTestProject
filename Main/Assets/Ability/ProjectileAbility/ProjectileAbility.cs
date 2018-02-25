using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : AbilityScript {

    public bool isLaucherSource;
    public GameObject projectile;
    public float velocity;

    private ProjectileShootTriggerable trigger;

    public override void TriggerAbility()
    {
        trigger.GetTarget();
    }


}

/*
using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability
{

    public float projectileForce = 500f;
    public Rigidbody projectile;

    private ProjectileShootTriggerable launcher;

    public override void Initialize(GameObject obj)
    {
        launcher = obj.GetComponent<ProjectileShootTriggerable>();
        launcher.projectileForce = projectileForce;
        launcher.projectile = projectile;
    }

    public override void TriggerAbility()
    {
        launcher.Launch();
    }

}
*/
