using UnityEngine;
using System.Collections;

public class ParentPhysObj : MonoBehaviour {
	// Use this for initialization
	public bool isDeath = false;
	public int CarbChange = 0;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public virtual void animate(){
	}
	//public void DrawModel(){
	//	instance = Instantiate (prefab);
	//}
}
