

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。
*/


/** BlueBack.Scene
*/
namespace BlueBack.Scene
{
	/** ChangeAction_Box_Base
	*/
	public interface ChangeAction_Box_Base
	{
		/** [ChangeAction_Box_Base]Change
		*/
		void Change(Scene a_scene);

		/** [ChangeAction_Box_Base]Action

			return == true : 完了。

		*/
		bool Action(Scene a_scene);
	}
}

