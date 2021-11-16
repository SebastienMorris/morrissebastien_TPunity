using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TSTSFuite : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je m'enfuie !");
        infos.AI.GetComponent<NavMeshAgent>().SetDestination(Random.insideUnitSphere * 5);
    }
}