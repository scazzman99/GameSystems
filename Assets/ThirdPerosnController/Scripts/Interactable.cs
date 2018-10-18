﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonController
{
    public class Interactable : MonoBehaviour
    {

        public virtual void Interact()
        {
            print("Interactable base class called!");
        }
    }
}
