using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private Animator animator;
    private bool hasFadedOut = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasFadedOut && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            animator.SetTrigger("FadeOutTrigger");
            hasFadedOut = true;  // Prevents multiple triggers
        }
    }
}
