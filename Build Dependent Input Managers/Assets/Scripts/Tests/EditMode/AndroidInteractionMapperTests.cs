using InteractionMapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityServices;

namespace Tests.EditMode
{
    public class AndroidInteractionMapperTests
    {

        #region CheckSelection

        [Test]
        public void CheckSelection_OneTouchBegan_SelectionOccurredAndTouchPositionReturned()
        {
            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Began
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckSelection(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckSelection_NoTouches_NoSelectionOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckSelection(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckSelection_OneTouchNotBegan_NoSelectionOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Stationary,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckSelection(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckSelection_MultipleTouches_NoSelectionOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                },
                new Touch
                {
                    phase = TouchPhase.Stationary,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckSelection(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        #endregion

        #region CheckDragging

        [Test]
        public void CheckDragging_OneTouchBegan_DraggingOccurredAndTouchPositionReturned()
        {
            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Began,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_NoTouches_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_MultipleTouches_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                },
                new Touch
                {
                    phase = TouchPhase.Stationary,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchMoved_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Moved,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchStationary_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Stationary,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchEnded_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Ended,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchCanceled_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Canceled,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchStationaryAndWasPreviouslyDragging_DraggingOccurredAndTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Stationary,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchMovedAndWasPreviouslyDragging_DraggingOccurredAndTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Moved,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchMovedAndWasThenWasNotPreviouslyDragging_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            unityInputService.GetTouches().Returns(new Touch[0]);
            result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsFalse(result);

            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Moved,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchStationaryAndWasThenWasNotPreviouslyDragging_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            unityInputService.GetTouches().Returns(new []{
                new Touch
                {
                    phase = TouchPhase.Moved,
                    fingerId = fingerId,
                },
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId + 1,
                }
            });
            result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsFalse(result);

            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Stationary,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragging(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        #endregion

        #region CheckDragEnd

        [Test]
        public void CheckDragEnd_OneTouchBegan_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchMoved_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Moved,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchStationary_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Stationary,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchEnded_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Ended,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchCanceled_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Canceled,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_NoTouches_NoDragEndOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchEndedAndWasPreviouslyDragging_DragEndOccurredAndTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Ended,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_OneTouchCanceledAndWasPreviouslyDragging_DragEndOccurredAndTouchPositionReturned()
        {
            var fingerId = Random.Range(0, 9);
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                    fingerId = fingerId,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            var randomTouchPosition = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Canceled,
                    fingerId = fingerId,
                }});

            result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragEnd_MultipleTouchesAndWasPreviouslyDragging_DragEndOccurredAndTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    fingerId = 1,
                    phase = TouchPhase.Began,
                }});
            var result = androidInteractionMapper.CheckDragging(out _);
            Assert.IsTrue(result);

            var randomTouchPosition1 = new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0);
            var randomTouchPosition2 = new Vector3(randomTouchPosition1.x + 1, randomTouchPosition1.y + 1, 0);
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition2,
                    phase = TouchPhase.Began,
                    fingerId = 2,
                },
                new Touch
                {
                    position = randomTouchPosition1,
                    phase = TouchPhase.Stationary,
                    fingerId = 1,
                }
                });

            result = androidInteractionMapper.CheckDragEnd(out var resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition1, resultTouchPosition);
        }

        #endregion

    }
}
