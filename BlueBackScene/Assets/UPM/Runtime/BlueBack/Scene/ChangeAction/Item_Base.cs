

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene.ChangeAction
*/
namespace BlueBack.Scene.ChangeAction
{
	/** Item_Base
	*/
	public interface Item_Base
	{
		/** [BlueBack.Scene.ChangeAction.ChangeAction_Item_Base]開始。
		*/
		void Start(ref BlueBack.Scene.Status a_status);

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Item_Base]アクション。

			return == true : 完了。

		*/
		bool Action(ref BlueBack.Scene.Status a_status);
	}
}

