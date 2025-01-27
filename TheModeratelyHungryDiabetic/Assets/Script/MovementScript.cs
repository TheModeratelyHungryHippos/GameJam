﻿using UnityEngine;
using System.Collections;
/// <summary>
/// Player controller and behavior
/// </summary>
public class MovementScript : MonoBehaviour
{
    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector3 speed = new Vector3(5, 0 , 5);

	public bool isHavingStroke = false;

	public bool isHavingHeartAttack = false;


    // 2 - Store the movement
    private Vector3 movement;

    void Update()
    {
		
        // Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		CarbBar x = gameObject.GetComponent<CarbBar> ();
		//print (x.CarbLevel);
		if (x.CarbLevel <= 0 || x.CarbLevel >= 420) {
			print (x.CarbLevel);
			print ("MASMMAM");
			killme ();
		}


		if (!isHavingStroke && !isHavingHeartAttack) {
			// Movement per direction
			movement = new Vector3 (speed.x * inputX, 0, speed.z * inputY);
		} else if (isHavingStroke) {
			movement = new Vector3 (1, 0, speed.z * inputY);

		} else {
			movement = new Vector3 (0, 0, 0);

		}

		/*
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
*/
    }
		
    void FixedUpdate()
    {
        // 5 - Move the game object
		GetComponent<Rigidbody>().velocity = movement;
    }

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.GetComponent<TunnelSegment> () != null) {
			return;
		}

		if (col.gameObject.GetComponent<ParentPhysObj> ().isDeath) {
			print ("HErer");
			killme ();
		} else {
			gameObject.GetComponent<CarbBar>().ConsumePowerup (col.gameObject.GetComponent<ParentPhysObj>().CarbChange);
		}


		Destroy (col.gameObject);
	}

	private void killme(){
		for (int i = 0; i < 5000; i++) {
		}
		Application.LoadLevel(Application.loadedLevel);
	}
}

