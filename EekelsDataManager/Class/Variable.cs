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
//
//using Microsoft.Win32;
//using System.ComponentModel;
//
//using System.Linq;
//using System.IO;
//using System.Xml.Serialization;
//using System.Xml.Linq;
//using System.Threading;
//
//namespace EekelsDataManager
//{
//	/// <summary>
//	/// Description of Alarm.
//	/// </summary>
//
//	public class Variable : VariableXML//, IInterface
//	{
//		
//		
//		private string _Path;
//		
//		public string Path{
//			get { return this._Path;}
//			set { this._Path = value;}
//		}
//
//		public RealTimeDB AllVariablesVisu {get; set;}
//		
//
//	
//	//#####################################################
//	//#
//	//# Function that returns a list<string> that contains all  
//	//# the variables that are in Visu+ and are not in Excel
//	//#
//	//# Remarks: The variables that are returned are filtered by 
//	//# their Struct Type with GetVariablesFromVisu()
//	//#
//	//#####################################################
//			
//	 
//			
//			public List<string> GetUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  Cell>>  Dict, string StructureType)
//			{
//				
//				//List<string> ElementsFromExcel = Dict.Keys.Select(p => p.Name).ToList();
//				
//
//				List<string> list = (from vrb in AllVariablesVisu.VariableList
//									where Dict.Keys.Any(p => p.Name.Equals(vrb.Name.Value)) == false && vrb.Name.StructType == StructureType
//									select vrb.Name.Value).ToList();	
//				
////				List<string> list = (from vrb in AllVariablesVisu.VariableList
////				                     where ElementsFromExcel.Any(p =>p.Equals(vrb.Name.Value)) == false  && (vrb.Name.StructType == StructureType)
////									 select vrb.Name.Value).ToList();
//									
//	  			return list;  
//					
//			}
//		
//	//#####################################################
//	//#
//	//# Function that removes all the variables that are
//	//# in Visu+ and aren't in Excel
//	//#
//	//# Remarks: The variables that are removed are filtered by 
//	//# their Struct Type with GetVariablesFromVisu()
//	//#
//	//#####################################################
//	
//			public List<string> RemoveUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  Cell>> Dict, string StructureType)
//			{
//				
//				var list = GetUnusedItemsFromVisu(Dict,StructureType);
//		        
//		        if (list.Count != 0){
//		        
//		        	foreach ( string element in list) {
//		        	
//		        	AllVariablesVisu.VariableList.Remove(GetVariableFromList(element));
//		        		
//		        	}
//		        	
//		        }
//				
//				return list;
//			
//			}
//		
//	//#####################################################
//	//#
//	//# Function that loads the file that contains the variables
//	//#
//	//#####################################################			
//			
//			public void Load(string Path)
//			{
//				this.Path = Path;
//				AllVariablesVisu = DeserializeFromXML(Path);
//				
//			}
//			
//	//#####################################################
//	//#
//	//# Function that add a variable element in tree
//	//#
//	//#####################################################			
//			
//			
//			public bool AddVariable(string TagName = "", string StructType = "", string Description = "", string Area = "")
//			{
//						
//				AllVariablesVisu.VariableList.Add(
//					new RealTimeDBVariableListVariable{Name = new RealTimeDBVariableListVariableName{
//										      		   Value = TagName, StructType = StructType, Type = "11", AreaType = "0", Address = "0",
//										      		   Bit = "0", Description = Description, Group = Area + "." + StructType, Shared = "0",
//										      		   Retentive = "1"},
//										      		   EnableTrace = new RealTimeDBVariableListVariableEnableTrace{}});
//				return true;
//			}
//			
//	
//			public bool AddRealTimeDBStructurePrototype(string StructureName)
//			{
//				Enums enums = new Enums();
//				AllVariablesVisu.StructureList.Add(
//					new RealTimeDBStructureListVariable{
//						Name = new VariableXML.RealTimeDBStructureListVariableName{
//							Description = "", Value = StructureName
//						},
//						MemberList = new List<VariableXML.RealTimeDBStructureListVariableMemberList>{}
//				
//					});
//				
//				var StructurePrototype = GetStructurePrototypeFromList(StructureName);
//				
//				switch (StructureName) {
//						
//						case "AIA":
//	
//							for(int i =0; i<= enums.AIAStructMembers.Length/2 - 1; i++){
//			
//								if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.AIAStructMembers[i,0]) == null) {
//								
//									AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.AIAStructMembers[i,1], enums.AIAStructMembers[i,0]);
//							    	
//								}
//								
//							}
//						break;
//						
//						case "DIA":
//						
//							for(int i =0; i<= enums.DIAStructMembers.Length/2 - 1; i++){
//			
//								if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DIAStructMembers[i,0]) == null) {
//								
//									AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DIAStructMembers[i,1], enums.DIAStructMembers[i,0]);
//							    	
//								}
//								
//							}
//						break;
//					
//						case "DI":
//						
//							for(int i =0; i<= enums.DIStructMembers.Length/2 - 1; i++){
//			
//								if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DIStructMembers[i,0]) == null) {
//								
//									AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DIStructMembers[i,1], enums.DIStructMembers[i,0]);
//							    	
//								}
//								
//							}
//						break;
//
//						case "AI":
//						
//							for(int i =0; i<= enums.AIStructMembers.Length/2 - 1; i++){
//			
//								if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.AIStructMembers[i,0]) == null) {
//								
//									AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.AIStructMembers[i,1], enums.AIStructMembers[i,0]);
//							    	
//								}
//								
//							}
//						break;
//
//						case "DO":
//							
//							for(int i =0; i<= enums.DOStructMembers.Length/2 - 1; i++){
//			
//								if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DOStructMembers[i,0]) == null) {
//								
//									AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DOStructMembers[i,1], enums.DOStructMembers[i,0]);
//							    	
//								}
//								
//							}
//						break;
//						
//					}
//				
//				return true;
//	
//			}
//			
//			public bool AddRealTimeDBStructurePrototypeMember(RealTimeDBStructureListVariable StructurePrototype, string StructurePrototypeMemberType, string StructurePrototypeMemberName)
//			{
//				
//				StructurePrototype.MemberList.Add(
//					new RealTimeDBStructureListVariableMemberList{
//						Name = new RealTimeDBStructureListVariableMemberListName{
//							Type = StructurePrototypeMemberType, Value = StructurePrototypeMemberName
//						}
//					});
//				
//				return true;
//				
//			}
//			
//			public RealTimeDBStructureListVariable GetStructurePrototypeFromList(string StructureName)
//			{
//				
//				return AllVariablesVisu.StructureList.Find(p => p.Name.Value == StructureName);
//				
//			}
//			
//			public RealTimeDBStructureListVariableMemberList GetStructurePrototypeMemberFromList(RealTimeDBStructureListVariable StructurePrototype, string StructurePrototypeMemberName)
//			{
//				
//				return StructurePrototype.MemberList.Find(p => p.Name.Value == StructurePrototypeMemberName);
//				
//			}
//						
//			
//			public RealTimeDBVariableListVariable GetVariableFromList (string Variable)
//			{
//					
//				return AllVariablesVisu.VariableList.FirstOrDefault(p => p.Name.Value == Variable);
//				
//			}
//			
//		
//		
//			
//		public void Serialize()
//		{ 
//	    	XmlSerializer serializer = new XmlSerializer(typeof(RealTimeDB)); 
//	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
//	    	ns.Add("","");
//	    	using (TextWriter writer = new StreamWriter(Path))
//	    	{
//	        	serializer.Serialize(writer, AllVariablesVisu, ns); 
//	    	} 
//		}
//
//	
//	}
//			
//}
//	
//
