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

		Vector3 mousePos = cam.ScreenToViewportPoint (Input.mousePosition);
		//cam.transform.localEulerAngles = cam.transform.localEulerAngles + Vector3.up * mousePos.normalized.x * 0.05f;
		float mouseX = Input.GetAxisRaw("Mouse X");


		rigi.AddForce (cam.transform.forward.normalized * velForward);
		rigi.AddForce (cam.transform.right.normalized * velLateral);
		//Debug.Log ("Update velX: "+velX+ " -- velZ: "+velZ);
		//Debug.Log ("Update mousePos: "+mousePos.normalized.x);
	}
}
