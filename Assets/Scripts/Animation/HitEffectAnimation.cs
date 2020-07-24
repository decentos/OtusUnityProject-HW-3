using UnityEngine;

public class HitEffectAnimation : MonoBehaviour
{
    public ParticleSystem Effect;

    public void PlayEffect()
    {
        Effect.Play();
    }
}
