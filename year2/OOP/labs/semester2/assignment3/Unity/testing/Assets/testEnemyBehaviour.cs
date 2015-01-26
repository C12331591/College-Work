using UnityEngine;
using System.Collections;

public class testEnemyBehaviour : MonoBehaviour {

	private float speed;
	public Vector2 look;
	private float theta;
	//private GameObject player;
	//private float sideways;
	//private float timer;

	// Use this for initialization
	void Start () {
		speed = gameObject.GetComponent<enemyCore> ().speed;
		theta = gameObject.GetComponent<enemyCore> ().theta;
		//player = GameObject.FindWithTag("Player");
		//sideways = Mathf.PI / 2.0f;
		//timer = 2.5f;

		//theta = Random.Range (0.0f, Mathf.PI * 2.0f);
		//theta = -(Mathf.PI / 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Vector2.Distance(transform.position, player.transform.position) < 5.0f)
		{
			look = Vector2.Lerp(transform.position, player.transform.position, 1.0f);
		}
		else
		{
			look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));

			transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));

			theta += 0.01f;
		}*/

		/*timer -= Time.deltaTime;

		if (timer < 0)
		{
			sideways = -sideways;
			timer = 2.5f;
		}*/
		//theta = gameObject.GetComponent<enemyCore> ().theta;

		look = new Vector2 (Mathf.Sin (theta), -Mathf.Cos (theta));
		//Vector2 sideLook = new Vector2 (Mathf.Sin (theta + sideways), -Mathf.Cos (theta + sideways));
		transform.rotation = Quaternion.Euler (0.0f, 0.0f, theta * (180 / Mathf.PI));

		transform.position += (Vector3)look * speed * Time.deltaTime;
		//transform.position += (Vector3)sideLook * speed * Time.deltaTime;
	}
}
