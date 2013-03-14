using UnityEngine;
using System.Collections;

public class InduktionsSpule : MonoBehaviour {
	
	public GameObject erregerSpule_prefab;
	ErregerSpule erregerSpule;
	public SpiralenGenerator spulenWickler_prefab;
	GameObject spule;
	Elektron[] elekronen = new Elektron[100];
	public Elektron elektronen_prefab;
	
	public float t;
	public float v;
	public float N;
	public float r0;
	public float r1;
	public float Phi0;
	public float Phi1;
	public float alpha0;
	public float alpha1;
	public float Uind;
	public int ne;
	
	// Use this for initialization
	void Start ()
	{
		erregerSpule = erregerSpule_prefab.GetComponent<ErregerSpule>();
		SpiralenGenerator spulenWickler = Instantiate(spulenWickler_prefab) as SpiralenGenerator;
		spulenWickler.CreateSpiral(r0,0.001f,N);
		spule = spulenWickler.spirale;
		spule.transform.parent = this.transform;
		erstelleElektronen();
	}
	
	void erstelleElektronen()
	{
		for(int i = 0; i < ne; i++)
		{
			float y = 0, z = 0;
			
			y = Mathf.Sin(i * (2 * Mathf.PI / ne)) * r0;
			z = Mathf.Cos(i * (2 * Mathf.PI / ne)) * r0;
			
			elekronen[i] = Instantiate(elektronen_prefab,new Vector3(0.5f,y,z),Quaternion.identity) as Elektron;
			
			elekronen[i].s = i * (2 * Mathf.PI / ne) * r0;
		}
	}
	
	float calcUind()
	{
		return -N * (Phi1 - Phi0) / t;
	}
	
	float calcPhi()
	{
		return erregerSpule.B0 * Mathf.PI * r0 * r0;
	}
	
	void moveElectrons(bool uhrzeigersinn)
	{
		for(int i = 0; i < ne; i++)
		{
			if(uhrzeigersinn)
				elekronen[i].s += elekronen[i].v * Time.deltaTime;
			else
				elekronen[i].s -= elekronen[i].v * Time.deltaTime;
			
			elekronen[i].transform.position = new Vector3(0.5f,Mathf.Sin(elekronen[i].s / r0) * r0,Mathf.Cos(elekronen[i].s / r0) * r0);
			
			elekronen[i].vgesamt = v;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		t += Time.deltaTime;
		
		Phi0 = calcPhi();
		Uind = calcUind();
		moveElectrons(true);
	}
}
