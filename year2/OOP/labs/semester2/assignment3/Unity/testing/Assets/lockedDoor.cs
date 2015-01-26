using UnityEngine;
using System.Collections;

public class lockedDoor : MonoBehaviour {

	public bool needsRed;
	public bool needsBlue;
	public bool needsGreen;
	private Vector3 originalPosition;
	private float openDirection;
	private Vector2 look;

	// Use this for initialization
	void Start () {
		originalPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindWithTag("Player");
		Vector2 plrPos = player.GetComponent<Transform> ().position;

		if (Vector2.Distance(player.transform.position, transform.position) < 15.0f)
		{
			if ( ok() )
			{
				open();
			}
		}
		else
		{
			openDirection = 4.0f;
			close();
		}
	}

	void open()
	{
		if (openDirection == 4.0f)//if it's 4, the player just came into range
		{
			GameObject player = GameObject.FindWithTag("Player");
			
			Vector2 plrPos = player.GetComponent<Transform> ().position;
			
			float angle = Mathf.Atan2 ((plrPos.y - transform.position.y), (plrPos.x - transform.position.x));
			
			if (angleRange(angle, 0.0f))
			{
				openDirection = 0.0f;
			}
			else if (angleRange(angle, Mathf.PI / 2))
			{
				openDirection = Mathf.PI / 2;
			}
			else if (angleRange(angle, Mathf.PI) || angleRange(angle, -Mathf.PI))
			{
				openDirection = Mathf.PI;
			}
			else if (angleRange(angle, -Mathf.PI / 2))
			{
				openDirection = -Mathf.PI / 2;
			}
			else//it shouldn't get this far, but there's no harm in including this just in case
			{
				openDirection = Mathf.PI + (Mathf.PI / 4);//to make it clear when it didn't work
			}

			look = new Vector2 (Mathf.Sin (openDirection), -Mathf.Cos (openDirection));
		}

		if (Vector2.Distance(originalPosition, transform.position) < 10.0f)
		{
			transform.position += (Vector3)look * 3.0f * Time.deltaTime;
		}
	}

	void close()
	{
		if (Vector2.Distance(originalPosition, transform.position) > 0.1f)
		{
			//transform.position += (Vector3)look * 1.0f * Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime);
		}
	}

	bool ok()
	{
		GameObject player = GameObject.FindWithTag("Player");

		bool valid = true;

		if (needsRed)
		{
			valid = valid && player.GetComponent<playerStatus>().redKey;
		}

		if (needsBlue)
		{
			valid = valid && player.GetComponent<playerStatus>().blueKey;
		}

		if (needsGreen)
		{
			valid = valid && player.GetComponent<playerStatus>().greenKey;
		}

		return valid;
	}

	bool angleRange(float angle, float middle)
	{
		return ((angle >= (middle - (Mathf.PI / 4))) && (angle <= (middle + (Mathf.PI / 4))));
	}
}
