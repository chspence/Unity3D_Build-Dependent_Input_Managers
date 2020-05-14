using InteractionMapper;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR;
using UnityServices;

namespace Tests.EditMode
{
    public class AndroidInteractionMapperTests
    {

        #region CheckSelection

        [Test]
        public void CheckSelection_OneTouchBegan_SelectionOccurredAndTouchPositionReturned()
        {
            var randomTouchPosition = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 0);
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Began,
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
        public void CheckSelection_MultipleTouchesBegan_NoSelectionOccurredAndNoTouchPositionReturned()
        {
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    phase = TouchPhase.Began,
                },
                new Touch
                {
                    phase = TouchPhase.Began,
                }});
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);

            var result = androidInteractionMapper.CheckSelection(out var resultTouchPosition);

            Assert.IsFalse(result);
            Assert.AreEqual(null, resultTouchPosition);
        }

        #endregion

        #region CheckDragging

        [Test]
        public void CheckDragging_OneTouchCausedSelectionAndStationary_DraggingOccurredAndTouchPositionReturned()
        {
            var randomTouchPosition = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 0);
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Began,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            Assert.IsTrue(androidInteractionMapper.CheckSelection(out var resultTouchPosition));
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Stationary,
                }
            });

            var result = androidInteractionMapper.CheckDragging(out resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }

        [Test]
        public void CheckDragging_OneTouchCausedSelectionAndMoved_DraggingOccurredAndTouchPositionReturned()
        {
            var randomTouchPosition = new Vector3(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10), 0);
            var unityInputService = Substitute.For<IUnityInputService>();
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Began,
                }
            });
            var androidInteractionMapper = new AndroidInteractionMapper(unityInputService);
            Assert.IsTrue(androidInteractionMapper.CheckSelection(out var resultTouchPosition));
            unityInputService.GetTouches().Returns(new[]{
                new Touch
                {
                    position = randomTouchPosition,
                    phase = TouchPhase.Moved,
                }
            });

            var result = androidInteractionMapper.CheckDragging(out resultTouchPosition);

            Assert.IsTrue(result);
            Assert.AreEqual(randomTouchPosition, resultTouchPosition);
        }


        [Test]
        public void CheckDragging_OneTouchDidntCauseSelectionAndStationary_NoDraggingOccurredAndNoTouchPositionReturned()
        {
            
        }
        #endregion

        //Dragging should include Began too.... because this isn't 1 to 1 with mouse states, began will return if its the first frame while getmouse and et mouse down both return true simultanesously
        //      maybe check that phase ISNT canceled or ended, but does this contradict
        //      check for 1 touch, which is the selected touch... hmm then if dragging ever ran before selection it wouldnt have a selected touch and return false that frame
        // Dragging must be immediately after a selection and connected to it, else 1 touch selection and dragging, 2 touches, dragend, remove 1 touch/1 remains, dragging again
        //  (if CheckDragging were to only check for "the existence of one touch" instead of "the continuation of a specific selection")
        // multiple touches causes select and drag to fail, dragend always fired if a touch is being tracked, regardless of tracked touch's phase
        // end/canceled phases should both trigger DragEnd
        // need to be able to track touch via id between frames, might be play test or a yield in edit test. create a new test script to see what that sample says about skipping frames in the editor

    }
}
