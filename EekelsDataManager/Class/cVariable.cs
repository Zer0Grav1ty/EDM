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

using Microsoft.Win32;
using System.ComponentModel;

using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading;

namespace EekelsDataManager
{
	/// <summary>
	/// Description of Alarm.
	/// </summary>

	public class XMLVariables : ReadVariableXML 
{
			
			private RealTimeDB AllVariablesVisu {get; set;}
	
			string _sRTDBPath;
			public string sRTDBPath {
				get{ return this._sRTDBPath;}
				set{this._sRTDBPath = value;}
			}
			
			XElement _xmlRTDB;
			public XElement xmlRTDB {
				get{ return this._xmlRTDB;}
				set{this._xmlRTDB = value;}
			}
			
			string _StructureType;
			public string StructureType {
				get{ return this._StructureType;}
				set{this._StructureType = value;}
			}
			
			
	
	//#####################################################
	//#
	//# Function that returns a list<string> that contains all  
	//# the variables that are in Visu+ and are not in Excel
	//#
	//# Remarks: The variables that are returned are filtered by 
	//# their Struct Type with GetVariablesFromVisu()
	//#
	//#####################################################
			
	 
			
			private List<string> GetUnusedVariblesFromVisu(Dictionary<string, Dictionary<string, string>> Dict, string StructureType)
			{
				
				
				List<string> list = (from vrb in AllVariablesVisu.VariableList
									where Dict.Keys.Contains(vrb.Name.Value) == false //&& vrb.Name.StructType == StructureType
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
	
			public void RemoveUnusedVariableFromVisu(Dictionary<string, Dictionary<string, string>> Dict, string StructureType)
			{
				
				var list = GetUnusedVariblesFromVisu(Dict,StructureType);
		        
		        if (list.Count != 0){
		        
		        	foreach ( string element in list) {
		        	
		        	//RealTimeDBVariableListVariable test =	GetXmlVariable(element);
		        	AllVariablesVisu.VariableList.Remove(GetXmlVariable(element));
		        		
		        	}
		        	
		        }
				
			}
		
	
			
	//#####################################################
	//#
	//# Function that loads the file that contains the variables
	//#
	//#####################################################			
			
			public void LoadRTDB(string sPath)
			{
				
				//xmlRTDB = XElement.Load(sPath);
				AllVariablesVisu = DeserializeFromXML(sPath);
				
			}
			
	//#####################################################
	//#
	//# Function that add a variable element in tree
	//#
	//#####################################################			
			
			public bool AddVariableElement(string TagName = "", string StructType = "", string Description = "", string Area = "")
			{
				
						
		AllVariablesVisu.VariableList.Add(new RealTimeDBVariableListVariable{
				      	EnableTrace = new ReadVariableXML.RealTimeDBVariableListVariableEnableTrace{},
				      	Name = new ReadVariableXML.RealTimeDBVariableListVariableName{
				      		Value = TagName, StructType = StructType, Type = "11", AreaType = "0", Address = "0",
				      		Bit = "0", Description = Description, Group = Area + "." + StructType, Shared = "0",
					      	Retentive = "1"}});
		
			return true;
			}
			
		
			public RealTimeDBVariableListVariable GetXmlVariable(string TagName)
			{
				
			   var element =  (from vrb in AllVariablesVisu.VariableList
				               where vrb.Name.Value == TagName
			  				   select vrb).FirstOrDefault();
			   
			   return element;
				
			}
						
			
			public void SetVariableGroup(XElement xmlElement, string sValue)
			{	
				
				xmlElement.Element("Name").Attribute("Group").Value = sValue;
			}
			
			public void SetVariableDescription(XElement xmlElement,string Value)//XElement xmlElement, string sValue)
			{
				xmlElement.Element("Name").Attribute("Description").Value = Value;
			}
//	
//			public bool CheckIfVariableExistInVisu(string Variable)
//			{
//				
//				return (AllVariablesVisu.Variable.Find(p => p.Name.VariableName == Variable) != null) ? true : false;
//				
//			}
			
			public RealTimeDBVariableListVariable GetVariableInfo (string Variable)
			{
				
				return AllVariablesVisu.VariableList.Find(p => p.Name.Value == Variable);
				
			}
		
		
			
		public void Serialize(string sPath)
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(RealTimeDB)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	ns.Add("","");
	    	using (TextWriter writer = new StreamWriter(sPath))
	    	{
	        	serializer.Serialize(writer, AllVariablesVisu, ns); 
	    	} 
		}
			
	
	}
			
}
	

