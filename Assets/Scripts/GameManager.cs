using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Text forceText, oppforceText, frictionForce, friction;
	public Slider forceSlider, oppforceSlider;
	public GameObject item;
	public GameObject arrowPositive, arrowNegative, arrowfrictionPositive, arrowfrictionNegative;
	public GameObject arrowPositiveHead, arrowNegativeHead, arrowfrictionPositiveHead, arrowfrictionNegativeHead;
	public PhysicsMaterial2D phyMat;
	public Vector2 objectVelocity;
	public Vector3 localVel;

	public bool slowMotion;

	public float arrowScaleXfactor, frictionArrowScaleXfactor;

	public float forceValueX, oppforceValueX,frictionValue, maxfriction, frictionForceValue, gravityValue, massValue, staticFriction, dynamicFriction, dynamicFrictionValue;
	// Use this for initialization
	void Start () {

		frictionValue = phyMat.friction;
		gravityValue = item.GetComponent<Rigidbody2D> ().gravityScale;
		massValue = item.GetComponent<Rigidbody2D> ().mass;
		objectVelocity = item.GetComponent<Rigidbody2D> ().velocity;
		maxfriction = frictionValue * massValue * 9.8f * gravityValue ;
		frictionForceValue = 0;
		frictionForce.text = "0 N ";
		forceText.text = " 0 N";
		localVel = item.transform.InverseTransformDirection(objectVelocity);
	}

	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//updateValues ();
		updateV ();


	
	}

	public void showObject()
	{
		gameObject.SetActive (true);
	}

	public void hideObject()
	{
		gameObject.SetActive (false);
	}

	void updateValues(){

		forceValueX = forceSlider.value;
	
		//forceText.text =  "Force: " + forceValueX.ToString ("F1");
	
		frictionValue = phyMat.friction;

		massValue = item.GetComponent<Rigidbody2D> ().mass;
		maxfriction = frictionValue * massValue * 9.8f * gravityValue ;

		arrowScaleXfactor = Mathf.Sqrt (Mathf.Abs(forceValueX));
			
		if (objectVelocity.magnitude == 0) {
			if (Mathf.Abs (forceValueX) <= maxfriction) {

				frictionForceValue = forceValueX;
				frictionArrowScaleXfactor = Mathf.Sqrt ((Mathf.Abs (frictionForceValue)));
				frictionForce.text = "Friction Force: " + forceValueX.ToString ();

				if (forceValueX > 0) {
					arrowPositiveHead.SetActive (true);
					arrowNegativeHead.SetActive (false);
					arrowfrictionPositiveHead.SetActive (true);
					arrowfrictionNegativeHead.SetActive (false);
					arrowfrictionPositive.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
					arrowfrictionNegative.transform.localScale = Vector3.zero;
					arrowPositive.transform.localScale = new Vector3 (arrowScaleXfactor/2.2f, 0.05f, 0.01f)  ;
					arrowNegative.transform.localScale = Vector3.zero; 
				} else {
					if (forceValueX < 0) {
						arrowPositiveHead.SetActive (false);
						arrowNegativeHead.SetActive (true);
						arrowfrictionPositiveHead.SetActive (false);
						arrowfrictionNegativeHead.SetActive (true);
						arrowPositive.transform.localScale = new Vector3 (arrowScaleXfactor/2.2f, 0.05f, 0.01f)  ;
						arrowNegative.transform.localScale = Vector3.zero; 
					}
					arrowfrictionNegative.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
					arrowfrictionPositive.transform.localScale = Vector3.zero;
				}
			} else {

				frictionForceValue = maxfriction;
				frictionArrowScaleXfactor = Mathf.Sqrt ((Mathf.Abs (frictionForceValue)));
				frictionForce.text = "Friction Force: " + maxfriction.ToString ();
				if (forceValueX > 0) {
					arrowfrictionPositive.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
					arrowfrictionNegative.transform.localScale = Vector3.zero;
				} else {
					arrowfrictionNegative.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
					arrowfrictionPositive.transform.localScale = Vector3.zero;
				}

			
			}
		} 
		else {

			frictionForceValue = 0.8f * maxfriction;
			frictionArrowScaleXfactor = Mathf.Sqrt ((Mathf.Abs (frictionForceValue)));

			if(localVel.x > 0)
			{
				arrowPositiveHead.SetActive (true);
				arrowNegativeHead.SetActive (false);
				arrowfrictionPositiveHead.SetActive (true);
				arrowfrictionNegativeHead.SetActive (false);
				arrowfrictionPositive.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
				arrowfrictionNegative.transform.localScale = Vector3.zero;
				arrowPositive.transform.localScale = new Vector3 (arrowScaleXfactor/2.2f, 0.05f, 0.01f)  ;
				arrowNegative.transform.localScale = Vector3.zero;
				forceText.text = localVel.x.ToString();
				
			}
			else if(localVel.x < 0)
			{
				arrowPositiveHead.SetActive (false);
				arrowNegativeHead.SetActive (true);
				arrowfrictionPositiveHead.SetActive (false);
				arrowfrictionNegativeHead.SetActive (true);
				arrowfrictionNegative.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
				arrowfrictionPositive.transform.localScale = Vector3.zero;
				arrowNegative.transform.localScale = new Vector3 (arrowScaleXfactor/2.2f, 0.05f, 0.01f)  ;
				arrowPositive.transform.localScale = Vector3.zero;
				forceText.text = localVel.x.ToString();
			}

			else {
				arrowNegative.transform.localScale = new Vector3 (arrowScaleXfactor/2.2f, 0.05f, 0.01f)  ;
				arrowPositive.transform.localScale = Vector3.zero;
				
			}


		}

	}

	void updateV(){

		forceValueX = forceSlider.value;
		frictionValue = phyMat.friction;
		staticFriction = frictionValue ;
		dynamicFriction = frictionValue * 0.7f;
		massValue = item.GetComponent<Rigidbody2D> ().mass;
		maxfriction = staticFriction * massValue * 9.8f * gravityValue ;
		dynamicFrictionValue = dynamicFriction * massValue * 9.8f * gravityValue ;
		arrowScaleXfactor = Mathf.Sqrt (Mathf.Abs(forceValueX));
		objectVelocity = item.GetComponent<Rigidbody2D> ().velocity;
		forceText.text =  "Force: " + forceValueX.ToString ("F1");
		localVel = item.transform.InverseTransformDirection(objectVelocity); 

		if (forceValueX > 0) {
			arrowPositiveHead.SetActive (true);
			arrowNegativeHead.SetActive (false);
			arrowPositive.transform.localScale = new Vector3 (arrowScaleXfactor / 2.2f, 0.05f, 0.01f);
			arrowNegative.transform.localScale = Vector3.zero; 
		}
	

		else if (forceValueX < 0){

			arrowPositiveHead.SetActive (false);
			arrowNegativeHead.SetActive (true);
			arrowNegative.transform.localScale = new Vector3 (arrowScaleXfactor / 2.2f, 0.05f, 0.01f);
			arrowPositive.transform.localScale = Vector3.zero; 

		}


		if (objectVelocity.sqrMagnitude == 0) {

			frictionForceValue = forceValueX; 
			frictionArrowScaleXfactor = Mathf.Sqrt (Mathf.Abs (forceValueX));
			if (forceValueX >= 0) {

				arrowfrictionPositiveHead.SetActive (true);
				arrowfrictionNegativeHead.SetActive (false);
				arrowfrictionPositive.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
				arrowfrictionNegative.transform.localScale = Vector3.zero;

				
			} else {

				arrowfrictionPositiveHead.SetActive (false);
				arrowfrictionNegativeHead.SetActive (true);
				arrowfrictionNegative.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2.5f, 0.05f, 0.01f);
				arrowfrictionPositive.transform.localScale = Vector3.zero;
				
			}
			
		} 
		else {

			frictionForceValue = dynamicFrictionValue ;
			frictionArrowScaleXfactor = Mathf.Sqrt (Mathf.Abs (frictionForceValue));
			if(localVel.x >= 0.01)
			{
				arrowfrictionPositiveHead.SetActive (true);
				arrowfrictionNegativeHead.SetActive (false);
				arrowfrictionPositive.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2f, 0.05f, 0.01f);
				arrowfrictionNegative.transform.localScale = Vector3.zero;


			}
			else if (localVel.x <= 0.01)
			{
				arrowfrictionPositiveHead.SetActive (false);
				arrowfrictionNegativeHead.SetActive (true);
				arrowfrictionNegative.transform.localScale = new Vector3 (frictionArrowScaleXfactor / 2f, 0.05f, 0.01f);
				arrowfrictionPositive.transform.localScale = Vector3.zero;

			} 
		

		}
		
	}

	public void slowMotionFunc(){
		if (Time.timeScale == 1.0F)
			Time.timeScale = 0.1F;
		else
			Time.timeScale = 1.0F;
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}



}
