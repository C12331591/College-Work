using UnityEngine;
using System.Collections;

public class roomEnemy : MonoBehaviour {

	private float speed;
	private Vector2 look;
	private float theta;
	public float targetDistance;
	private GameObject bullet;
	public int bulletDelay;
	private int curDelay;
	private Vector2 thrust;
	private Vector2 velocity;
	public float speedDecay;
	private float curSpeed;
	private bool clockwise;
	private float edge;
	private float turnSpeed;

	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<enemyCore> ().speed;
		theta = gameObject.GetComponent<enemyCore> ().theta;

		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
		thrust = new Vector2 (0.0f, 0.0f);
		velocity = new Vector2 ();

		clockwise = false;
		edge = 0.0f;
		turnSpeed = 2.0f;

		curDelay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
		
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
		
		GameObject player = GameObject.FindWithTag("Player");
		
		Vector2 plrPos = player.GetComponent<Transform> ().position;

		if (Vector2.Distance(transform.position, plrPos) > targetDistance)
		{
			float angle = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
			theta = angle + (Mathf.PI / 2);
			look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

			curSpeed = speed;
		}
		else
		{
			float angle = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
			angle += (Mathf.PI / 2);//angle to player
			edge = angle + (Mathf.PI / 4);//as far as it should be going on one side

			if (theta > edge && clockwise)
			{
				clockwise = false;
			}
			else if (theta < (edge - (Mathf.PI / 2)) && !clockwise)
			{
				clockwise = true;
			}
			
			if (clockwise)
			{
				theta += turnSpeed * Time.deltaTime;
			}
			else
			{
				theta -= turnSpeed * Time.deltaTime;
			}

			/*if (curDelay++ > bulletDelay)
			{
				bullet = Instantiate(Resources.Load ("enemyBulletStraight"), new Vector3(transform.position.x + (look.x * 1.5f), transform.position.y + (look.y * 1.5f), transform.position.z), transform.rotation) as GameObject;
				curDelay = 0;
			}*/
		}

		curSpeed -= speedDecay * Time.deltaTime;
		thrust = new Vector2 (curSpeed, curSpeed);
		velocity = new Vector2(thrust.x * look.x, thrust.y * look.y);

		if (curSpeed > 0.0f)
		{
			transform.position += (Vector3)velocity * Time.deltaTime;
		}

	}
}
