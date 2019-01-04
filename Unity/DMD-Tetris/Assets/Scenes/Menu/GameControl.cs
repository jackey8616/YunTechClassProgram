using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    private GameController controller;

	// Use this for initialization
	void Start () {
        controller = GameController.Instance;
	}
	
    public void EnterGame() {
        controller.EnterGame();
    }

    public void ExitGame() {
        controller.ExitGame();
    }
}
