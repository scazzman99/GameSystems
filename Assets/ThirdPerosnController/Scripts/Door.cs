using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class Door : Interactable
    {

        public Animator anim;


        public override void Interact()
        {

            bool isOpen = anim.GetBool("isOpen"); //toggle open
            anim.SetBool("isOpen", !isOpen); //anims door
        }
    }
}
