

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene.ChangeAction
*/
namespace BlueBack.Scene.ChangeAction
{
	/** シングルロードリクエスト。次のシーン。
	*/
	public sealed class SingleLoadRequestNextUnityScene : BlueBack.Scene.ChangeAction.Execute_Base<SingleLoadRequestNextUnityScene.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** Create

			a_sceneactivation_allow : シーンを起動。

		*/
		public static Item_Base Create(bool a_sceneactivation_allow)
		{
			return new BlueBack.Scene.ChangeAction.Item<SingleLoadRequestNextUnityScene.ID>(new SingleLoadRequestNextUnityScene(a_sceneactivation_allow),SingleLoadRequestNextUnityScene.ID.Default);
		}

		/** シーンを起動。
		*/
		public bool sceneactivation_allow;

		/** constructor
		*/
		private SingleLoadRequestNextUnityScene(bool a_sceneactivation_allow)
		{
			this.sceneactivation_allow = a_sceneactivation_allow;
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]開始。
		*/
		public void Start(SingleLoadRequestNextUnityScene.ID a_id,ref BlueBack.Scene.Status a_status)
		{
			#if(DEF_BLUEBACK_DEBUG_ASSERT)
			DebugTool.Assert(a_status.loadscene_async == null,"error");
			#endif

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("ChangeAction_SingleLoaRequestNextUnityScene : Change");
			#endif

			string t_scene_name = a_status.scene_next.GetUnitySceneName();
			if(t_scene_name != null){
				a_status.loadscene_async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_scene_name,UnityEngine.SceneManagement.LoadSceneMode.Single);
				if(a_status.loadscene_async != null){
					a_status.loadscene_async.allowSceneActivation = this.sceneactivation_allow;
				}else{
					#if(DEF_BLUEBACK_DEBUG_ASSERT)
					DebugTool.Assert(false,t_scene_name);
					#endif
				}
			}else{
				a_status.loadscene_async = null;
			}
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]アクション。

			return == true : 完了。

		*/
		public bool Action(SingleLoadRequestNextUnityScene.ID a_id,ref BlueBack.Scene.Status a_status)
		{
			return true;
		}
	}
}

