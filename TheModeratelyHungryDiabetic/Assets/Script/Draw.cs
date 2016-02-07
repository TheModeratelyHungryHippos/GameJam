using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class Draw : object {

	public static System.Collections.Generic.Queue<TunnelSegment> TunnelQueue = new System.Collections.Generic.Queue<TunnelSegment>();

	/// <summary>
	/// Sets up initial tunnel.
	/// </summary>
	public static void SetUpInitialTunnel()
	{
		for (int i = 0; i < 10; i++) {
			AddTunnleSegment (new int[] { -1, -1, -1, -1, -1 });
		}
	}

	public static void Update(int[] GeneratorObjects){


		//need to add wall section to list of walls
		AddTunnleSegment(GeneratorObjects);

		printArr (GeneratorObjects);
	}

	public static void AddTunnleSegment(int[] x) {
		
	}

	private static void AddObjectsToSectors(){
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
