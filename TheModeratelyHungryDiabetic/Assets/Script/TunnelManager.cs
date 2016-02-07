using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelManager : MonoBehaviour {

	public GameObject tunnelPrefab;
	public GameObject player;
	private GameObject lastTunnel;

	private int skipCount = 0;

	private System.Collections.Generic.Queue<GameObject> tunnelQueue = new System.Collections.Generic.Queue<GameObject>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			lastTunnel = (GameObject)Instantiate (tunnelPrefab, new Vector3(35, 100 - (i * 10), 0), new Quaternion());
			tunnelQueue.Enqueue (lastTunnel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (tunnelQueue.Peek ().transform.position.y > player.transform.position.y) {
			Destroy(tunnelQueue.Dequeue().gameObject);
			lastTunnel = (GameObject)Instantiate (tunnelPrefab, new Vector3 (35, lastTunnel.transform.position.y- (10 - lastTunnel.GetComponent<TunnelSegment>().Speed), 0), new Quaternion ());
			tunnelQueue.Enqueue (lastTunnel);

			if (skipCount == 0) {
				lastTunnel.GetComponent<TunnelSegment> ().ShouldGenOb = true;
				skipCount = Random.Range (5, 9);
			}
			skipCount--;

		}
	}
}
