

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** ChangeAction_Item_Base
	*/
	public interface ChangeAction_Item_Base
	{
		/** [ChangeAction_Item_Base]Change
		*/
		void Change(Scene a_scene);

		/** [ChangeAction_Item_Base]Action

			return == true : 完了。

		*/
		bool Action(Scene a_scene);
	}
}

