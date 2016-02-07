using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelManager : MonoBehaviour {

	public Rigidbody tunnelPrefab;
	public GameObject player;
	private Rigidbody lastTunnel;
	int a = 0;

	private System.Collections.Generic.Queue<Rigidbody> tunnelQueue = new System.Collections.Generic.Queue<Rigidbody>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			lastTunnel = (Rigidbody)Instantiate (tunnelPrefab, new Vector3(35, 100 - (i * 10), 0), new Quaternion());
			lastTunnel.name = a.ToString();
			a++;
			tunnelQueue.Enqueue (lastTunnel);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody temp = lastTunnel;
		if (tunnelQueue.Peek ().transform.position.y > player.transform.position.y) {
			Rigidbody temp3 = lastTunnel;
			Destroy(tunnelQueue.Dequeue().gameObject);
			lastTunnel = (Rigidbody)Instantiate (tunnelPrefab, new Vector3 (35, lastTunnel.transform.position.y- (10 - lastTunnel.GetComponent<TunnelSegment>().Speed), 0), new Quaternion ());
			lastTunnel.name = a.ToString();
			a++;
			tunnelQueue.Enqueue (lastTunnel);

			Debug.Log (temp.transform.position.y - lastTunnel.transform.position.y);
		}
	}
}
