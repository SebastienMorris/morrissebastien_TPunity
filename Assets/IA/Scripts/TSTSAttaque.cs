using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TSTSAttaque : FSMState<TSTStateInfo>
{
    private float TimeShoot = 0;

    public override void doState(ref TSTStateInfo infos)
    {
        // Update is called once per frame
        Debug.Log("J'attaque!");
        TimeShoot -= Time.deltaTime;
            if (TimeShoot <= 0)
            {
                TimeShoot = infos.TimeBetweenShots;

                //Création du projetctile au bon endroit
                Transform proj = GameObject.Instantiate(infos.PrefabProjectile, infos.AI.transform.position + infos.AI.transform.forward * infos.OffsetForwardShoot, infos.AI.transform.rotation);
                proj.parent = infos.Parent;
                Vector3 dirct = new Vector3(infos.AI.transform.forward.x, infos.AI.transform.forward.y + infos.shotArc, infos.AI.transform.forward.z);
                //Ajout d une impulsion de départ
                proj.GetComponent<Rigidbody>().AddForce(dirct * infos.ProjectileStartSpeed, ForceMode.Impulse);
                infos.AI.GetComponent<NavMeshAgent>().SetDestination(infos.target.transform.position);
            }
    }
}
    
