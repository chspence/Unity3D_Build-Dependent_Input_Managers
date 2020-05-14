using UnityEngine;

namespace InteractionMapper
{
    public interface IPlatformInteractionMapper
    {
        bool CheckSelection(out Vector3? vector3);
        bool CheckDragging(out Vector3? vector3);
        bool CheckDragEnd(out Vector3? vector3);
    }
}