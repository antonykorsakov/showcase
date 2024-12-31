using ProjModules.CameraModule.Runtime.Controller;
using ProjModules.PrefabFactoryModule.Runtime;
using ProjModules.UiContainerModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjRuntime.CameraModule.Behavior
{
    public class CameraStackBeh : IInitializable
    {
        [Inject] private ICameraStackController CameraStackController { get; }
        [Inject] private IPrefabFactory<Camera> GameplayCameraFactory { get; }
        [Inject] private IPrefabFactory<UiContainerView> UiPanelsContainerFactory { get; }

        public void Initialize()
        {
            GameplayCameraFactory.CompletedEvent += () =>
                CameraStackController.SetGameCamera(GameplayCameraFactory.Item);

            UiPanelsContainerFactory.CompletedEvent += () =>
                CameraStackController.SetUiCamera(UiPanelsContainerFactory.Item.UiCamera);
        }
    }
}