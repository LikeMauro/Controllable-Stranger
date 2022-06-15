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
            ModHelper.Console.WriteLine($"{nameof(ControllableStranger)} Loaded correctly!", MessageType.Success);
        }

        private void Update()
        {
            if (Keyboard.current.numpad1Key.wasPressedThisFrame)
            {
                Locator.GetRingWorldController().BeginDeploySails();
                Locator.GetRingWorldController().BeginLightFlicker();
                Locator.GetRingWorldController().BeginDepartSolarSystem();
            }

            if (Locator.GetRingWorldController()._sailsDeploying == true && Keyboard.current.numpad0Key.wasPressedThisFrame)
            {
                if (Locator.GetRingWorldController()._playerInsideRingWorld)
                {
                    Locator.GetRingWorldController()._solarSailOneShot.PlayOneShot(global::AudioType.SolarSail_RW_End, 1f);
                    Locator.GetRingWorldController()._solarSailLooping.FadeOut(0.2f, OWAudioSource.FadeOutCompleteAction.STOP, 0f);
                    Locator.GetRingWorldController()._damOneShotAudio_Far.PlayOneShot(global::AudioType.StationShudder_DW, 1f);
                    if (Locator.GetPlayerController().GetGroundBody() == Locator.GetRingWorldController()._ringWorldBody)
                    {
                        RumbleManager.PlayStationShudder(1f);
                    }
                }
                if (Locator.GetDreamWorldAudioController() != null)
                {
                    Locator.GetDreamWorldAudioController().OnSolarSailStop();
                }
                Locator.GetRingWorldController()._solarSailClosedCollider.SetActivation(false);
                Locator.GetRingWorldController()._solarSailOpenCollider.SetActivation(true);
                Locator.GetRingWorldController()._solarSailClosedProxy.SetActive(false);
                Locator.GetRingWorldController()._solarSailOpenProxy.SetActive(true);
                Locator.GetRingWorldController()._sailsDeployed = true;
            }
            
            if (Keyboard.current.numpad2Key.wasPressedThisFrame)
            {
                Locator.GetRingWorldController().BreakDam();
            }

            if (Keyboard.current.numpad3Key.wasPressedThisFrame)
            {
                Locator.GetRingWorldController().CollapseLighthouse();
            }
        }
    }
}
