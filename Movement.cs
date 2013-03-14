using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	float r;
	float s = Mathf.PI * 0.25f;
	GameObject spule;
	float alpha;
	
	// Use this for initialization
	void Start ()
	{
		
		spule = GameObject.Find("Erreger Spule");
		r = spule.GetComponent<ErregerSpule>().l;
	}
	
	void setCameraPos()
	{
		transform.position = new Vector3(Mathf.Cos(s / r) * r + r / 2,0,Mathf.Sin(s / r) * r);
		
		float deltaX = ((transform.position.x + r / 2) - spule.transform.position.x);
		float deltaZ = (transform.position.z - spule.transform.position.z) - 20;
		alpha = Mathf.Atan(deltaX / deltaZ) / (Mathf.PI / 180);
		
		if(deltaZ > 0)
			alpha += 180;
		
		transform.eulerAngles = new Vector3(0,alpha,0);
	}
	
	void OnGUI()
	{
		GUI.skin.button.fontSize = 40;
		
		GUILayout.BeginHorizontal();
		
		if(GUILayout.RepeatButton("left"))
			s--;
		if(GUILayout.RepeatButton("right"))
			s++;
		
		GUILayout.EndHorizontal();
	}
	
	// Update is called once per frame
	void Update ()
	{
		setCameraPos();
	}
}
