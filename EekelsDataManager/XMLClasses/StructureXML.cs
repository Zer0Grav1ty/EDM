/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 25.03.2014
 * Time: 8:56
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
using System.Collections.ObjectModel;
using System.Text;

namespace EekelsDataManager
{
	/// <summary>
	/// Description of ReatStructureXML.
	/// </summary>
	/// 

	public class StructureXML 
	{

		private string _Path;
		
		public string Path{
			get { return this._Path;}
			set { this._Path = value;}
		}
		
		private MembersListDB _structure;
		
		public MembersListDB xmlStructure {
			get { return _structure;}
			set { _structure = value;}
		}
		
		/// <remarks/>
		[XmlRoot()]
		public partial class MembersListDB : INotifyPropertyChanged
		{
		    
		    private ObservableCollection<MembersListDBVariableListVariable> memberListDBField;
		    
		    /// <remarks/>
		    [XmlArray("VariableList")]
    		[XmlArrayItem("Variable")]	
		    
		    public ObservableCollection<MembersListDBVariableListVariable> MemberListDB {
		        get {
		            return this.memberListDBField;
		        }
		        set {
		            this.memberListDBField = value;
		            RaisePropertyChanged("MembersListDB");
		        }
		    }
    		
	    #region *** INotifyPropertyChanged Members and Invoker ***
	    public event PropertyChangedEventHandler PropertyChanged;
	
