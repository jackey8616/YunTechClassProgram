using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour {

    public GameObject baseObject;
    private Gun gunScript;

    private bool isDebug = false;
    private float period;
    private float gap;
    private int materialIndex = 0;
    private Material[] cubeMaterials = new Material[2];
    private Material targetCube;
    private float cubeVelocity;
    private float leftTime;

    // Use this for initialization
    void Start () {
        this.gunScript = GameObject.Find("Gun").GetComponent<Gun>();
        this.updateParameter();
        
        this.targetCube = Resources.Load("TargetCube") as Material;
        this.cubeMaterials[0] = Resources.Load("CubeMatA") as Material;
        this.cubeMaterials[1] = Resources.Load("CubeMatA") as Material;
        //this.cubeMaterials[1] = Resources.Load("CubeMatB") as Material;
    }
	
	// Update is called once per frame
	void Update () {
        this.leftTime -= Time.deltaTime;
        if (this.leftTime < 0) {
            int emptyIndex = Random.Range(-3, 4);
            GameObject majorObject = null;
            ArrayList childCubes = new ArrayList();

            for (int i = -3; i < 4; ++i) {
                GameObject clone = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Vector3 v = new Vector3(Vector3.zero.x - 1.0F * i, 1.0F, Vector3.zero.z + 4.0F);
                clone.transform.parent = baseObject.transform;
                clone.transform.localPosition = v;

                Rigidbody rb = clone.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.velocity = Vector3.back * this.cubeVelocity;
                
                BoxCollider bc = clone.AddComponent<BoxCollider>();
                bc.isTrigger = true;

                if (i == emptyIndex) {
                    majorObject = clone;
                    majorObject.name = "MajorCube";
                    majorObject.AddComponent<MajorCube>();
                    // majorObject.GetComponent<Renderer>().material = targetCube;
                } else {
                    clone.name = "Cube";
                    clone.GetComponent<Renderer>().material = cubeMaterials[this.materialIndex];
                    childCubes.Add(clone);
                }
            }
            majorObject.GetComponent<MajorCube>().cubes = childCubes;
            
            if (this.isDebug)
                this.leftTime = this.period;
            else
                this.leftTime = Random.Range(this.period, this.period * 7);
            this.materialIndex = this.materialIndex == cubeMaterials.Length - 1 ? 0 : this.materialIndex + 1;
            this.updateParameter();
        }
	}

    void updateParameter() {
        this.period = this.gunScript.period;
        this.gap = this.gunScript.gap;
        this.isDebug = this.gunScript.isDebug;

        this.cubeVelocity = (1 + this.gap) / this.period;
    }
}
