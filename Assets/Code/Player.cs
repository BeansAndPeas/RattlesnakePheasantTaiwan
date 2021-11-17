using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private new Rigidbody rigidbody;

    void Start() {
        this.rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        if(PressingForward()) {
            this.rigidbody.AddForce(transform.forward);
        }
    }

    bool PressingForward() => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
}
