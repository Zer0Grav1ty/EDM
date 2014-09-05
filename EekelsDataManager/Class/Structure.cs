///*
// * Created by SharpDevelop.
// * User: 3duser
// * Date: 14.02.2014
// * Time: 13:29
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Threading;

namespace EekelsDataManager
{
	/// <summary>
	/// Description of Alarm.
	/// </summary>
	
	
	public class Structure : StructureXML
	{
		
//		private string _Path;
//		
//		public string Path{
//			get { return this._Path;}
//			set { this._Path = value;}
//		}
//		
//		public MembersListDB AllStructuresVisu {get; set;}
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
//		private List<string> GetUnusedMembersFromVisu(Dictionary<string, Dictionary<string, string>> Dict)
//		{
//			
//			
//			List<string> list = (from vrb in AllStructuresVisu.MemberListDB
//			                     where Dict.Keys.Contains(vrb.Name) == false
//								select vrb.Name).ToList();			
//								
//  			return list; 
//				
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
//		public void RemoveUnusedMembersFromVisu(List<string> VariableList)
//		{
//			
//			//var list = GetUnusedMembersFromVisu(Dict);
//	        
//	        if (VariableList.Count != 0){
//	        
//	        	foreach ( string element in VariableList) {
//	        	
//					AllStructuresVisu.MemberListDB.Remove(GetVariableMemberFromList(element));
//	        		
//	        	}
//	        	
//	        }
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
//			AllStructuresVisu = DeserializeStructureFromXML(Path);
//			
//		}
//		
////#####################################################
////#
////# Function that add a variable element in tree
////#
////#####################################################			
//		
//	public bool AddMemberVariable(string TagName, string StructType, string MinRange, string MaxRange, string EU, string HLimit,
//                             	  string HHLimit, string LLimit, string LLLimit, string Address)
//	{
//	
//	if(GetVariableMemberFromList(TagName) != null) return false;
//		
//	AllStructuresVisu.MemberListDB.Add(
//		new MembersListDBVariableListVariable{
//			Name = TagName, MemberList = new ObservableCollection<StructureXML.MembersListDBVariableListVariableMemberListMember>{}
//		});
//	
//	var StructureInfo = GetVariableMemberFromList(TagName);
//	
//	
//	switch (StructType) {
//			        			
//			case "AIA":
//
//				AddAIATemplateStructureMembers(StructureInfo, MinRange, MaxRange, EU, HLimit, HHLimit, LLimit, LLLimit,Address);
//				          
//			break;
//		
//		
//    		case "DIA":
//    			
//				AddDIATemplateStructureMember(StructureInfo, Address);
//				
//			break;
//			
//			case "DI":
//				
//				AddDITemplateStructureMember(StructureInfo, Address);
//				
//			break;
//			
//			case "AI":
//			
//				AddAITemplateStructureMember(StructureInfo, MinRange, MaxRange, EU, Address);
//			
//			break;
//			
//			case "DO":
//				
//				AddDOTemplateStructureMember(StructureInfo, Address);
//				
//			break;
//			
//		}
//
//	
//	return true;
//                            		      	
//	}
//		
//	public bool AddMember(MembersListDBVariableListVariable VariableName,string MemberName, string InitialValue, int Type, string AttachedAlarm = "", int EngineeringData = 0, string RawMin = "",
//	                            string RawMax = "", string EUMin = "", string EUMax = "", string EU = "", string DynamicSettings = "")
//	{
//		VariableName.MemberList.Add(
//			new MembersListDBVariableListVariableMemberListMember{
//				Name = new StructureXML.MembersListDBVariableListVariableMemberListMemberName{
//					Value = MemberName, Type = Type.ToString(), EngineeringData = EngineeringData.ToString(), RawMin = RawMin, RawMax = RawMax, EUMin = EUMin, EUMax = EUMax,
//					EU = EU, InitialValue = InitialValue, DynamicSettings = DynamicSettings},
//				EnableTrace = new StructureXML.MembersListDBVariableListVariableMemberListMemberEnableTrace{},
//				EnableOPCServer = "0",
//				EnableNetworkClient = "0",
//				EnableMapRealTimeToDB = new StructureXML.MembersListDBVariableListVariableMemberListMemberEnableMapRealTimeToDB{},
//				AlarmList = new StructureXML.MembersListDBVariableListVariableMemberListMemberAlarmList{n0 = AttachedAlarm}
//			});
//			
//		return true;
//	}
//
//		
//		public MembersListDBVariableListVariable GetVariableMemberFromList (string MemberName)
//		{
//			
//			return AllStructuresVisu.MemberListDB.FirstOrDefault(p => p.Name == MemberName);
//			
//		}
//		
//		public MembersListDBVariableListVariableMemberListMember GetMemberFromList(MembersListDBVariableListVariable VariableMemberName, string MemberName)
//		{
//			
//			try {
//				
//				return VariableMemberName.MemberList.FirstOrDefault(p => p.Name.Value == MemberName);
//				
//			} catch (Exception e) {
//				
//				Debug.WriteLine(e);
//				throw;
//				
//			}
//			
//		}
//		
//		public bool AddAIATemplateStructureMembers(MembersListDBVariableListVariable VariableName, string MinRange, string MaxRange, 
//		                                           string EU, string HLimit, string HHLimit, string LLimit, string LLLimit, string PLCAddress)
//		{
//			
//			bool IsModified = false;
//			
//			if(GetMemberFromList(VariableName, "IO") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "IO","" , (int)Enums.VariableType.Float, "", (int)Enums.EngineeringData.Enable, "", "",
//			   	                          MinRange, MaxRange, EU, PLCAddress);
//			   	
//			}
//			
//		   if(GetMemberFromList(VariableName, "Enable") == null){
//			   	
//				IsModified = AddMember(VariableName, "Enable","1" , (int)Enums.VariableType.Bool, "Disable");
//			   	
//		   }
//			
//			if(GetMemberFromList(VariableName, "Force") == null){
//			   	
//				IsModified = AddMember(VariableName, "Force","0" , (int)Enums.VariableType.Bool, "Forced");
//			   	
//		   }
//			
//		   if(GetMemberFromList(VariableName, "HThresholdValue") == null){
//			   	
//				IsModified = AddMember(VariableName, "HThresholdValue",HLimit, (int)Enums.VariableType.Word);
//			   	
//		   }
//
//		   if(GetMemberFromList(VariableName, "HHThresholdValue") == null){
//			   	
//				IsModified = AddMember(VariableName, "HHThresholdValue",HHLimit, (int)Enums.VariableType.Word);
//			   	
//		   }
//
//		   if(GetMemberFromList(VariableName, "LThresholdValue") == null){
//			   	
//				IsModified = AddMember(VariableName, "LThresholdValue",LLimit, (int)Enums.VariableType.Word);
//			   	
//		   }		        				
//			
//		
//		   if(GetMemberFromList(VariableName, "LLThresholdValue") == null){
//			   	
//				IsModified = AddMember(VariableName, "LLThresholdValue",LLLimit, (int)Enums.VariableType.Word);
//			   	
//		   }	
//			
//		   if(GetMemberFromList(VariableName, "HAlarmStatus") == null){
//			   	
//				IsModified = AddMember(VariableName, "HAlarmStatus", "0", (int)Enums.VariableType.Byte);
//			   	
//		   }	
//			
//		   if(GetMemberFromList(VariableName, "HAlarmStatus") == null){
//			   	
//				IsModified = AddMember(VariableName, "HAlarmStatus", "0", (int)Enums.VariableType.Byte);
//			   	
//		   }
//
//		   if(GetMemberFromList(VariableName, "HHAlarmStatus") == null){
//			   	
//				IsModified = AddMember(VariableName, "HHAlarmStatus", "0", (int)Enums.VariableType.Byte);
//			   	
//		   }
//			
//		   if(GetMemberFromList(VariableName, "LAlarmStatus") == null){
//			   	
//				IsModified = AddMember(VariableName, "LAlarmStatus", "0", (int)Enums.VariableType.Byte);
//			   	
//		   }
//			
//		   if(GetMemberFromList(VariableName, "LLAlarmStatus") == null){
//			   	
//				IsModified = AddMember(VariableName, "LLAlarmStatus", "0", (int)Enums.VariableType.Byte);
//			   	
//		   }
//			
//			return IsModified;
//		}
//		
//		public bool AddDIATemplateStructureMember(MembersListDBVariableListVariable VariableName, string PLCAddress)
//		{
//			
//			bool IsModified = false;
//			
//			if(GetMemberFromList(VariableName, "IO") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "IO","" , (int)Enums.VariableType.Bool, "", (int)Enums.EngineeringData.Disable, "", "",
//			   	                          "", "", "", PLCAddress);
//			   	
//			}
//			
//			if(GetMemberFromList(VariableName, "Enable") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "Enable","1" , (int)Enums.VariableType.Bool, "Disable");
//			   	
//			}
//			
//			if(GetMemberFromList(VariableName, "Force") == null){
//			   	
//				IsModified = AddMember(VariableName, "Force","0" , (int)Enums.VariableType.Bool, "Forced");
//			   	
//		   }
//			
//			if(GetMemberFromList(VariableName, "AlarmStatus") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "AlarmStatus","0" , (int)Enums.VariableType.Bool);
//			   	
//			}
//
//			return IsModified;
//						
//		}
//		
//		public bool AddDITemplateStructureMember(MembersListDBVariableListVariable VariableName, string PLCAddress)
//		{
//			
//			bool IsModified = false;
//			
//			if(GetMemberFromList(VariableName, "IO") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "IO","" , (int)Enums.VariableType.Bool, "", (int)Enums.EngineeringData.Disable, "", "",
//			   	                          "", "", "", PLCAddress);
//			   	
//			}
//					
//			if(GetMemberFromList(VariableName, "Force") == null){
//			   	
//				IsModified = AddMember(VariableName, "Force","0" , (int)Enums.VariableType.Bool, "Forced");
//			   	
//		   }
//			
//			return IsModified;
//			
//		}
//		
//		public bool AddAITemplateStructureMember(MembersListDBVariableListVariable VariableName, string MinRange, string MaxRange, 
//		                                           string EU, string PLCAddress)
//		{
//			
//			bool IsModified = false;
//			
//			if(GetMemberFromList(VariableName, "IO") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "IO","" , (int)Enums.VariableType.Float, "", (int)Enums.EngineeringData.Enable, "", "",
//			   	                           MinRange, MaxRange, EU, PLCAddress);
//			   	
//			}
//			
//			if(GetMemberFromList(VariableName, "Force") == null){
//			   	
//				IsModified = AddMember(VariableName, "Force","0" , (int)Enums.VariableType.Bool, "Forced");
//			   	
//		   }
//			
//			return IsModified;
//			
//		}
//		
//		public bool AddDOTemplateStructureMember(MembersListDBVariableListVariable VariableName, string PLCAddress)
//		{
//			
//			bool IsModified = false;
//			
//			if(GetMemberFromList(VariableName, "IO") == null){
//		        				   	
//				IsModified = AddMember(VariableName, "IO","" , (int)Enums.VariableType.Bool, "", (int)Enums.EngineeringData.Disable, "", "",
//			   	                          "", "", "", PLCAddress);
//			   	
//			}
//			
//			if(GetMemberFromList(VariableName, "Force") == null){
//			   	
//				IsModified = AddMember(VariableName, "Force","0" , (int)Enums.VariableType.Bool, "Forced");
//			   	
//		   }
//			
//			return IsModified;
//			
//		}
//		
//		
//		public void Serialize()
//		{ 
//	    	XmlSerializer serializer = new XmlSerializer(typeof(MembersListDB)); 
//	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
//	    	ns.Add("","");
//	    	using (TextWriter writer = new StreamWriter(Path))
//	    	{
//	        	serializer.Serialize(writer, AllStructuresVisu, ns); 
//	    	} 
//		}
		
		
	}
	
}
