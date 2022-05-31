using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthill : MonoBehaviour
{
    public float size = 1;
    float antsInHill = 10;

    [SerializeField]
    ParticleSystem antsParticles;

    void Start()
    {
        size = Random.Range(1f, 2f);
        transform.localScale = new Vector3(size, size, 0);
        antsInHill = Random.Range(1000, 5000);
    }

    public void GettingSucked()
    {
        
        antsParticles.Emit((int)size);
        Camera.main.GetComponent<CameraShake>().TriggerShake();
        antsInHill--;
        if (antsInHill == 0)
        {
            Destroy(gameObject);
        }
    }
}
