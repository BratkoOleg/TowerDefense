using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;

    void Update()
    {
        CheckWindow();
    }

    private void CheckWindow()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if(windows[i].gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
                CloseWindows(windows[i]);
                break;
            }
            Time.timeScale = 1;
        }
    }

    private void CloseWindows(GameObject active)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if(windows[i].gameObject.name != active.gameObject.name)
                windows[i].gameObject.SetActive(false);
        }
    }
}
