using UnityEngine;
using System.Collections;

public class playerBomb : MonoBehaviour {

	public bool active;
	public float radius;
	public float decay;
	private bool held;
	private GameObject explosion;
	public bool hasBomb;

	// Use this for initialization
	void Start () {
		decay = 0.0f;
		held = false;
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("b"))
		{
			if (!held && !active && hasBomb)
			{
				active = true;
				explosion = Instantiate(Resources.Load ("plrbomb"), new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
			}

			held = true;
		}
		else
		{
			held = false;
		}

		if (active)
		{
			decay += (Time.deltaTime * radius);

			if (decay > radius)
			{
				active = false;
				decay = 0.0f;
			}
		}
	}
}
