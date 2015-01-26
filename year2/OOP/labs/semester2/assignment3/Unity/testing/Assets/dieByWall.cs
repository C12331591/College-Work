using UnityEngine;
using System.Collections;

public class dieByWall : MonoBehaviour {

	public bool Wall = false;
	public bool Door = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Wall" && Wall)
		{
			Destroy(this.gameObject);
		}

		if (col.gameObject.tag == "Door" && Door)
		{
			Destroy(this.gameObject);
		}
	}
}
