using UnityEngine;

public class menuController : MonoBehaviour {

	private Canvas canvas;
	private playerMovement pm;
	public GameObject select; 
	private int count = 0;


	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas>();
		pm = GameObject.Find("Player").GetComponent<playerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Z))
		{
			canvas.enabled = !canvas.enabled;
			pm.enabled = !pm.enabled;
			count = 0;
		} 

		Vector3[] positionArray = new Vector3[3];

		positionArray[0] = new Vector3(-141,108,0);
		positionArray[1] = new Vector3(-141,71,0);
		positionArray[2] = new Vector3(-141,145,0);

		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			select.transform.localPosition = positionArray[count];
			count++;
			if (count>=3)
			{
				count=0;
			}
		}
	}
}