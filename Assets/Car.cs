using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private ParticleSystem carSmoke;
    private AudioSource horn;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        horn = GetComponentInChildren<AudioSource>();

        carSmoke.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("Debo encontrar ayuda, tal vez algunas herramientas sirvan. . .");
            AudioManager.instance.PlaySound(SoundClips.CarLock);
            horn.Stop();
        }
    }
}
