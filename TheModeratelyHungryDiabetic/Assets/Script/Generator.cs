using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Generator : object {
	
	// Update is called once per frame
	public static void Update () {
		Stats.Init ();
		// ______________
		// |  0   |  1   |
		// |   +-----+   |
		// |---|  4  |---|
		// |   +-----+   |
		// |  2   |  3   |
		// --------------
		List<int> output = new List<int>() { -1, -1, -1, -1, -1 }; 

		int[] weights = Stats.GameObjects.Select (x => x.Weight).ToArray<int> ();

		int numItemsToGenerate = chooseIndex (Stats.GeneratedItemsPercent);

		List<int> idxOfItemsToAdd = new List<int> ();
		List<ObjectStats> selectedObjects = new List<ObjectStats> ();

		for (int i = 0; i < numItemsToGenerate; i++) {
			int index = chooseIndex(weights);
			idxOfItemsToAdd.Add(index);
			//Debug.Log("A");
			selectedObjects.Add(Stats.GameObjects[index]);
			//Debug.Log ("B");
		}

		// If a "full room" type is selected we are done
		foreach (ObjectStats x in selectedObjects) {
			if (x.QType == QType.FullRoom) {
				output [4] = x.ID;
				Draw.Update(output.ToArray<int>());
				return;
			}
		}

		// Arbitrarily assign locations
		List<int> availIndexes = new List<int>() { 0, 1, 2, 3};
		for (int i = 0; i < selectedObjects.Count; i++) {
			int idx = UnityEngine.Random.Range (0, availIndexes.Count);
			output [availIndexes [idx]] = selectedObjects [i].ID;
			availIndexes.RemoveAt (idx);
		}


		// If a  "Moving" type is selected we make room for it
		// Potential Bug here. What happens when 2 moving types with the same ID are selected?
		foreach (ObjectStats x in selectedObjects) {
			if (x.QType == QType.Moving) {
				int idx = output.FindIndex (y => y == x.ID);

				if (idx == -1) {
					Debug.Log (x.Name);
					throw new Exception ("Tell Ashley this happened. It shouldn't but it might");
					continue;
				}

				// If we get here we need to remove all other moving blocks
				for (int i = idx; i < output.Count; i++) {
					
					if (output[i] != -1 && Stats.GameObjects [output [i]].QType == QType.Moving) {
						output [i] = -1;
					}
				}

				// Find the index of the cell being moved to
				if (x.Direction == Direction.LeftRight) {
					idx ^= 1;
				} else {
					idx ^= 2;
				}

				// Empty a space for the movement
				output [idx] = -1;

				// We remove all other moving objects, so this will only happen once
				break;
					
			}
		}

		// Make sure there is an open space
		if (output.Contains (-1)) {
			Draw.Update(output.ToArray<int>());
			return;
		}

		foreach (ObjectStats x in selectedObjects) {
			if (x.QType == QType.Avoidable) {
				Draw.Update(output.ToArray<int>());
				return;
			}
		}

		// If we get here then we need to make space for the player
		int rnd = UnityEngine.Random.Range(0, 4);
		output[rnd] = -1;

		Draw.Update(output.ToArray<int>());
		return;
	

	}

	private static int chooseIndex(int[] weights){
		// This will calc the weight 
		int total = 0;

		var sorted = weights
			.Select((x, i) => new KeyValuePair<int, int>(x, i))
			.OrderBy(x => x.Key)
			.ToList();

		weights = sorted.Select (x => x.Key).ToArray<int> ();
		int[] idx = sorted.Select (x => x.Value).ToArray<int> ();

		for (int i = 0; i < weights.Length; i++) {
			total += weights [i];
		}

		int rnd = UnityEngine.Random.Range (0, total);
		for (int i = 0; i < weights.Length; i++) {
			if (rnd - weights[i] < 0) {
				return idx[i];
			}
			rnd -= weights[i];
		}
		return -1;
	}

	private static void printArr(int[] x){
		string y = "";
		for(int i = 0; i < x.Length; i++){
			y += x [i] + " "; 
		}
		Debug.Log (y);
	}
}
