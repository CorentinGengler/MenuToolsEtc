using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[DisallowMultipleComponent]//empèche d'ajouter plusieurs fois ce script au même objet
public class Life  : MonoBehaviour
{
    
    #region Public Members
    [ContextMenuItem("Default Values", "PutBackDefaultHealthValues")]//ajoute une option click droit "default values" qui lance la fonction private void PutBackDefaultHealthValues()

    [Header("Health Related Parameters")]

    [SerializeField]
    [Tooltip ("Current health of the attached object/character")]
    private int m_currentHeath=10;
    [SerializeField]
    [Tooltip("Maximum health of the attached object/character")]
    private int m_maxHeath=10;

    [System.Serializable]
    public class LifeChangeEvent : UnityEvent<int> { }
    public LifeChangeEvent _onLifeChange;
    [System.Serializable]
    public class DeathEvent : UnityEvent<bool> { }
    public DeathEvent _onDeath;

    [Header("Debug tools")]
    public bool m_ActivateDebugTools;
    #endregion


    #region Public Void
    
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
                _onLifeChange.Invoke(m_currentHeath);
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
    void Awake () 
    {
		
	}
	
	void Update () 
    {
		
	}

    private void OnValidate()
    {
        MyCurrentHealth = m_currentHeath;
        MymaxHealth = m_maxHeath;
    }

    private void LifeChanged(int Health)
    {
        if((Health!=m_previousHealth)&&(Health!=0))
        {
            Debug.Log("life is now at " + Health);
            m_previousHealth = Health;
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
