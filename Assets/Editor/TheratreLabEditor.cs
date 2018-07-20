using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class TheratreLabEditor : EditorWindow {
	public string[] lights = new string[] {"Leko", "Source Four", "Strip"};
	public string[] positions = new string[] {"FOH1", "1st Electric", "2nd Electric"};
	public string[] focusAreas = new string[] {"Area 1", "Area 2", "Bob"};
	public int index = 0;
	
	static float intensity = 0.0f;
	static float angle = 0.0f;
	private static float inchesApart = 0.0f;
	private float multiplier = 0;
	private float centerOfBar;
	private float seperationDist;
	private float anchorMov = 0;
	
	string positionName = "Position Name";
	
	int posHeight = 0;
	int posDepth = 0;
	int posWidth = 0;
	private int barWidthScale = 8;

	public bool starCenter;
	public bool startSplit;
	
	

	CreateHangLocations locationCreator = null;
	
	void OnEnable(){
		locationCreator = GameObject.Find("MakePipes").GetComponent<CreateHangLocations>();
	}
	

	[MenuItem ("Window/Theatre Lab")]
	
	
	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(TheratreLabEditor));
	}

	void OnGUI(){
		
		EditorGUILayout.TextField ("NEW LIGHT", EditorStyles.boldLabel);
		
		GUILayout.BeginVertical("box");
	
		EditorGUILayout.Space();
		
		index = EditorGUILayout.Popup("Light Type", index, lights);
		index = EditorGUILayout.Popup("Position", index, positions);
		index = EditorGUILayout.Popup("Focus To", index, focusAreas);
		intensity = EditorGUILayout.Slider("Intensity", intensity, 1, 100);
		angle = EditorGUILayout.Slider("Angle", angle, 1, 100);
		
		if (GUILayout.Button("Create Light")){
			
		}
		GUILayout.EndVertical();
		
		EditorGUILayout.TextField ("NEW POSITION", EditorStyles.boldLabel);
		
		GUILayout.BeginVertical("box");
		positionName = GUILayout.TextField (positionName, 25);;
		EditorGUILayout.Space();
		
		posHeight = EditorGUILayout.IntSlider("Height", posHeight, 0, 100);
		posDepth = EditorGUILayout.IntSlider("Depth", posDepth, -100, 100);
		posWidth = EditorGUILayout.IntSlider("Width", posWidth, 0, 100);
		inchesApart = EditorGUILayout.Slider("Seperation Distance", inchesApart, .1f, 50);
//  posHeight = EditorGUILayout.IntSlider("# of Hang Points)", posHeight, 0, 100);
		
		
		if (GUILayout.Button("Create Position")){
			GameObject	newPipe = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			newPipe.AddComponent<LightingPositions>();
			
			
			float heightConversion = posHeight * .3048f;
			float depthConversion = posDepth * .3048f;
			float widthConversion = posWidth * .3048f;
			newPipe.transform.position = new Vector3(0, heightConversion, depthConversion);

			newPipe.transform.Rotate(Vector3.forward * 90, Space.World);
			newPipe.transform.localScale = new Vector3(.1f, widthConversion, .1f);
			newPipe.tag = "LightingPosition";
			newPipe.name = positionName;
//	Creates Spheres for Snap Zones
			InstantiateSnapZones(newPipe, heightConversion, depthConversion, widthConversion);
		}
		GUILayout.EndVertical();
		
		
	}

	private void InstantiateSnapZones(GameObject newPipe, float heightConversion, float depthConversion, float widthConversion)
	{
//  Convert inchesApart from unity meters to inches *Doesnt Work Correctly Currently 7/11/18*
		seperationDist = Convert.ToSingle(inchesApart * .3048);
		centerOfBar = (widthConversion / 2);
		int i = 0;
		
		while (newPipe.transform.position.x + multiplier <= newPipe.transform.position.x + widthConversion-1)
		{

			multiplier = seperationDist * i;
			GameObject RightAnchorpoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			RightAnchorpoint.transform.position =
				new Vector3(newPipe.transform.position.x + multiplier, heightConversion, depthConversion);
			RightAnchorpoint.transform.localScale = new Vector3(.15f, .15f, .15f);
			RightAnchorpoint.AddComponent<Rigidbody>();
			RightAnchorpoint.transform.parent = newPipe.transform;
			GameObject LeftAnchorpoints = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			LeftAnchorpoints.transform.position =
				new Vector3(newPipe.transform.position.x - multiplier, heightConversion, depthConversion);
			LeftAnchorpoints.transform.localScale = new Vector3(.15f, .15f, .15f);
			LeftAnchorpoints.AddComponent<Rigidbody>();
			LeftAnchorpoints.transform.parent = newPipe.transform;

			i++;
		}

		Debug.Log(newPipe.transform.position.x);

		multiplier = 0;
	}
}
