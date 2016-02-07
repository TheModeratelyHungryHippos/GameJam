using UnityEngine;
using System.Collections;

public class CarbBar : MonoBehaviour {

	int CarbLevel { get; set; }

	bool isVisible { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isVisible) {
			CarbLevel -= (int)Time.deltaTime;
		}
	}

	void StartCarbBar(){
		CarbLevel = 210;
		isVisible = true;


	}


}
