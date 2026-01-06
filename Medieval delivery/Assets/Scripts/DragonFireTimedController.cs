using System.Collections;
using UnityEngine;

public class DragonFireTimedController : MonoBehaviour
{
    [Header("Particle systems (flame, embers, smoke)")]
    [SerializeField] private ParticleSystem[] fireSystems;

    [Header("Timing (seconds)")]
    [SerializeField] private float minWaitBetweenBreaths = 6f;
    [SerializeField] private float maxWaitBetweenBreaths = 18f;

    [SerializeField] private float minBreathDuration = 1.5f;
    [SerializeField] private float maxBreathDuration = 4f;

    [Header("Optional: start enabled?")]
    [SerializeField] private bool startAutomatically = true;

    private Coroutine _loop;

    private void Start()
    {
        StopAll();

        if (startAutomatically)
            _loop = StartCoroutine(BreathLoop());
    }

    private IEnumerator BreathLoop()
    {
        while (true)
        {
            float wait = Random.Range(minWaitBetweenBreaths, maxWaitBetweenBreaths);
            yield return new WaitForSeconds(wait);

            StartFire();

            float duration = Random.Range(minBreathDuration, maxBreathDuration);
            yield return new WaitForSeconds(duration);

            StopFire();
        }
    }

    public void StartFire()
    {
        foreach (var ps in fireSystems)
        {
            if (!ps) continue;
            ps.Play(true);
        }
    }

    public void StopFire()
    {
        foreach (var ps in fireSystems)
        {
            if (!ps) continue;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void StopAll()
    {
        foreach (var ps in fireSystems)
        {
            if (!ps) continue;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    public void TriggerBreathNow(float duration = 3f)
    {
        if (_loop != null) StopCoroutine(_loop);
        StartCoroutine(TriggerRoutine(duration));
    }

    private IEnumerator TriggerRoutine(float duration)
    {
        StartFire();
        yield return new WaitForSeconds(duration);
        StopFire();
        _loop = StartCoroutine(BreathLoop());
    }
}
