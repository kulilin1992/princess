using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGem : MonoBehaviour
{
    [SerializeField] float resetTime = 3.0f;
    [SerializeField] AudioClip pickupSound;

    [SerializeField] ParticleSystem pickUpVFX;

    AudioSource audioSource;

    new Collider collider;

    MeshRenderer meshRenderer;

    WaitForSeconds waitResetTime;

    void Awake()
    {
        collider = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        waitResetTime = new WaitForSeconds(resetTime);
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.CanAirJump = true;
            collider.enabled = false;
            meshRenderer.enabled = false;


            audioSource.PlayOneShot(pickupSound);
            Instantiate(pickUpVFX, transform.position, transform.rotation);

            StartCoroutine(nameof(ResetCoroutine));
        }
    }

    void Reset ()
    {
        collider.enabled = true;
        meshRenderer.enabled = true;
    }
    IEnumerator ResetCoroutine()
    {
        yield return waitResetTime;
        Reset();
    }
}
