using UnityEngine;
using System.Collections;

public class cameraFollowArrow : MonoBehaviour
{
	private GameObject arrow;
	public float distance = 1.0f;

	// Use this for initialization
	void Start ()
	{
		arrow = GameObject.FindWithTag("Player");
		Vector3 newPos = new Vector3 ((arrow.transform.position.x - (-Mathf.Sin (arrow.GetComponent<arrowMovement> ().theta) * distance)), (arrow.transform.position.y - (Mathf.Cos (arrow.GetComponent<arrowMovement> ().theta) * distance)), transform.position.z);
		transform.position = newPos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 newPos = new Vector3 ((arrow.transform.position.x - (-Mathf.Sin (arrow.GetComponent<arrowMovement> ().theta) * distance)), (arrow.transform.position.y - (Mathf.Cos (arrow.GetComponent<arrowMovement> ().theta) * distance)), transform.position.z);
		transform.position = newPos;
	}
}