using UnityEngine;
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


    // 2 - Store the movement
    private Vector3 movement;

    void Update()
    {
        // Retrieve axis information
        float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

        // Movement per direction
        movement = new Vector3( speed.x * inputX, 0, speed.x * inputY);


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

}

