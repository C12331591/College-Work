using UnityEngine;
using System.Collections;

public class bounceEnemy : MonoBehaviour {

	private float speed;
	private Vector2 look;
	private float theta;
	private float angle;

	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<enemyCore> ().speed;
		theta = gameObject.GetComponent<enemyCore> ().theta;
		angle = Random.Range (-(Mathf.PI / 3), (Mathf.PI / 3));
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Wall")
		{
			angle = -angle;
		}
	}

	// Update is called once per frame
	void Update () {
		look = new Vector2 (Mathf.Sin (theta + angle), -Mathf.Cos (theta + angle));
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, (theta + angle) * (180 / Mathf.PI));
		transform.position += (Vector3)look * speed * Time.deltaTime;
	}
}
