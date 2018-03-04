using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHealth : MonoBehaviour {

    public Stats stats;
    public int health;
    public TextMeshProUGUI text;

    public string message;

    void Start()
    {
        stats = GetComponentInParent<Stats>();
    }

    void Update () {
        health = stats.health;
        message = "Health: " + health.ToString();
        text.text = message;
    }
}
