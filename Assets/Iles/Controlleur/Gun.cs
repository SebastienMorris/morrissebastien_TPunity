using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Controller MyController;
    public Transform PrefabProjectile;
    public float ProjectileStartSpeed = 50;
    public float OffsetForwardShoot = 2;
    public float TimeBetweenShots = 0.5f;
    private float TimeShoot = 0;
    public Transform Parent;

    // Update is called once per frame
    void Update()
    {
        TimeShoot -= Time.deltaTime;

        if (MyController.WantsToShoot && TimeShoot <= 0)
        {
            TimeShoot = TimeBetweenShots;

            //Création du projetctile au bon endroit
            Transform proj = GameObject.Instantiate(PrefabProjectile, transform.position + transform.forward * OffsetForwardShoot, transform.rotation);
            proj.parent = Parent;           
            //Ajout d une impulsion de départ
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileStartSpeed, ForceMode.Impulse);
            if (Input.GetButton("Fire2"))
            {
                foreach (Transform child in Parent)
                {
                    GameObject.Destroy(child.gameObject);
                }
            }
        }
    }
}
