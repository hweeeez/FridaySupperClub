using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public string sceneToLoad;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    private float currentValue;
    private float targetValue;
    [SerializeField]
    [Range(0, 1)]
    private float progressAnimationMultiplier = 0.25f;
    void Start()
    {
        progressBar.value = currentValue = targetValue = 0;

        loadingOperation = SceneManager.LoadSceneAsync("PlayableTest01");
        loadingOperation.allowSceneActivation = false;
    }
    void Update()
    {
        targetValue = loadingOperation.progress / 0.9f;
        currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);
        progressBar.value = currentValue;
       // progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        if (Mathf.Approximately(currentValue, 1))
        {
            loadingOperation.allowSceneActivation = true;
        }
    }
    IEnumerator waitLoad()
    {
        yield return new WaitForSeconds(10f);
        loadingOperation.allowSceneActivation = true;
    }

}
