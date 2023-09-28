using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    private float curStamina;
    private float maxStamina;

    void OnEnable()
    {
        EventBus.Instance.TriedToUseSkill += OnChangedStamina;
        curStamina = 0;
        maxStamina = 10;
    }

    void OnDisable()
    {
        EventBus.Instance.TriedToUseSkill -= OnChangedStamina;
    }

    void Update()
    {
        if(curStamina < maxStamina)
        {
            curStamina += Time.deltaTime;
            _image.fillAmount = curStamina / maxStamina;
        }
    }

    private void OnChangedStamina(float cost, string name)
    {
        if(curStamina >= cost)
        {
            curStamina -= cost;
            EventBus.Instance.UsedSkill?.Invoke(name);
        }
    }
}
