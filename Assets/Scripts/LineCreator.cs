using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	int vertexCount = 0;
	bool mouseDown = false;
	LineRenderer line;

	public GameObject blast;

	public GameObject splash;

	void Awake () {
		line = GetComponent<LineRenderer> ();
	}

	void Start () {
		
	}

	void Update () {
		// Android specific code
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				// Gets only the first touch (No multi-touch)
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					line.positionCount = vertexCount + 1;
					Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					line.SetPosition (vertexCount, mousePos);
					vertexCount++;

					BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
					box.transform.position = line.transform.position;
					box.size = new Vector2 (0.1f, 0.1f);
				}

				if (Input.GetTouch (0).phase == TouchPhase.Ended) {
					line.positionCount = 0;
					vertexCount = 0;

					BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();
					foreach (BoxCollider2D box in colliders) {
						Destroy (box);
					}
				}
			}

		// Windows specific code (Editor)
		} else if (Application.platform == RuntimePlatform.WindowsEditor) {

			if (Input.GetMouseButtonDown (0)) {
				mouseDown = true;
			}

			if (mouseDown) {
				line.positionCount = vertexCount + 1;
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				line.SetPosition (vertexCount, mousePos);
				vertexCount++;

				BoxCollider2D box = gameObject.AddComponent<BoxCollider2D> ();
				box.transform.position = line.transform.position;
				box.size = new Vector2 (0.1f, 0.1f);
			}

			if (Input.GetMouseButtonUp (0)) {
				mouseDown = false;
				line.positionCount = 0;
				vertexCount = 0;

				BoxCollider2D[] colliders = GetComponents<BoxCollider2D> ();
				foreach (BoxCollider2D box in colliders) {
					Destroy (box);
				}
			}
		}
	} // Update

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Bomb") {
			GameObject b = Instantiate (blast, target.transform.position, Quaternion.identity) as GameObject;
			Destroy (b.gameObject, 2f);
			Destroy (target.gameObject);
		}

		if (target.gameObject.tag == "Fruit") {
			GameObject s = Instantiate (splash, new Vector3(target.transform.position.x -1, target.transform.position.y,0), Quaternion.identity) as GameObject;
			Destroy (s.gameObject, 2f);
			Destroy (target.gameObject);
		}
	}

} // LineCreator