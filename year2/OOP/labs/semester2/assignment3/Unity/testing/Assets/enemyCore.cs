using UnityEngine;
using System.Collections;

public class enemyCore : MonoBehaviour {

	public float health;
	public float speed;
	public float theta;
	public float powerupChance = 50;

	// Use this for initialization
	void Start () {
		setDirection ();

	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1)
		{
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "PlayerBullet")
		{
			if (Random.Range(0, 100) <= powerupChance)
			{
				GameObject powerup = Instantiate(Resources.Load ("powerUp"), new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion()) as GameObject;
			}

			health -= col.gameObject.GetComponent<bulletCore>().damage;
		}
	}

	bool angleRange(float angle, float middle)
	{
		return ((angle >= (middle - (Mathf.PI / 4))) && (angle <= (middle + (Mathf.PI / 4))));
	}

	void setDirection()//makes the enemy point towards the player
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