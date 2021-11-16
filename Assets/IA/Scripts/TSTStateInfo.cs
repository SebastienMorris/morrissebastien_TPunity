using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class TSTStateInfo : FSMStateInfo
{
    public bool CanSeeTarget;
    public bool CloseToTarget;
    public float PcentLife;
    
    public Transform AI;
    public Transform Parent;
    public Transform target;
    public Transform PrefabProjectile;
    
    public float ProjectileStartSpeed = 5;
    public float OffsetForwardShoot = 2;
    public float TimeBetweenShots = 0.5f;
    public float shotArc = 0;
}
