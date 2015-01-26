using UnityEngine;
using System.Collections;

public class enemyBulletStraight : MonoBehaviour {
	
	private float speed;
	private float theta;
	private Vector2 look;
	
	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<bulletCore> ().speed;
		theta = transform.rotation.z / (180 / Mathf.PI);
		
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
		
		//transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (Vector3)look  * speed * Time.deltaTime;

		//theta = Mathf.Asin (transform.rotation.x);
		
		//look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

		//transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
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
		else if (col.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
