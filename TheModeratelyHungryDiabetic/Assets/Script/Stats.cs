using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class Stats : object {

	public static int[] GeneratedItemsPercent;
	public static ObjectStats[] GameObjects;
	public static Dictionary<string, int> KeyMap = new Dictionary<string, int> ();
	private static bool hasBeenInit = false;


	// Use this for initialization
	public static void Init () {
		if (hasBeenInit) {
			return;
		}
		hasBeenInit = true;

		// % No items, % One items, % Two items, % Three items, % Four items
		GeneratedItemsPercent = new int[5]{0, 0, 0, 1, 0 };
		GameObjects = new ObjectStats[3];
		GameObjects [0] = new ObjectStats ("Wall", 0, QType.Blocking, Direction.None, 1, typeof(Wall));
		GameObjects [1] = new ObjectStats ("Apple", 1, QType.Avoidable, Direction.None, 2, typeof(Wall)); // TODO: Change type
		GameObjects [2] = new ObjectStats ("Spikes", 2, QType.Avoidable, Direction.None, 3, typeof(Wall));  // TODO: Change type

		for (int i = 0; i < GameObjects.Length; i++) {
			KeyMap [GameObjects [i].Name] = i;
		}
	}

	public static void ResetStats(){
		
	}




}
