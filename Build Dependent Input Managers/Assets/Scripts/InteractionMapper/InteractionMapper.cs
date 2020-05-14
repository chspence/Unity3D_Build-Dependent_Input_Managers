using System;
using UnityEngine;
using UnityServices;

namespace InteractionMapper
{
    [Serializable]
    public abstract class InteractionMapper : IPlatformInteractionMapper
    {
        protected IUnityInputService UnityInputService;

        protected InteractionMapper(
            IUnityInputService unityInputService)
        {
            UnityInputService = unityInputService;
        }

        public abstract bool CheckSelection(out Vector3? vector3);
        public abstract bool CheckDragging(out Vector3? vector3);
        public abstract bool CheckDragEnd(out Vector3? vector3);
    }

}