using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IG1EnemyController : AgentController
{
    public TSTStateInfo infos = new TSTStateInfo();
    public FSMachine<TSTSBase, TSTStateInfo> machine = new FSMachine<TSTSBase, TSTStateInfo>();
    void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseSight>().AddSenseHandler(new AISense<SightStimulus>.SenseEventHandler(HandleSight));
        GetComponent<AISenseSight>().AddObjectToTrack(player);
        GetComponent<AISenseHearing>().AddSenseHandler(new AISense<HearingStimulus>.SenseEventHandler(HandleHearing));
        GetComponent<AISenseHearing>().AddObjectToTrack(player);
    }

    void HandleSight(SightStimulus sti, AISense<SightStimulus>.Status evt)
    {
        if (evt == AISense<SightStimulus>.Status.Enter)
        {
            Debug.Log("Objet " + evt + " vue en " + sti.position);
            infos.CanSeeTarget = true;
            infos.CloseToTarget = true;
        }
        if (evt == AISense<SightStimulus>.Status.Stay)
        {
            infos.CanSeeTarget = true;
            infos.CloseToTarget = true;
        }
        if (evt == AISense<SightStimulus>.Status.Leave)
        {
            infos.CanSeeTarget = false;
            infos.CloseToTarget = false;
        }
    }

    void HandleHearing(HearingStimulus sti, AISense<HearingStimulus>.Status evt)
    {
        if (evt == AISense<HearingStimulus>.Status.Enter)
        {
            Debug.Log("Objet " + evt + " ouïe en " + sti.position);
            infos.CanSeeTarget = true;
            infos.CloseToTarget = true;
        }
        if (evt == AISense<HearingStimulus>.Status.Stay)
        {
            infos.CanSeeTarget = true;
            infos.CloseToTarget = true;
        }

        if (evt == AISense<HearingStimulus>.Status.Leave)
        {
            infos.CanSeeTarget = true;
            infos.CloseToTarget = true;
        }
    }

    void Update()
    {
        machine.Update(infos);
    }
    
}
