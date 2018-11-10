using UnityEngine;

public class playerMovement : MonoBehaviour {

public Rigidbody rb;

public float forwardForce =2000f;
public float sidewaysForce = 500f;

	// Update is called once per frame
	void FixedUpdate ()
	{
		rb.AddForce(0,0,forwardForce * Time.deltaTime);

		if(Input.GetKey("s"))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(sidewaysForce * Time.deltaTime,0,0);
		}

		if(Input.GetKey("w"))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(-sidewaysForce * Time.deltaTime,0,0);
		}

		if(Input.GetKey("a"))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(0,0,-sidewaysForce * Time.deltaTime);
		}

		if(Input.GetKey("d"))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(0,0,sidewaysForce * Time.deltaTime);
		}
	}
}
