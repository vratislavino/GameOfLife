using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 500, ForceMode.Impulse);
    }
}
