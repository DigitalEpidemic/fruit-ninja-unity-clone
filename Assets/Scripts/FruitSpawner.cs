using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruit;
	public float maxX;

	void Start () {
		Invoke ("StartSpawning", 1f);
	}

	void Update () {
		
	}

	public void StartSpawning () {
		InvokeRepeating ("SpawnFruitGroups", 1f, 6f);
	}

	public void StopSpawning () {
		CancelInvoke ("SpawnFruitGroup");
		StopCoroutine ("SpawnFruit");
	}

	public void SpawnFruitGroups () {
		StartCoroutine ("SpawnFruit");
	}

	IEnumerator SpawnFruit () {
		for (int i = 0; i < 5; i++) {
			float rand = Random.Range (-maxX, maxX);
			Vector3 pos = new Vector3 (rand, transform.position.y, 0);
			GameObject f = Instantiate (fruit, pos, Quaternion.identity) as GameObject;
			f.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 15f), ForceMode2D.Impulse);
			f.GetComponent<Rigidbody2D> ().AddTorque (Random.Range (-20f, 20f));

			yield return new WaitForSeconds (0.5f);
		}
	}

} // FruitSpawner