using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class PcInteractionMapperTests
    {
        #region CheckSelection

        [Test]
        public void CheckSelection_PrimaryMouseNotClicked_NoSelection()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var pcInteractionMapper = new PcInteractionMapper(unityInputService);

            unityInputService.GetMouseButtonDown(0).Returns(false);
            var result = pcInteractionMapper.CheckSelection();

            Assert.IsNull(result);
        }

        [Test]
        public void CheckSelection_PrimaryMouseClicked_MousePositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var pcInteractionMapper = new PcInteractionMapper(unityInputService);
            var mousePositionVector3 = new Vector3(1, 2, 3);

            unityInputService.GetMouseButtonDown(0).Returns(true);
            unityInputService.GetMousePosition().Returns(mousePositionVector3);
            var result = pcInteractionMapper.CheckSelection();

            Assert.AreEqual(mousePositionVector3, result);
        }

        [Test]
        public void CheckSelection_PrimaryMouseClickedAndHeldDown_MousePositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var pcInteractionMapper = new PcInteractionMapper(unityInputService);
            var mousePositionVector3 = new Vector3(1, 2, 3);

            unityInputService.GetMouseButtonDown(0).Returns(true);
            unityInputService.GetMouseButton(0).Returns(true);
            unityInputService.GetMousePosition().Returns(mousePositionVector3);
            var result = pcInteractionMapper.CheckSelection();

            Assert.AreEqual(mousePositionVector3, result);
        }

        [Test]
        public void CheckSelection_PrimaryMouseClickedAndReleased_MousePositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var pcInteractionMapper = new PcInteractionMapper(unityInputService);
            var mousePositionVector3 = new Vector3(1, 2, 3);

            unityInputService.GetMouseButtonDown(0).Returns(true);
            unityInputService.GetMouseButtonUp(0).Returns(true);
            unityInputService.GetMousePosition().Returns(mousePositionVector3);
            var result = pcInteractionMapper.CheckSelection();

            Assert.AreEqual(mousePositionVector3, result);
        }

        #endregion

        //#region CheckForDragging

        //[Test]
        //public void CheckForDragging_Nothing_DraggingEventIsNotRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDraggingGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, onDraggingGameEvent, null, null);

        //    unityInputService.GetMouseButton(1).Returns(false);
        //    pcInteractionMapper.CheckForDragging();

        //    onDraggingGameEvent.DidNotReceive().Raise();
        //}

        //[Test]
        //public void CheckForDragging_LeftMouseButton_DraggingEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDraggingGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, onDraggingGameEvent, null, null);

        //    unityInputService.GetMouseButton(1).Returns(true);
        //    pcInteractionMapper.CheckForDragging();

        //    onDraggingGameEvent.Received().Raise();
        //}

        //[Test]
        //public void CheckForDragging_LeftMouseButtonDownAndLeftMouseButton_DraggingEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDraggingGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, onDraggingGameEvent, null, null);

        //    unityInputService.GetMouseButtonDown(1).Returns(true);
        //    unityInputService.GetMouseButton(1).Returns(true);
        //    pcInteractionMapper.CheckForDragging();

        //    onDraggingGameEvent.Received().Raise();
        //}

        //[Test]
        //public void CheckForDragging_LeftMouseButtonAndLeftMouseButtonUp_DraggingEventIsNotRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDraggingGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, onDraggingGameEvent, null, null);

        //    unityInputService.GetMouseButton(1).Returns(true);
        //    unityInputService.GetMouseButtonUp(1).Returns(true);
        //    pcInteractionMapper.CheckForDragging();

        //    onDraggingGameEvent.DidNotReceive().Raise();
        //}

        //#endregion

        //#region CheckForDragEnd

        //[Test]
        //public void CheckForDragEnd_Nothing_DragEndIsNotRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDragEndGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, null, onDragEndGameEvent, null);

        //    unityInputService.GetMouseButtonUp(1).Returns(false);
        //    pcInteractionMapper.CheckForDragEnd();

        //    onDragEndGameEvent.DidNotReceive().Raise();
        //}

        //[Test]
        //public void CheckForDragEnd_LeftMouseButtonUp_DragEndEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDragEndGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, null, onDragEndGameEvent, null);

        //    unityInputService.GetMouseButtonUp(1).Returns(true);
        //    pcInteractionMapper.CheckForDragEnd();

        //    onDragEndGameEvent.Received().Raise();
        //}

        //[Test]
        //public void CheckForDragEnd_LeftMouseButtonDownAndLeftMouseButtonUp_DragEndEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDragEndGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, null, onDragEndGameEvent, null);

        //    unityInputService.GetMouseButtonDown(1).Returns(true);
        //    unityInputService.GetMouseButtonUp(1).Returns(true);
        //    pcInteractionMapper.CheckForDragEnd();

        //    onDragEndGameEvent.Received().Raise();
        //}

        //[Test]
        //public void CheckForDragEnd_LeftMouseButtonAndLeftMouseButtonUp_DragEndEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDragEndGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, null, onDragEndGameEvent, null);

        //    unityInputService.GetMouseButton(1).Returns(true);
        //    unityInputService.GetMouseButtonUp(1).Returns(true);
        //    pcInteractionMapper.CheckForDragEnd();

        //    onDragEndGameEvent.Received().Raise();
        //}

        //[Test]
        //public void CheckForDragEnd_LeftMouseButtonDownAndLeftMouseButtonAndLeftMouseButtonUp_DragEventIsRaised()
        //{
        //    var unityInputService = Substitute.For<IUnityInputService>();
        //    var onDragEndGameEvent = Substitute.For<IGameEvent>();
        //    var pcInteractionMapper = new pcInteractionMapper(unityInputService, null, null, onDragEndGameEvent, null);

        //    unityInputService.GetMouseButtonDown(1).Returns(true);
        //    unityInputService.GetMouseButton(1).Returns(true);
        //    unityInputService.GetMouseButtonUp(1).Returns(true);
        //    pcInteractionMapper.CheckForDragEnd();

        //    onDragEndGameEvent.Received().Raise();
        //}

        //#endregion
    }
}
