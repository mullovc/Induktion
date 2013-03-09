using UnityEngine;
using System.Collections;

public class InduktionsSpule : MonoBehaviour {
	
	public GameObject erregerSpule_prefab;
	ErregerSpule erregerSpule;
	
	public float t;
	public float v;
	public float N;
	public float A0;
	public float A1;
	public float Phi0;
	public float Phi1;
	public float alpha0;
	public float alpha1;
	public float Uind;
	
	// Use this for initialization
	void Start ()
	{
		erregerSpule = erregerSpule_prefab.GetComponent<ErregerSpule>();
	}
	
	float calcUind()
	{
		return -N * (Phi1 - Phi0) / t;
	}
	
	float calcPhi()
	{
		return erregerSpule.B0 * A0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		t += Time.deltaTime;
		
		Phi0 = calcPhi();
		Uind = calcUind();
	}
}
