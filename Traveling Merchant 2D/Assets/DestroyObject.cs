using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {


	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0.5f);
		Invoke ("DestroyThis", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestroyThis()
	{
		Destroy (gameObject);
	}
}
