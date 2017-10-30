using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractIsland : MonoBehaviour {

	public GameObject interactIcon;
	void Start () {
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		interactIcon.SetActive(true);
	}

	void OnTriggerExit(Collider other)
	{
		interactIcon.SetActive (false);
	}
}
