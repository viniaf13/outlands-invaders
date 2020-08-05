using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSoundSystem : MonoBehaviour
{
    [SerializeField] AudioClip laserSFX = default;
    [SerializeField] float timeBetweenLasers = 0.1f;
 
    private new ParticleSystem particleSystem;
    private bool isPlayingSound = false;
    private bool skipFirstUpdate = true;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particleSystem.emission.enabled && !isPlayingSound && !skipFirstUpdate)
        {
            StartCoroutine(PlayLaserSound());
        }
        skipFirstUpdate = false; //todo: arrumar essa gambiarra. Som do tiro tocando uma vez antes de começar
    }

    private IEnumerator PlayLaserSound()
    {
        isPlayingSound = true;
        yield return new WaitForSeconds(timeBetweenLasers); 
        AudioSource.PlayClipAtPoint(laserSFX, transform.position);
        isPlayingSound = false;
    }
}
