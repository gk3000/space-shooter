using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("Current")]
    [SerializeField] bool isUsedByEnemy;
    [SerializeField] float firingRateVariance = 0.2f;
    [SerializeField] float minFiringRate = 0.2f;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    // The Awake method is called when the script instance is being loaded
    void Awake()
    {
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isUsedByEnemy)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFire();
    }

    // update fire
    void UpdateFire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    // fire continuously 
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);

            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.linearVelocity = transform.up * projectileSpeed;       // always to Y direction
            }

            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,   // Calculates the time to wait before firing the next projectile, adding some variance, 
                                            baseFiringRate + firingRateVariance);            // and ensuring it doesn't go below the minimum firing rate
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);        // it can shoot only with this firingRate, even if it press the button super fast
        }
    }
}
