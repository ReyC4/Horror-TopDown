using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTimer : MonoBehaviour
{
    [Header("Time Limit Settings")]
    public float timeLimit = 5.0f;  // Batas waktu dalam detik

    [Header("Scene Settings")]
    public string menuSceneName = "MainMenu";  // Nama scene menu

    private bool isTimerActive = false;  // Flag untuk mengecek apakah timer aktif

    void Start()
    {
        // Mulai coroutine untuk menghitung waktu
        StartCoroutine(BackToMenuAfterTime());
    }

    IEnumerator BackToMenuAfterTime()
    {
        isTimerActive = true;

        // Tunggu selama timeLimit detik
        yield return new WaitForSeconds(timeLimit);

        // Kembali ke scene menu
        SceneManager.LoadScene(menuSceneName);
    }

    public void CancelTimer()
    {
        // Hentikan coroutine dan matikan timer
        StopCoroutine(BackToMenuAfterTime());
        isTimerActive = false;
    }

    public void RestartTimer()
    {
        // Jika timer aktif, mulai ulang coroutine
        if (isTimerActive)
        {
            StopCoroutine(BackToMenuAfterTime());
        }
        StartCoroutine(BackToMenuAfterTime());
    }
}
