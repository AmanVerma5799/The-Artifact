using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    [SerializeField] private GameObject slashPrefab;
    [SerializeField] private float cooldown = 0.3f;

    private float timer;

    private AudioSource audioSource;
    private Camera maincamera;
    private GameObject artifact;

    private Vector3 spawnPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        maincamera = Camera.main;
        artifact = GameObject.FindWithTag("Artifact");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timer)
        {
            SlashAttack();
            audioSource.Play();

            timer = Time.time + cooldown;
        }
    }

    void SlashAttack()
    {
        if(!artifact)
        {
            return;
        }

        spawnPosition = maincamera.ScreenToWorldPoint(Input.mousePosition);
        spawnPosition.z = 0;

        Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
    }
}
