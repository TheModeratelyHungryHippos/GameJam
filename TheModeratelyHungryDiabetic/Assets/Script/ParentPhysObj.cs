using UnityEngine;
using System.Collections;

public class ParentPhysObj : MonoBehaviour {

	public Rigidbody prefab;
	private Rigidbody instance;

	// Use this for initialization
	public virtual void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void DrawModel(){
		instance = Instantiate (prefab);
	}
}
