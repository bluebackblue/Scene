

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。初期化パラメータ。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** InitParam
	*/
	public struct InitParam
	{
		/** unitycallback
		*/
		public string unitycallback_name;
		public bool unitycallback_hide;

		#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
		public string debugview_name;
		#endif

		/** updatemode
		*/
		public UpdateMode updatemode;

		/** CreateDefault
		*/
		public static InitParam CreateDefault()
		{
			return new InitParam(){
				unitycallback_name = "scene",
				unitycallback_hide = false,
				#if(DEF_BLUEBACK_SCENE_DEBUGVIEW)
				debugview_name = "scene_debugview",
				#endif
				updatemode = UpdateMode.UnityUpdate,
			};
		}
	}
}

