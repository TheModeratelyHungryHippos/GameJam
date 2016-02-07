using UnityEngine;
using System;
using System.Collections;

public class TunnelSegment : MonoBehaviour {

	public float Speed = 0.1f;
	public bool ShouldGenOb = false;

	public Transform[] quads;

	void Start () {
		if (ShouldGenOb) {
			quads = new Transform[5] {
				gameObject.transform.GetChild (3),
				gameObject.transform.GetChild (4),
				gameObject.transform.GetChild (5),
				gameObject.transform.GetChild (6),
				gameObject.transform.GetChild (7)
			}; 

			int[] obsticles = Generator.Generate();

			for (int i = 0; i < quads.Length; i++) {
				if (obsticles [i] == -1) {
					continue;
				} 

				Transform prefab = Stats.GameObjects [obsticles [i]].Prefab;
				prefab = Instantiate(prefab);
				prefab.parent = quads[i];
				prefab.position = quads[i].position;

			}

		}
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, (transform.position.y + Speed), transform.position.z);

	}
}
