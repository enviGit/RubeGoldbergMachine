using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Wiatr : MonoBehaviour
{
    public Transform obj;
    ParticleSystem particlesSystem;
    ParticleSystem.Particle[] particles;
    Rigidbody myRigidbody;

    void Start()
    {
        particlesSystem = gameObject.GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[1];
        StartCoroutine(Particlesy());
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public IEnumerator Particlesy()
    {
        yield return new WaitForSeconds(25f);
        particlesSystem.GetParticles(particles);

        myRigidbody.velocity += particles[0].velocity;
        particles[0].position = myRigidbody.position;
        particles[0].velocity = Vector3.zero;

        particlesSystem.SetParticles(particles, 1);
    }

    public void SetupParticleSystem()
    {
        particlesSystem.startLifetime = Mathf.Infinity;
        particlesSystem.startSpeed = 0;
        particlesSystem.simulationSpace = ParticleSystemSimulationSpace.World;
        particlesSystem.maxParticles = 1;
        particlesSystem.emissionRate = 1;

        particlesSystem.Emit(1);
        particlesSystem.GetParticles(particles);
        particles[0].position = Vector3.zero;
        particlesSystem.SetParticles(particles, 1);
    }
}