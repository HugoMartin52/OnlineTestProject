using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public Stats stats;
    public float speed;

    void Start()
    {
        stats = GetComponentInParent<Stats>();
    }



    void Update()
    {
        speed = stats.speed;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * (speed);
        var z = Input.GetAxis("Vertical") * Time.deltaTime * (speed/10);
        var y = Input.GetAxis("Rotation") * Time.deltaTime * (speed/10);

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        transform.Translate(y, 0, 0);
    }

}
