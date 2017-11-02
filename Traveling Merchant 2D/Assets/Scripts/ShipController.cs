using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipController : MonoBehaviour {

	public float startingSpeed;
	public float speed;
	private Vector3 target;
	public bool moving;
	public Rigidbody shipRigidBody;
    public bool tradeScreen;
	public ParticleSystem clickSplash;
	public bool speedCheat;

	void Start () {
		speed = startingSpeed;
		target = transform.position;
	}

	void Update () {
        if (tradeScreen == false) {
			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
            }
        }
		shipRigidBody.AddForce (Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime) - transform.position, ForceMode.VelocityChange);
		//shipRigidBody.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		moving = shipRigidBody.velocity.magnitude > 0.2;

		if (Input.GetKeyDown(KeyCode.Home))
		{
			speedCheat = true;
		}
		if (Input.GetKeyDown(KeyCode.End))
		{
			speedCheat = false;
		}
		if (speedCheat)
		{
			speed = 500;
		} 
		else 
		{
			speed = startingSpeed;
		}

		if (moving && shipRigidBody.velocity.x < 0) 
		{
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		else 
		{
			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
}