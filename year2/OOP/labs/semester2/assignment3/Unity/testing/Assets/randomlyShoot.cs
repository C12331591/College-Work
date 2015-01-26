using UnityEngine;
using System.Collections;

public class randomlyShoot : MonoBehaviour {

	public float chance;
	private GameObject bullet;
	private Vector2 look;
	private GameObject player;
	private Vector2 plrPos;

	// Use this for initialization
	void Start () {
		look = gameObject.GetComponent<testEnemyBehaviour> ().look;
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		plrPos = player.GetComponent<Transform> ().position;

		if ((int)Random.Range(0, chance) == 1 && Vector2.Distance(transform.position, plrPos) < 15.0f)
		{
			bullet = Instantiate(Resources.Load ("enemyBulletSeeker"), new Vector3(transform.position.x + (look.x * 0.8f), transform.position.y + (look.y * 0.8f), transform.position.z), transform.rotation) as GameObject;
		}
	}
}
