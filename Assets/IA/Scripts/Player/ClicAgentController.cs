using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ClicAgentController : AgentController
{
    private Ray rayPickPos; //Déclaré ici pour pouvoir le visualiser, il doit rester accessible entre deux clics
    public Camera camera;
    public Transform winObject;

    void Update()
    {
        NoiseStatus n = transform.GetComponent<NoiseStatus>();
        if (Input.GetButtonDown("Fire1"))
        {
            rayPickPos = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rh;
            if (Physics.Raycast(rayPickPos, out rh))
            {
                FindPathTo(rh.point);
            }
        }
        if (Input.GetButton("Fire2"))
        {
            GetComponent<NavMeshAgent>().speed = 4;
            n.NoiseLevel = 1;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 2;  
            n.NoiseLevel = 0;
        }

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public new void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(rayPickPos.origin, rayPickPos.direction * 100);         
    }
    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name); 
    }
}
