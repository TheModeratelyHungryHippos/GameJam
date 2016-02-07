using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	int count = 100;
	// Use this for initialization
	void Start () {
		Generator.Update();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 0) {
			count = 100;
			Generator.Update ();
		}
		count--;
	}
}
