using ProjectFeatures.CameraModule.Runtime;
using ProjectFeatures.PrefabFactoryModule.Runtime;
using ProjectFeatures.UiModule.Runtime;
using ProjModules.UiContainerModule.Runtime;
using UnityEngine;
using Zenject;

namespace ProjectRuntime.Behavior
{
    public class CameraStackBehavior : IInitializable
    {
        [Inject] private ICameraStackController CameraStackController { get; }
        [Inject] private IPrefabFactory<Camera> GameplayCameraFactory { get; }
        [Inject] private IPrefabFactory<UiContainerView> UiPanelsContainerFactory { get; }

        public void Initialize()
        {
            GameplayCameraFactory.CompletedEvent += () =>
                CameraStackController.SetGameplayCamera(GameplayCameraFactory.Item);

            UiPanelsContainerFactory.CompletedEvent += () =>
                CameraStackController.SetUiCamera(UiPanelsContainerFactory.Item.UiCamera);
        }
    }
}