using UnityEngine;
using System.Collections;

public class seekerBullet : MonoBehaviour {
	
	private float speed;
	private float theta;
	private Vector2 look;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindWithTag("Player");
		Vector2 plrPos = player.GetComponent<Transform> ().position;
		theta = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
		theta += Mathf.PI / 2.0f;

		speed = gameObject.GetComponent<bulletCore> ().speed;

		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

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
			//Destroy(this.gameObject);
		}
		else if (col.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
		else if (col.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
