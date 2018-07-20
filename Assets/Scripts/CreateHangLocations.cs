using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Transform;

public class CreateHangLocations : MonoBehaviour {
	
	public GameObject basicPipe;
	public GameObject hangPoint;
	private GameObject newPipe; 
	float heightConversion;
	string name;

	// Use this for initialization
	void Start () {
		var newPipe = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//basicPipe.transform.localScale.x = width;
		//basicPipe.transform.position.y = height;
		//basicPipe.transform.position.z = depth;
	}
	
 public	void CreatePosition(string name, int height){
	 newPipe = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
	 heightConversion = height * .34f;
	 newPipe.transform.position = new Vector3(0, heightConversion, 0);

	 newPipe.transform.Rotate(Vector3.forward * 90, Space.World);
	 newPipe.tag = "LightingPosition";
	 newPipe.name = name;
	}
	


	void Update () {
		
	}
}
