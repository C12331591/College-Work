using UnityEngine;
using System.Collections;

public class arrowMovement : MonoBehaviour {
	public float speed = 1.0f;
	public float theta = 0.0f;
	private Vector2 look;
	public float turnSpeed = 0.5f;
	public float strafeSpeed = 5.0f;
	private bool mode = true;
	private bool switchHeld;
	private GameObject bullet;
	public int bulletDelay;
	private int curDelay;
	//private Light light = gameObject.GetComponent<Light>();


	// Use this for initialization
	void Start () {
		switchHeld = false;
		bulletDelay = 10;

		theta = Mathf.PI / 2;
	}

	// Update is called once per frame
	void Update () {

		if (mode) {
			if (Input.GetKey ("left"))
			{
				theta += turnSpeed / 10.0f;
			}
			else if (Input.GetKey ("right"))
			{
				theta -= turnSpeed / 10.0f;
			}

			coreMovement ();
		}
		else
		{
			if (Input.GetKey ("left"))
			{
				Vector2 left = new Vector2(Mathf.Sin(theta + (Mathf.PI / 2)), -Mathf.Cos(theta + (Mathf.PI / 2)));
				transform.position += (Vector3)left * strafeSpeed * Time.deltaTime;
			}
			else if (Input.GetKey ("right"))
			{
				Vector2 right = new Vector2(Mathf.Sin(theta - (Mathf.PI / 2)), -Mathf.Cos(theta - (Mathf.PI / 2)));
				transform.position += (Vector3)right * strafeSpeed * Time.deltaTime;
			}

			coreMovement ();
		}
	}

	void OnCollisionEnter(Collision col)
	{

	}

	void switchMode()
	{
		if (Input.GetKey ("space"))
		{
			if (!switchHeld)
			{
				mode = !mode;
				switchHeld = true;
			}

			if (!mode)
			{
				if (Input.GetKey ("down"))
				{
					theta = 0.0f;
				}
				else if (Input.GetKey ("up"))
				{
					theta = Mathf.PI;
				}
				else if (Input.GetKey ("right"))
				{
					theta = Mathf.PI / 2;
				}
				else if (Input.GetKey ("left"))
				{
					theta = (2 * Mathf.PI) - (Mathf.PI / 2);
				}
			}
		}
		else
		{
			switchHeld = false;
		}
	}

	void coreMovement()
	{
		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

		if (Input.GetKey("s"))
		{
			transform.position += (Vector3)look * (speed * 3) * Time.deltaTime;
		}
		else
		{
			transform.position += (Vector3)look * speed * Time.deltaTime;
		}
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));
		
		switchMode ();

		if (Input.GetKey ("z"))
		{
			if (curDelay > bulletDelay)
			{
				//bullet = Instantiate(Resources.Load ("bulletTest"), transform.position, transform.rotation) as GameObject;
				bullet = Instantiate(Resources.Load ("bulletTest"), new Vector3(transform.position.x + (look.x * 0.8f), transform.position.y + (look.y * 0.8f), transform.position.z), transform.rotation) as GameObject;
				curDelay = 0;

				//Physics.IgnoreCollision(bullet.collider, transform.collider);
				//This isn't compatible with 2d colliders!
			}
		}

		curDelay++;

		/*if (Input.GetKey("g"))
		{
			bullet = Instantiate(Resources.Load ("scriptedProjectile"), new Vector3(transform.position.x + (look.x * 0.8f), transform.position.y + (look.y * 0.8f), transform.position.z), transform.rotation) as GameObject;
		}*/
	}
}