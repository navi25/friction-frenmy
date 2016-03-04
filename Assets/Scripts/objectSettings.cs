using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class objectSettings : MonoBehaviour {

	public GameObject settingPanel; 
	public Slider massSlider, frictionSlider, gravitySlider;
	public PhysicsMaterial2D phyMat;
	public Text frictionValue, gravityValue, massValue;
	private Rigidbody2D body;

	void Start(){

		body = gameObject.GetComponent<Rigidbody2D> ();


	}


		
	void OnMouseOver()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			settingPanel.gameObject.SetActive (true);
		}


		
	}

	public void changeMass()
	{
		body.mass = massSlider.value;
		massValue.text = massSlider.value.ToString("F1") + " Kg";
	}

	public void changeFriction(){

		phyMat.friction = frictionSlider.value;
		frictionValue.gameObject.SetActive (true);
		frictionValue.text = frictionSlider.value.ToString("F1");
	}

	public void changeGravityValue(){

		body.gravityScale = gravitySlider.value;
		gravityValue.gameObject.SetActive (true);
		gravityValue.text = gravitySlider.value.ToString("F1");
	}

	public void hideObject(){
	
		settingPanel.SetActive (false);
	}





}
