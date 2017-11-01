using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementWithKeys : MonoBehaviour {

	public float scrollSpeed;
	public float cameraDistanceMax;
	public float cameraDistanceMin;
	public float cameraDistance;
	public float zoomSpeed;
	public GameObject ship;
	public Camera camera;
	public float smoothingFactor;
	public bool smoothing;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		camera.orthographicSize = cameraDistance;

		if(Input.GetKey(KeyCode.F1))
		{
			transform.position = new Vector3 (ship.transform.position.x,ship.transform.position.y,camera.transform.position.z);
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			transform.Translate(new Vector3(scrollSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow)  || Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0,-scrollSpeed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow)  || Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0,scrollSpeed * Time.deltaTime,0));
		}

		cameraDistance -= Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;
		cameraDistance = Mathf.Clamp (cameraDistance, cameraDistanceMin, cameraDistanceMax);
	}
}
