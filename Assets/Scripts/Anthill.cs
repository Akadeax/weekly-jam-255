using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthill : MonoBehaviour
{
    public float size = 1;

    [SerializeField]
    ParticleSystem antsParticles;

    void Start()
    {
        size = Random.Range(1f, 2f);
        transform.localScale = new Vector3(size, size, 0); 
    }

    public void GettingSucked()
    {
        antsParticles.Emit((int)size);
        Camera.main.GetComponent<CameraShake>().TriggerShake();
    }
}
