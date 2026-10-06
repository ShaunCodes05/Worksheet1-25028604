using JetBrains.Annotations;
using UnityEngine;

// base class for all states
public abstract class GameStateBase
{
    protected GameCon controller;

    // gives the state a reference to the controller
    public void Initialize(GameCon controller)
    {
        this.controller = controller;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

// normal gameplay state
public class GAMEPLAY : GameStateBase
{
    public override void Enter()
    {
        Time.timeScale = 1.0f;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            controller.ChangeState(controller.PAUSE);
        }
    }

    public override void Exit()
    {
        // nothing here yet
    }
}

// pause state
public class PAUSE : GameStateBase
{
    public override void Enter()
    {
        Time.timeScale = 0.0f;
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            controller.ChangeState(controller.GAMEPLAY);
        }
    }

    public override void Exit()
    {
        // nothing here yet
    }
}

public class GameCon : MonoBehaviour
{
    // add new states here
    public GAMEPLAY GAMEPLAY { get; private set; }
    public PAUSE PAUSE { get; private set; }

    private GameStateBase currentState;

    void Start()
    {
        // make the states
        GAMEPLAY = new GAMEPLAY();
        PAUSE = new PAUSE();

        // hand them the controller
        GAMEPLAY.Initialize(this);
        PAUSE.Initialize(this);

        // start on gameplay
        ChangeState(GAMEPLAY);
    }

    void Update()
    {
        currentState?.Update();
    }

    // switches to a new state
    public void ChangeState(GameStateBase newState)
    {
        if (newState == null || newState == currentState) return;

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}