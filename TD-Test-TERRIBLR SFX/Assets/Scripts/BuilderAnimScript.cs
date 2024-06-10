using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Builder selfBob;
    private Animator _animation;
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
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.IsMoving)
        {
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.IsIdle)
        {
            // anim
            // _animation.SetBool("otheranim_name", false);
            // _animation.SetBool("anim_name", true);
        }
        if (selfBob.DoneBuilding)
        {

        }
    }
}
