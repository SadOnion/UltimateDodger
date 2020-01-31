﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    public ParticleSystem particle;
    public void Emit()
    {
        Instantiate(particle,transform.position,particle.transform.rotation);
    }
}
