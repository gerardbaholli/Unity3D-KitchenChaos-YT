using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ContainerCounter : BaseCounter
{


    public event EventHandler OnPlayerGrabbedObject;


    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        Debug.Log("ContainerCounter_Interact");

        if (!player.HasKitchenObject())
        {
            // Player is not carrying anything
            Debug.Log("Player is not carrying anything");
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            InteractLogicServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        Debug.Log("ContainerCounter_InteractLogicServerRpc");
        InteractLogicClientRpc();
    }

    [ClientRpc]
    private void InteractLogicClientRpc()
    {
        Debug.Log("ContainerCounter_InteractLogicClientRpc");
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }

}