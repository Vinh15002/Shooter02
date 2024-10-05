using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class healthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;

    public float PersentOfHealth{
        get { return _currentHealth/_maxHealth; }
    }

    public bool IsVincible{get;set;}
    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent<float> GetHealth;



    public void TakeDamage(float damage){

        
        if(IsVincible){
            return;
        }
        _currentHealth = _currentHealth >= damage ? _currentHealth - damage : 0;
        if (_currentHealth == 0){
            OnDied.Invoke();
            
        }else {
            OnDamaged.Invoke();
        }
        GetHealth.Invoke(this.PersentOfHealth);
        

    }
    public void GetHeal(float Heal){
        if (_currentHealth  ==  _maxHealth){
            return;
        }
        else {
            _currentHealth += Heal;
            _currentHealth = _currentHealth <= _maxHealth ? _currentHealth : _maxHealth;
        }
        GetHealth.Invoke(this.PersentOfHealth);
    }
}
