//using System;

//public class BoolGameEventListener : NoParameterGameEventListener
//{
//    public new BoolUnityEvent Response;

//    public void OnEventRaised(object[] parameters)
//    {
//        if (!(parameters?[0] is bool))
//            throw new ArgumentException(
//                $"parameters[0] expected to be bool but was {parameters?[0].GetType()}");


//        Response.Invoke((bool)parameters[0]);
//    }
//}