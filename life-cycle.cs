using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake");
    }
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    void Start()
    {
        Debug.Log("Start");
    }
    void Update()
    {
        Debug.Log("Update");
    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }
    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }
    void ODisable()
    {
        Debug.Log("OnDisable");
    }
    void Oestroy()
    {
        Debug.Log("OnDestroy");        
    }
}
