

/**
	Copyright (c) blueback
	Released under the MIT License
	@brief シーン。変更アクション。
*/


/** BlueBack.Scene.ChangeAction
*/
namespace BlueBack.Scene.ChangeAction
{
	/** Item
	*/
	public sealed class Item<ID> : Item_Base
	{
		/** execute
		*/
		public Execute_Base<ID> execute;

		/** id
		*/
		public ID id;

		/** constructor
		*/
		public Item(Execute_Base<ID> a_execute,ID a_id)
		{
			//execute
			this.execute = a_execute;

			//id
			this.id = a_id;
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Item_Base]開始。
		*/
		public void Start(ref BlueBack.Scene.Status a_status)
		{
			if(this.execute != null){
				this.execute.Start(this.id,ref a_status);
			}
		}

		/** [BlueBack.Scene.ChangeAction.ChangeAction_Item_Base]アクション。

			return == true : 完了。

		*/
		public bool Action(ref BlueBack.Scene.Status a_status)
		{
			if(this.execute != null){
				return this.execute.Action(this.id,ref a_status);
			}
			return true;
		}
	}
}

