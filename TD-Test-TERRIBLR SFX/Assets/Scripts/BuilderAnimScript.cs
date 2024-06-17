using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Builder selfBob;
    public Animator _animation;
    void Start()
    {
        selfBob = GetComponent<Builder>();
        // _animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selfBob.IsBuilding)
        {
            setAllFalse();
            _animation.SetBool("isBuilding", true);
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.IsMoving)
        {
            setAllFalse();
            _animation.SetBool("isFlying", true);
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.IsIdle)
        {
            setAllFalse();
            _animation.SetBool("isIdle", true);
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.DoneBuilding)
        {
            setAllFalse();
            _animation.SetBool("isIdle", true);
        }
    }


    public void setAllFalse()
    {
        _animation.SetBool("isBuilding", false);
        _animation.SetBool("isMoving", false);
        _animation.SetBool("isFlying", false);
        _animation.SetBool("isIdle", false);
    }


}
