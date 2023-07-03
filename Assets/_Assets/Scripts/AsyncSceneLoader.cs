
using UnityEngine;
using UnityEngine.SceneManagement;
public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField]
    private ProgressBar _progress;
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private float _fakeDuration;
    private float _startTime;
    private AsyncOperation _loadingOperation;

    public void StartLoadScene()
    {
        gameObject.SetActive(true);
        DontDestroyOnLoad(this);
        _startTime = Time.unscaledTime;
        _loadingOperation = SceneManager.LoadSceneAsync(_sceneName);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (_loadingOperation == null) return;
        float fakeProgress = (Time.unscaledTime - _startTime) / _fakeDuration;
        float finalProgress = Mathf.Min(fakeProgress, _loadingOperation.progress);
        _progress.SetProgressValue(finalProgress);
        if (_loadingOperation.isDone && finalProgress >= 1f)
        {
            FinishLoading();
        }
    }
    private void FinishLoading()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
