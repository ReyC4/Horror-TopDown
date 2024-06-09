using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour
{
    public string sceneToLoad;  // Nama scene yang akan dimuat
    public GameObject instructionText;  // Objek UI untuk teks instruksi
    private bool isPlayerNearby = false;  // Flag untuk mengecek apakah pemain berada di dekat objek
    public Transform playerTransform; // Transform dari pemain

    void Start()
    {
        // Pastikan teks instruksi tidak ditampilkan pada awal permainan
        instructionText.SetActive(false);
    }

    void Update()
    {
        // Jika pemain berada di dekat objek dan menekan tombol (misalnya, E)
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            // Simpan nama scene saat ini
            PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
            
            // Simpan posisi pemain saat ini
            PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", playerTransform.position.z);

            // Pindah ke scene berikutnya
            SceneManager.LoadScene(sceneToLoad);
        }

        // Jika pemain berada di dekat objek dan menekan tombol (misalnya, R) untuk kembali ke scene sebelumnya
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.R))
        {
            // Muat scene sebelumnya jika ada
            if (PlayerPrefs.HasKey("PreviousScene"))
            {
                string previousScene = PlayerPrefs.GetString("PreviousScene");
                SceneManager.LoadScene(previousScene);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika objek yang mendekati adalah pemain
        if (other.CompareTag("Player"))
        {
            // Tampilkan teks instruksi
            instructionText.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Jika objek yang meninggalkan adalah pemain
        if (other.CompareTag("Player"))
        {
            // Sembunyikan teks instruksi
            instructionText.SetActive(false);
            isPlayerNearby = false;
        }
    }
}
