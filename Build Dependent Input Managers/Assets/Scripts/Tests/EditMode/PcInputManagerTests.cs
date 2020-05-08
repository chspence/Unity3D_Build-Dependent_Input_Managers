using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class PcInputManagerTests
    {
        #region CheckForSelection

        [Test]
        public void CheckForSelection_Nothing_SelectionEventIsNotRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, null);

            unityService.GetMouseButtonDown(1).Returns(false);
            pcInputManager.CheckForSelection();

            onSelectionGameEvent.DidNotReceive().Raise();
        }

        [Test]
        public void CheckForSelection_LeftMouseButtonDown_SelectionEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            pcInputManager.CheckForSelection();

            onSelectionGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForSelection_LeftMouseButtonDownAndLeftMouseButton_SelectionEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            unityService.GetMouseButton(1).Returns(true);
            pcInputManager.CheckForSelection();

            onSelectionGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForSelection_LeftMouseButtonDownAndLeftMouseButtonUp_SelectionEventIsNotRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForSelection();

            onSelectionGameEvent.DidNotReceive().Raise();
        }

        [Test]
        public void CheckForSelection_Nothing_InteractionPositionValueIsZeroedOut()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var interactionPositionVector3Variable = Substitute.For<IVector3Variable>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, interactionPositionVector3Variable);

            unityService.GetMouseButtonDown(1).Returns(false);
            pcInputManager.CheckForSelection();

            Assert.AreEqual(new Vector3(), interactionPositionVector3Variable.Value);
        }

        [Test]
        public void CheckForSelection_LeftMouseButtonDown_InteractionPositionValueIsSetToMousePosition()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onSelectionGameEvent = Substitute.For<IGameEvent>();
            var interactionPositionVector3Variable = Substitute.For<IVector3Variable>();
            var pcInputManager = new PcInputManager(unityService, onSelectionGameEvent, null, null, interactionPositionVector3Variable);

            unityService.GetMouseButtonDown(1).Returns(false);
            unityService.GetMousePosition().Returns(new Vector3(1,1,1));
            pcInputManager.CheckForSelection();

            Assert.AreEqual(new Vector3(1,1,1), interactionPositionVector3Variable.Value);
        }

        #endregion

        #region CheckForDragging

        [Test]
        public void CheckForDragging_Nothing_DraggingEventIsNotRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDraggingGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, onDraggingGameEvent, null, null);

            unityService.GetMouseButton(1).Returns(false);
            pcInputManager.CheckForDragging();

            onDraggingGameEvent.DidNotReceive().Raise();
        }

        [Test]
        public void CheckForDragging_LeftMouseButton_DraggingEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDraggingGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, onDraggingGameEvent, null, null);

            unityService.GetMouseButton(1).Returns(true);
            pcInputManager.CheckForDragging();

            onDraggingGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForDragging_LeftMouseButtonDownAndLeftMouseButton_DraggingEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDraggingGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, onDraggingGameEvent, null, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            unityService.GetMouseButton(1).Returns(true);
            pcInputManager.CheckForDragging();

            onDraggingGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForDragging_LeftMouseButtonAndLeftMouseButtonUp_DraggingEventIsNotRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDraggingGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, onDraggingGameEvent, null, null);

            unityService.GetMouseButton(1).Returns(true);
            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForDragging();

            onDraggingGameEvent.DidNotReceive().Raise();
        }

        #endregion

        #region CheckForDragEnd

        [Test]
        public void CheckForDragEnd_Nothing_DragEndIsNotRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDragEndGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, null, onDragEndGameEvent, null);

            unityService.GetMouseButtonUp(1).Returns(false);
            pcInputManager.CheckForDragEnd();

            onDragEndGameEvent.DidNotReceive().Raise();
        }

        [Test]
        public void CheckForDragEnd_LeftMouseButtonUp_DragEndEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDragEndGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, null, onDragEndGameEvent, null);

            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForDragEnd();

            onDragEndGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForDragEnd_LeftMouseButtonDownAndLeftMouseButtonUp_DragEndEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDragEndGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, null, onDragEndGameEvent, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForDragEnd();

            onDragEndGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForDragEnd_LeftMouseButtonAndLeftMouseButtonUp_DragEndEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDragEndGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, null, onDragEndGameEvent, null);

            unityService.GetMouseButton(1).Returns(true);
            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForDragEnd();

            onDragEndGameEvent.Received().Raise();
        }

        [Test]
        public void CheckForDragEnd_LeftMouseButtonDownAndLeftMouseButtonAndLeftMouseButtonUp_DragEventIsRaised()
        {
            var unityService = Substitute.For<IUnityInputService>();
            var onDragEndGameEvent = Substitute.For<IGameEvent>();
            var pcInputManager = new PcInputManager(unityService, null, null, onDragEndGameEvent, null);

            unityService.GetMouseButtonDown(1).Returns(true);
            unityService.GetMouseButton(1).Returns(true);
            unityService.GetMouseButtonUp(1).Returns(true);
            pcInputManager.CheckForDragEnd();

            onDragEndGameEvent.Received().Raise();
        }

        #endregion
    }
}
