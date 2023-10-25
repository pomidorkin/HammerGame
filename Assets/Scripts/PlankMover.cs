using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMover : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x >= 21.0f)
        {
            transform.localPosition = new Vector2(transform.localPosition.x - (21.0f * 2), transform.localPosition.y);
        }
    }
}
