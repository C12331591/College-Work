using UnityEngine;
using System.Collections;

public class enemyBulletMovement : MonoBehaviour {
	
	private float speed;
	private float theta;
	private Vector2 look;

	// Use this for initialization
	void Start () {
		setDirection ();

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

	bool angleRange(float angle, float middle)
	{
		return ((angle >= (middle - (Mathf.PI / 4))) && (angle <= (middle + (Mathf.PI / 4))));
	}
	
	void setDirection()//same as when spawning an enemy
	{
		GameObject player = GameObject.FindWithTag("Player");
		
		Vector2 plrPos = player.GetComponent<Transform> ().position;
		
		float angle = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
		
		if (angleRange(angle, 0.0f))
		{
			theta = 0.0f;
		}
		else if (angleRange(angle, Mathf.PI / 2))
		{
			theta = Mathf.PI / 2;
		}
		else if (angleRange(angle, Mathf.PI) || angleRange(angle, -Mathf.PI))
		{
			theta = Mathf.PI;
		}
		else if (angleRange(angle, -Mathf.PI / 2))
		{
			theta = -Mathf.PI / 2;
		}
		else//it shouldn't get this far, but there's no harm in including this just in case
		{
			//theta = 0.0f;
			theta = Mathf.PI + (Mathf.PI / 4);//to make it clear when it didn't work
		}
		
		theta += Mathf.PI / 2.0f;//the correct direction is actually 90 degrees from what comes from the calculation
	}
}
