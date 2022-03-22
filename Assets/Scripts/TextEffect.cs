using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffect : MonoBehaviour
{
    [SerializeField] public float LerpDuration;
    private ParticleSystem _volumeFog;

    private void Awake()
    {
        _volumeFog = GetComponentInChildren<ParticleSystem>();
    }

    [ContextMenu("Appear")]
    public void Appear()
    {
        StartCoroutine(EffectAnimation(0.9f, 0f));
    }
    
    [ContextMenu("Dissapear")]
    public void Dissapear()
    {
        StartCoroutine(EffectAnimation(0f, 0.9f));
    }
    
    IEnumerator EffectAnimation(float startValue, float endValue)
    {
        float timeElapsed = 0;
        float valueToLerp = 0;

        Material material01 = GetComponent<MeshRenderer>().material;
        _volumeFog?.Play();

        while (timeElapsed < LerpDuration)
        {
            valueToLerp = Mathf.Lerp( startValue, endValue, timeElapsed / LerpDuration);
            timeElapsed += Time.deltaTime;
            material01.SetFloat("_Dissolve", valueToLerp);
            yield return null;
        }
    }
}
