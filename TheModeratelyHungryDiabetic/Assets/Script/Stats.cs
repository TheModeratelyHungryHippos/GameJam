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
		GeneratedItemsPercent = new int[5]{1, 1, 1, 1, 1 };
		GameObjects = new ObjectStats[6];
		GameObjects [0] = new ObjectStats ("Wall", 0, QType.Blocking, Direction.None, 20, typeof(BlockingWall));
		GameObjects [1] = new ObjectStats ("Apple", 1, QType.Avoidable, Direction.None, 20, typeof(BlockingWall)); // TODO: Change type
		GameObjects [2] = new ObjectStats ("Spikes", 2, QType.Avoidable, Direction.None, 20, typeof(BlockingWall));  // TODO: Change type
		GameObjects [3] = new ObjectStats ("MoveLR", 3, QType.Moving, Direction.LeftRight, 20, typeof(BlockingWall));  // TODO: Change type
		GameObjects [4] = new ObjectStats ("MoveUP", 4, QType.Moving, Direction.UpDown, 20, typeof(BlockingWall));  // TODO: Change type
		GameObjects [5] = new ObjectStats ("Full", 5, QType.FullRoom, Direction.None, 20, typeof(BlockingWall));  // TODO: Change type

		for (int i = 0; i < GameObjects.Length; i++) {
			KeyMap [GameObjects [i].Name] = i;
		}
	}

	public static void ResetStats(){
		
	}




}
