using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    [SerializeField] ParticleSystem brickParticles;

    public static ParticlesManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SpawnBrickParticles(Vector2 position)
    {
        Instantiate(brickParticles, position, Quaternion.identity, transform);
    }
}
