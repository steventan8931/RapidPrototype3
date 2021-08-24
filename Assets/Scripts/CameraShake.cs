using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraShake : MonoBehaviour
{
    public Transform m_CameraPos;

    private void Start()
    {
        m_CameraPos = transform;
    }
    public IEnumerator Shake(float _Duration, float _Magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < _Duration)
        {
            float x = Random.Range(-1f, 1f) * _Magnitude;
            float y = Random.Range(-1f, 1f) * _Magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shake(0.15f, 0.4f));
        }
    }
}
