using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody rigi;
	public Animator anim;
	public float vel = 5;
	public Camera cam;
	public bool canMove = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!canMove)
			return;
		
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputZ = Input.GetAxisRaw("Vertical");

		float velLateral = inputX * Time.deltaTime * 100000 * vel; 
		float velForward = inputZ * Time.deltaTime * 100000 * vel; 


		if (inputX == 0 && inputZ == 0) {
			rigi.velocity = Vector3.zero;
			return;
		} else if (Mathf.Abs(inputX) > 0) {
			//rigi.AddForce (transform.right * velLateral);
			transform.eulerAngles += Vector3.up * Time.deltaTime * inputX * 50;

		}else if(Mathf.Abs(inputZ) > 0)
		{						
			Vector3 force = transform.forward * velForward * inputZ * Time.deltaTime * 100;
			Debug.DrawLine (transform.position, transform.forward * 100, Color.yellow);
			rigi.AddForce (force);
		}

		//Debug.Log ("Update mousePos: "+mousePos.normalized.x);
	}

}
