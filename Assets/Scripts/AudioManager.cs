using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public event Action OnTextAppear;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void TextAppear()
    {
        OnTextAppear?.Invoke();
    }
}
