/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 25.03.2014
 * Time: 13:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
public partial class Enums
{

 	public enum VariableType
	{
		Bool,
		SignedByte,
		Byte,
		SignedWord,
		Word,
		SignedDword,
		DWord,
		Float,
		Double,
		String
	};
 	
 	public enum EngineeringData
 	{
 		Disable,
 		Enable
 	};
	
 	public enum ThresholdCondition
 	{
 		majorEqual,
 		minorEqual,
 		Equal
 	}
 	
 	public enum ModbusFunctionCode
 	{
 		
 		Coils,
 		InputDiscretes,
 		MultipleRegisters,
 		InputRegisters,
 		SingleCoil,
 		SingleRegister	
 		
 	}
 	
 	public enum TaskType
 	{
 		Input,
 		InputOutput,
 		ExceptionOutput,
 		UnconditionalOutput
 	}

}
