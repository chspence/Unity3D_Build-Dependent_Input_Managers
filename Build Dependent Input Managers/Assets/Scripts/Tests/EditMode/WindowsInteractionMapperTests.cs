using InteractionMapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityServices;

namespace Tests.EditMode
{
    public class WindowsInteractionMapperTests
    {

        #region CheckSelection

        [Test]
        public void CheckSelection_PrimaryMouseClicked_SelectionOccurredAndMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0,10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButtonDown(0).Returns(true);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckSelection(out var resultMousePosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomMousePosition, resultMousePosition);
        }

        [Test]
        public void CheckSelection_PrimaryMouseNotClicked_NoSelectionOccurredAndNoMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButtonDown(0).Returns(false);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckSelection(out var resultMousePosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultMousePosition);
        }

        #endregion

        #region CheckDragging

        [Test]
        public void CheckDragging_PrimaryMouseHeldDown_DraggingOccurredAndMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0,10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButton(0).Returns(true);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckDragging(out var resultMousePosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomMousePosition, resultMousePosition);
        }

        [Test]
        public void CheckDragging_PrimaryMouseNotHeldDown_NoDraggingOccurredAndNoMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0,10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButton(0).Returns(false);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckDragging(out var resultMousePosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultMousePosition);
        }

        [Test]
        public void CheckDragging_PrimaryMouseHeldDownAndReleased_NoDraggingOccurredAndNoMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0,10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButton(0).Returns(true);
            unityInputService.GetMouseButtonUp(0).Returns(true);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckDragging(out var resultMousePosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultMousePosition);
        }

        #endregion

        #region CheckForDragEnd

        [Test]
        public void CheckDragEnd_PrimaryMouseReleased_DragEndOccurredAndMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0,10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButtonUp(0).Returns(true);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckDragEnd(out var resultMousePosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomMousePosition, resultMousePosition);
        }

        [Test]
        public void CheckDragEnd_PrimaryMouseNotReleased_NoDragEndAndNoMousePositionReturned()
        {
            var randomMousePosition = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetMouseButtonUp(0).Returns(false);
            unityInputService.GetMousePosition().Returns(randomMousePosition);
            var windowsInteractionMapper = new WindowsInteractionMapper(unityInputService);

            var result = windowsInteractionMapper.CheckDragEnd(out var resultMousePosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultMousePosition);
        }

        #endregion
    }
}
