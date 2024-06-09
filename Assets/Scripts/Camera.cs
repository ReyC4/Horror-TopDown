using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang akan diikuti oleh kamera
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera
    public Vector3 offset; // Jarak antara kamera dan objek yang diikuti

    private void FixedUpdate()
    {
        // Mengatur posisi kamera agar berada di atas karakter
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        // Menghitung posisi kamera yang diinginkan dengan smoothing
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Mengatur posisi kamera sesuai dengan yang diinginkan
        transform.position = smoothedPosition;
    }
}