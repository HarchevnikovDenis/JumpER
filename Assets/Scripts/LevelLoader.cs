using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        animator.SetTrigger("CrossFade_End");

        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
