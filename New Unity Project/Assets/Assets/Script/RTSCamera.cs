using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

    public float Scrollzone = 30;
    public float ScrollSpeed = 5;

    public float xMin = 0;
    public float xMax = 10;

    public float yMin = 10;
    public float yMax = 15;
   
    public float zMin = 0;
    public float zMax = 10;

    private Vector3 desiredPosition;
    

    private void Start()
    {
        desiredPosition = transform.position;
    }
   

	// Update is called once per frame
	void Update () {

        float x = 0, y = 0, z = 0;
        float speed = ScrollSpeed * Time.deltaTime;
        
		if(Input.mousePosition.x < Scrollzone){
            x -= speed;
        } else if (Input.mousePosition.x > Screen.width - Scrollzone){
            x += speed;
        }


        if (Input.mousePosition.y < Scrollzone){
            z -= speed;
        }
        else if (Input.mousePosition.y > Screen.height - Scrollzone){
            z += speed;
        }

        y += Input.GetAxis("Mouse ScrollWheel");


        Vector3 move = new Vector3(x, y, z) + desiredPosition;
        move.x = Mathf.Clamp(move.x, xMin, xMax);
        move.y = Mathf.Clamp(move.y, yMin, yMax);
        move.z = Mathf.Clamp(move.z, zMin, zMax);
        desiredPosition = move;
        transform.position = Vector3.Lerp(transform.position,desiredPosition,2f);



    }
}
