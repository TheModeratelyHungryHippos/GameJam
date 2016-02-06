using UnityEngine;
using System.Collections;

public static class Stats : object {

	public static int[] GeneratedItemsPercent;
	public static ObjectStats[] GameObjects;
	private static bool hasBeenInit = false;

	// Use this for initialization
	public static void Init () {
		if (hasBeenInit) {
			return;
		}
		hasBeenInit = true;

		// % No items, % One items, % Two items, % Three items, % Four items, % Five items
		GeneratedItemsPercent = new int[6]{0, 0, 0, 1, 0, 0 };
		GameObjects = new ObjectStats[3];
		GameObjects [0] = new ObjectStats ("Wall0", 1, QType.Blocking, Direction.None, 1, typeof(Wall));
		GameObjects [1] = new ObjectStats ("Wall1", 1, QType.Blocking, Direction.None, 2, typeof(Wall));
		GameObjects [2] = new ObjectStats ("Wall2", 1, QType.Blocking, Direction.None, 3, typeof(Wall));
	}

}
