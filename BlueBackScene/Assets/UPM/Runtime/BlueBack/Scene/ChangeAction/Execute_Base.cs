

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene.ChangeAction
*/
namespace BlueBack.Scene.ChangeAction
{
	/** Execute_Base
	*/
	public interface Execute_Base<ID>
	{
		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]開始。
		*/
		void Start(ID a_id,ref BlueBack.Scene.Status a_status);

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Base<ID>]アクション。

			return == true : 完了。

		*/
		bool Action(ID a_id,ref BlueBack.Scene.Status a_status);
	}
}

