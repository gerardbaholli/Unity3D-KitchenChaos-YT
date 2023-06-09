using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Instance_OnSelectedCounterChanged;
    }

    private void Instance_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (clearCounter == e.selectedCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);
    }

}
