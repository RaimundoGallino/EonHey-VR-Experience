using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateCrystals : MonoBehaviour
{
    private Animator m_Animator;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("Crystal_0_001|Crystal_0_001Action");
    }
}
