using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticleController : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreatDustParticle()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}
