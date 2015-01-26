using UnityEngine;
using System.Collections;

public class testObstacle : MonoBehaviour {
	
	private GameObject obj, clone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "PlayerBullet")
		{
			Destroy(this.gameObject);
		}
	}
}
