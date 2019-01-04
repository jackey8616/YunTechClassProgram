using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int score = GameController.Instance.score;
        GameObject.Find("FinalScoreAmount").GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

}
