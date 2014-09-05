///*
// * Created by SharpDevelop.
// * User: 3duser
// * Date: 14.02.2014
// * Time: 13:29
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Win32;
//using System.ComponentModel;
//using System.Collections.ObjectModel;
//using Excel = Microsoft.Office.Interop.Excel;
//using System.Linq;
//using System.IO;
//using System.Xml.Linq;
//using System.Xml.Serialization;
//using System.Threading;
//
//namespace EekelsDataManager
//{
//	/// <summary>
//	/// Description of Alarm.
//	/// </summary>
//	
//
//	
//			
//	public class Alarm : AlarmXML//, IInterface
//	{	
//			
//		private string _Path;
//		
//		public string Path{
//			get { return this._Path;}
//			set { this._Path = value;}
//		}
//		
//		public Alarms AllAlarmsVisu {get; set;}
//		 
//		
////#####################################################
////#
////# Function that returns a list<string> that contains all  
////# the variables that are in Visu+ and are not in Excel
////#
////# Remarks: The variables that are returned are filtered by 
////# their Struct Type with GetVariablesFromVisu()
////#
////#####################################################
//		
//		public List<string> GetUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  Cell>> Dict, string StructType)
//		{
//			
//			
//			List<string> list = (from vrb in AllAlarmsVisu.AlarmList
//			                     where Dict.Keys.Any(p => p.Name.Contains(vrb.Name.Value)) == false &&  vrb.Name.Area.Split('.')[1] == StructType
//								select vrb.Name.Value).ToList();	
//								
//  			return list; 
//				//Dict.Keys.Contains(vrb.Name.Value)
//		}
//	
////#####################################################
////#
////# Function that removes all the variables that are
////# in Visu+ and aren't in Excel
////#
////# Remarks: The variables that are removed are filtered by 
////# their Struct Type with GetVariablesFromVisu()
////#
////#####################################################
//
//		public List<string> RemoveUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  Cell>> Dict, string StructType)
//		{
//			
//			var list = GetUnusedItemsFromVisu(Dict, StructType);
//	        
//	        if (list.Count != 0){
//	        
//	        	foreach ( string element in list) {
//	        	
//					AllAlarmsVisu.AlarmList.Remove(GetItemFromList(element));
//	        		
//	        	}
//	        	
//	        }
//			
//			return list;
//			
//		}
//	
//
//		
////#####################################################
////#
////# Function that loads the file that contains the variables
////#
////#####################################################			
//		
//		public void Load(string Path)
//		{
//			this.Path = Path;
//			AllAlarmsVisu = DeserializeAlarmsFromXML(Path);
//			
//		}
//		
////#####################################################
////#
////# Function that add a variable element in tree
////#
////#####################################################			
//		
//	public bool AddAlarm(string TagName, string StructType, string Area, string Description, string Delay, string Condition,string Variable = "", string EnableVariable = "" )
//		{
//		
//	AllAlarmsVisu.AlarmList.Add(
//		new AlarmsAlarmListAlarm{
//              Name = new AlarmXML.Name{
//                   Value = TagName, Device = "", Area = Area + "." + StructType, Variable = Variable, 
//                   ThresholdExclusive = "1", Enabled = "1", OnQualityGood = "0", VariableDuration = "",
//                   EnableVariable = EnableVariable, EnableDispMsg = "", Hysteresis = "0"},
//			  ThresholdList = new ObservableCollection<AlarmXML.AlarmsAlarmListAlarmThresholdListThreshold>{
//			  }			  
//		});
//		
//	var AlarmInfo = GetItemFromList(TagName);
//		
//	switch (StructType) {
//				
//		case "AIA":
//				
//			AddTemplateAIAThreshold(AlarmInfo, Delay);
//			break;
//			
//		case "DIA":
//			
//			AddTemplateDIAThreshold(AlarmInfo, Delay, Condition);
//			break;
//	}	
//		
//	return true;
//                      		      	
//		}
//		
//	public bool AddThresholdElement(AlarmsAlarmListAlarm alarm, string ThresholdName, string Delay, 
//	                                int Condition,string VarStatus = "", string Threshold = "0", string ThresholdVar = "", string ThresholdVarLow = "")
//	{
//		alarm.ThresholdList.Add(
//			new AlarmsAlarmListAlarmThresholdListThreshold{
//				Name = new AlarmXML.Name{
//					Area = "",Title = "",Help ="",DurationFormat ="",
//					ReadAccessLevel = "4294901760",WriteAccessLevel = "4294901760",Value = ThresholdName,},
//				Execution = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdExecution{
//					Condition = Condition.ToString(), Threshold = Threshold, ThresholdVar = ThresholdVar,SecDelay = Delay,
//					ThresholdLow = "0",ThresholdVarLow = ThresholdVarLow, VariableStatus = VarStatus},
//				Commands = "",
//				CommandsOn = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdCommandsOn{},
//				CommandsAck = "",
//				CommandsReset = "",
//				CommandsOff = "",
//				Style = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdStyle{}				
//			});
//		return true;
//	}
//
//		
//		public AlarmsAlarmListAlarm GetItemFromList (string Variable)
//		{	
//			return AllAlarmsVisu.AlarmList.FirstOrDefault(p => p.Name.Value == Variable);	
//		}
//		
//		public AlarmsAlarmListAlarmThresholdListThreshold GetThreshold (List<AlarmsAlarmListAlarmThresholdListThreshold> ThresholdList, string Threshold)
//		{
//			return	ThresholdList.Where(p => p.Name.Value == Threshold).FirstOrDefault();
//		}
//		
//		public List<AlarmsAlarmListAlarmThresholdListThreshold> GetThresholdList (AlarmsAlarmListAlarm alarm)
//		{  
//			if(alarm == null) return null;
//			return alarm.ThresholdList.ToList();
//		}
//		
//		
//		
//		public void Serialize()
//		{ 
//	    	XmlSerializer serializer = new XmlSerializer(typeof(Alarms)); 
//	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
//	    	ns.Add("","");
//	    	using (TextWriter writer = new StreamWriter(Path))
//	    	{
//	        	serializer.Serialize(writer, AllAlarmsVisu, ns); 
//	    	} 
//		}
//		
//		public bool AddTemplateAIAThreshold(AlarmsAlarmListAlarm alarm, string Delay)
//		{
//			
//			bool isModified = false;
//			
//			
//			var ThresholdList = GetThresholdList(alarm);
//			
//        	if(GetThreshold(ThresholdList,"High") == null){
//				isModified = AddThresholdElement(alarm, "High", Delay, (int)Enums.ThresholdCondition.majorEqual,
//			                          alarm.Name.Value + ":HAlarmStatus", "" , alarm.Name.Value + ":HThresholdValue");									
//			}
//			
//			if(GetThreshold(ThresholdList,"HighHigh") == null){
//				isModified = AddThresholdElement(alarm, "HighHigh", Delay, (int)Enums.ThresholdCondition.majorEqual, 
//			                          alarm.Name.Value + ":HHAlarmStatus", "", alarm.Name.Value + ":HHThresholdValue");
//												
//			}
//
//			if(GetThreshold(ThresholdList,"Low") == null){
//				isModified = AddThresholdElement(alarm, "Low", Delay, (int)Enums.ThresholdCondition.minorEqual, 
//			                          alarm.Name.Value + ":LAlarmStatus", "", alarm.Name.Value + ":LThresholdValue");
//												
//			}		        				
//		
//			if(GetThreshold(ThresholdList,"LowLow") == null){
//				isModified = AddThresholdElement(alarm, "LowLow", Delay, (int)Enums.ThresholdCondition.minorEqual, 
//			                          alarm.Name.Value + ":LLAlarmStatus","", alarm.Name.Value + ":LLThresholdValue");
//												
//			}
//			
//			return isModified;
//			
//		}
//		
//		public bool AddTemplateDIAThreshold(AlarmsAlarmListAlarm alarm, string Delay, string Condition)
//		{
//			bool isModified = false;
//			
//			if (alarm == null) return isModified;
//			
//			var ThresholdList = GetThresholdList(alarm);
//			
//			if(GetThreshold(ThresholdList,"Digital") == null){
//				isModified = AddThresholdElement(alarm, "Digital", Delay, (int)Enums.ThresholdCondition.Equal, 
//			                          alarm.Name.Value + ":AlarmStatus", Condition );
//												
//			}
//			
//			return isModified;
//			
//		}
//		
//		public void CreateTemplateAlarms()
//		{
//		
//			if(GetItemFromList("Disable") == null){
//				AddAlarm("Disable", "", "Messages", "Disable", "", "");
//				AddThresholdElement(AllAlarmsVisu.AlarmList.FirstOrDefault(p => p.Name.Value == "Disable"), "Disable","0", (int)Enums.ThresholdCondition.Equal );
//			}
//			
//			if(GetItemFromList("Forced") == null){
//				AddAlarm("Forced", "", "Messages", "Forced", "", "");
//				AddThresholdElement(AllAlarmsVisu.AlarmList.FirstOrDefault(p => p.Name.Value == "Forced"), "Forced","1", (int)Enums.ThresholdCondition.Equal );
//			}
//			
//		}
//
//	}
//
//
//}
//		
//	
//
//
