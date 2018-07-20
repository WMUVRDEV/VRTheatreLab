using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangPoint : MonoBehaviour {

	public LightingPositions position;
	public GameObject parentObj;
	void Start (){

		if (parentObj.transform.parent != null)
		{
			position = GetComponentInParent<LightingPositions>();
		}
	}
}