	    protected virtual void RaisePropertyChanged(string propertyName)
	    {
	    	
		    var temp = PropertyChanged;
		    if (temp != null)
		    temp(this, new PropertyChangedEventArgs(propertyName));
		    
	    }
	    #endregion
		}
		
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariable  : INotifyPropertyChanged
		{
		    
		    private string nameField;
		    
		    private ObservableCollection<MembersListDBVariableListVariableMemberListMember> memberListField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public string Name {
		        get {
		            return this.nameField;
		        }
		        set {
		            this.nameField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [XmlArray("MemberList")]
		    [System.Xml.Serialization.XmlArrayItemAttribute("Member", typeof(MembersListDBVariableListVariableMemberListMember), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
		    public ObservableCollection<MembersListDBVariableListVariableMemberListMember> MemberList {
		        get {
		            return this.memberListField;
		        }
		        set {
		            this.memberListField = value;
		            RaisePropertyChanged("MemberList");
		        }
		    }
		    
			#region *** INotifyPropertyChanged Members and Invoker ***
		    public event PropertyChangedEventHandler PropertyChanged;
		
		    protected virtual void RaisePropertyChanged(string propertyName)
		    {
		    	
			    var temp = PropertyChanged;
			    if (temp != null)
			    temp(this, new PropertyChangedEventArgs(propertyName));
			    
		    }
		    #endregion
			}
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMember : INotifyPropertyChanged
		{
		    
		    private string enableOPCServerField;
		    
		    private string enableNetworkClientField;
		    
		    private MembersListDBVariableListVariableMemberListMemberName nameField;
		    
		    private MembersListDBVariableListVariableMemberListMemberEnableTrace enableTraceField;
		    
		    private MembersListDBVariableListVariableMemberListMemberEnableMapRealTimeToDB enableMapRealTimeToDBField;
		    
		    private MembersListDBVariableListVariableMemberListMemberAlarmList alarmListField;
		    
		    private MembersListDBVariableListVariableMemberListMemberDataLoggerList dataLoggerListField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public string EnableOPCServer {
		        get {
		            return this.enableOPCServerField;
		        }
		        set {
		            this.enableOPCServerField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public string EnableNetworkClient {
		        get {
		            return this.enableNetworkClientField;
		        }
		        set {
		            this.enableNetworkClientField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("Name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
		    public MembersListDBVariableListVariableMemberListMemberName Name {
		        get {
		            return this.nameField;
		        }
		        set {
		            this.nameField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("EnableTrace", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
		    public MembersListDBVariableListVariableMemberListMemberEnableTrace EnableTrace {
		        get {
		            return this.enableTraceField;
		        }
		        set {
		            this.enableTraceField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("EnableMapRealTimeToDB", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
		    public MembersListDBVariableListVariableMemberListMemberEnableMapRealTimeToDB EnableMapRealTimeToDB {
		        get {
		            return this.enableMapRealTimeToDBField;
		        }
		        set {
		            this.enableMapRealTimeToDBField = value;
		        }
		    }
		    
		   	[System.Xml.Serialization.XmlElementAttribute("AlarmList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
		    public MembersListDBVariableListVariableMemberListMemberAlarmList AlarmList {
		        get {
		            return this.alarmListField;
		        }
		        set {
		            this.alarmListField = value;
		        }
		    }
		   	
		   	[System.Xml.Serialization.XmlElementAttribute("DataLoggerList", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
		    public MembersListDBVariableListVariableMemberListMemberDataLoggerList DataLoggerList {
		        get {
		            return this.dataLoggerListField;
		        }
		        set {
		            this.dataLoggerListField = value;
		        }
		    }
		   	
		#region *** INotifyPropertyChanged Members and Invoker ***
	    public event PropertyChangedEventHandler PropertyChanged;
	
	    protected virtual void RaisePropertyChanged(string propertyName)
	    {
	    	
		    var temp = PropertyChanged;
		    if (temp != null)
		    temp(this, new PropertyChangedEventArgs(propertyName));
		    
	    }
	    #endregion
		}
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMemberName : INotifyPropertyChanged
		{
		    
		    private string typeField;
		    
		    private string initialValueField;
		    
		    private string rawMinField;
		    
		    private string rawMaxField;
		    
		    private string euField;
		    
		    private string dynamicSettingsField;
		    
		    private string engineeringDataField;
		    
		    private string eUMinField;
		    
		    private string eUMaxField;
		    
		    private string defaultFormatField;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Type {
		        get {
		            return this.typeField;
		        }
		        set {
		            this.typeField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string InitialValue {
		        get {
		            return this.initialValueField ?? "0";
		        }
		        set {
		    		
		    		if(value == ""){
		    			value = "0";
		    		}
		    		
		    		if(this.initialValueField != value){
		    			
		    			this.initialValueField = value;
		    			RaisePropertyChanged("InitialValue");
		    			
		    		}
		        }
		    }
		    
		   	 /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RawMin {
		        get {
		            return this.rawMinField;
		        }
		        set {
		    		if(this.rawMinField != value){
		    			
		    			 this.rawMinField = value ?? "0";
		    			 RaisePropertyChanged("RawMin");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RawMax {
		        get {
		            return this.rawMaxField;
		        }
		        set {
		    		if(this.rawMaxField != value){
		    			
		    			this.rawMaxField = value ?? "10000";
		    			RaisePropertyChanged("RawMax");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EU {
		        get {
		            return this.euField;
		        }
		        set {
		    		if(this.euField != value){
		    			
		    			this.euField = value ?? "";
		    			RaisePropertyChanged("EU");
		    			
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DynamicSettings {
		        get {
		            return this.dynamicSettingsField ?? "";
		        }
		        set {
		    		if(this.dynamicSettingsField != value){
		    			
		    			this.dynamicSettingsField = value ?? "";
		    			RaisePropertyChanged("DynamicSettings");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EngineeringData {
		        get {
		            return this.engineeringDataField;
		        }
		        set {
		            this.engineeringDataField = value ?? "0";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EUMin {
		        get {
		            return this.eUMinField;
		        }
		        set {
		    		if(this.eUMinField != value){
		    			
		    			this.eUMinField = value ?? "0";
		    			RaisePropertyChanged("EUMin");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EUMax {
		        get {
		            return this.eUMaxField;
		        }
		        set {
		    		if(this.eUMaxField != value){
		    			
		    			this.eUMaxField = value ?? "1000";
		    			RaisePropertyChanged("EUMax");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DefaultFormat {
		        get {
		            return this.defaultFormatField;
		        }
		        set {
		    		if(this.defaultFormatField != value){
		    			
		    			this.defaultFormatField = value;
		    			
		    			RaisePropertyChanged("DefaultFormat");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlTextAttribute()]
		    public string Value {
		        get {
		            return this.valueField;
		        }
		        set {
		            this.valueField = value;
		        }
		    }
		    
		#region *** INotifyPropertyChanged Members and Invoker ***
	    public event PropertyChangedEventHandler PropertyChanged;
	
	    protected virtual void RaisePropertyChanged(string propertyName)
	    {
	    	
		    var temp = PropertyChanged;
		    if (temp != null)
		    temp(this, new PropertyChangedEventArgs(propertyName));
		    
	    }
	    #endregion
		}
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMemberEnableTrace : INotifyPropertyChanged
		{
		    
		    private string durationDaysField;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DurationDays {
		        get {
		            return this.durationDaysField;
		        }
		        set {
		            this.durationDaysField = value ?? "730";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlTextAttribute()]
		    public string Value {
		        get {
		            return this.valueField;
		        }
		        set {
		            this.valueField = value ?? "0";
		        }
		    }
		    
		#region *** INotifyPropertyChanged Members and Invoker ***
	    public event PropertyChangedEventHandler PropertyChanged;
	
	    protected virtual void RaisePropertyChanged(string propertyName)
	    {
	    	
		    var temp = PropertyChanged;
		    if (temp != null)
		    temp(this, new PropertyChangedEventArgs(propertyName));
		    
	    }
	    #endregion
		}
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMemberEnableMapRealTimeToDB : INotifyPropertyChanged
		{
		    
		    private string modeField;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Mode {
		        get {
		            return this.modeField;
		        }
		        set {
		            this.modeField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlTextAttribute()]
		    public string Value {
		        get {
		            return this.valueField;
		        }
		        set {
		            this.valueField = value;
		        }
		    }
		    
			#region *** INotifyPropertyChanged Members and Invoker ***
		    public event PropertyChangedEventHandler PropertyChanged;
		
		    protected virtual void RaisePropertyChanged(string propertyName)
		    {
		    	
			    var temp = PropertyChanged;
			    if (temp != null)
			    temp(this, new PropertyChangedEventArgs(propertyName));
			    
		    }
		    #endregion
	    
		}
		
		/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMemberAlarmList : INotifyPropertyChanged
		{
		
			private string n0Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string n0 {
		        get {
		            return this.n0Field;
		        }
		        set {
		            this.n0Field = value;
		        }
		    }
		    
		    
		    
		    #region *** INotifyPropertyChanged Members and Invoker ***
		    public event PropertyChangedEventHandler PropertyChanged;
		
		    protected virtual void RaisePropertyChanged(string propertyName)
		    {
		    	
			    var temp = PropertyChanged;
			    if (temp != null)
			    temp(this, new PropertyChangedEventArgs(propertyName));
			    
		    }
		    #endregion
			
		}
		
				/// <remarks/>
		[XmlType()]
		public partial class MembersListDBVariableListVariableMemberListMemberDataLoggerList : INotifyPropertyChanged
		{
		
			private string n0Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string n0 {
		        get {
		            return this.n0Field;
		        }
		        set {
		            this.n0Field = value;
		        }
		    }
		    
		    
		    
		    #region *** INotifyPropertyChanged Members and Invoker ***
		    public event PropertyChangedEventHandler PropertyChanged;
		
		    protected virtual void RaisePropertyChanged(string propertyName)
		    {
		    	
			    var temp = PropertyChanged;
			    if (temp != null)
			    temp(this, new PropertyChangedEventArgs(propertyName));
			    
		    }
		    #endregion
			
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

		public void RemoveUnusedItems(List<string> VariableList)
		{
			
			//var list = GetUnusedMembersFromVisu(Dict);
	        
	        if (VariableList.Count != 0){
	        
	        	foreach ( string element in VariableList) {
	        	
					xmlStructure.MemberListDB.Remove(GetVariableMemberFromList(element));
	        		
	        	}
	        	
	        }
			
		}
	
		public void RemoveUnusedItems(IEnumerable<string> VariableList)
		{
			
			//var list = GetUnusedMembersFromVisu(Dict);
	        
			if (VariableList == null) return ;
			
			if (VariableList.Count() != 0){
	        
	        	foreach ( string element in VariableList) {
	        	
					xmlStructure.MemberListDB.Remove(GetVariableMemberFromList(element));
	        		
	        	}
	        	
	        }
			
		}
		
//#####################################################
//#
//# Function that loads the file that contains the variables
//#
//#####################################################			
		
		public void Load(string Path)
		{
			this.Path = Path;
			MembersListDB data = new MembersListDB();
		
			var textReader = new StreamReader(Path);
			var deserializer = new XmlSerializer(typeof(MembersListDB));
			xmlStructure = (MembersListDB)deserializer.Deserialize(textReader);
			MembersListDB xmlData = (MembersListDB)xmlStructure;
			textReader.Close();
			
		}
		
//#####################################################
//#
//# Function that add a variable element in tree
//#
//#####################################################			
		
public bool EnableMemberProperties(string TagName, List<string> Members, List<string> DataType, List<string> InitialValue, List<string> Headers){
	
	MembersListDBVariableListVariable StructVariable = AddMember(TagName);					
	
	string sInitialValue = "";
	string DataLogger = "";
	
	for (int i = 0; i < Members.Count; i++){
		
		if(Headers.Contains(Members[i])){
			
			int index = Headers.IndexOf(Members[i]);
		   	
		   	sInitialValue =  InitialValue[index];
		   	
		   	if(Headers[index] == "DataFormat"){
				
				switch (sInitialValue) {
    					
    				case "1" :
    					
    					sInitialValue = "x.x";
    					break;
    					
    				case "2" :
    					
    					sInitialValue = "x.xx";
    					break;
    				
    				case "3" :
    					
	    				sInitialValue = "x.xxx";	
	    				break;
    				
    				default :
    					
    					sInitialValue = "x";
    					break;
					}
				}
		   	
		   		if(Headers[index] == "Condition"){
		   		
		   			if(InitialValue[index].ToUpper() == "TRUE"){
		   			
		   				sInitialValue = "1";
		   			
		   			}
		   		
		   			else{
		   			
		   				sInitialValue = "0";
		   		
		   			}
				
				}
		   	
		   }
		
		if(Members[i] == "IO"){
			
			DataLogger = "Log1sec";
			
		}
		
		else{
			
			DataLogger = "";
			
		}
		
		AddStructureMember(StructVariable, Members[i], DataType[i], sInitialValue, "", DataLogger);
	
	}
		
	return true;

}


public void EditInitialValueForMembers(string TagName,string InitialValue,string Header){
	
	MembersListDBVariableListVariable StructVariable = GetVariableMemberFromList(TagName);
	
	if (StructVariable == null) return;
		
	if(GetMemberFromList(StructVariable, Header) != null){
		
		if(Header == "DataFormat"){
			
			switch (InitialValue) {
					
				case "1" :
					
					InitialValue = "x.x";
					break;
					
				case "2" :
					
					InitialValue = "x.xx";
					break;
				
				case "3" :
					
    				InitialValue = "x.xxx";	
    				break;
				
				default :
					
					InitialValue = "x";
					break;
				}
			
		}
		
		if(Header == "Condition"){
	   		
   			if(InitialValue == "True"){
   			
   				InitialValue = "1";
   			
   			}
   		
   			else{
   			
   				InitialValue = "0";
   		
   			}
		
		}
	
		GetMemberFromList(StructVariable, Header).Name.InitialValue = InitialValue;
	}

}
		
	public MembersListDBVariableListVariable AddMember(string TagName, string StructType= "0", string MinRange = "0", string MaxRange = "100", string EU = "", string DefaultFormat ="" ,string HLimit = "" ,
                             	  string HHLimit = "", string LLimit = "", string LLLimit = "", string Address = "", string BlockGroup = "")
	{
	
	if(GetVariableMemberFromList(TagName) == null) {
		
		xmlStructure.MemberListDB.Add(
			new MembersListDBVariableListVariable{
				Name = TagName, MemberList = new ObservableCollection<StructureXML.MembersListDBVariableListVariableMemberListMember>{}
			});
		
	}
	
	return xmlStructure.MemberListDB.FirstOrDefault(p => p.Name == TagName);
	   
	
	}
		
	public bool AddStructureMember(MembersListDBVariableListVariable VariableName,string MemberName, string Type, string InitialValue = "", string AttachedAlarm = "", string DataLogger = "", int EngineeringData = 0, string RawMin = "0",
	                            string RawMax = "1000", string EUMin = "0", string EUMax = "100", string EU = "", string DefaultFormat = "", string DynamicSettings = "",  string BlockGroup = "")
	{
	
	if (GetMemberFromList(VariableName, MemberName) != null) return false;
	
		VariableName.MemberList.Add(
			new MembersListDBVariableListVariableMemberListMember{
				Name = new StructureXML.MembersListDBVariableListVariableMemberListMemberName{
					Value = MemberName, Type = Type.ToString(), EngineeringData = EngineeringData.ToString(), RawMin = RawMin, RawMax = RawMax, EUMin = EUMin, EUMax = EUMax, DefaultFormat = DefaultFormat,
					EU = EU, InitialValue = InitialValue, DynamicSettings = DynamicSettings},
				EnableTrace = new StructureXML.MembersListDBVariableListVariableMemberListMemberEnableTrace{},
				EnableOPCServer = "0",
				EnableNetworkClient = "0",
				EnableMapRealTimeToDB = new StructureXML.MembersListDBVariableListVariableMemberListMemberEnableMapRealTimeToDB{},
				AlarmList = new StructureXML.MembersListDBVariableListVariableMemberListMemberAlarmList{n0 = AttachedAlarm},
				DataLoggerList = new StructureXML.MembersListDBVariableListVariableMemberListMemberDataLoggerList{n0 = DataLogger}
			});
			
		return true;
	}
	

		
		public MembersListDBVariableListVariable GetVariableMemberFromList (string MemberName)
		{
			
			return xmlStructure.MemberListDB.FirstOrDefault(p => p.Name == MemberName);
			
		}
		
		public MembersListDBVariableListVariableMemberListMember GetMemberFromList(MembersListDBVariableListVariable VariableMemberName, string MemberName)
		{
			
			try {
				
				return VariableMemberName.MemberList.FirstOrDefault(p => p.Name.Value == MemberName);
				
			} catch (Exception e) {
				
				Debug.WriteLine(e);
				throw;
				
			}
			
		}
		
		
		public void Serialize()
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(MembersListDB)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	ns.Add("","");
	    	using (StreamWriter writer = new StreamWriter(Path, false,Encoding.Unicode))
	    	{
	        	serializer.Serialize(writer, xmlStructure, ns); 
	    	} 
		}
	
	}
}
