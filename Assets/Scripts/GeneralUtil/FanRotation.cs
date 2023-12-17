using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    Transform trans;
    Vector3 r = Vector3.zero;

    private void Awake()
    {
        trans = GetComponent<Transform>();
    }
    void Update()
    {
        trans.RotateAround(trans.position, Vector3.forward, 20f * Time.deltaTime);
    }
}
