//using System;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

//public class NewBehaviourScript : MonoBehaviour, IPlatformInteractionMapper
//{
//    public Text Text;
//    public Vector3GameEvent OnSelectionGameEvent;

//    private InteractionMapper _interactionMapper;

//    void Awake()
//    {
//        switch (Application.platform)
//        {
//            case RuntimePlatform.WindowsEditor:
//                _interactionMapper = new WindowsInteractionMapper(new UnityInputService());
//                break;
//            case RuntimePlatform.WindowsPlayer:
//                _interactionMapper = new WindowsInteractionMapper(new UnityInputService());
//                break;
//            case RuntimePlatform.Android:
//                _interactionMapper = new AndroidInteractionMapper(new UnityInputService());
//                break;
//            default:
//                throw new ArgumentOutOfRangeException();
//        }
//        Text.text = Application.platform.ToString();
//    }

//    private void Update()
//    {
//        if (CheckSelection(out var vector3))
//            OnSelectionGameEvent.Raise(vector3);
//    }

//    public bool CheckSelection(out Vector3? vector3)
//    {
//        return _interactionMapper.CheckSelection(out vector3);
//    }
//}
