using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static GameController instance;
    public static GameController Instance {
        get{
            if (instance != null) {
                return instance;      // Early return the created instance 
            }
            
            instance = FindObjectOfType<GameController>();
            if (instance != null) {
                return instance;
            }

            GameObject obj = new GameObject("GameController");
            instance = obj.AddComponent<GameController>();

            return instance;
        }
    }

    public int score = 0;

    void Awake() {
        if (Instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void EnterGame() {
        score = 0;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void OverGame() {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void ExitGame () {
        Application.Quit();
    }

}
