using UnityEngine;
using System.Collections;

public class bulletMovement : MonoBehaviour {

	private int decay;
	private float speed;
	private float theta;
	private Vector2 look;

	// Use this for initialization
	void Start () {
		GameObject arrow;
		arrow = GameObject.FindWithTag("Player");
		theta = arrow.GetComponent<arrowMovement> ().theta;
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

		speed = gameObject.GetComponent<bulletCore> ().speed;
		decay = gameObject.GetComponent<bulletCore> ().decay;

		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (Vector3)look  * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
		}
		else if (col.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}