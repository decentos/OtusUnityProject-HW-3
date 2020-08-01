using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class SoundPlay : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioClip _damageClip;
    [SerializeField] private AudioClip _deathClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.clip = _clip;
        _audioSource.Play();
    }

    public void PlayDeath()
    {
        _audioSource.clip = _deathClip;
        _audioSource.Play();
    }

    public void PlayDamage()
    {
        _audioSource.clip = _damageClip;
        _audioSource.Play();
    }
}
