using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    public Rigidbody _RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            _RigidBody.velocity = Vector3.forward;
        }
    }
}
