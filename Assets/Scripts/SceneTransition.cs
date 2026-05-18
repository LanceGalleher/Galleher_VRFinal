using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private bool loading = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger: " + other.name);

        if (loading) return;

        if (other.CompareTag("Player"))
        {
            loading = true;
            SceneManager.LoadScene("Main");
        }
    }
}
