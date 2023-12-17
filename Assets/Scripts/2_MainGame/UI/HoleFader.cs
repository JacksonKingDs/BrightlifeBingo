namespace MainGame.VisualFeedback
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HoleFader : MonoBehaviour
    {
        public static HoleFader Instance;
        private Animator animator;

        private void Awake()
        {
            Instance = this;
            animator = GetComponent<Animator>();
            Open();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Close();
            }
        }

        public void Open()
        {
            animator.Play("Open");
        }

        public void Close()
        {
            animator.Play("Close");
        }
    }
}
