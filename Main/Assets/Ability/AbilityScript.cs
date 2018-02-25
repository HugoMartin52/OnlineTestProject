using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityScript : ScriptableObject {

    public string aName;
    public float cooldown;
    public bool smartCast;

    public abstract void TriggerAbility();

}
