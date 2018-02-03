using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDestroyer : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Fruit" || target.gameObject.tag == "Bomb") {
			Destroy (target.gameObject);
		}
	}

} // FruitDestroyer