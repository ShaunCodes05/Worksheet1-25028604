using JetBrains.Annotations;
using UnityEngine;

public enum GameState {GAMEPLAY, PAUSE}

public class GameCon : MonoBehaviour
{

    public GameState state;

    bool ChangeGamestate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.GAMEPLAY:
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        state = GameState.PAUSE;
                        ChangeGamestate = true;
                        print("yes");
                    }
                    break;
                }
            case GameState.PAUSE:
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        state = GameState.GAMEPLAY;
                        ChangeGamestate = true;
                    }
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
    private void LateUpdate()
    {
        if (ChangeGamestate)
        {
            if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
            else if (state == GameState.GAMEPLAY)
            { Time.timeScale = 1.0f; }

           ChangeGamestate = false;
        }

    }
}
