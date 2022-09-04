

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** UnityCallBack_MonoBehaviour
	*/
	#if(!DEF_BLUEBACK_SCENE_DISABLE_DEFAULTEXECUTIONORDER)
	[UnityEngine.DefaultExecutionOrder(-1)]
	#endif
	public sealed class UnityCallBack_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** [cache]scene
		*/
		public Scene scene;

		/** CreateInstance
		*/
		public static UnityCallBack_MonoBehaviour CreateInstance(in InitParam a_initparam,Scene a_scene)
		{
			//new UnityEngine.GameObject
			UnityEngine.GameObject t_gameobject = new UnityEngine.GameObject(a_initparam.unitycallback_name);

			//DontDestroyOnLoad
			UnityEngine.GameObject.DontDestroyOnLoad(t_gameobject);

			//AddComponent
			UnityCallBack_MonoBehaviour t_monobehaviour = t_gameobject.AddComponent<UnityCallBack_MonoBehaviour>();

			//[cache]scene
			t_monobehaviour.scene = a_scene;

			//hideFlags
			if(a_initparam.unitycallback_hide == true){
				t_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
			}

			return t_monobehaviour;
		}

		/** DeleteInstance
		*/
		public static void DeleteInstance(ref UnityCallBack_MonoBehaviour a_monobehaviour)
		{
			if(a_monobehaviour != null){
				//scene
				a_monobehaviour.scene = null;

				//Destroy
				UnityEngine.GameObject.Destroy(a_monobehaviour.gameObject);
				a_monobehaviour = null;
			}
		}

		/** Update
		*/
		private void Update()
		{
			if(this.scene != null){
				this.scene.phase.UnityUpdate(ref this.scene.status);
			}
		}

		/** LateUpdate
		*/
		private void FixedUpdate()
		{
			if(this.scene != null){
				this.scene.phase.UnityFixedUpdate(ref this.scene.status);
			}
		}

		/** LateUpdate
		*/
		private void LateUpdate()
		{
			if(this.scene != null){
				this.scene.phase.UnityLateUpdate(ref this.scene.status);
			}
		}
	}
}

