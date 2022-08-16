

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
	public sealed class Scene : System.IDisposable , UnityCallBack_Base
	{
		/** action
		*/
		public ChangeAction_Item_Base[] action_changeaction_list;
		public int action_index;

		/** phase
		*/
		public PhaseType phase;

		/** scene
		*/
		public Scene_Base scene_current;
		public Scene_Base scene_next;

		/** request
		*/
		public Scene_Base request_scene;
		public ChangeAction_Item_Base[] request_changeaction_list;

		/** loadscene_async
		*/
		public UnityEngine.AsyncOperation loadscene_async;

		/** callback_gameobject
		*/
		private UnityEngine.GameObject callback_gameobject;

		/** constructor
		*/
		public Scene()
		{
			//action
			this.action_changeaction_list = null;
			this.action_index = 0;

			//phase
			this.phase = PhaseType.Boot;

			//scene
			this.scene_current = null;
			this.scene_next = null;

			//request
			this.request_scene = null;
			this.request_changeaction_list = null;

			//loadscene_async
			this.loadscene_async = null;

			//callback
			this.callback_gameobject = new UnityEngine.GameObject("Scene");
			UnityEngine.GameObject.DontDestroyOnLoad(this.callback_gameobject);
			this.callback_gameobject.AddComponent<UnityCallBack_MonoBehaviour>().unitycallback = this;

			#if(DEF_BLUEBACK_SCENE_HIDEINNERGAMEOBJECT)
			this.callback_gameobject.hideFlags = UnityEngine.HideFlags.HideInHierarchy;
			#endif
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			if(this.callback_gameobject != null){
				UnityEngine.GameObject.Destroy(this.callback_gameobject);
				this.callback_gameobject = null;
			}
		}

		/** SetNextScene
		*/
		public void SetNextScene(Scene_Base a_scene,ChangeAction_Item_Base[] a_changeaction_list)
		{
			//request
			this.request_scene = a_scene;
			this.request_changeaction_list = a_changeaction_list;
		}

		/** [BlueBack.Scene.UnityCallBack_Base]UnityUpdate
		*/
		public void UnityUpdate()
		{
			this.Inner_PhaseUpdate();
			if(this.scene_current != null){
				this.scene_current.UnityUpdate(this.phase);
			}
		}

		/** [BlueBack.Scene.UnityCallBack_Base]UnityFixedUpdate
		*/
		public void UnityFixedUpdate()
		{
			if(this.scene_current != null){
				this.scene_current.UnityFixedUpdate(this.phase);
			}
		}

		/** [BlueBack.Scene.UnityCallBack_Base]UnityLateUpdate
		*/
		public void UnityLateUpdate()
		{
			if(this.scene_current != null){
				this.scene_current.UnityLateUpdate(this.phase);
			}
		}

		/** Inner_PhaseUpdate
		*/
		private void Inner_PhaseUpdate()
		{
			switch(this.phase){
			case PhaseType.Boot:
				{
					//起動。

					#if(DEF_BLUEBACK_DEBUG_LOG)
					DebugTool.Log(string.Format("{0} : {1}","Inner_Update",this.phase));
					#endif

					if(this.request_scene != null){
						//リクエストあり。

						//scene
						this.scene_current = null;
						this.scene_next = this.request_scene;

						//action
						this.action_changeaction_list = this.request_changeaction_list;
						this.action_index = 0;

						//request
						this.request_scene = null;
						this.request_changeaction_list = null;

						//phase
						this.phase = PhaseType.ChangeAction;

						//Change
						if(this.action_changeaction_list != null){
							if(this.action_index < this.action_changeaction_list.Length){
								this.action_changeaction_list[this.action_index].Change(this);
							}
						}
					}
				}break;
			case PhaseType.ChangeAction:
				{
					#if(DEF_BLUEBACK_DEBUG_LOG)
					DebugTool.Log(string.Format("{0} : {1}","Inner_Update",this.phase));
					#endif

					bool t_fix = false;

					//action_changeaction_list
					if(this.action_changeaction_list != null){
						if(this.action_index < this.action_changeaction_list.Length){
							if(this.action_changeaction_list[this.action_index].Action(this) == true){
								this.action_index++;
								if(this.action_index < this.action_changeaction_list.Length){
									this.action_changeaction_list[this.action_index].Change(this);
								}else{
									t_fix = true;
								}
							}
						}else{
							t_fix = true;
						}
					}else{
						t_fix = true;
					}

					//fix
					if(t_fix == true){
						Scene_Base t_prev_scene = this.scene_current;

						if(this.scene_current != null){
							this.scene_current.SceneEnd(this.scene_next);
						}

						this.scene_current = this.scene_next;
						this.scene_next = null;

						this.action_changeaction_list = null;
						this.action_index = 0;

						this.phase = PhaseType.Running;

						this.scene_current.SceneStart(t_prev_scene);
					}
				}break;
			case PhaseType.Running:
				{
					if(this.request_scene != null){
						//リクエストあり。

						//scene
						this.scene_next = this.request_scene;

						//action
						this.action_changeaction_list = this.request_changeaction_list;
						this.action_index = 0;

						//request
						this.request_scene = null;
						this.request_changeaction_list = null;

						//phase
						this.phase = PhaseType.ChangeAction;

						//Change
						this.action_changeaction_list[this.action_index].Change(this);
					}
				}break;
			}
		}
	}
}

