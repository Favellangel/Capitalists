using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animation anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    public void AnimPlay()
    {
        anim.Play();
    }
}
