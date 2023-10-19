using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBeam : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }
}
