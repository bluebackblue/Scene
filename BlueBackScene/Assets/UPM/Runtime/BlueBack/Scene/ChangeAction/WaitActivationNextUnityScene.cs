

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene.ChangeAction
*/
namespace BlueBack.Scene.ChangeAction
{
	/** シーンの起動待ち。次のシーン。
	*/
	public sealed class WaitActivationNextUnityScene : BlueBack.Scene.ChangeAction.Execute_Base<WaitActivationNextUnityScene.ID>
	{
		/** ID
		*/
		public enum ID{Default=0}

		/** Create

			a_add_wait_frame : 追加で待つフレーム数。

		*/
		public static Item_Base Create(int a_add_wait_frame)
		{
			return new BlueBack.Scene.ChangeAction.Item<WaitActivationNextUnityScene.ID>(new WaitActivationNextUnityScene(a_add_wait_frame),WaitActivationNextUnityScene.ID.Default);
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
		private WaitActivationNextUnityScene(int a_add_wait_frame)
		{
			//add_wait_frame
			this.add_wait_frame = a_add_wait_frame;
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]開始。
		*/
		public void Start(WaitActivationNextUnityScene.ID a_id,ref Status a_status)
		{
			#if(DEF_BLUEBACK_DEBUG_LOG)
			DebugTool.Log("WaitActivationNextUnityScene : Change");
			#endif

			//frame
			this.frame = this.add_wait_frame;

			//シーン起動。
			if(a_status.loadscene_async != null){
				a_status.loadscene_async.allowSceneActivation = true;
			}
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]アクション。

			return == true : 完了。

		*/
		public bool Action(WaitActivationNextUnityScene.ID a_id,ref Status a_status)
		{
			if(a_status.loadscene_async != null){
				if(a_status.loadscene_async.isDone == true){
					a_status.loadscene_async = null;
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

