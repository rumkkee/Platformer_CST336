using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, InteractableBlock
{
    private void OnCollisionEnter(Collision collision)
    {
        OnHit();
    }

    public void OnHit()
    {
        //Debug.Log("Brick hit!");
        ParticlesManager.instance.SpawnBrickParticles(this.transform.position);
        Destroy(gameObject);
    }
}
