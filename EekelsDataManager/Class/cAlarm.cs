/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 14.02.2014
 * Time: 13:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading;

namespace EekelsDataManager
{
	/// <summary>
	/// Description of Alarm.
	/// </summary>
	
			
	public class XMLAlarms : ReadAlarmXML
	{	
			
//	Alarms alarm = new Alarms();
		private Alarms AllAlarmsVisu {get; set;}
//
//		string _sALRPath;
//		public string sALRPath {
//			get{ return this._sALRPath;}
//			set{this._sALRPath = value;}
//		}
//		
//		XElement _xmlALR;
//		public XElement xmlALR {
//			get{ return this._xmlALR;}
//			set{this._xmlALR = value;}
//		}
//		
//		string _StructureType;
//		public string StructureType {
//			get{ return this._StructureType;}
//			set{this._StructureType = value;}
//		}

//#####################################################
//#
//# Function that returns a list<string> that contains all  
//# the variables that are in Visu+ and are not in Excel
//#
//# Remarks: The variables that are returned are filtered by 
//# their Struct Type with GetVariablesFromVisu()
//#
//#####################################################
		
		private List<string> GetUnusedAlarmsFromVisu(Dictionary<string, Dictionary<string, string>> Dict)
		{
			
			
			List<string> list = (from vrb in AllAlarmsVisu.AlarmList
								where Dict.Keys.Contains(vrb.Name.Value) == false
								select vrb.Name.Value).ToList();	
								
  			return list; 
				
		}
	
//#####################################################
//#
//# Function that removes all the variables that are
//# in Visu+ and aren't in Excel
//#
//# Remarks: The variables that are removed are filtered by 
//# their Struct Type with GetVariablesFromVisu()
//#
//#####################################################

		public void RemoveUnusedAlarmsFromVisu(Dictionary<string, Dictionary<string, string>> Dict)
		{
			
			var list = GetUnusedAlarmsFromVisu(Dict);
	        
	        if (list.Count != 0){
	        
	        	foreach ( string element in list) {
	        	
					AllAlarmsVisu.AlarmList.Remove(GetXmlAlarm(element));
	        		
	        	}
	        	
	        }
			
		}
	

		
//#####################################################
//#
//# Function that loads the file that contains the variables
//#
//#####################################################			
		
		public void LoadALR(string sPath)
		{

			AllAlarmsVisu = DeserializeAlarmsFromXML(sPath);
			
		}
		
//#####################################################
//#
//# Function that add a variable element in tree
//#
//#####################################################			
		
	public bool AddAlarmElement(string TagName, string Area, string Description, string Delay, string ThresholdVal = "")
		{
	
	if(GetXmlAlarm(TagName) != null) return false;
		
	AllAlarmsVisu.AlarmList.Add(
		new AlarmsAlarmListAlarm{
              Name = new ReadAlarmXML.Name{
                   Value = TagName, Device = "", Area = Area, Variable = TagName + ":IO", 
                   ThresholdExclusive = "1", Enabled = "1", OnQualityGood = "0", VariableDuration = "",
                   EnableVariable = TagName + ":Enable", EnableDispMsg = "", Hysteresis = "0"},
				ThresholdList = new List<ReadAlarmXML.AlarmsAlarmListAlarmThresholdListThreshold>{
			  }			  
		});
		
	return true;
                            		      	
		}
		
	public bool AddThresholdElement(AlarmsAlarmListAlarm alarm, string ThresholdName, string Delay, 
	                                string Condition,string VarStatus, string ThresholdVar = "", string ThresholdVarLow = "")
	{
		alarm.ThresholdList.Add(
			new AlarmsAlarmListAlarmThresholdListThreshold{
				Name = new ReadAlarmXML.Name{
					Area = "",Title = "",Help ="",DurationFormat ="",
					ReadAccessLevel = "4294901760",WriteAccessLevel = "4294901760",Value = ThresholdName,},
				Execution = new ReadAlarmXML.AlarmsAlarmListAlarmThresholdListThresholdExecution{
					Condition = Condition, Threshold = "0", ThresholdVar = ThresholdVar,SecDelay = Delay,
					ThresholdLow = "0",ThresholdVarLow = ThresholdVarLow, VariableStatus = VarStatus},
				Commands = "",
				CommandsOn = new ReadAlarmXML.AlarmsAlarmListAlarmThresholdListThresholdCommandsOn{},
				CommandsAck = "",
				CommandsReset = "",
				CommandsOff = "",
				Style = new ReadAlarmXML.AlarmsAlarmListAlarmThresholdListThresholdStyle{}				
			});
		return true;
	}

		public AlarmsAlarmListAlarm GetXmlAlarm(string TagName)
		{
			
		   var element = (from vrb in AllAlarmsVisu.AlarmList
		  				 where vrb.Name.Value == TagName
		  				 select vrb).FirstOrDefault();
		   
		   return element;
			
		}
		
		public AlarmsAlarmListAlarm GetAlarmInfo (string Variable)
		{
			
			return AllAlarmsVisu.AlarmList.Find(p => p.Name.Value == Variable);
			
		}
		
		public AlarmsAlarmListAlarmThresholdListThreshold ThresholdList (AlarmsAlarmListAlarm alarm, string Threshold)
		{
			if (alarm == null) return null;
			
		   var element = (from vrb in alarm.ThresholdList
				 where vrb.Name.Value == Threshold
				 select vrb).FirstOrDefault();
		   
		   return element;

		}
		
		public void Serialize(string sPath)
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(Alarms)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	ns.Add("","");
	    	using (TextWriter writer = new StreamWriter(sPath))
	    	{
	        	serializer.Serialize(writer, AllAlarmsVisu, ns); 
	    	} 
		}

	}


}
		
	


