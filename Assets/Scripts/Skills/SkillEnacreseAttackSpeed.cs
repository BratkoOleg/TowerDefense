using UnityEngine;
using UnityEngine.UI;

public class SkillEnacreseAttackSpeed : MonoBehaviour, ISkillable
{
    //skill increasing shooting speed

    [SerializeField] private float _skillReload;
    [SerializeField] private float _skillCost;
    [SerializeField] private float _workTimeSkill;
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

    private void OnFinishedReload(string name)
    {
        if(this.gameObject.name == name)
        reloaded = true;
    }

    public void SetReload()
    {
        EventBus.Instance.GotReloadSkill?.Invoke(_skillReload, this.gameObject.name);
    }

    public void TryToUseSkill()
    {
        if(reloaded == true)
        EventBus.Instance.TriedToUseSkill?.Invoke(_skillCost, this.gameObject.name);
    }

    private void OnUsedSkill(string name)
    {
        if(this.gameObject.name == name)
        {
            EncreaseAttackSpeed();
            reloaded = false;
            SetReload();
        }
    }

    private void EncreaseAttackSpeed()
    {
        EventBus.Instance.Skill1WasUsed?.Invoke(_workTimeSkill);
    }
}
