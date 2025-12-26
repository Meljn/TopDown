using System;
using UnityEngine;

public class EnemyStateMachine
{
    public event Action<EnemyState, EnemyState> StateChanged;

    public EnemyState currentState { get; private set; }

    private EnemyStateMachine()
    {
        currentState = EnemyState.Idle;
    }

    public void ChangeState(EnemyState nextState)
    {
        if (currentState is EnemyState.Dead || currentState == nextState)
        {
            return;
        }

        var previousState = currentState;
        StateChanged?.Invoke(previousState, currentState);
        currentState = nextState;
    }

}
