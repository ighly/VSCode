using UnityEngine;

public class playerMovement : MonoBehaviour {

public Rigidbody rb;

public float forwardForce =2000f;
public float sidewaysForce = 500f;

public Sprite fwdsprite;
public Sprite bcksprite;

	void Start ()
	{
	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		rb.AddForce(0,0,forwardForce * Time.deltaTime);

		if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(sidewaysForce * Time.deltaTime,0,0);
			rb.transform.eulerAngles = new Vector3(0,45,0);
			GetComponent<SpriteRenderer>().sprite = fwdsprite;
		}

		if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(-sidewaysForce * Time.deltaTime,0,0);
			rb.transform.eulerAngles = new Vector3(0,225,0);
			GetComponent<SpriteRenderer>().sprite = bcksprite;
		}

		if(Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(0,0,-sidewaysForce * Time.deltaTime);
			rb.transform.eulerAngles = new Vector3(0,45,0);
			GetComponent<SpriteRenderer>().sprite = bcksprite;
		}

		if(Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(0,0,sidewaysForce * Time.deltaTime);
			rb.transform.eulerAngles = new Vector3(0,225,0);
			GetComponent<SpriteRenderer>().sprite = fwdsprite;
		}
	}
}