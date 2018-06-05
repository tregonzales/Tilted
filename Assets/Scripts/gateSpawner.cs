using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateSpawner : MonoBehaviour {

	public GameObject gatePrefab;
	public float distance;
	public int spawnNum;
	private float currentYtrans = 0;
	private GameObject[] currentGates;

	// Use this for initialization
	void Start () {
		currentGates = new GameObject[spawnNum];
		//make first ten
		createGates();
	}

	public void createGates() {
		GameObject curGate;
		Vector3 position;
		for (int i = 0; i < currentGates.Length; i++) {
			position = new Vector3(0, currentYtrans, 0);
			curGate = Instantiate(gatePrefab, position, Quaternion.identity);
			currentYtrans += distance;
			// curGate.GetComponentInChildren<gateWallShifter>().Shift();
			currentGates[i] = curGate;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
