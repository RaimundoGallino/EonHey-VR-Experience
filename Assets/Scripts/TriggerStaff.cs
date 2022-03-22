using System;
using System.Collections;
using UnityEngine;

public class TriggerStaff : MonoBehaviour
{
    [SerializeField] private AudioSource textAudio;
    [SerializeField] private GameObject text01;
    [SerializeField] private GameObject text02;
    [SerializeField] private GameObject text03;
    [SerializeField] private float timeBetween01;
    [SerializeField] private float timeBetween02;
    [SerializeField] private float lerpDuration;
    private bool allreadyActivated = false;

    private void OnTriggerEnter(Collider box)
    {
        if (box.CompareTag("Player") && !allreadyActivated)
        {
            TriggerAudio();
            TriggerEffects();
            allreadyActivated = true;
        }
    }
    private void TriggerAudio()
    {
        
    }

    private void TriggerEffects()
    {
        StartCoroutine(EffectAnimation());
    }

    IEnumerator EffectAnimation()
    {
        float timeElapsed = 0;
        float startValue = 0.9f;
        float endValue = 0;
        float valueToLerp = 0;
        var dissolveAmount = 2;
        
        Material material01 = text01.GetComponent<MeshRenderer>().material;
        Material material02 = text02.GetComponent<MeshRenderer>().material;
        Material material03 = text03.GetComponent<MeshRenderer>().material;
        
        textAudio.Play();
        
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp( startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            material01.SetFloat("_Dissolve", valueToLerp);
        }
        yield return new WaitForSeconds(timeBetween01);
        
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp( startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            material01.SetFloat("_Dissolve", valueToLerp);
        }
    }
}
