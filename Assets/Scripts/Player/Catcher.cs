using UnityEngine;

public class Catcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        runner runner = other.GetComponent<runner>();
        if (runner != null)
        {
            Debug.Log("Caught runner: " + runner.name);
            GameManager.Instance.OnRunnerCaught(runner);
            Destroy(runner.gameObject);
        }
    }
}
