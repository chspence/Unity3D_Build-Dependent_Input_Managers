//using System;
//using System.Collections;
//using NSubstitute;
//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.TestTools;

//namespace Tests.EditMode
//{
//    public class GameEventTests
//    {
//        #region OverriddenRaise

//        [Test]
//        public void Raise_NoListeners_NoError()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();

//            try
//            {
//                gameEvent.OverriddenRaise();
//            }
//            catch (Exception e)
//            {
//                Assert.Fail(e.Message);
//            }
//            Assert.Pass();
//        }

//        [Test]
//        public void Raise_OneListener_ListenerMethodIsCalled()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet = false;
//            var noParameterGameEventListener = new Vector3GameEventListener{Response = new Vector3UnityEvent<object[]>()};
//            noParameterGameEventListener.Response.AddListener((input) => valueBeingSet = true);
//            gameEvent.RegisterListener(noParameterGameEventListener);

//            gameEvent.OverriddenRaise();

//            Assert.AreEqual(true, valueBeingSet);
//        }

//        [Test]
//        public void Raise_OneListenerWithOneParameterInResponse_ListenerMethodIsCalledCorrectly()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet = Vector3.zero;
//            var parameter = Vector3.one;
//            var noParameterGameEventListener = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            noParameterGameEventListener.Response.AddListener((input) => valueBeingSet = (Vector3) input[0]);
//            gameEvent.RegisterListener(noParameterGameEventListener);

//            gameEvent.OverriddenRaise(parameter);

//            Assert.AreEqual(parameter, valueBeingSet);
//        }

//        [Test]
//        public void Raise_OneListenerWithMultipleParametersInResponse_ListenerMethodIsCalledCorrectly()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet = 0;
//            var parameter1 = 1;
//            var parameter2 = 1;
//            var noParameterGameEventListener = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            noParameterGameEventListener.Response.AddListener((input) => valueBeingSet = (int)input[0] + (int)input[1]);
//            gameEvent.RegisterListener(noParameterGameEventListener);

//            gameEvent.OverriddenRaise(parameter1, parameter2);

//            Assert.AreEqual(parameter1 + parameter2, valueBeingSet);
//        }

//        [Test]
//        public void Raise_MultipleListeners_ListenerMethodsAreCalled()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet1 = false;
//            var valueBeingSet2 = false;
//            var gameEventListener1 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener1.Response.AddListener((input) => valueBeingSet1 = true);
//            gameEvent.RegisterListener(gameEventListener1);
//            var gameEventListener2 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener2.Response.AddListener((input) => valueBeingSet2 = true);
//            gameEvent.RegisterListener(gameEventListener2);

//            gameEvent.OverriddenRaise();

//            Assert.AreEqual(true, valueBeingSet1);
//            Assert.AreEqual(true, valueBeingSet2);
//        }

//        [Test]
//        public void Raise_MultipleListenersWithOneParameterInResponse_ListenerMethodsAreCalledCorrectly()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet1 = false;
//            var valueBeingSet2 = false;
//            var parameter = true;
//            var gameEventListener1 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener1.Response.AddListener((input) => valueBeingSet1 = (bool)input[0]);
//            gameEvent.RegisterListener(gameEventListener1);
//            var gameEventListener2 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener2.Response.AddListener((input) => valueBeingSet2 = (bool)input[0]);
//            gameEvent.RegisterListener(gameEventListener2);

//            gameEvent.OverriddenRaise(parameter);

//            Assert.AreEqual(parameter, valueBeingSet1);
//            Assert.AreEqual(parameter, valueBeingSet2);
//        }

//        [Test]
//        public void Raise_MultipleListenersWithMultipleParametersInResponse_ListenerMethodsAreCalledCorrectly()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet1 = 0;
//            var valueBeingSet2 = 0;
//            var parameter1 = 1;
//            var parameter2 = 1;
//            var gameEventListener1 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener1.Response.AddListener((input) => valueBeingSet1 = (int)input[0] + (int)input[1]);
//            gameEvent.RegisterListener(gameEventListener1);
//            var gameEventListener2 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener2.Response.AddListener((input) => valueBeingSet2 = (int)input[0] + (int)input[1]);
//            gameEvent.RegisterListener(gameEventListener2);

//            gameEvent.OverriddenRaise(parameter1, parameter2);

//            Assert.AreEqual(parameter1 + parameter2, valueBeingSet1);
//            Assert.AreEqual(parameter1 + parameter2, valueBeingSet2);
//        }

//        [Test]
//        public void Raise_OneListenerUnregistered_ListenerMethodNotCalled()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet = false;
//            var noParameterGameEventListener = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            noParameterGameEventListener.Response.AddListener((input) => valueBeingSet = true);
//            gameEvent.RegisterListener(noParameterGameEventListener);

//            gameEvent.UnregisterListener(noParameterGameEventListener);
//            gameEvent.OverriddenRaise();

//            Assert.AreEqual(false, valueBeingSet);
//        }

//        [Test]
//        public void Raise_MultipleListenersUnregistered_ListenerMethodsNotCalled()
//        {
//            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
//            var valueBeingSet1 = false;
//            var valueBeingSet2 = false;
//            var gameEventListener1 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener1.Response.AddListener((input) => valueBeingSet1 = true);
//            gameEvent.RegisterListener(gameEventListener1);
//            var gameEventListener2 = new Vector3GameEventListener { Response = new Vector3UnityEvent<object[]>() };
//            gameEventListener2.Response.AddListener((input) => valueBeingSet2 = true);
//            gameEvent.RegisterListener(gameEventListener2);

//            gameEvent.UnregisterListener(gameEventListener1);
//            gameEvent.UnregisterListener(gameEventListener2);
//            gameEvent.OverriddenRaise();

//            Assert.AreEqual(false, valueBeingSet1);
//            Assert.AreEqual(false, valueBeingSet2);
//        }

//        #endregion
//    }
//}
