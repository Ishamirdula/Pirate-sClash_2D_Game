using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.UI;
using UnityEngine.InputSystem;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField]
        private UIInventoryPage inventoryUI;

        public int inventorySize = 10;

        private void Start()
        {
            inventoryUI.InitializeInventoryUI(inventorySize);
        }

        public void Update()
        {
            if (Keyboard.current.iKey.wasReleasedThisFrame)
            {
                Debug.Log("Inventory key pressed");
                if (inventoryUI.isActiveAndEnabled == false)
                {
                    inventoryUI.Show();
                }
                else
                {
                    inventoryUI.Hide();
                }

            }
        }
    }
}
