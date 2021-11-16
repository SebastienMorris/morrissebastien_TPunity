using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Canard : MonoBehaviour
{
    public float minSoundDelay = 1;
    public float randomDelay = 5;
    private float _nextSoundDelay = 0;
    private AudioSource _aSource;
    
    public float maxPitch = 2;
    public float minPitch = 0.1f;
    
    [Range(0.0f, 5.0f)]
    public float vitesseAvance = 2;
    [Range(0.0f, 360.0f)]
    public float vitesseTourne = 20;


    private void ComputeNextSoundDelay()
    {
        _nextSoundDelay = minSoundDelay + Random.Range(0, randomDelay);
    }

    private void Pitch()
    {
        _aSource = GetComponent<AudioSource>();
        _aSource.pitch = minPitch + Random.Range(0, maxPitch);
    }

    void Start()
    {
        _aSource = GetComponent<AudioSource>();
        ComputeNextSoundDelay();
        Pitch();
    }
    
    void Update()
    {
        _nextSoundDelay -= Time.deltaTime;
        if (_nextSoundDelay <= 0)
        {
            Pitch();
            _aSource.Play();
            ComputeNextSoundDelay();
        }
        //Faire des ronds dans l'eau
        transform.position += transform.forward * Time.deltaTime * vitesseAvance;
        transform.rotation = Quaternion.AngleAxis(vitesseTourne * Time.deltaTime, Vector3.up) * transform.rotation;
    }
}