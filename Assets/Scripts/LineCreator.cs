using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	int vertexCount = 0;
	bool mouseDown = false;
	LineRenderer line;

	void Awake () {
		line = GetComponent<LineRenderer> ();
	}

	void Start () {
		
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mouseDown = true;
		}

		if (mouseDown) {
			line.positionCount = vertexCount + 1;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			line.SetPosition (vertexCount, mousePos);
			vertexCount++;
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseDown = false;
			line.positionCount = 0;
			vertexCount = 0;
		}
	}

} // LineCreator