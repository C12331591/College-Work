using UnityEngine;
using System.Collections;

public class cannon : MonoBehaviour {

	private GameObject player;
	private float theta;
	public string orientation;
	private GameObject bullet;
	public int bulletDelay;
	private int curDelay;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");

		curDelay = 0;

		/*if (orientation.ToLower() == "up")
		{
			theta = Mathf.PI;
		}*/

		switch (orientation)
		{
			case "up":
			{
				theta = -Mathf.PI;//minus for compatibility with the palyer angle
				break;
			}
			case "right":
			{
				//theta = Mathf.PI + (Mathf.PI / 2);
				theta = Mathf.PI / 2;
				break;
			}
			case "down":
			{
				theta = 0.0f;
				break;
			}
			case "left":
			{
				theta = -(Mathf.PI / 2);
				break;
			}
			default:
			{
				theta = 0.0f;
				break;
			}
		}

		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 plrPos = player.GetComponent<Transform> ().position;
		
		/*float angle = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
		angle += (Mathf.PI / 2);

		if ((angle <= (theta + (Mathf.PI / 32)) && angle >= (theta - (Mathf.PI / 32))) || (angle <= (-theta + (Mathf.PI / 32)) && angle >= (-theta - (Mathf.PI / 32))))
		{
			if (curDelay++ > bulletDelay)
			{
				Vector2 look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
				bullet = Instantiate(Resources.Load ("enemyBullet"), new Vector3(transform.position.x + (look.x * 0.8f), transform.position.y + (look.y * 0.8f), transform.position.z), transform.rotation) as GameObject;
				curDelay = 0;
			}
		}*/

		if (Vector2.Distance(plrPos, transform.position) < 30.0f)
		{
			if (curDelay++ > bulletDelay)
			{
				Vector2 look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
				bullet = Instantiate(Resources.Load ("enemyBullet"), new Vector3(transform.position.x + (look.x * 1.0f), transform.position.y + (look.y * 1.0f), transform.position.z), transform.rotation) as GameObject;
				curDelay = 0;
			}
		}
	}
}
