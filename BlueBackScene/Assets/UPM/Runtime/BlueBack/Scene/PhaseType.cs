

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。フェーズ。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** PhaseType
	*/
	public enum PhaseType
	{
		/** Boot
		*/
		Boot,

		/** ChangeAction
		*/
		ChangeAction,

		/** 実行。
		*/
		Running,

		#if(false)

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

		#endif
	}
}

