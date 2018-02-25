﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Custom/Stats")]
public class StatsScript: ScriptableObject {

    public int maxHealth = 200;
    public int maxOverHealth = 200;
    public int maxShield = 200;
    [Space]
    public int maxSpeed = 400;
    public int maxPhysicalDamage = 10;
    public int maxMagicalDamage = 20;

}
