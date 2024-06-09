using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour
{
    void Start()
    {
        // Periksa apakah ada posisi yang tersimpan di PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            // Ambil posisi tersimpan
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");

            // Atur posisi karakter ke posisi yang tersimpan
            transform.position = new Vector3(x, y, z);
        }
    }
}