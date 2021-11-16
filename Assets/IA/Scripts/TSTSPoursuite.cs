using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TSTSPoursuite : FSMState<TSTStateInfo>
{
    public override void doState(ref TSTStateInfo infos)
    {
        Debug.Log("Je suis à sa poursuite !");
        infos.AI.GetComponent<NavMeshAgent>().SetDestination(infos.target.transform.position);
    }
}
