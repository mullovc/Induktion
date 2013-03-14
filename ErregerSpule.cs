using UnityEngine;
using System.Collections;

public class ErregerSpule : MonoBehaviour {
	
	//InduktionsSpule induktionsSpule;
	public SpiralenGenerator spulenWickler_prefab;
	GameObject spule;
	
	public float B0;
	public float B1;
	public float I0;
	public float I1;
	public float N;
	public float l;
	public float A;
	public float r;
	float My0 = 4 * Mathf.PI * 0.0000001f;
	
	// Use this for initialization
	void Start ()
	{
		r = calcr();
		//induktionsSpule = induktionsSpule_prefab.GetComponent<InduktionsSpule>();
		SpiralenGenerator spulenWickler = Instantiate(spulenWickler_prefab) as SpiralenGenerator;
		spulenWickler.zeigeWerte = true;
		spulenWickler.CreateSpiral(r,l,N);
		spule = spulenWickler.spirale;
		spule.transform.parent = this.transform;
	}
	
	float calcB()
	{
		return My0 * (N * I0) / (2 * Mathf.PI * l);
	}
	
	float calcr()
	{
		return Mathf.Sqrt(A / Mathf.PI);
	}
	
	// Update is called once per frame
	void Update ()
	{
		B0 = calcB();
	}
}
