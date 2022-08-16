

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** シングルロードリクエスト。次のシーン。
	*/
	public sealed class ChangeAction_SingleLoadRequestNextUnityScene : BlueBack.Scene.ChangeAction_Base<ChangeAction_SingleLoadRequestNextUnityScene.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** Create

			a_sceneactivation_allow : シーンを起動。

		*/
		public static ChangeAction_Item_Base Create(bool a_sceneactivation_allow)
		{
			return new ChangeAction_Item<ChangeAction_SingleLoadRequestNextUnityScene.ID>(new ChangeAction_SingleLoadRequestNextUnityScene(a_sceneactivation_allow),ChangeAction_SingleLoadRequestNextUnityScene.ID.Default);
		}

		/** シーンを起動。
		*/
		public bool sceneactivation_allow;

		/** constructor
		*/
		private ChangeAction_SingleLoadRequestNextUnityScene(bool a_sceneactivation_allow)
		{
			this.sceneactivation_allow = a_sceneactivation_allow;
		}

		/** [ChangeAction_Base<ID>]Change
		*/
		public void Change(ChangeAction_SingleLoadRequestNextUnityScene.ID a_id,Scene a_scene)
		{
			#if(DEF_BLUEBACK_DEBUG_ASSERT)
			DebugTool.Assert(a_scene.loadscene_async == null,"error");
			#endif

			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("ChangeAction_SingleLoaRequestNextUnityScene : Change");
			#endif

			string t_scene_name = a_scene.scene_next.GetUnitySceneName();
			if(t_scene_name != null){
				a_scene.loadscene_async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(t_scene_name,UnityEngine.SceneManagement.LoadSceneMode.Single);
				if(a_scene.loadscene_async != null){
					a_scene.loadscene_async.allowSceneActivation = this.sceneactivation_allow;
				}else{
					#if(DEF_BLUEBACK_DEBUG_ASSERT)
					DebugTool.Assert(false,t_scene_name);
					#endif
				}
			}else{
				a_scene.loadscene_async = null;
			}
		}

		/** [ChangeAction_Base<ID>]Action

			return == true : 完了。

		*/
		public bool Action(ChangeAction_SingleLoadRequestNextUnityScene.ID a_id,Scene a_scene)
		{
			return true;
		}
	}
}

