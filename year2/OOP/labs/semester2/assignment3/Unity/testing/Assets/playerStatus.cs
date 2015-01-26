using UnityEngine;
using System.Collections;

public class playerStatus : MonoBehaviour {

	public float health;
	public bool redKey, greenKey, blueKey;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0.0f)
		{
			//Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "EnemyBullet")
		{
			health -= col.gameObject.GetComponent<bulletCore>().damage;
		}

		if (col.gameObject.tag == "Powerup")
		{
			int ran = (int)Random.Range(0, 2);

			if (ran == 0)
			{
				health += 20;
			}
			else if (ran == 1)
			{
				if (gameObject.GetComponent<arrowMovement>().bulletDelay > 2.0f)
					gameObject.GetComponent<arrowMovement>().bulletDelay -= 2;
			}
			else
			{
				gameObject.GetComponent<arrowMovement>().strafeSpeed += 0.5f;
			}
		}
	}
}
