using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour {
	[SerializeField] private float velocidade = 180f;

	void Update() {
		transform.localRotation = Quaternion.AngleAxis((velocidade * Time.time) % 360, Vector3.forward);
	}
}
