using UnityEngine;
using System.Collections;

public class SpiralenGenerator : MonoBehaviour {
	
	public GameObject kugel_prefab;
	GameObject[] kugeln = new GameObject[10000];
	public GameObject spirale;
	public bool zeigeWerte;
	
	float windungenSlider = 1f;
	float amplitudenSlider = 5;
	float laengenSlider = 20;
	float windungsAnzahlSlider = 5;
	float kugelnProWindungSlider = -1;
	
	
	void Start ()
	{
	}
	
	void OnGUI()
	{
		if(zeigeWerte)
		{
			GUILayout.BeginArea(new Rect(0,Screen.height * 0.2f,Screen.width * 0.3f,Screen.height));
			
			if(GUILayout.Button("Reset"))
			{
				CreateSpiral(amplitudenSlider,laengenSlider,windungsAnzahlSlider,windungenSlider,kugelnProWindungSlider);
			}
			GUILayout.Label("Frequenz: " + windungenSlider);
			windungenSlider = GUILayout.HorizontalSlider(windungenSlider,0,20);
			GUILayout.Label("Amplitude: " + amplitudenSlider);
			amplitudenSlider = GUILayout.HorizontalSlider(amplitudenSlider,0,10);
			GUILayout.Label("Laenge: " + laengenSlider);
			laengenSlider = GUILayout.HorizontalSlider(laengenSlider,0,1000);
			GUILayout.Label("Windungen2: " + windungsAnzahlSlider);
			windungsAnzahlSlider = GUILayout.HorizontalSlider(windungsAnzahlSlider,0,100);
			GUILayout.Label("Kugeln/Windung: " + kugelnProWindungSlider);
			kugelnProWindungSlider = GUILayout.HorizontalSlider(kugelnProWindungSlider,0,100);
			
			GUILayout.EndArea();
		}
	}
	
	public void CreateSpiral(float amplitude,float laenge,float windungsAnzahl,float frequenz = 1,float kugelnProWindung = -1)
	{
		float y = 0,z = 0;
		windungsAnzahl *= 2 * Mathf.PI;
		if(kugelnProWindung == -1)
			kugelnProWindung = laenge / (Mathf.Pow(laenge,1.1f) / 20);
		
		if(spirale != null)
			Destroy(spirale.gameObject);
		spirale = new GameObject();
		spirale.gameObject.name = "Spirale";
		
		for(int i = 0; i < windungsAnzahl * kugelnProWindung; i++)
		{
			float x = i / kugelnProWindung;
			
			y = Mathf.Sin(x * frequenz) * amplitude;
			z = Mathf.Cos(x * frequenz) * amplitude;
			
			kugeln[i] = Instantiate(kugel_prefab,new Vector3((float)i * laenge / windungsAnzahl / kugelnProWindung,y,z),Quaternion.identity) as GameObject;
			kugeln[i].transform.parent = spirale.transform;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
