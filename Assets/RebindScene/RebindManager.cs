using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RebindManager : MonoBehaviour
{
    private MenuControl menucontrol;

    // Start is called before the first frame update
    void Awake()
    {
        menucontrol = new MenuControl();
        menucontrol.Enable();
    }



    // Update is called once per frame
    void Update()
    {
        //MenuControl();
    }

    private void OnDestroy()
    {
        menucontrol?.Dispose();
    }

    private void MenuControl()
    {
        menucontrol.menu.Enter.started += Enter;
    }

    private void Enter(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("gameScene");
    }

    public void onGame()
    {
        SceneManager.LoadScene("gameScene");
    }
}
