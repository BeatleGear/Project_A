using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private HeroHealth _heroHealth;
    [SerializeField] private Gradient _gradient;
    // Start is called before the first frame update
    void Awake()
    {
        _heroHealth.HealthChanged += OnHealthChanged;
        _healthBarFilling.color = _gradient.Evaluate(1);
    }

    private void OnDestroy()
    {
        _heroHealth.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        _healthBarFilling.fillAmount = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
