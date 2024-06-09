using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAudioManager : MonoBehaviour
{
    public AudioClip[] sceneAudioClips;  // Array untuk menyimpan file audio yang sesuai dengan tiap scene
    private AudioSource audioSource;

    void Awake()
    {
        // Pastikan objek ini tidak dihancurkan ketika scene berganti
        DontDestroyOnLoad(gameObject);

        // Ambil komponen AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        // Tambahkan event untuk mendeteksi perubahan scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Matikan audio source saat scene baru dimuat
        audioSource.Stop();

        // Cek nama scene untuk memutar audio yang sesuai
        switch (scene.name)
        {
            case "Scene1":
                audioSource.clip = sceneAudioClips[0];
                break;
            case "Scene2":
                audioSource.clip = sceneAudioClips[1];
                break;
            // Tambahkan case untuk scene lain dan audio mereka
        }

        // Jika ada audio clip yang diatur, putar audio
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    void OnDestroy()
    {
        // Hapus event ketika objek dihancurkan
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
