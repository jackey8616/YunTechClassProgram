using UnityEngine;

public class Gun : MonoBehaviour {
   
    public int unMissCount = 0;
    public int speedCount = 0;
    public int life = 3;

    public bool isDebug = false;
    public float period = 0.5F;
    public float gap = 0.3F;

    private int nowPosition = 0;
    private GameController gameControl;
    private UnityEngine.UI.Text scoreObj;
    private UnityEngine.UI.Text lifeObj;
    
    void Start() {
        gameControl = GameController.Instance;
        scoreObj = GameObject.Find("ScoreAmount").GetComponent<UnityEngine.UI.Text>();
        lifeObj = GameObject.Find("LifeAmount").GetComponent<UnityEngine.UI.Text>();
        updateText();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bullet.name = "Bullet";
            bullet.transform.position = this.transform.position;
            bullet.AddComponent<Bullet>();

            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(Vector3.forward * 300);

            Collider c = bullet.GetComponent<Collider>();
            c.isTrigger = true;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (nowPosition < 3) {
                Vector3 v = gameObject.transform.position;
                v.x += 1.5F;
                gameObject.transform.position = v;
                nowPosition++;
            } else {
                Vector3 v = gameObject.transform.position;
                v.x -= 1.5F * 6;
                gameObject.transform.position = v;
                nowPosition = -3;
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (nowPosition > -3) {
                Vector3 v = gameObject.transform.position;
                v.x -= 1.5F;
                gameObject.transform.position = v;
                nowPosition--;
            } else {
                Vector3 v = gameObject.transform.position;
                v.x += 1.5F * 6;
                gameObject.transform.position = v;
                nowPosition = 3;
            }
        }
    }

    void updateText () {
        this.scoreObj.text = gameControl.score.ToString();
        this.lifeObj.text = life.ToString();
    }

    public void increaseSpeedCount () {
        speedCount++;
        if (speedCount == 10) {
            if (this.period >= 0.2F)
                this.period -= this.period / 30; // 0.5 / 20 = 0.025
            //this.gap += 0.3F;
            //this.gap += 0.06F;    // 0.3 / 5
            //this.gap += 5.0F;
            speedCount = 0;
        }
        
    }

    public void decreaseSpeed () {
        //this.period += 0.025F;
        //this.gap -= 0.06F;
        //this.gap /= 2;
    }

    public void increaseUnMiss () {
        this.unMissCount++;
        if (this.unMissCount == 5) {
            this.increaseLife();
            this.resetUnMiss();
        }
        this.increaseSpeedCount();
    }

    public void decreaseUnMiss() {
        this.unMissCount--;
        if (this.unMissCount == -5) {
            this.resetUnMiss();
        }
    }

    public void resetUnMiss() {
        this.unMissCount = 0;
    }

    public void increaseScore () {
        this.gameControl.score++;
        this.increaseUnMiss();
        this.updateText();
    }

    public void decreaseScore () {
        this.gameControl.score--;
        this.updateText();
    }

    public void increaseLife() {
        this.life++;
        this.updateText();
    }

    public void decreaseLife() {
        this.life--;
        this.updateText();
        if (this.life == 0) {
            gameControl.OverGame();
        } else {
            decreaseUnMiss();
        }
    }
}
