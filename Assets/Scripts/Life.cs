using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[DisallowMultipleComponent]//blocks the user from adding the same script multipe time on the same object
[System.Serializable]
public class Life  : MonoBehaviour
{
    
    #region Public Members
    [ContextMenuItem("Default Values", "PutBackDefaultHealthValues")]//add on option right click "default values" that triggers void PutBackDefaultHealthValues()

    [Header("Health Related Parameters")]

    [SerializeField]
    [Tooltip ("Current health of the attached object/character")]
    private int m_currentHeath=10;
    
    [SerializeField]
    [Tooltip("Maximum health of the attached object/character")]
    private int m_maxHeath=10;
    
    [System.Serializable]
    public class LifeChangeEvent : UnityEvent { }
    [System.Serializable]
    public class DeathEvent : UnityEvent<bool> { }

    [Space(20f)]
    public LifeChangeEvent _onLifeChange;
    [Space(10f)]
    public DeathEvent _onDeath;

    [Header("Debug tools")]
    public bool m_ActivateDebugTools;
    #endregion


    #region Public Void

    public void LifeChanged()
    {
        if ((m_currentHeath != m_previousHealth) && (m_currentHeath != 0))
        {
            Debug.Log("life of " + gameObject.name + "is now at " + m_currentHeath);
            m_previousHealth = m_currentHeath;
        }

    }

    private void PutBackDefaultHealthValues()
    {
        m_currentHeath = 10;
        m_maxHeath = 10;
    }


    #endregion
    public int MyCurrentHealth
    {
        get { return m_currentHeath; }
        set {
                m_currentHeath = Mathf.Clamp(value, 0, 99999);
                _onLifeChange.Invoke();
                if (m_currentHeath == 0)
                {
                    _onDeath.Invoke(true);
                }
        }
    }
    public int MymaxHealth
    {
        get { return m_maxHeath; }
        set {m_maxHeath = Mathf.Clamp(value, 1, 99999);}
    }

    #region System

    void Start () 
    {
        _onLifeChange.AddListener(LifeChanged);
        _onDeath.AddListener(IsDead);
        m_previousHealth = m_currentHeath;
    }


    //test delegate
    public delegate void DoSomething(float testfloat);
    public DoSomething _attack;
    private void Kick(float damage)
    {

    }
    private void Punch(float damage)
    {

    }
    void Awake () 
    {
        _attack += Kick;
        _attack += Punch;
        _attack(0.1f);//il vas lancer Kick ET punch en leur donnant la valeur 0.1f
    }
    


    void Update () 
    {
        
    }

    private void OnValidate()
    {
        MyCurrentHealth = m_currentHeath;
        MymaxHealth = m_maxHeath;
        if(m_currentHeath>m_maxHeath)
        {
            m_currentHeath = m_maxHeath;
        }
    }

    
    private void IsDead(bool isDead)
    {
        if(m_previousIsDead==false)
        {
            Debug.Log(gameObject.name + " just died !");
            m_previousIsDead = isDead;
        }
        
    }


    
    

    #endregion

    #region Private Void

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members
    private int m_previousHealth;
    private bool m_previousIsDead;
    #endregion

}
