using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect : MonoBehaviour {

    public Stats stats;
    public int damage;
    public bool isTrigged = false;

    public float effectCooldown = 1.0f;

    float timer;

    void Start () {

        timer = 0.0f;
    }

    private void OnTriggerStay(Collider other)
    {
        stats = other.GetComponentInParent<Stats>();
        isTrigged = true;
    }

    private void OnTriggerExit(Collider other)
    {
        stats = null;
        isTrigged = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && isTrigged)
        {
            stats.RemoveHealth(damage);
            timer = effectCooldown;
        }
    }
}
