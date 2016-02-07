using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour {

	public GameObject CarbBarSlider;
	public GameObject Player;
	public GameObject Camera;
	Vector3 originalCameraPosition;

	float shakeAmt = 1;

	void Start()
	{ 
		//ShakingLevel = CarbBarSlider.GetComponent<CarbBar> ().ShakingMeter;
		InvokeRepeating ("PeriodicCameraShake", 0, 1);
	}

	void PeriodicCameraShake() 
	{
		//
		originalCameraPosition = Player.transform.localPosition;
		shakeAmt =  CarbBarSlider.GetComponent<CarbBar> ().ShakingMeter * .0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.3f);

	}

	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = Camera.transform.position;
			pp.x+= quakeAmt;
			pp.z += quakeAmt;// can also add to x and/or z
			Camera.transform.position = pp;
		}
	}

	void StopShaking()
	{
		CancelInvoke("CameraShake");
		Camera.transform.position = originalCameraPosition;
	}


}
