using UnityEngine;
using System.Collections;

public static class Draw : object {
	public static void Update(int[] x){
		printArr (x);
	}

	private static void printArr(int[] x){
		string y = "";
		for(int i = 0; i < x.Length; i++){
			y += x [i] + " "; 
		}
		Debug.Log (y);
	}
}
