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
		GameObjects = new ObjectStats[12];
		GameObjects [0] = new ObjectStats ("FoodBanana", 0, QType.Avoidable, Direction.None, 20, Stats.Load("BananaPrefab"));
		GameObjects [1] = new ObjectStats ("FoodPineapple", 1, QType.Avoidable, Direction.None, 20, Stats.Load("PineapplePrefab")); 
		GameObjects [2] = new ObjectStats ("FoodBigPretzel", 2, QType.Avoidable, Direction.None, 20, Stats.Load("PretzelPrefab")); 
		GameObjects [3] = new ObjectStats ("FoodPizza", 3, QType.Avoidable, Direction.None, 20, Stats.Load("PizzaPrefab")); 
		GameObjects [4] = new ObjectStats ("InsulinOne", 4, QType.Avoidable, Direction.None, 20, Stats.Load("SyringePrefab"));  
		GameObjects [5] = new ObjectStats ("InsulinThree", 5, QType.Avoidable, Direction.None, 20, Stats.Load("SyringePrefab"));
		GameObjects [6] = new ObjectStats ("InsulinFive", 6, QType.Avoidable, Direction.None, 20, Stats.Load("SyringePrefab"));
		GameObjects [7] = new ObjectStats ("InsulinSeven", 7, QType.Avoidable, Direction.None, 20, Stats.Load("SyringePrefab"));
		GameObjects [8] = new ObjectStats ("BlockingWall", 8, QType.Blocking, Direction.None, 20, Stats.Load("WallRegularPrefab"));
		GameObjects [9] = new ObjectStats ("BlockingUDWall", 9, QType.Moving, Direction.UpDown, 0, null);
		GameObjects [10] = new ObjectStats ("BlockingLRWall", 10, QType.Moving, Direction.LeftRight, 0, null);
		GameObjects [11] = new ObjectStats ("Fan", 11, QType.FullRoom, Direction.None, 40, Stats.Load("FanPrefab"));


		for (int i = 0; i < GameObjects.Length; i++) {
			KeyMap [GameObjects [i].Name] = i;
		}
	}

	public static void ResetStats(){
		
	}

	private static Transform Load(string name){

		Transform x = (Transform)Resources.Load(name, typeof(Transform));
		return (Transform)UnityEngine.Object.Instantiate (x);

	}
}

