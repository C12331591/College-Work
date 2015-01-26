using UnityEngine;
using System.Collections;

public class testBehaviourAlt : MonoBehaviour {

	private float speed;
	private Vector2 look;
	private float theta;

	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<enemyCore> ().speed;
		theta = Random.Range (0.0f, Mathf.PI * 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
		
		transform.position += (Vector3)look * speed * Time.deltaTime;

		theta += Time.deltaTime / (speed * 2.0f);
	}
}
