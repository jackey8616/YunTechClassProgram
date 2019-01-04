using UnityEngine;

public class Bullet : MonoBehaviour {

    private bool triggered = false;
    private Gun gunObj;
    
	// Update is called once per frame
	void Update ()
    {
        gunObj = GameObject.Find("Gun").GetComponent<Gun>();
    }

    void OnTriggerEnter(Collider other) {
        string colliderName = other.gameObject.name;
        if (triggered || colliderName.Equals("BottomBorderPlane") || colliderName.Equals("Gun") || colliderName.Equals("Bullet"))
            return;
        triggered = !triggered;

        if (colliderName.Equals("MajorCube")) {
            gunObj.increaseScore();
        } else if (colliderName.Equals("Cube")) {
            gunObj.decreaseLife();
        }
        Destroy(gameObject);
    }
}
