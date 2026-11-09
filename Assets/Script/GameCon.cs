
using UnityEngine;


public abstract class GameStateBase
{
    protected GameCon controller;

    public GameObject ItemUI;

    public void Initialize(GameCon controller, GameObject ui)
    {
        this.controller = controller;
        this.ItemUI = ui;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class GAMEPLAY : GameStateBase
{
    public override void Enter()
    {
        Time.timeScale = 1.0f;

        ItemUI.SetActive(false);
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
    }
}

public class PAUSE : GameStateBase
{
    public override void Enter()
    {
        Time.timeScale = 0.0f;

        ItemUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
    }
}

public class GameCon : MonoBehaviour
{
    public GAMEPLAY GAMEPLAY { get; private set; }
    public PAUSE PAUSE { get; private set; }

    public GameStateBase currentState { get; private set; }

    [SerializeField] private GameObject ItvMen;

    void Start()
    {
        // Check if the UI has been assigned
        //if (ItvMen == null)
       // {
       //     Debug.LogError("Hello");
       //     return;
       // }

        GAMEPLAY = new GAMEPLAY();
        PAUSE = new PAUSE();

        GAMEPLAY.Initialize(this, ItvMen);
        PAUSE.Initialize(this, ItvMen);

        ChangeState(GAMEPLAY);
    }

    void Update()
    {
        currentState?.Update();
    }

    public void ChangeState(GameStateBase newState)
    {
        if (newState == null || newState == currentState) return;

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
