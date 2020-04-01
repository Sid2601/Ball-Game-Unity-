using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovment : MonoBehaviour {
    public Transform sphereloc;
    private Transform camerapos;
    public Vector3 offset;

    // Use this for initialization
    void Start () {
        camerapos = GetComponent<Transform>();
       
    }
	
	// Update is called once per frame
	void Update () {
        camerapos.position = sphereloc.position + offset;
	}
}
