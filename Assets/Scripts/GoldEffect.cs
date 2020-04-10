using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem goldEffect;

    public void PlayGoldEffect()
    {
        goldEffect.Play();
    }
}
