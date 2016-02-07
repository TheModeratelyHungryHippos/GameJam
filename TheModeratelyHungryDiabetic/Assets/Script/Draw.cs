using UnityEngine;
using System.Text;
using System.Collections;

public static class Draw : object {
	public static void Update(int[] x){
		printArr (x);
	}

	private static void printArr(int[] x){
		StringBuilder sb = new StringBuilder ();
		ObjectStats o;
		for(int i = 0; i < x.Length; i++){
			if (x [i] == -1) {
				sb.Append ("E ");
				continue;
			}
			o = Stats.GameObjects [x [i]];
			sb.Append (o.Name + " ");
		}
		sb.Append ("\n");
		Debug.Log (sb.ToString());
	}
}
