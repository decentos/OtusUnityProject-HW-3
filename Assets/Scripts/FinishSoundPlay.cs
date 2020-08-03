using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class FinishSoundPlay : MonoBehaviour
{
    [SerializeField] private AudioClip _winClip;
    [SerializeField] private AudioClip _loseClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        _audioSource.clip = _winClip;
        _audioSource.Play();
    }

    public void PlayLose()
    {
        _audioSource.clip = _loseClip;
        _audioSource.Play();
    }
}
