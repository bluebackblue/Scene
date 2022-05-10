

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** シーンの起動待ち。次のシーン。
	*/
	public sealed class ChangeAction_WaitActivationNextUnityScene : BlueBack.Scene.ChangeAction_Base<ChangeAction_WaitActivationNextUnityScene.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** CreateActionBox

			a_add_wait_frame			: 追加で待つフレーム数。

		*/
		public static ChangeAction_Box_Base CreateActionBox(int a_add_wait_frame)
		{
			return new ChangeAction_Box<ChangeAction_WaitActivationNextUnityScene.ID>(new ChangeAction_WaitActivationNextUnityScene(a_add_wait_frame),ChangeAction_WaitActivationNextUnityScene.ID.Default);
		}

		/** add_wait_frame

			「loadscene_async.isDone == true」直後はフレームレートが下がる。

		*/
		public int add_wait_frame;

		/** frame
		*/
		public int frame;

		/** constructor
		*/
		private ChangeAction_WaitActivationNextUnityScene(int a_add_wait_frame)
		{
			//add_wait_frame
			this.add_wait_frame = a_add_wait_frame;
		}

		/** [ChangeAction_Base<ID>]Change
		*/
		public void Change(ChangeAction_WaitActivationNextUnityScene.ID a_id,Scene a_scene)
		{
			#if(DEF_BLUEBACK_SCENE_LOG)
			DebugTool.Log("ChangeAction_WaitActivationNextUnityScene : Change");
			#endif

			//frame
			this.frame = this.add_wait_frame;

			//シーン起動。
			a_scene.loadscene_async.allowSceneActivation = true;
		}

		/** [ChangeAction_Base<ID>]Action

			return == true : 完了。

		*/
		public bool Action(ChangeAction_WaitActivationNextUnityScene.ID a_id,Scene a_scene)
		{
			#if(DEF_BLUEBACK_SCENE_LOG)
			DebugTool.Log("ChangeAction_WaitActivationNextUnityScene : Action");
			#endif

			if(a_scene.loadscene_async != null){
				if(a_scene.loadscene_async.isDone == true){
					a_scene.loadscene_async = null;
				}else{
					return false;
				}
			}

			this.frame--;
			if(this.frame <= 0){
				return true;
			}

			return false;
		}
	}
}

