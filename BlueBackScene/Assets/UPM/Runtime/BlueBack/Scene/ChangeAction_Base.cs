

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** ChangeAction_Base
	*/
	public interface ChangeAction_Base<ID>
	{
		/** [ChangeAction_Base<ID>]Change

			return == true : 完了。

		*/
		void Change(ID a_id,Scene a_scene);

		/** [ChangeAction_Base<ID>]Action

			return == true : 完了。

		*/
		bool Action(ID a_id,Scene a_scene);
	}
}

