using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class ParticleMouseFollow : MonoBehaviour {

	public GameObject clickSplash;
	private Vector3 mousePos;
	private Vector3 worldPos;
	private int layerMask;

	// Use this for initialization
	void Start () {
		layerMask = LayerMask.GetMask("Water, PlayerShip");
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0)) 
		{
			if(!Physics.Raycast(ray, out hit, layerMask))
			{
			mousePos = Input.mousePosition;
			mousePos.z = 1.5f;
			worldPos = Camera.main.ScreenToWorldPoint(mousePos);
			Instantiate (clickSplash, worldPos, Quaternion.identity);
			}
		}

	}
}
