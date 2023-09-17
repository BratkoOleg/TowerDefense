using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    [SerializeField] Image _image;
    private float _reload;
    private float _maxReload;

    void OnEnable()
    {
        EventBus.Instance.GotReloadSkill += SetReloadSkill;
    }

    void OnDisable()
    {
        EventBus.Instance.GotReloadSkill -= SetReloadSkill;
    }

    private void SetReloadSkill(float reload)
    {
        _reload = reload;
        _maxReload = reload;
    }

    void Update()
    {
        if(_reload > 0)
        {
            _reload -= Time.deltaTime;
            _image.fillAmount = _reload / _maxReload;
        }
        else
        {
            EventBus.Instance.FinishedReloadSkill?.Invoke();
        }
    }
}
