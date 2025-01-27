﻿using UnityEngine;
using System.Collections;

public class StatsEditor : MonoBehaviour {

	int StatsTimer = 0;
	public const int LevelOne = 10;
	public const int LevelTwo = 20;
	public const int LevelThree = 30;
	public const int LevelFour = 40;
	public const int LevelFive = 50;
	public const int MaxLevel = 60;


	bool isStopped = true;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("RunEditor", 0, 1);
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
		if (!isStopped) {
			
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

		} else if (StatsTimer <= LevelThree) {
			if (StatsTimer <= LevelThree) {
				if (StatsTimer % 5 == 0) {
					Stats.GeneratedItemsPercent [0]++;
					Stats.GeneratedItemsPercent [1]++;
				} else if (StatsTimer % 3 == 0) {
					Stats.GeneratedItemsPercent [2]++;
					Stats.GeneratedItemsPercent [3]++;
				} else {
					Stats.GeneratedItemsPercent [3]++;
				}
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
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType == QType.Avoidable) {
					iObj.Weight++;
				} else {
					iObj.Weight += 2;
				}
			}
		}

		else if (StatsTimer <= LevelTwo) {
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType == QType.Avoidable) {
					iObj.Weight++;
				} else {
					iObj.Weight += 4;
				}
			}
		}

		else if (StatsTimer <= LevelThree) {
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType != QType.Avoidable) {
					iObj.Weight += 8;
				}
			}
		}

		else if (StatsTimer <= LevelFour) {
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType != QType.Avoidable) {
					iObj.Weight += 12;
				}
			}
		}

		else if (StatsTimer <= LevelFive) {
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType != QType.Avoidable) {
					iObj.Weight += 24;
				}
			}
		}
		else {
			foreach (ObjectStats iObj in Stats.GameObjects) {
				if (iObj.QType != QType.Avoidable) {
					iObj.Weight += 20;
				}
			}
		}


	}
}


