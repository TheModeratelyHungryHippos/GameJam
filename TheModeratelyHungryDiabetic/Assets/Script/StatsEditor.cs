using UnityEngine;
using System.Collections;

public class StatsEditor : MonoBehaviour {

	int StatsTimer = 0;
	public const int LevelOne = 10;
	public const int LevelTwo = 20;


	bool isStopped = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetStats() {
		isStopped = true;
		StatsTimer = 0;
		Stats.ResetStats ();


	}

	public void RunEditor() {
		while (isStopped == false) {
			WaitForSeconds (1);
			StatsTimer++;
			AdjustAllWeights ();
		}
	}

	private void AdjustAllWeights(){
		AdjustGeneratedItemPercent ();
		AdjustObjWeights ();
	}

	/// <summary>
	/// Adjusts the generated item percent.
	/// Defaults: 0: 1, rest 0
	/// </summary>
	private void AdjustGeneratedItemPercent(){
		if (StatsTimer <= LevelOne) {
			if (StatsTimer % 3 == 0) {
				Stats.GeneratedItemsPercent [0]++;
			} else {
				Stats.GeneratedItemsPercent [1]++;
			}
		} else if (StatsTimer <= LevelTwo) {
			if (StatsTimer % 3 == 0) {
				Stats.GeneratedItemsPercent [0]++;
				Stats.GeneratedItemsPercent [1]++;
			} else {
				Stats.GeneratedItemsPercent [2]++;
			}

		} else {
			Stats.GeneratedItemsPercent [3]++;
			Stats.GeneratedItemsPercent [4]++;
			if (StatsTimer >= 60) {
				if (Stats.GeneratedItemsPercent [0] != 1 && Stats.GeneratedItemsPercent [1] != 10) {
					Stats.GeneratedItemsPercent [0] = 1;
					Stats.GeneratedItemsPercent [1] = 5;
					Stats.GeneratedItemsPercent [2] = 10;
				}
			}
		}
	}

	/// <summary>
	/// Adjusts the object weights.
	/// </summary>
	private void AdjustObjWeights(){
		if (StatsTimer <= LevelOne) {
			Stats.GameObjects
		}
	}

}
