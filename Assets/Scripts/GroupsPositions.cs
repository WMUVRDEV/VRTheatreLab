using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsPositions : MonoBehaviour {
	
	public List<GameObject> lPositions = new List<GameObject>();
	public List<LightingGroups> lGroups = new List<LightingGroups>();
	

	// Use this for initialization
	void Start () {
		
		foreach(GameObject LP in GameObject.FindGameObjectsWithTag("LightingPosition")) {
 
			lPositions.Add(LP);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}