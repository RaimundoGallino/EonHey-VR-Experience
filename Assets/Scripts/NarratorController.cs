using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NarratorController : MonoBehaviour
{
    [SerializeField] private NarratorData[] _narrations;

    private AudioSource _src;

    private int _currentIndex;
    
    private void Awake()
    {
        _src = GetComponent<AudioSource>();
    }

    public void Play()
    {
        StartCoroutine(Principal());
    }

    IEnumerator Routine(NarratorData data)
    {
        _src.clip = data.Clip;
        _src.Play();
        
        data.Text.Appear();
        
        // var startingTime = Time.time + data.Clip.length;
        // while (Time.time < startingTime)
        //     yield return null;

        yield return new WaitForSeconds(data.Clip.length);

        data.Text.Dissapear();
    }

    IEnumerator Principal()
    {
        while (_currentIndex < _narrations.Length)
        {
            yield return Routine(_narrations[_currentIndex++]);
            
            yield return null;
        }
    }
}
