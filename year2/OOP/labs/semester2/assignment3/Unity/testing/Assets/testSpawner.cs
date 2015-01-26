using UnityEngine;
using System.Collections;

public class testSpawner : MonoBehaviour {

	private bool held;
	private GameObject spawner;
	private GameObject player;
	public string spawn;//this value must be set in the editor
	public float radius;//ditto
	public int spawnNumber;//ditto

	private float timer;
	private int curSpawn;

	// Use this for initialization
	void Start () {
		held = false;
		player = GameObject.FindWithTag("Player");
		timer = 0.0f;
		curSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftAlt))
		{
			if (!held)
			{
				spawner = Instantiate(Resources.Load (spawn), new Vector3(transform.position.x, transform.position.y, 0.0f), transform.rotation) as GameObject;
			}

			held = true;
		}
		else
		{
			held = false;
		}

		if (Vector2.Distance(player.transform.position, transform.position) < radius)
		{
			if (timer > (0.5))
			{
				if (curSpawn < spawnNumber)
				{
					spawner = Instantiate(Resources.Load (spawn), new Vector3(transform.position.x, transform.position.y, 0.0f), transform.rotation) as GameObject;
					curSpawn++;
				}

				timer = 0.0f;
			}

			timer += Time.deltaTime;
		}
		else
		{
			curSpawn = 0;
			timer = 0.0f;
		}
	}
}
