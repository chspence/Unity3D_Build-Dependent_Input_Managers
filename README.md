# Unity3D Build-Dependent Input Managers

A project for testing a handful of approaches to thoughtful software design within the Unity3D design platform. 

The goal is to create an Input Management system which determines at runtime which set of (Input.) Inputs to validate event triggering logic from based on the current build's platform while also being EditMode unit-testable for non-Unity-specific logic as well as highly decoupled between the various game systems.

* Focus points
  - SOLID Design Principles
  - Scriptable Objects for Dependency Injection via Unity Editor Scriptable-Object references which are determined at runtime
    - It should be noted that while not implemented for this project, the Factory pattern is a viable approach to further pass dependencies via references made in the Unity Editor  
  - Humble Object pattern utilized to isolate Unity framework static classes from the project-specific logic to allow for EditMode testing through interface mocking
  - TDD design loop applied for "fully" tested project logic
    - Excluding the above stated exceptions for humble wrapper objects used to handle runtime Unity MonoBehaviour events, ie Awake, Start, Update, etc
    
- Some alternatives to the DI approach mentioned above were found during the project research and planning and given below for contrast:
  - DI Frameworks (ex Zenject)
    - Projects become heavily dependent on continued third-party support, eventully your project can't survive without it
    - Addition of another level of dependency ambiguity to the already reference-driven Unity Editor
  - Service Locator pattern
    - In a way, the effect of this is what happens with the decided-upon approach
    - Potentially slow, due to using reflection method for interface-locating
    - In my research, many individuals stated some variation of this approach so definitely potential with this
  - Singleton anti-pattern 
    - High coupling throughout code 
    - "Dependency Web" is likely to lead to lack of ability to modularly interact with the system created 

Technology Stack
- Unity 2019.3.11f1
- Visual Studio 2017 Community
- Unity Test Runner 
- NUnit
- NSubstitute (version 2.0.3.0/.../net35/NSubstitute.dll works for listed version of Unity)
  - Copy .dll into Asset folder and add it as an "Assembly Reference" for the test-specific Assembly

References
* [TDD in Unity - Blog](https://blogs.unity3d.com/2018/11/02/testing-test-driven-development-with-the-unity-test-runner/)

* [Game Architecture with Scriptable Objects - Video](https://www.youtube.com/watch?v=raQ3iHhE_Kk)

* [Game Architecture with Scriptable Objects - Blog](https://unity.com/how-to/architect-game-code-scriptable-objects)

* [Unit Testing Scriptable Objects - Forum Post](https://forum.unity.com/threads/unit-testing-scriptableobjects.501457/)

* [Unit Testing Player Input in Unity aka "Humble Object Wrapping the Unity Framework" - Video](https://www.youtube.com/watch?v=MGx5mb5b3sY&list=LLBSPX1RMEN2A6io0IGVlcuw)

* [Importing NSubstitute - Forum Post](https://answers.unity.com/questions/1582128/unity20183-nsubstitute-how-to-import.html)

* [Understanding Method Injection - Blog](https://freecontent.manning.com/understanding-method-injection/)