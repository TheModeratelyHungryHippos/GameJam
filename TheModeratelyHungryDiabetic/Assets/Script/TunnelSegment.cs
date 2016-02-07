using UnityEngine;
using System.Collections;

public class TunnelSegment : MonoBehaviour {

	public float Speed = 0.1f;
	public string name;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, (transform.position.y + Speed), transform.position.z);

	}
}
