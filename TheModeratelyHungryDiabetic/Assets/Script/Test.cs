using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	int count = 10;
	// Use this for initialization
	void Start () {
		Generator.Update();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 0) {
			count = 10;
			Generator.Update ();
		}
		count--;
	}
}
