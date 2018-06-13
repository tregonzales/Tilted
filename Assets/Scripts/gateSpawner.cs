using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateSpawner : MonoBehaviour {

	public GameObject gatePrefab;
	public float distance;
	public int spawnNum;
	private float currentYtrans = 0;
	// private GameObject[] currentGates;

	// Use this for initialization
	void Start () {
		// currentGates = new GameObject[spawnNum];
		//make first ten
		createGates(false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void createGates(bool clear = true) {
		// GameObject curGate;
		Vector3 position;
		spawnNum = clear ? 10 : spawnNum; 
		for (int i = 0; i < spawnNum; i++) {
			position = new Vector3(0, currentYtrans, 0);
			// curGate = Instantiate(gatePrefab, position, Quaternion.identity);
			Instantiate(gatePrefab, position, Quaternion.identity);
			currentYtrans += distance;
			// currentGates[i] = curGate;
		}
	}
}
