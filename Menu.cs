using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	
	bool menuIsOpen;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(Screen.width * 0.8f,0,Screen.width * 0.2f,Screen.height * 0.2f),"Settings"))
			menuIsOpen = true;
		if(menuIsOpen)
			GUI.Window(0,new Rect(0,0,Screen.width,Screen.height),createWindow,"Settings");
	}
	
	void createWindow(int a)
	{
		GUILayout.BeginArea(new Rect(20,20,Screen.width - 80,Screen.height - 40));
		
		if(GUILayout.Button("Create"))
			print ("asfd");
			
		
		GUILayout.EndArea();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
