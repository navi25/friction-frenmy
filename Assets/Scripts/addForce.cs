using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class addForce : MonoBehaviour {

	public Vector2 forceValue;
	public Slider forceSlider ;

	public Text preText, forceText, thresholdForce;
	private float forceValueX, forceValueY;


	public Vector3 forward, rearward;

	void Start()
	{
		forceValueX = 0;

		//forceText.fontSize = (int)Screen.height /15;
	}



	void FixedUpdate(){
		
		forceValueY = 0;
		forceValue = new Vector2(forceValueX, forceValueY);
		addforce ();

	}

	public void addforce(){

		gameObject.GetComponent<Rigidbody2D> ().AddForce (forceValue);


	}


	public  void valueforceChange()
	{
		forceValueX = forceSlider.value;
	}









}
