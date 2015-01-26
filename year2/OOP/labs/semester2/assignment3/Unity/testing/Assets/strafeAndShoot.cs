using UnityEngine;
using System.Collections;

public class strafeAndShoot : MonoBehaviour {

	private float speed;
	private Vector2 look;
	private float theta;
	public float targetDistance;
	private GameObject bullet;
	public int bulletDelay;
	private int curDelay;
	private int strafeTimer;
	private float sideways;

	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<enemyCore> ().speed;
		theta = gameObject.GetComponent<enemyCore> ().theta;
		strafeTimer = 45;
		sideways = Mathf.PI / 2;
		curDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));

		GameObject player = GameObject.FindWithTag("Player");
		
		Vector2 plrPos = player.GetComponent<Transform> ().position;

		if (Vector2.Distance(transform.position, plrPos) > targetDistance + 2.5f)
		{
			transform.position += (Vector3)look * speed * Time.deltaTime;
		}
		else if (Vector2.Distance(transform.position, plrPos) < targetDistance - 2.5f)
		{
			transform.position -= (Vector3)look * speed * (Time.deltaTime * 1.5f);
		}
		else
		{
			if (curDelay++ > bulletDelay)
			{
				bullet = Instantiate(Resources.Load ("enemyBullet"), new Vector3(transform.position.x + (look.x * 0.8f), transform.position.y + (look.y * 0.8f), transform.position.z), transform.rotation) as GameObject;
				curDelay = 0;
			}

			Vector2 strafe = new Vector2(Mathf.Sin (theta + sideways), -Mathf.Cos (theta + sideways));

			transform.position += (Vector3)strafe * speed * Time.deltaTime;

			transform.position -= (Vector3)look * speed * (Time.deltaTime * 0.7f);
		}

		if (--strafeTimer < 0)
		{
			sideways = -sideways;
			strafeTimer = 45;
		}
	}
}
