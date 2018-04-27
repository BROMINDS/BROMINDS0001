using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Rigidbody rigi;
	public Animator anim;
	public float velRotation = 5;
	public Camera cam;
	public bool canMove = true;
	public Transform indicator;
	public Transform container;
	public Transform indicatorMov;
	void Start () {
		
	}

	private bool canRote = false;

	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			canRote = !canRote;
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			if (indicatorMov.parent == null) {
				indicatorMov.parent = indicator.parent;
				indicatorMov.position = indicator.position;
			} else {
				indicatorMov.parent = null;
			}
		}

		if (!canMove)
			return;
		
		float inputX = Input.GetAxisRaw("Horizontal");
		float inputZ = Input.GetAxisRaw("Vertical");

		float velLateral = inputX * Time.deltaTime * 100000 * velRotation; 
		float velForward = inputZ * Time.deltaTime * 100000 * velRotation; 


		if (inputX == 0 && inputZ == 0) {
			rigi.velocity = Vector3.zero;
			return;
		} else {

			transform.eulerAngles += Vector3.up * Time.deltaTime * inputX * 10 * velRotation;	
			Debug.Log ("Indicador: "+indicator.position+" -- Container: "+container.position);
			rigi.AddForce (transform.forward * 100 * inputZ);
		}

		Debug.DrawLine (container.position, indicator.position, Color.yellow);
	}

}
