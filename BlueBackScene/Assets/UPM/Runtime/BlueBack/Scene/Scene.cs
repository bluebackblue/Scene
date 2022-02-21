

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
	public sealed class Scene : System.IDisposable
	{
		/** Phase
		*/
		private enum Phase
		{
			/** Null
			*/
			Null,

			/** 開始。初回。
			*/
			StartFirst,

			/** 開始。
			*/
			Start,

			/** 実行。
			*/
			Running,

			/** 終了。初回。
			*/
			EndFirst,

			/** 終了。
			*/
			End,
		}

		/** phase
		*/
		private Phase phase;

		/** scene
		*/
		private Scene_Base scene_current;
		private Scene_Base scene_request;
		private Scene_Base scene_next;

		/** async
		*/
		private UnityEngine.AsyncOperation async;

		/** startdelay

			「this.async.isDone == true」直後はフレームレートが下がる。

		*/
		private int startdelay;

		/** callback_gameobject
		*/
		private UnityEngine.GameObject callback_gameobject;

		/** constructor
		*/
		public Scene()
		{
			//phase
			this.phase = Phase.Null;

			//scene
			this.scene_current = null;
			this.scene_request = null;
			this.scene_next = null;

			//async
			this.async = null;

			//startdelay
			this.startdelay = 0;

			//callback
			this.callback_gameobject = new UnityEngine.GameObject("Scene");
			UnityEngine.GameObject.DontDestroyOnLoad(this.callback_gameobject);
			this.callback_gameobject.AddComponent<CallBack_MonoBehaviour>().scene = this;

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
		public void SetNextScene(Scene_Base a_scene)
		{
			this.scene_request = a_scene;
		}

		/** IsNextScene
		*/
		public bool IsNextScene()
		{
			return (this.scene_request != null);
		}

		/** OnUnityUpdate
		*/
		public void OnUnityUpdate()
		{
			this.Inner_PhaseUpdate();
			if(this.phase == Phase.Running){
				this.scene_current.UnityUpdate();
			}
		}

		/** OnUnityLateUpdate
		*/
		public void OnUnityLateUpdate()
		{
			if(this.phase == Phase.Running){
				this.scene_current.UnityLateUpdate();
			}
		}

		/** OnUnityFixedUpdate
		*/
		public void OnUnityFixedUpdate()
		{
			if(this.phase == Phase.Running){
				this.scene_current.UnityFixedUpdate();
			}
		}

		/** Inner_PhaseUpdate
		*/
		private void Inner_PhaseUpdate()
		{
			switch(this.phase){
			case Phase.Null:
				{
					if(this.scene_request != null){
						//リクエストあり。
						this.scene_current = this.scene_request;
						this.scene_request = null;
						this.phase = Phase.StartFirst;

						//シーン。読み込み開始。
						string t_scene_name = this.scene_current.GetSceneName();
						if(t_scene_name != null){
							this.async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_scene_name,UnityEngine.SceneManagement.LoadSceneMode.Single);
							if(this.async != null){
								this.async.allowSceneActivation = true;
							}else{
								#if(DEF_BLUEBACK_SCENE_ASSERT)
								DebugTool.Assert(false,t_scene_name);
								#endif
							}
						}
					}
				}break;
			case Phase.StartFirst:
				{
					//開始。初回。

					this.scene_current.CurrentSceneStartFirst();
					this.phase = Phase.Start;
					this.startdelay = 0;
				}break;
			case Phase.Start:
				{
					//開始。

					bool t_fix = true;

					if(this.async != null){
						t_fix = false;
						if(this.async.isDone == true){
							this.async = null;
							this.startdelay = 5;
						}
					}else if(this.startdelay > 0){
						this.startdelay--;
						t_fix = false;
					}

					if(this.scene_current.CurrentSceneStart(t_fix) == true){
						if(t_fix == true){
							this.phase = Phase.Running;
						}
					}
				}break;
			case Phase.Running:
				{
					//実行。

					if(this.scene_current.CurrentSceneRunning() == true){
						//シーン遷移を許可。
						if(this.scene_request != null){
							this.scene_next = this.scene_request;
							this.scene_request = null;
							this.phase = Phase.EndFirst;
						}
					}
				}break;
			case Phase.EndFirst:
				{
					//終了。初回。

					this.scene_current.CurrentSceneEndFirst();
					this.scene_next.BeforeSceneEndFirst();
					this.phase = Phase.End;

					//シーン。読み込み開始。
					string t_scene_name = this.scene_next.GetSceneName();
					if(t_scene_name != null){
						this.async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_scene_name,UnityEngine.SceneManagement.LoadSceneMode.Single);
						this.async.allowSceneActivation = false;
					}
				}break;
			case Phase.End:
				{
					//終了。

					if(this.scene_current.CurrentSceneEnd() == true){
						//終了シーン。完了。
						this.scene_next.BeforeSceneEndLast();
						this.scene_current = this.scene_next;
						this.scene_next = null;
						this.phase = Phase.StartFirst;
						this.startdelay = 0;

						//シーン。許可。
						if(this.async != null){
							this.async.allowSceneActivation = true;
						}
					}else{
						this.scene_next.BeforeSceneEnd();
					}
				}break;
			}
		}
	}
}

