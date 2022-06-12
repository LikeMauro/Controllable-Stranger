using OWML.Common;
using OWML.ModHelper;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ControllableStranger
{
    public class ControllableStranger : ModBehaviour
    {
        private void Awake()
        {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        private void Start()
        {
            ModHelper.Console.WriteLine($"Controllable Stranger Mod Loaded!");
        }

        private void Update()
        {
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                Locator.GetRingWorldController().BreakDam();
            }

            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                Locator.GetRingWorldController().CollapseLighthouse();
            }
        }
    }
}
