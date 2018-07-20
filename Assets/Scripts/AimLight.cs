using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLight : MonoBehaviour {

	public Transform target;
	public Transform yolkPivot;
	public Transform bodyPivot;

	void Awake(){
		Body();
	}

	void Start () {
		
		Yolk();
		
	}
	
	void Yolk (){
		Vector3 targetPostitionYolk = new Vector3( target.position.x, yolkPivot.position.y, target.position.z ) ;
		yolkPivot.transform.LookAt( targetPostitionYolk ) ;
	}
	
	void Body (){
		Vector3 targetPostitionBody = new Vector3( bodyPivot.position.x, target.position.y, target.position.z ) ;
		bodyPivot.transform.LookAt( targetPostitionBody ) ;
	}

}
