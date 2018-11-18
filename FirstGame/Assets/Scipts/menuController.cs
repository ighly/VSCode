using UnityEngine;

public class menuController : MonoBehaviour {

	private Canvas canvas;
	private playerMovement pm;
	public GameObject select;
	private int count = 0;
	public CanvasGroup itemMenu;
	private bool itemOn = false;

	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas>();
		pm = GameObject.Find("Player").GetComponent<playerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3[] positionArray = new Vector3[3];

		positionArray[0] = new Vector3(-141,108,0);
		positionArray[1] = new Vector3(-141,71,0);
		positionArray[2] = new Vector3(-141,145,0);

		Vector3[] itemArray = new Vector3[12]; 

		itemArray[0] = new Vector3(-25,140,0);
		itemArray[1] = new Vector3(139,140,0);
		itemArray[2] = new Vector3(-25,102,0);
		itemArray[3] = new Vector3(139,102,0);
		itemArray[4] = new Vector3(-25,63,0);
		itemArray[5] = new Vector3(139,63,0);
		itemArray[6] = new Vector3(-25,24,0);
		itemArray[7] = new Vector3(139,24,0);
		itemArray[8] = new Vector3(-25,-14,0);
		itemArray[9] = new Vector3(139,-14,0);
		itemArray[10] = new Vector3(-25,-51,0);
		itemArray[11] = new Vector3(139,-51,0);

		//toggle canvas, toggle player movement, move menu select to origin

		if(Input.GetKeyUp(KeyCode.Z))
		{
			if(!canvas.enabled)
			{
			canvas.enabled = true;
			pm.enabled = false;
			count=0;
			select.transform.localPosition = positionArray[2];
			itemMenu.alpha=0;
			}
			else
			{
				if(canvas.enabled)
				{
					itemMenu.alpha=1;
					itemOn = true;
					select.transform.localPosition = itemArray[0];
				}
			}			
		}

		if (Input.GetKeyUp(KeyCode.X))
		{
			if(!itemOn)
			{
				canvas.enabled = false;
				pm.enabled = true;
			}
			else {
				if (itemOn)
				{
					itemMenu.alpha = 0;
					itemOn=false;
				}
			}
		}

		//cycles through menu select positions
		if (Input.GetKeyUp(KeyCode.DownArrow) && canvas.enabled)
		{
			select.transform.localPosition = positionArray[count];
			count++;
			if (count>=3)
			{
				count=0;
			}
		}

		if (Input.GetKeyUp(KeyCode.UpArrow) && canvas.enabled)
		{
			select.transform.localPosition = positionArray[count];
			count--;
			if (count<=3)
			{
				count=0;
			}
		}
	}
}