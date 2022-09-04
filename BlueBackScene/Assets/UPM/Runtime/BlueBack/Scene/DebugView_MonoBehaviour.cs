

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。デバッグ表示。
*/


/** BlueBack.Scene
*/
#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
namespace BlueBack.Scene
{
	/** DebugView_MonoBehaviour
	*/
	public sealed class DebugView_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** [cache]scene
		*/
		public Scene scene;

		/** CreateInstance
		*/
		public static DebugView_MonoBehaviour CreateInstance(in InitParam a_initparam,Scene a_scene)
		{
			//new UnityEngine.GameObject
			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject(a_initparam.debugview_name);

			//DontDestroyOnLoad
			UnityEngine.GameObject.DontDestroyOnLoad(t_gameobject);

			//AddComponent
			DebugView_MonoBehaviour t_monobehaviour = t_gameobject.AddComponent<DebugView_MonoBehaviour>();

			//[cache]scene
			t_monobehaviour.scene = a_scene;

			return t_monobehaviour;
		}

		/** DeleteInstance
		*/
		public static void DeleteInstance(ref DebugView_MonoBehaviour a_monobehaviour)
		{
			if(a_monobehaviour != null){
				//scene
				a_monobehaviour.scene = null;

				//Destroy
				UnityEngine.GameObject.Destroy(a_monobehaviour.gameObject);
				a_monobehaviour = null;
			}
		}
	}
}
#endif

