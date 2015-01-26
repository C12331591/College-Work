using UnityEngine;
using System.Collections;

public class explosionBehaviour : MonoBehaviour {

	private GameObject player;
	private GameObject[] enemies;
	private GameObject[] blockages;
	private float radius;
	private float decay;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");

		transform.position = player.GetComponent<Transform>().position;
		transform.localScale = new Vector3 (0, 0, 0);
		radius = player.GetComponent<playerBomb>().radius;
		decay = player.GetComponent<playerBomb>().decay;
	}
	
	// Update is called once per frame
	void Update () {
		float increase = Time.deltaTime * radius;
		transform.localScale = new Vector3 (transform.localScale.x + increase, transform.localScale.y + increase, transform.localScale.z);

		if (!player.GetComponent<playerBomb>().active)
		{
			Destroy(this.gameObject);
		}

		transform.position = player.GetComponent<Transform>().position;

		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		blockages = GameObject.FindGameObjectsWithTag ("Blockage");

		decay = player.GetComponent<playerBomb>().decay;

		foreach(GameObject cur in enemies)
		{
			if (Vector2.Distance(transform.position, cur.GetComponent<Transform>().position) <= (decay / 2))
			{
				Destroy(cur.gameObject);
			}
		}

		foreach(GameObject cur in blockages)
		{
			if (Vector2.Distance(transform.position, cur.GetComponent<Transform>().position) <= (decay / 2))
			{
				Destroy(cur.gameObject);
			}
		}
	}
}
