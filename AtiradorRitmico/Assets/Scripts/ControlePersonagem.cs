using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovimentoPersonagem))]
[RequireComponent(typeof(HabilidadeTiro))]
public class ControlePersonagem : MonoBehaviour {
	const int MOUSE_LEFT = 0;
	private MovimentoPersonagem movimento;
	private HabilidadeTiro habTiro;

	private Camera camera;
	private bool seguindoMouse = false;
	private Vector3 direction;

	[Header("Teclas")]
	[SerializeField] private KeyCode teclaTiroGrave = KeyCode.Z;
	[SerializeField] private KeyCode teclaTiroAgudo = KeyCode.X;
	[Header("Botões")]
	[SerializeField] private RectTransform areaBotoes;
	[SerializeField] private Button botaoTiroGrave;
	[SerializeField] private Button botaoTiroAgudo;

	void Awake () {
		movimento = GetComponent<MovimentoPersonagem>();
		habTiro = GetComponent<HabilidadeTiro>();
		if (botaoTiroGrave != null) botaoTiroGrave.onClick.AddListener(() => habTiro.Atirar(0));
		if (botaoTiroAgudo != null) botaoTiroAgudo.onClick.AddListener(() => habTiro.Atirar(1));

		camera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
	}
	
	void Update () {
		if (Input.GetKeyDown(teclaTiroGrave)) habTiro.Atirar(0);
		if (Input.GetKeyDown(teclaTiroAgudo)) habTiro.Atirar(1);
		Vector2 setas = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (setas.magnitude > 0.5f) {
			movimento.Andar (setas.normalized);
			seguindoMouse = false;
		} else {
			if (Input.GetMouseButtonDown (MOUSE_LEFT) && !clicandoBotoes()) {
				seguindoMouse = true;

				direction = new Vector3 ((float)Input.mousePosition.x / ((float)Screen.width / 2),
					(float)Input.mousePosition.y / ((float)Screen.height / 2), -1f);
				direction += Vector3.down + Vector3.left;
				direction.x *= (camera.orthographicSize * (float)Screen.width / Screen.height);
				direction.y *= camera.orthographicSize;
				direction += transform.position;
			}
			if (seguindoMouse) {
				if ((direction - transform.position).magnitude <= 0.2f) seguindoMouse = false;
				movimento.Andar ((direction - transform.position).normalized);
			} else {
				movimento.Andar (Vector2.zero);
			}
		}
	}

	bool clicandoBotoes() {
		Vector3[] corners = new Vector3[4];
		areaBotoes.GetWorldCorners(corners);

		return entre(corners[0].x, Input.mousePosition.x, corners[2].x)
			&& entre(corners[0].y, Input.mousePosition.y, corners[1].y);
	}

	bool entre(float min, float val, float max) {
		return (min <= val) && (val <= max);
	}
}
