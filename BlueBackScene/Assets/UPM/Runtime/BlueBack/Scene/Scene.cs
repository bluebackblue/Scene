

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** Scene
	*/
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public sealed class Scene : System.IDisposable
	{
		/** status
		*/
		public Status status;

		/** phase
		*/
		public Phase phase;

		/** constructor
		*/
		public Scene(in InitParam a_initparam)
		{
			//step
			this.status.step = Step.Boot;

			//action
			this.status.changeaction_index = 0;
			this.status.changeaction_list = null;

			//phase_type
			this.phase = new Phase();

			//scene
			this.status.scene_current = null;
			this.status.scene_next = null;

			//request
			this.status.request_scene = null;
			this.status.request_changeaction_list = null;

			//loadscene_async
			this.status.loadscene_async = null;

			//unitycallback
			this.status.unitycallback_monobehaviour = UnityCallBack_MonoBehaviour.CreateInstance(in a_initparam,this);

			//debugview
			#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
			this.status.debugview_monobehaviour = DebugView_MonoBehaviour.CreateInstance(in a_initparam,this);
			#endif
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			//debugview
			#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
			DebugView_MonoBehaviour.DeleteInstance(ref this.status.debugview_monobehaviour);
			#endif

			//unitycallback
			UnityCallBack_MonoBehaviour.DeleteInstance(ref this.status.unitycallback_monobehaviour);

			//phase
			if(this.phase != null){
				this.phase.Dispose();
				this.phase = null;
			}
		}

		/** SetNextScene
		*/
		public void SetNextScene(Scene_Base a_scene,ChangeAction.Item_Base[] a_changeaction_list)
		{
			//request
			this.status.request_scene = a_scene;
			this.status.request_changeaction_list = a_changeaction_list;
		}

		/** ManualUpdate
		*/
		public void ManualUpdate()
		{
			//phase
			this.phase.ManualUpdate(ref this.status);
		}
	}
}

