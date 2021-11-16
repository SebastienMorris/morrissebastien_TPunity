using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float posX = 0;
    public float posY = 4;
    public float posZ = -0.5f;
    public float MomentToThrow = 0.3f;
    public Transform Object;
    public int forceThrow = 15;

    public void ThrowTheObject()
    {
        Vector3 pos = new Vector3(posX, posY, posZ);
        Transform balle = Instantiate(Object, transform.position + pos, transform.rotation);
        balle.GetComponent<Rigidbody>().AddForce(transform.forward * forceThrow, ForceMode.Impulse);
    }
}
