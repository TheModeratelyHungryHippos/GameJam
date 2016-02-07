using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, (float)(transform.position.y + 0.5), transform.position.z);
	}
}
