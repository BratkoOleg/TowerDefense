using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour, ISkillable
{
    [SerializeField] private float _skillReload;
    [SerializeField] private float _skillCost;
    [SerializeField] private Button _button;
    private bool reloaded = true;

    void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TryToUseSkill);
        EventBus.Instance.UsedSkill += OnUsedSkill;
        EventBus.Instance.FinishedReloadSkill += OnFinishedReload;
    }

    void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
        EventBus.Instance.UsedSkill -= OnUsedSkill;
        EventBus.Instance.FinishedReloadSkill -= OnFinishedReload;
    }

    private void OnFinishedReload()
    {
        reloaded = true;
    }

    public void SetReload()
    {
        EventBus.Instance.GotReloadSkill?.Invoke(_skillReload);
    }

    private void OnUsedSkill()
    {
        Debug.Log("skill was used");
        reloaded = false;
        SetReload();
    }

    public void TryToUseSkill()
    {
        if(reloaded == true)
        EventBus.Instance.TriedToUseSkill?.Invoke(_skillCost);
    }
}
