using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    private float time;
    private bool isRunning = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (!isRunning) return;

        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
