using UnityEngine;
using System.Collections;

public class CarbBar : MonoBehaviour {

	int CarbLevel { get; set; }

	public GameObject Player;

	public GameObject CarbBarGUI;

	public GameObject BlindnessOverlay;

	const int LowCarbs = 120;

	const int VeryLowCarbs = 20;

	const int HighCarbs = 300;

	const int VeryHighCarbs = 400;

	const int MaxMeterValue = 100;

	const int MaxCarbs = 420;

	int ShakingMeter = 0;

	int StrokeMeter = 0;

	int BlindnessMeter = 0;

	int HeartAttackMeter =0;

	bool isVisible { get; set; }

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateCarbBar", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ConsumePowerup(int numberOfCarbs){
		CarbLevel += numberOfCarbs;
	}

	/// <summary>
	/// Starts the carb bar.
	/// </summary>
	void StartCarbBar(){
		CarbLevel = 210;
		isVisible = true;
	}

	void EndCarbBar(){
		isVisible = false;
	}

	void UpdateCarbBar() {
		if (isVisible) {
			if (CarbLevel > 0) {
				if (CarbLevel > MaxCarbs) {
					CarbLevel = MaxCarbs;
				}
				CarbLevel--;
			} else {
				CarbLevel = 0;
			}
			ModifyShakingMeter ();
			SyncScreenShake (); //NEEDS FINISHING

			ModifyStrokeMeter ();
			SyncStroke (); //NEEDS FINISHING

			ModifyBlindMeter ();
			SyncBlindness (); //NEEDS FINISHING

			ModifyHeartAttackMeter ();
			SyncHeartAttack (); //NEEDS FINISHING

		}
	}

	private void ModifyShakingMeter(){
		if (CarbLevel > LowCarbs) {
			if (ShakingMeter > 0) {
				ShakingMeter--;
			}
		} else {
			ShakingMeter+=2;
		}
	}

	private void SyncScreenShake(){
		//needs to be implemented.
	}

	private void ModifyStrokeMeter(){
		if (CarbLevel > LowCarbs) {
			if (StrokeMeter > 0) {
				StrokeMeter--;
			} 
		} else if (CarbLevel < VeryLowCarbs) {
			StrokeMeter += 10;
		}
	}

	private void SyncStroke(){
		if (StrokeMeter >= MaxMeterValue) {
			Player.GetComponent<MovementScript> ().isHavingStroke = true;
		} else {
			//GUI ques?
		}
	}

	private void ModifyBlindMeter(){
		if (CarbLevel > HighCarbs) {
			BlindnessMeter++;
		}
	}

	private void SyncBlindness(){
		float lBlindValue = (BlindnessMeter * 0.01F);
		Color temp = BlindnessOverlay.GetComponent<Renderer> ().material.color;
		temp.a = lBlindValue;
		BlindnessOverlay.GetComponent<Renderer> ().material.color = temp ;
	}

	private void ModifyHeartAttackMeter(){
		if (CarbLevel > VeryHighCarbs) {
			HeartAttackMeter += 10;
		} else if (CarbLevel < HighCarbs) {
			HeartAttackMeter--;
		}
	}

	private void SyncHeartAttack(){
		if (HeartAttackMeter >= MaxMeterValue) {
			Player.GetComponent<MovementScript> ().isHavingHeartAttack = true;
		} else {
			//GUI effects
		}
	}

}
