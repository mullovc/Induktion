using UnityEngine;
using System.Collections;

public class ErregerSpule : MonoBehaviour {
	
	//InduktionsSpule induktionsSpule;
	public SpiralenGenerator spulenWickler;
	GameObject spule;
	
	public float B0;
	public float B1;
	public float I0;
	public float I1;
	public float N;
	public float l;
	float My0 = 4 * Mathf.PI * 0.0000001f;
	
	// Use this for initialization
	void Start ()
	{
		//induktionsSpule = induktionsSpule_prefab.GetComponent<InduktionsSpule>();
		spulenWickler.CreateSpiral(5,l,N);
		spule = spulenWickler.spirale;
		spule.transform.parent = this.transform;
	}
	
	float calcB()
	{
		return My0 * (N * I0) / (2 * Mathf.PI * l);
	}
	
	// Update is called once per frame
	void Update ()
	{
		B0 = calcB();
	}
}
