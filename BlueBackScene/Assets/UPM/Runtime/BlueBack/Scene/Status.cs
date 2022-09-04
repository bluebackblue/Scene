

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** Status
	*/
	#if(UNITY_EDITOR)
	[System.Serializable]
	#endif
	public struct Status
	{
		/** step
		*/
		public Step step;

		/** updatemode
		*/
		public UpdateMode updatemode;

		/** changeaction
		*/
		public int changeaction_index;
		public ChangeAction.Item_Base[] changeaction_list;

		/** scene
		*/
		public Scene_Base scene_current;
		public Scene_Base scene_next;

		/** request
		*/
		public Scene_Base request_scene;
		public ChangeAction.Item_Base[] request_changeaction_list;

		/** loadscene_async
		*/
		public UnityEngine.AsyncOperation loadscene_async;

		/** unitycallback_monobehaviour
		*/
		public UnityCallBack_MonoBehaviour unitycallback_monobehaviour;

		/** debugview
		*/
		#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
		public DebugView_MonoBehaviour debugview_monobehaviour;
		#endif
	}
}

