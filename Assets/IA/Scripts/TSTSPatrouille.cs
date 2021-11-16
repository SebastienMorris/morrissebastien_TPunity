using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TSTSPatrouille : FSMState<TSTStateInfo>
{
    private float timer = 5;

    public override void doState(ref TSTStateInfo infos)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log("Je patrouille!");
            infos.AI.GetComponent<NavMeshAgent>().SetDestination(Random.insideUnitSphere );
        }
    }
}

