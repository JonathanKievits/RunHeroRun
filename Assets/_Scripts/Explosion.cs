using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]private ParticleSystem _explosion;

    public void PlayParticle()
    {
        _explosion.Emit(10);
    }
}
