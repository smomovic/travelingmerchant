using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float speed;
	private Vector3 target;
	public bool moving;
	public Rigidbody shipRigidBody;
    public bool tradeScreen;

	void Start () {
		target = transform.position;
	}

	void Update () {
        if (tradeScreen == false) {
            if (Input.GetMouseButton(0)) {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
            }
        }
		shipRigidBody.AddForce (Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime) - transform.position, ForceMode.VelocityChange);
		//shipRigidBody.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		moving = shipRigidBody.velocity.magnitude > 0.2;



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