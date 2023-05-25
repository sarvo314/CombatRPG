using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    private void OnEnable()
    {
        PlayerControls.OnCastSpell += CastAnimation;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void CastAnimation()
    {
        animator.SetTrigger("cast");
    }
    public void PlayAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("velocity_x", horizontal);
        animator.SetFloat("velocity_y", vertical);
    }
    private void OnDisable()
    {
        PlayerControls.OnCastSpell -= CastAnimation;
    }
}
