using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLight : MonoBehaviour {

	public Canvas NewLightCanvas;
	public GameObject Leko;



	// Use this for initialization
	void Start () {
		NewLightCanvas.enabled = false;

	}
	
	void OnMouseDown(){
		//Instantiate(Leko, transform.position, Quaternion.identity);
		NewLightStart(); // pass position information
		}
	
	public void NewLightStart () {
		NewLightCanvas.enabled = true;
		// add a default name?
		// get light positions
		// get hangPoints
		//get groups
	
	}
	
	public void CreateNewLight(){
		
	}
	
	public void CancelNewLight(){
		NewLightCanvas.enabled = false;
	}
	
	
	
}
