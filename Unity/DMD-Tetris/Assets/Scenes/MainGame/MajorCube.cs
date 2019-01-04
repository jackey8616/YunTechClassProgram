using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorCube : MonoBehaviour {

    public ArrayList cubes = new ArrayList();

    private bool triggered = false;

    private Gun gunObj;

    // Use this for initialization
    void Start () {
        gunObj = GameObject.Find("Gun").GetComponent<Gun>();
    }

    void OnTriggerEnter(Collider other) {
        if (triggered)
            return;
        triggered = !triggered;

        string colliderName = other.gameObject.name;
        if (colliderName.Equals("Bullet") || colliderName.Equals("Cube") || colliderName.Equals("MajorCube")) {
            foreach (GameObject obj in this.cubes) {
                Destroy(obj);
            }
            Destroy(gameObject);
        } else if (colliderName.Equals("BottomBorderPlane")) { // Touch bottom border
            foreach (GameObject obj in this.cubes) {
                Destroy(obj);
            }
            Destroy(gameObject);
            gunObj.decreaseLife();
        }
    }
}
