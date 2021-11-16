using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCD : MonoBehaviour
{
    public List<Transform> Bones = new List<Transform>{};
    public int NbBonesLimit = 0;
    public Transform target;
    public float Blending = 0;
    
    private void doCCD(Vector3 targetPos, float blending)
    {
        for (int i = 1; i < Bones.Count && i <= NbBonesLimit; i++)
        {
            Vector3 directionActuelle = (Bones[0].position - Bones[i].position).normalized;
            Vector3 directionDesiree = (targetPos - Bones[i].position).normalized;
            Quaternion rotation = Quaternion.FromToRotation(directionActuelle, directionDesiree.normalized);
            Bones[i].rotation = Quaternion.Lerp(Bones[i].rotation , (rotation) * Bones[i].rotation, blending);
        }
    }

    private void Update()
    {
        doCCD(target.position,Blending);
    }
}
