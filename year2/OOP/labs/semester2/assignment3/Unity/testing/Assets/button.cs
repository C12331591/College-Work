using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "PlayerBullet")
		{
			//open the door
			GameObject door = GameObject.Find("doorTriggered");
			door.GetComponent<triggeredDoor>().trigger = true;
		}
	}
}
