using UnityEngine;
using System.Collections;

public class CarbBar : MonoBehaviour {

	int CarbLevel { get; set; }

	public GameObject Player;

	public GameObject CarbBarGUI;

	const int LowCarbs = 120;

	const int VeryLowCarbs = 20;

	const int HighCarbs = 300;

	const int VeryHighCarbs = 420;

	const int MaxMeterValue = 100;

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

	void UpdateCarbBar() {
		if (isVisible) {
			
			CarbLevel--;
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
		//sync blindness level.
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
