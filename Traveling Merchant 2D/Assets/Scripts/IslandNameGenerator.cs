using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandNameGenerator : MonoBehaviour {

	public TextMesh islandNameText;
	public string[] islandNames;

	void Start () {
		islandNameText.text = islandNames [Random.Range (0, islandNames.Length)];
	}

	void Update () {
		
	}
}
