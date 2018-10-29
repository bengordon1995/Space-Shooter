using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour {

	private float score;
	public TextMeshProUGUI textMesh;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime * 1000;
		int roundedScore = (int) score;
		textMesh.text = roundedScore.ToString();
	}
}
