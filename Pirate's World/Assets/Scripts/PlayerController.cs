using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public Joystick joystick;

    private Quaternion targetRotation;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        Vector3 looking = FloatingJoystick.direction;
        targetRotation = Quaternion.LookRotation(looking, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0);
        
    }
}
