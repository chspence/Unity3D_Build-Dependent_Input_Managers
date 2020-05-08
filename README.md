"# Unity3D_Build-Dependent_Input_Managers" 

Notable aspects of this project
	Scriptable Objects for Dependency Injection via Unity Editor Scriptable-Object references which are determined at runtime
		It should be noted that while not implemented for this example, the Factory pattern could be used for instantiating Scriptable-Object-dependent objects at runtime via premade factories with Scriptable Object references made in the Unity Editor
		This was done as an alternative to:
			DI Frameworks (Projects become heavily dependent on continued third-party support and add another level of dependency ambiguity to the already reference-driven Unity Editor, ex Zenject)
			Service Locator pattern (potentially slow, interface-locating custom logic. Many sources stated they use this approach so further investigation for valid usage might be warranted)
			Singleton anti-pattern (large amounts of coupling potentially introduced)
	Humble Object pattern utilized to isolate Unity framework static classes from the project-specific logic to allow for easy Unit testing of project code via interface mocking
	TDD applied for "fully" tested project logic (excluding the above stated exceptions for humble wrapper classes used to handle runtime Unity MonoBehaviours events, ie Awake, Start, Update, etc)
		Test Class per Class being tested
		"MethodName_StateUnderTest_ExpectedResult" test method naming standard
			"What if the method is renamed?", its a price in time I'm willing to pay for readability
	
Technology Stack
	Unity 2019.3.11f1
	Visual Studio 2017 Community
	NUnit
	NSubstitute (version 2.0.3.0/.../net35/NSubstitute.dll works for listed version of Unity)
		Copy .dll into Asset folder and add it as an "Assembly Reference" for the test-specific Assembly

References
	TDD in Unity:
		https://blogs.unity3d.com/2018/11/02/testing-test-driven-development-with-the-unity-test-runner/
	
	Game Architecture with Scriptable Objects - Video:
		https://www.youtube.com/watch?v=raQ3iHhE_Kk

	Game Architecture with Scriptable Objects - Blog:
		https://unity.com/how-to/architect-game-code-scriptable-objects

	Unit testing Scriptable Objects:
		https://forum.unity.com/threads/unit-testing-scriptableobjects.501457/

	Unit Testing Player Input in Unity - Video (Humble Object wrapping Unity Framework):
		https://www.youtube.com/watch?v=MGx5mb5b3sY&list=LLBSPX1RMEN2A6io0IGVlcuw

	Importing NSubstitute:
		https://answers.unity.com/questions/1582128/unity20183-nsubstitute-how-to-import.html