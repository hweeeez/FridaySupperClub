using System.Collections;
using UnityEngine;

public static class Screenshake
{
    public static IEnumerator ShakeCoroutine(Camera inCamera, float inMagnitude, float inDuration)
    {
        float elapsed = 0;
        Vector3 originalPos = inCamera.transform.localPosition;
        do
        {
            elapsed += Time.deltaTime;
            inCamera.transform.localPosition = originalPos + Random.insideUnitSphere * inMagnitude;
            yield return null;
        }
        while (elapsed < inDuration);
        inCamera.transform.localPosition = originalPos;
    }
}
