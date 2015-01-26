using UnityEngine;
using System.Collections;

public class bulletCore : MonoBehaviour {

	public int decay;
	public float speed;
	public float damage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (decay-- < 0)
		{
			Destroy(this.gameObject);
		}
	}
}
