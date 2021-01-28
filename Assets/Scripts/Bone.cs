using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bone : MonoBehaviour
{
    public  GameObject musclePrefab;
    public  Bone[]     muscleBones;
    public  Bone[]     joints;

    private Muscle[]   _muscles;

    private void Start()
    {
        InitMuscles();
    }

    private void InitBones()
    {
        
    }

    private void InitMuscles()
    {
        _muscles = new Muscle[muscleBones.Length];
        for (var i = 0; i < _muscles.Length; i++)
        {
            var muscle = Instantiate(musclePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Muscle>();
            muscle.fromBone = this;
            muscle.toBone   = muscleBones[i];
            _muscles[i]     = muscle;
        }
    }
}
