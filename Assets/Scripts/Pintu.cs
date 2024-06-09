using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Contoh: Jika tombol ditekan, atur animator parameter "IsOpen" menjadi true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsOpen", true);
        }
    }
}

