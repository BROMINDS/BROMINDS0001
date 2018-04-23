using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorCapsule : MonoBehaviour {

	public Animator anim;

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("OnCollisionEnter: "+col.gameObject.name);
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("OnTriggerEnter: " + col.gameObject.name);
		if (col.gameObject.tag == "Player") {
			Player player = col.GetComponent<Player> ();
			player.rigi.velocity = Vector3.zero;
			player.transform.position = new Vector3(transform.position.x, player.transform.position.y,transform.position.z);
			player.transform.LookAt (transform.right);
			player.canMove = false;
			gameObject.SetActive (false);
			anim.Play ("closeDoor");
		}
	}
}
