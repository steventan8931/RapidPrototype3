using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraShake : MonoBehaviour
{
    public float m_ShakeDuration = 0.15f;
    public float m_ShakeMagnitude = 0.4f;
    public bool m_ShakeFinished = false;
    public float m_NewX = 0.0f;
    public float m_NewY = 0.0f;

    public IEnumerator Shake(float _Duration, float _Magnitude)
    {
        m_ShakeFinished = false;
        Vector3 originalPos = transform.position;

        float timeElapsed = 0.0f;

        while (timeElapsed < _Duration)
        {
            float x = Random.Range(-1f, 1f) * _Magnitude;
            float y = Random.Range(-1f, 1f) * _Magnitude;
            m_NewX = x;
            m_NewY = y;
            transform.position = new Vector3(x, y, originalPos.z);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;
        m_ShakeFinished = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<CamFollower>().enabled = false;
            StartCoroutine(Shake(m_ShakeDuration, m_ShakeMagnitude));
        }
        if (m_ShakeFinished)
        {
            GetComponent<CamFollower>().enabled = true;
        }
    }
}
