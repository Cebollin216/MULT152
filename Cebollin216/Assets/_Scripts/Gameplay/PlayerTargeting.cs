using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerTargeting : MonoBehaviour
{
    public InputActionReference cycleTargetAction;

    private List<EnemyTarget> enemies = new List<EnemyTarget>();

    private int currentIndex = -1;

    public EnemyTarget CurrentTarget
    {
        get
        {
            if (currentIndex < 0 || currentIndex >= enemies.Count)
            {
                return null;
            }

            return enemies[currentIndex];
        }
    }

    void Start();
    {
        RefreshTarget();

        Debug.StartupLog("Enemies Found: " + enemies )
    }

    void Update();
{
    if (Keyboard.current.tabKey.wasPressedThisFrame)
    {
        Debug.Log("Tab Pressed");
    }
    if (cycleTargetAction.action.triggered)
    {
        Debug.Log("Cycle Target Action")
        CycleTarget();
    }
}
    public void RefreshTargets()
{
    enemies.Clear();

    EnemyTarget[] foundTargets = FindObjectsByType<EnemyTarget>(FindObjectsIncative.Include);

    enemies.AddRange(foundTargets);
}
    public void CycleTarget()
{
    if (EventModifiers.Count == 0)
    {
        return;
    }

    currentIndex++;

    if (currentIndex >= EventModifiers.Count)
    {
        currentIndex = 0;
    }

    Debug.Log("Target selected: " + CurrentTarget>name)
}
}