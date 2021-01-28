using System.Linq;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public GameObject musclePrefab;
    public Bone[]     muscleBones;
    public Bone[]     rightJoints;
    public Bone[]     leftJoints;

    private Muscle[]   _muscles;

    private void Start()
    {
        InitBones();
        InitMuscles();
    }

    private void InitBones()
    {
        foreach (var bone in rightJoints)
            CreateHinge(bone, true);

        foreach (var bone in leftJoints)
            CreateHinge(bone, false);
    }

    private void CreateHinge(Bone bone, bool isRight)
    {
        var hinge = gameObject.AddComponent<HingeJoint2D>();
        hinge.connectedBody                = bone.GetComponent<Rigidbody2D>();
        hinge.autoConfigureConnectedAnchor = false;
        hinge.useLimits                    = true;
        var isMuscled = muscleBones.Any(bone.Equals);
        if (isRight)
        {
            hinge.anchor          = new Vector2(2,  0);
            hinge.connectedAnchor = new Vector2(-2, 0);
            var isAbove = hinge.jointAngle > 0;
            hinge.limits = new JointAngleLimits2D
            {
                max = isMuscled ? (isAbove ? 75 : 0)   : 75,
                min = isMuscled ? (isAbove ? 0  : -75) : -75
            };
        }
        else //isLeft
        {
            hinge.anchor          = new Vector2(-2, 0);
            hinge.connectedAnchor = new Vector2(2,  0);
            var isAbove = hinge.jointAngle < 0;
            hinge.limits = new JointAngleLimits2D()
            {
                min = isMuscled ? (isAbove ? -75 : 75) : 75,
                max = isMuscled ? 0 : -75
            };
        }
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
