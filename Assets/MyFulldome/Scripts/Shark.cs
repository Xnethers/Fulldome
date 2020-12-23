using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.Demo.SlotRacer.Utils;

public class Shark : MonoBehaviour
{
    public Animator animator;
    public string animateName;
    public bool isTrue;
    public SplineWalker bezier;
    public float speed = 1;

    void OnEnable() 
    {
        animator.SetBool(animateName,isTrue);
        bezier.Speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
