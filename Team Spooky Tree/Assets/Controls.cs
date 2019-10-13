using System;

namespace andy {
	
	public struct Controls
	{
		public string x, y, jump, attack;
		public Controls(string x_in, string y_in, string jump_in, string attack_in){
			x = x_in;
			y = y_in;
			jump = jump_in;
			attack = attack_in;
		}
}

}