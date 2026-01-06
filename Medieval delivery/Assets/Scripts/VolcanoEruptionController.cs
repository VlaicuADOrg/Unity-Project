using System.Collections;
using UnityEngine;

public class VolcanoEruptionController : MonoBehaviour
{
    [Header("Particle systems to control")]
    [SerializeField] private ParticleSystem[] eruptionSystems;

    [Header("Timing (seconds)")]
    [SerializeField] private float minWaitBetweenEruptions = 15f;
    [SerializeField] private float maxWaitBetweenEruptions = 45f;

    [SerializeField] private float minEruptionDuration = 4f;
    [SerializeField] private float maxEruptionDuration = 10f;

    [Header("Optional: intensity")]
    [SerializeField] private bool scaleEmissionDuringEruption = true;
    [SerializeField] private float emissionMultiplier = 1.0f; 

    private Coroutine _loop;

    private void OnEnable()
    {
        StopAll();
        _loop = StartCoroutine(EruptionLoop());
    }

    private void OnDisable()
    {
        if (_loop != null) StopCoroutine(_loop);
        StopAll();
    }

    private IEnumerator EruptionLoop()
    {
        while (true)
        {
            float wait = Random.Range(minWaitBetweenEruptions, maxWaitBetweenEruptions);
            yield return new WaitForSeconds(wait);

            StartEruption();

            float duration = Random.Range(minEruptionDuration, maxEruptionDuration);
            yield return new WaitForSeconds(duration);

            StopEruption();
        }
    }

    public void StartEruption()
    {
        foreach (var ps in eruptionSystems)
        {
            if (!ps) continue;

            if (scaleEmissionDuringEruption)
            {
                var em = ps.emission;
                em.rateOverTimeMultiplier *= emissionMultiplier;
                em.rateOverDistanceMultiplier *= emissionMultiplier;
            }

            ps.Play(true);
        }
    }

    public void StopEruption()
    {
        foreach (var ps in eruptionSystems)
        {
            if (!ps) continue;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            if (scaleEmissionDuringEruption && emissionMultiplier != 0f)
            {
                var em = ps.emission;
                em.rateOverTimeMultiplier /= emissionMultiplier;
                em.rateOverDistanceMultiplier /= emissionMultiplier;
            }
        }
    }

    private void StopAll()
    {
        foreach (var ps in eruptionSystems)
        {
            if (!ps) continue;
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    public void TriggerNow(float duration = 6f)
    {
        if (_loop != null) StopCoroutine(_loop);
        StartCoroutine(TriggerRoutine(duration));
    }

    private IEnumerator TriggerRoutine(float duration)
    {
        StartEruption();
        yield return new WaitForSeconds(duration);
        StopEruption();
        _loop = StartCoroutine(EruptionLoop());
    }
}
