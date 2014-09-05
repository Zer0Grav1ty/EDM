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
//using Excel = Microsoft.Office.Interop.Excel;
//using System.Linq;
//using System.Xml.Linq;
//using System.Threading;
//
//namespace EekelsDataManager
//{
//	/// <summary>
//	/// Description of Alarm.
//	/// </summary>
//	
//	
//	public class ThresholdInfo
//	{
//
//		
//		string _TagName;
//		public string TagName {
//			get{ return this._TagName;}
//			set{this._TagName = value;}
//		}
//		
//		string _Description;
//		public string Description {
//			get{ return this._Description;}
//			set{this._Description = value;}
//		}
//			
//		string _Group;
//		public string Group {
//			get{ return this._Group;}
//			set{this._Group = value;}
//		}
//
//	}
//		
//	public class cThreshold : ThresholdInfo
//	{	
//			
//
//		private List<VariableInfo> AllVariablesVisu {get; set;}
//
//		string _sRTDBPath;
//		public string sRTDBPath {
//			get{ return this._sRTDBPath;}
//			set{this._sRTDBPath = value;}
//		}
//		
//		XElement _xmlRTDB;
//		public XElement xmlRTDB {
//			get{ return this._xmlRTDB;}
//			set{this._xmlRTDB = value;}
//		}
//		
//		string _StructureType;
//		public string StructureType {
//			get{ return this._StructureType;}
//			set{this._StructureType = value;}
//		}
////#####################################################
////#
////# Function that returns a list<string> that contains all the variables
////# from Visu+, filtered by there struct type
////#
////#####################################################
//
//		private void GetVariablesFromVisu()
//		{
//			
//			XElement xVariables = xmlRTDB;
//			
//			List<VariableInfo> searched = 
//				 (from xmlVar in xVariables.Descendants("Name")
//				  where (string)xmlVar.Attribute("StructType") == "AIA"
//				  select new VariableInfo {
//				  		TagName = (string)xmlVar.Value,
//				  		Group = (string)xmlVar.Attribute("Group").Value,
//				  		Description = (string)xmlVar.Attribute("Description").Value
//				   }
//				  
//				 ).ToList();
//
//			AllVariablesVisu = searched;
//			
//		}
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
//		private List<string> GetUnusedVariblesFromVisu(Dictionary<string, Dictionary<string, string>> Dict)
//		{
//			
//			
//			List<string> list = (from vrb in AllVariablesVisu
//								where Dict.Keys.Contains(vrb.TagName) == false
//								select vrb.TagName).ToList();	
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
//		public void RemoveUnusedVariableFromVisu(Dictionary<string, Dictionary<string, string>> Dict)
//		{
//			
//			var list = GetUnusedVariblesFromVisu(Dict);
//	        
//	        if (list.Count != 0){
//	        
//	        	foreach ( string element in list) {
//	        	
//	        		GetXmlVariable(element).Remove();
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
//		public void LoadRTDB(string sPath)
//		{
//			
//			xmlRTDB = XElement.Load(sPath);
//			GetVariablesFromVisu();
//			
//		}
//		
////#####################################################
////#
////# Function that add a variable element in tree
////#
////#####################################################			
//		
//		public void AddVariableElement(string TagName, string StructType, string sDescription, string Area)
//		{
//
//			xmlRTDB.Element("VariableList").Add(
//				new XElement("Variable",
//				             new XElement("Name", new XAttribute("Type", "11"),new XAttribute("StructType", StructType),new XAttribute("AreaType", "0"),
//				                          new XAttribute("Address", "0"), new XAttribute("Bit","0"),new XAttribute("Description", sDescription),
//				                          new XAttribute("Group", Area + "." + StructType),new XAttribute("Shared", "0"),new XAttribute("Retentive", "1"), TagName),
//				             new XElement("EnableTrace", new XAttribute("DurationDays","730"), "0"),
//				             new XElement("EnableOPCServer","0"),
//				             new XElement("EnableNetworkClient","0"),
//				             new XElement("EnableMapRealTimeToDB","0")
//				            ));
//		}
//		
//	
//		public XElement GetXmlVariable(string TagName)
//		{
//			
//		   var element =  (from vrb in xmlRTDB.Descendants("Variable")
//			                where vrb.Element("Name").Value == TagName
//		  				 select vrb).FirstOrDefault();
//		   
//		   return element;
//			
//		}
//					
//		
//		public void SetVariableGroup(XElement xmlElement, string sValue)
//		{	
//			
//			xmlElement.Element("Name").Attribute("Group").Value = sValue;
//		}
//		
//		public void SetVariableDescription(XElement xmlElement, string sValue)
//		{
//			xmlElement.Element("Name").Attribute("Description").Value = sValue;
//		}
//		
//		public bool CheckIfVariableExistInVisu(string Variable)
//		{
//			
//			return (AllVariablesVisu.Find(p => p.TagName == Variable) != null) ? true : false;
//			
//		}
//		
//		public VariableInfo GetVariableInfo (string Variable)
//		{
//			
//			return AllVariablesVisu.Find(p => p.TagName == Variable);
//			
//		}
//		
//
//	}
