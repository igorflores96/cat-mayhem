using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnStart : MonoBehaviour
{
    [SerializeField] private Transform _initialJumpLocal;
    [SerializeField] private Rigidbody catRigidBody;

    public void JumpThis()
    {
        Vector3 _inicialJump = _initialJumpLocal.position - transform.position;
        _inicialJump.y = 3f;
        catRigidBody.AddForce(_inicialJump.normalized * 3f, ForceMode.Impulse);
    }
}
