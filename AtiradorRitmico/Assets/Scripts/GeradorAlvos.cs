using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorAlvos : MonoBehaviour {
	[SerializeField] private GameObject alvoPrefab;
	[SerializeField] private GameObject instancia;
	[SerializeField] private float raioAlcance = 4f;
	
	// Sempre que um alvo for destruído, outro alvo aparece
	void Update () {
		if (instancia == null) {
			instancia = Instantiate(alvoPrefab);
			instancia.transform.SetParent(transform);
			instancia.transform.position = Random.insideUnitCircle.normalized * raioAlcance; 
		}
	}
}
