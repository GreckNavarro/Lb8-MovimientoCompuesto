using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 5.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            Destroy(gameObject, 3.0f);
        }
    }
}
