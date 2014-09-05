using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Microsoft.Win32;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading;

namespace EekelsDataManager
{

	public class DriverXml {
		
	
		private ObservableCollection<DriverSettings> _driverList = new ObservableCollection<DriverSettings>();
		
		public ObservableCollection<DriverSettings> DriverList {
			get {return _driverList;}
			set {_driverList = value;}
		}	
		
		private string Path {get; set;}
		
		public string[] files {get; set;}
		
		private List<string> driverListName {get; set;}
		
		/// <remarks/>
		[XmlRoot()]
		public partial class DriverSettings : INotifyPropertyChanged {
		
			private DriverSettingsGeneralSettings generalSettingsField;
			
			private DriverSettingsDebug debugField;
			
			private DriverSettingsEIPDriverSettings eipDriverSettingsField;
			
			private DriverSettingsS7TCPDriverSettings s7tcpDriverSettingsField; 	
			
			private DriverSettingsModbusTCPSettings modbusTcpSettingsField;
			
			private ObservableCollection<DriverSettingsJobListJob> jobListField;
			
			private ObservableCollection<DriverSettingsStationListStation> stationListField;
			
			/// <remarks/>
		    [XmlElement("GeneralSettings")]
		    public DriverSettingsGeneralSettings GeneralSettings {
		        get {
		            return this.generalSettingsField;
		        }
		        set {	
		    		
	    			this.generalSettingsField = value;
//	    			RaisePropertyChanged("GeneralSettings");
		        }
		    }
			
			/// <remarks/>
		    [XmlElement("Debug")]
		    public DriverSettingsDebug Debug {
		        get {
		            return this.debugField;
		        }
		        set {

	    			this.debugField = value;
	    			//RaisePropertyChanged("Debug");
		        }
		    }
		    
		    [XmlElement("EIPDriverSettings")]
		    public DriverSettingsEIPDriverSettings EIPDriverSettings {
		    	get {
		            return this.eipDriverSettingsField;
		        }
		        set {
	    			this.eipDriverSettingsField = value;
	    			//RaisePropertyChanged("EIPDriverSettings");
		        }
		    }
		        
		    /// <remarks/>
		    [XmlElement("S7TCPDriverSettings")]
		    public DriverSettingsS7TCPDriverSettings S7TCPDriverSettings {
		        get {
		            return this.s7tcpDriverSettingsField;
		        }
		        set {
	
	    			this.s7tcpDriverSettingsField = value;
	    			//RaisePropertyChanged("S7TCPDriverSettings");

		        }
		    }
		    
		    [XmlElement("ModbusTCPSettings")]
		    public DriverSettingsModbusTCPSettings ModbusTCPSettings {
		        get {
		            return this.modbusTcpSettingsField;
		        }
		        set {
		    			
	    			this.modbusTcpSettingsField = value;
	    			//RaisePropertyChanged("ModbusTCPSettings");
	
		        }
		    }
		    
		    /// <remarks/>
		    [XmlArray("JobList")]
		    [XmlArrayItem("Job")]
		    public ObservableCollection<DriverSettingsJobListJob> JobList {
		        get {
		            return this.jobListField;
		        }
		        set {
	    			this.jobListField = value;
	    			RaisePropertyChanged("Job");
		        }
		    }
		
		    /// <remarks/>
		    [XmlArray("StationList")]
		    [XmlArrayItem("Station")]
		    public ObservableCollection<DriverSettingsStationListStation> StationList {
		        get {
		            return this.stationListField;
		        }
		        set {
	    			this.stationListField = value;
	    			RaisePropertyChanged("Station");
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
		public partial class DriverSettingsGeneralSettings : INotifyPropertyChanged {
		    
		    private string waitTimeField;
		    
		    private string timeOutField;
		    
		    private string synchroStartField;
		    
		    private string minimumJobThresholdField;
		    
		    private string defRefreshTimeNotInUseField;
		    
		    private string enableCOMInterfaceField;
		    
		    private string pollingTimeField;
		    
		    private string pollingTimeNotInUseField;
		    
		    private string priorityProtocolThreadField;
		    
		    private string baseClassBuildField;
		    
		    private string driverVersionField;
		    
		    private string aggregationLimitField;
		    
		    private string directWriteIOField;
		    
		    private string setInUseStructureFieldsField;
		    
		    private string suspendTasksInErrorField;
		    
		    private string expandGroup1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string WaitTime {
		        get {
		            return this.waitTimeField ?? "0";
		        }
		        set {
		    		if(this.waitTimeField != value){
		    			
		    			this.waitTimeField = value ?? "0";
		    			RaisePropertyChanged("WaitTime");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string TimeOut {
		        get {
		            return this.timeOutField ?? "50";
		        }
		        set {
		    		if(this.timeOutField != value){
		    			
		    			this.timeOutField = value ?? "50";
		    			RaisePropertyChanged("TimeOut");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SynchroStart {
		        get {
		            return this.synchroStartField ?? "false";
		        }
		        set {
		    		if(this.synchroStartField != value){
		    			
		    			this.synchroStartField = value ?? "false";
		    			RaisePropertyChanged("SynchroStart");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string MinimumJobThreshold {
		        get {
		            return this.minimumJobThresholdField ?? "5";
		        }
		        set {
		    		if(this.minimumJobThresholdField != value){
		    			
		    			this.minimumJobThresholdField = value ?? "5";
		    			RaisePropertyChanged("MinimumJobThreshold");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DefRefreshTimeNotInUse {
		        get {
		            return this.defRefreshTimeNotInUseField ?? "100";
		        }
		        set {
		    		if(this.defRefreshTimeNotInUseField != value){
		    			
		    			this.defRefreshTimeNotInUseField = value ?? "100";
		    			RaisePropertyChanged("DefRefreshTimeNotInUse");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EnableCOMInterface {
		        get {
		            return this.enableCOMInterfaceField ?? "true";
		        }
		        set {
		    		if(this.enableCOMInterfaceField != value){
		    			
		    			this.enableCOMInterfaceField = value ?? "true";
		    			RaisePropertyChanged("EnableCOMInterface");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PollingTime {
		        get {
		            return this.pollingTimeField ?? "0";
		        }
		        set {
		    		if(this.pollingTimeField != value){
		    			
		    			this.pollingTimeField = value ?? "0";
		    			RaisePropertyChanged("PollingTime");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PollingTimeNotInUse {
		        get {
		            return this.pollingTimeNotInUseField ?? "0";
		        }
		        set {
		    		if(this.pollingTimeNotInUseField != value){
		    			
		    			this.pollingTimeNotInUseField = value ?? "0";
		    			RaisePropertyChanged("PollingTimeNotInUse");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PriorityProtocolThread {
		        get {
		            return this.priorityProtocolThreadField ?? "0";
		        }
		        set {
		            this.priorityProtocolThreadField = value ?? "0";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string BaseClassBuild {
		        get {
		            return this.baseClassBuildField;
		        }
		        set {
		            this.baseClassBuildField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DriverVersion {
		        get {
		            return this.driverVersionField;
		        }
		        set {
		            this.driverVersionField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string AggregationLimit {
		        get {
		            return this.aggregationLimitField ?? "0";
		        }
		        set {
		            this.aggregationLimitField = value ?? "0";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DirectWriteIO {
		        get {
		            return this.directWriteIOField ?? "false";
		        }
		        set {
		            this.directWriteIOField = value ?? "false";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SetInUseStructureFields {
		        get {
		            return this.setInUseStructureFieldsField ?? "false";
		        }
		        set {
		            this.setInUseStructureFieldsField = value ?? "false";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SuspendTasksInError {
		        get {
		            return this.suspendTasksInErrorField ?? "true";
		        }
		        set {
		            this.suspendTasksInErrorField = value ?? "true";
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandGroup1 {
		        get {
		            return this.expandGroup1Field ?? "1";
		        }
		        set {
		            this.expandGroup1Field = value ?? "1";
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
		public partial class DriverSettingsDebug : INotifyPropertyChanged {
		    
		    private string debugWindowField;
		    
		    private string maxLogEntriesField;
		    
		    private string logFileNameField;
		    
		    private string enableLogFileField;
		    
		    private string expandGroup2Field;
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string DebugWindow {
		        get {
		            return this.debugWindowField ?? "false";
		        }
		        set {
		            this.debugWindowField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string MaxLogEntries {
		        get {
		            return this.maxLogEntriesField ?? "10000";
		        }
		        set {
		            this.maxLogEntriesField = value ?? "10000";
		        }
		    }
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string LogFileName {
		        get {
		            return this.logFileNameField;
		        }
		        set {
		            this.logFileNameField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string EnableLogFile {
		        get {
		            return this.enableLogFileField ?? "true";
		        }
		        set {
		            this.enableLogFileField = value ?? "true";
		        }
		    }
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string ExpandGroup2 {
		        get {
		            return this.expandGroup2Field ?? "1";
		        }
		        set {
		            this.expandGroup2Field = value ?? "1";
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
		
		[XmlType("EIPDriverSettings")]
		public class DriverSettingsEIPDriverSettings
		{
			
		}
		
		/// <remarks/>
		[XmlType("S7TCPDriverSettings")]
		public partial class DriverSettingsS7TCPDriverSettings : INotifyPropertyChanged {
		    
		    private string remoteDeviceIDField;
		    
		    private string remoteRackField;
		    
		    private string remoteSlotField;
		    
		    private string expandS7Group1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteDeviceID {
		        get {
		            return this.remoteDeviceIDField ?? "1";
		        }
		        set {
		    		if(this.remoteDeviceIDField != value){
		    			
		    			this.remoteDeviceIDField = value;
		    			RaisePropertyChanged("RemoteDeviceID");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteRack {
		        get {
		            return this.remoteRackField ?? "0";
		        }
		        set {
		    		if(this.remoteRackField != value){
		    			
		    			this.remoteRackField = value;
		    			RaisePropertyChanged("RemoteRack");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteSlot {
		        get {
		            return this.remoteSlotField ?? "0";
		        }
		        set {
		    		if(this.remoteSlotField != value){
		    			
		    			this.remoteSlotField = value;
		    			RaisePropertyChanged("RemoteSlot");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandS7Group1 {
		        get {
		            return this.expandS7Group1Field ?? "1";
		        }
		        set {
		            this.expandS7Group1Field = value;
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
		
		[XmlType("ModbusTCPSettings")]
		public class DriverSettingsModbusTCPSettings : INotifyPropertyChanged
		{
			
			private string singleSocketField;
		    
		    private string expandSpecificGroup1Field;
			
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SingleSocket {
		        get {
		            return this.singleSocketField ?? "0";
		        }
		        set {
		    		if(this.singleSocketField != value){
		    			
		    			this.singleSocketField = value;
		    			RaisePropertyChanged("SingleSocket");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandSpecificGroup1 {
		        get {
		            return this.expandSpecificGroup1Field ?? "0";
		        }
		        set {
		            this.expandSpecificGroup1Field = value;
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
		public partial class DriverSettingsJobListJob : INotifyPropertyChanged {
		    
		    private Name nameField;
		    
		    private DriverSettingsJobListJobVariableList variableListField;
		    
		    private DriverSettingsJobListJobDeviceTaskSettings deviceTaskSettingsField;
		    
		    private DriverSettingsJobListJobModbusTCPIP modbusTCPIPField;
		    
		    /// <remarks/>
		    [XmlElement("Name")]
		    public Name Name {
		        get {
		            return this.nameField;
		        }
		        set {

	    			this.nameField = value;
	    			RaisePropertyChanged("Name");

		        }
		    }
		    
		    /// <remarks/>
		    [XmlElement("VariableList")]
		    public DriverSettingsJobListJobVariableList VariableList {
		        get {
		            return this.variableListField;
		        }
		        set {

	    			this.variableListField = value;
	    			RaisePropertyChanged("VariableList");

		        }
		    }
		    
		    /// <remarks/>
		    [XmlElement("DeviceTaskSettings")]
		    public DriverSettingsJobListJobDeviceTaskSettings DeviceTaskSettings {
		        get {
		            return this.deviceTaskSettingsField;
		        }
		        set {

	    			this.deviceTaskSettingsField = value;
	    			RaisePropertyChanged("DeviceTaskSettings");

		        }
		    }
		    
		    /// <remarks/>
		    [XmlElement("ModbusTCPIP")]
		    public DriverSettingsJobListJobModbusTCPIP ModbusTCP {
		        get {
		            return this.modbusTCPIPField;
		        }
		        set {

	    			this.modbusTCPIPField = value;
	    			RaisePropertyChanged("ModbusTCPIP");

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
		public partial class Name : INotifyPropertyChanged {
		    
		    private string typeField;
		    
		    private string stationField;
		    
		    private string pollingTimeField;
		    
		    private string pollingTimeNotInUseField;
		    
		    private string conditionalVariableField;
		    
		    private string swapByteField;
		    
		    private string swapWordField;
		    
		    private string isDynamicField;
		    
		    private string outputAtStartupField;
		    
		    private string varAddressOffsetField;
		    
		    private string expandGroup1Field;
		    
		    private string maxRetriesField;
		    
		    private string stateVariableField;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Type {
		        get {
		            return this.typeField;
		        }
		        set {
   		    		if(this.typeField != value){
		    			
		    			this.typeField = value;
		    			RaisePropertyChanged("Type");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Station {
		        get {
		            return this.stationField;
		        }
		        set {
	    		    string sValue;
	    			if (value == "") {
	    				
	    				sValue = "DummyStation";
	    				
	    			}
					else{
						
						sValue = value;
						
					}

		            if(this.stationField != sValue){
  
		    			this.stationField = sValue;
		    			RaisePropertyChanged("Station");
		    			    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PollingTime {
		        get {
		            return this.pollingTimeField;
		        }
		        set {
   		    		if(this.pollingTimeField != value){
		    			
		    			this.pollingTimeField = value;
		    			RaisePropertyChanged("PollingTime");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PollingTimeNotInUse {
		        get {
		            return this.pollingTimeNotInUseField;
		        }
		        set {
   		    		if(this.pollingTimeNotInUseField != value){
		    			
		    			this.pollingTimeNotInUseField = value;
		    			RaisePropertyChanged("PollingTimeNotInUse");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ConditionalVariable {
		        get {
		            return this.conditionalVariableField;
		        }
		        set {
  		    		if(this.conditionalVariableField != value){
		    			
		    			this.conditionalVariableField = value;
		    			RaisePropertyChanged("ConditionalVariable");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SwapByte {
		        get {
		            return this.swapByteField;
		        }
		        set {
  		    		if(this.swapByteField != value){
		    			
		    			this.swapByteField = value;
		    			RaisePropertyChanged("SwapByte");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SwapWord {
		        get {
		            return this.swapWordField;
		        }
		        set {
  		    		if(this.swapWordField != value){
		    			
		    			this.swapWordField = value;
		    			RaisePropertyChanged("SwapWord");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string IsDynamic {
		        get {
		            return this.isDynamicField;
		        }
		        set {
		            this.isDynamicField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string OutputAtStartup {
		        get {
		            return this.outputAtStartupField;
		        }
		        set {
  		    		if(this.outputAtStartupField != value){
		    			
		    			this.outputAtStartupField = value;
		    			RaisePropertyChanged("OutputAtStartup");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string VarAddressOffset {
		        get {
		            return this.varAddressOffsetField;
		        }
		        set {
		            this.varAddressOffsetField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandGroup1 {
		        get {
		            return this.expandGroup1Field;
		        }
		        set {
		            this.expandGroup1Field = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string MaxRetries {
		        get {
		            return this.maxRetriesField;
		        }
		        set {
  		    		if(this.maxRetriesField != value){
		    			
		    			this.maxRetriesField = value;
		    			RaisePropertyChanged("MaxRetries");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string StateVariable {
		        get {
		            return this.stateVariableField;
		        }
		        set {
		    		if(this.stateVariableField != value){
		    			
		    			this.stateVariableField = value;
		    			RaisePropertyChanged("StateVariable");
		    			
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
  		    		if(this.valueField != value){
		    			
		    			this.valueField = value;
		    			RaisePropertyChanged("Value");
		    			
		    		}
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
		public partial class DriverSettingsJobListJobVariableList : INotifyPropertyChanged {
		    
		    private string v0Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string V0 {
		        get {
		            return this.v0Field;
		        }
		        set {
  		    		if(this.v0Field != value){
		    			
		    			this.v0Field = value;
		    			RaisePropertyChanged("V0");
		    			
		    		}
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
		public partial class DriverSettingsJobListJobDeviceTaskSettings : INotifyPropertyChanged {
		    
		    private string deviceAddressField;
		    
		    private string s7_200Field;
		    
		    private string expandS7Group1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DeviceAddress {
		        get {
		            return this.deviceAddressField;
		        }
		        set {
  		    		if(this.deviceAddressField != value){
		    			
		    			this.deviceAddressField = value;
		    			RaisePropertyChanged("DeviceAddress");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string S7_200 {
		        get {
		            return this.s7_200Field;
		        }
		        set {
		            this.s7_200Field = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandS7Group1 {
		        get {
		            return this.expandS7Group1Field;
		        }
		        set {
		            this.expandS7Group1Field = value;
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
		public partial class DriverSettingsJobListJobModbusTCPIP : INotifyPropertyChanged {
			
			private string unitIDField;
			
			private string functionCodeField;
			
			private string startAddressField;
			
			private string registerSizeField;
			
			/// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string UnitID {
		        get {
		            return this.unitIDField;
		        }
		        set {
  		    		if(this.unitIDField != value){
		    			
		    			this.unitIDField = value;
		    			RaisePropertyChanged("UnitID");
		    			
		    		}
		        }
		    }
			
			/// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string FunctionCode {
		        get {
		            return this.functionCodeField;
		        }
		        set {
  		    		if(this.functionCodeField != value){
		    			
		    			this.functionCodeField = value;
		    			RaisePropertyChanged("FunctionCode");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string StartAddress {
		        get {
		            return this.startAddressField;
		        }
		        set {
 		    		if(this.startAddressField != value){
		    			
		    			this.startAddressField = value;
		    			RaisePropertyChanged("StartAddress");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RegisterSize {
		        get {
		            return this.registerSizeField;
		        }
		        set {
 		    		if(this.registerSizeField != value){
		    			
		    			this.registerSizeField = value;
		    			RaisePropertyChanged("RegisterSize");
		    			
		    		}
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
		public partial class DriverSettingsStationListStation : INotifyPropertyChanged {
		    
		    private DriverSettingsStationListStationName nameField;
		    
		    private DriverSettingsStationListStationServer serverField;
		    
		    private DriverSettingsStationListStationQueue queueField;
		    
		    private DriverSettingsStationListStationTimeouts timeoutsField;
		    
		    private DriverSettingsStationListStationRASSettings rASSettingsField;
		    
		    private DriverSettingsStationListStationDeviceStationSettings deviceStationSettingsField;
		    
		    private DriverSettingsStationListStationABStationSettings abStationSettingsField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("Name", IsNullable=true)]
		    public DriverSettingsStationListStationName Name {
		        get {
		            return this.nameField;
		        }
		        set {

	    			this.nameField = value;
	    			RaisePropertyChanged("Name");
	    			
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("Server", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationServer Server {
		        get {
		            return this.serverField;
		        }
		        set {

	    				this.serverField = value;
	    				RaisePropertyChanged("Server");
		            }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("Queue", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationQueue Queue {
		        get {
		            return this.queueField;
		        }
		        set {
		    			
	    			this.queueField = value;
	    			RaisePropertyChanged("Queue");

		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("Timeouts", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationTimeouts Timeouts {
		        get {
		            return this.timeoutsField;
		        }
		        set {
		    			
	    			this.timeoutsField = value;
	    			RaisePropertyChanged("Timeouts");

		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("RASSettings", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationRASSettings RASSettings {
		        get {
		            return this.rASSettingsField;
		        }
		        set {
		            this.rASSettingsField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlElementAttribute("DeviceStationSettings", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationDeviceStationSettings DeviceStationSettings {
		        get {
		            return this.deviceStationSettingsField;
		        }
		        set {
		    			
	    			this.deviceStationSettingsField = value;
	    			RaisePropertyChanged("DeviceStationSettings");

		        }
		    }
		    
		    [System.Xml.Serialization.XmlElementAttribute("ABStationSettings", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
		    public DriverSettingsStationListStationABStationSettings ABStationSettings{
		    	get {
		            return this.abStationSettingsField;
		        }
		        set {
		            this.abStationSettingsField = value;
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
		
		[XmlType()]
		public class DriverSettingsStationListStationName : INotifyPropertyChanged {
			
			private string maxRetriesField;
		    
		    private string stateVariableField;
		    
		    private string expandGroup1Field;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string MaxRetries {
		        get {
		            return this.maxRetriesField ?? "1";
		        }
		        set {
		    		if(this.maxRetriesField != value){
		    			
		    			this.maxRetriesField = value;
		    			RaisePropertyChanged("MaxRetries");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string StateVariable {
		        get {
		            return this.stateVariableField ?? "";
		        }
		        set {
		    		if(this.stateVariableField != value){
		    			
		    			this.stateVariableField = value;
		    			RaisePropertyChanged("StateVariable");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandGroup1 {
		        get {
		            return this.expandGroup1Field ?? "0";
		        }
		        set {
		            this.expandGroup1Field = value;
		        }
		    }
		    
			[System.Xml.Serialization.XmlTextAttribute()]
		    public string Value {
		        get {
		            return this.valueField;
		        }
		        set {
	    			if(this.valueField != value){
		    			
		    			this.valueField = value;
		    			RaisePropertyChanged("Value");
		    			
		    		}
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
		public partial class DriverSettingsStationListStationServer : INotifyPropertyChanged {
		    
		    private string serverAddressField;
		    
		    private string serverPortField;
		    
		    private string backupServerAddressField;
		    
		    private string switchServerTimeoutField;
		    
		    private string localBoundAddressField;
		    
		    private string localBoundPortField;
		    
		    private string usePingField;
		    
		    private string expandTcpGroup1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ServerAddress {
		        get {
		            return this.serverAddressField ?? "";
		        }
		        set {
		    		if(this.serverAddressField != value){
		    			
		    			this.serverAddressField = value ?? "";
		    			RaisePropertyChanged("ServerAddress");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ServerPort {
		        get {
		            return this.serverPortField ?? "102";
		        }
		        set {
		    		if(this.serverPortField != value){
		    			
		    			this.serverPortField = value ?? "102";
		    			RaisePropertyChanged("ServerPort");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string BackupServerAddress {
		        get {
		            return this.backupServerAddressField ?? "";
		        }
		        set {
		    		if(this.backupServerAddressField != value){
		    			
		    			this.backupServerAddressField = value ?? "";
		    			RaisePropertyChanged("BackupServerAddress");
		    			
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string SwitchServerTimeout {
		        get {
		            return this.switchServerTimeoutField ?? "10000";
		        }
		        set {
	    			if(this.switchServerTimeoutField != value){
		    			
		    			this.switchServerTimeoutField = value;
		    			RaisePropertyChanged("SwitchServerTimeout");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string LocalBoundAddress {
		        get {
		            return this.localBoundAddressField ?? "";
		        }
		        set {
		    		if(this.localBoundAddressField != value){
		    			
		    			this.localBoundAddressField = value;
		    			RaisePropertyChanged("LocalBoundAddress");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string LocalBoundPort {
		        get {
		            return this.localBoundPortField ?? "0";
		        }
		        set {
		    		if(this.localBoundPortField != value){
		    			
		    			this.localBoundPortField = value;
		    			RaisePropertyChanged("LocalBoundPort");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string UsePing {
		        get {
		            return this.usePingField ?? "false";
		        }
		        set {
		            this.usePingField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandTcpGroup1 {
		        get {
		            return this.expandTcpGroup1Field ?? "0";
		        }
		        set {
		            this.expandTcpGroup1Field = value;
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
		public partial class DriverSettingsStationListStationQueue : INotifyPropertyChanged {
		    
		    private string maxReceiveField;
		    
		    private string maxSendField;
		    
		    private string expandTcpGroup2Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string MaxReceive {
		        get {
		            return this.maxReceiveField ?? "1024";
		        }
		        set {
		            this.maxReceiveField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string MaxSend {
		        get {
		            return this.maxSendField ?? "1024";
		        }
		        set {
		            this.maxSendField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandTcpGroup2 {
		        get {
		            return this.expandTcpGroup2Field ?? "0";
		        }
		        set {
		            this.expandTcpGroup2Field = value;
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
		public partial class DriverSettingsStationListStationTimeouts : INotifyPropertyChanged {
		    
		    private string rxTimeoutField;
		    
		    private string txTimeoutField;
		    
		    private string expandTcpGroup3Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RxTimeout {
		        get {
		            return this.rxTimeoutField ?? "5000";
		        }
		        set {
		            this.rxTimeoutField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string TxTimeout {
		        get {
		            return this.txTimeoutField ?? "5000";
		        }
		        set {
		            this.txTimeoutField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandTcpGroup3 {
		        get {
		            return this.expandTcpGroup3Field ?? "0";
		        }
		        set {
		            this.expandTcpGroup3Field = value;
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
		public partial class DriverSettingsStationListStationRASSettings : INotifyPropertyChanged {
		    
		    private string phoneBookEntryField;
		    
		    private string phoneNumberField;
		    
		    private string userNameField;
		    
		    private string passwordField;
		    
		    private string retriesField;
		    
		    private string disconnectAfterSecsField;
		    
		    private string enableRASCallOnThisStationField;
		    
		    private string promptForConnectionField;
		    
		    private string retryAfterSecsField;
		    
		    private string dialOnlyOnCommandField;
		    
		    private string expandRasGroup1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PhoneBookEntry {
		        get {
		            return this.phoneBookEntryField;
		        }
		        set {
		            this.phoneBookEntryField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PhoneNumber {
		        get {
		            return this.phoneNumberField;
		        }
		        set {
		            this.phoneNumberField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string UserName {
		        get {
		            return this.userNameField;
		        }
		        set {
		            this.userNameField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Password {
		        get {
		            return this.passwordField;
		        }
		        set {
		            this.passwordField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Retries {
		        get {
		            return this.retriesField ?? "3";
		        }
		        set {
		            this.retriesField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DisconnectAfterSecs {
		        get {
		            return this.disconnectAfterSecsField ?? "10";
		        }
		        set {
		            this.disconnectAfterSecsField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string EnableRASCallOnThisStation {
		        get {
		            return this.enableRASCallOnThisStationField ?? "false";
		        }
		        set {
		            this.enableRASCallOnThisStationField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PromptForConnection {
		        get {
		            return this.promptForConnectionField ?? "false";
		        }
		        set {
		            this.promptForConnectionField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RetryAfterSecs {
		        get {
		            return this.retryAfterSecsField ?? "30";
		        }
		        set {
		            this.retryAfterSecsField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DialOnlyOnCommand {
		        get {
		            return this.dialOnlyOnCommandField ?? "false";
		        }
		        set {
		            this.dialOnlyOnCommandField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandRasGroup1 {
		        get {
		            return this.expandRasGroup1Field;
		        }
		        set {
		            this.expandRasGroup1Field = value;
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
		public partial class DriverSettingsStationListStationDeviceStationSettings : INotifyPropertyChanged {
		    
		    private string s7_200Field;
		    
		    private string remoteDeviceIDField;
		    
		    private string remoteRackField;
		    
		    private string remoteSlotField;
		    
		    private string backupDeviceIDField;
		    
		    private string backupRackField;
		    
		    private string backupSlotField;
		    
		    private string expandS7Group1Field;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string S7_200 {
		        get {
		            return this.s7_200Field ?? "0";
		        }
		        set {
		            this.s7_200Field = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteDeviceID {
		        get {
		            return this.remoteDeviceIDField ?? "2";
		        }
		        set {
		    		if(this.remoteDeviceIDField != value){
		    			
		    			this.remoteDeviceIDField = value;
		    			RaisePropertyChanged("RemoteDeviceID");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteRack {
		        get {
		            return this.remoteRackField ?? "0";
		        }
		        set {
		    		if(this.remoteRackField != value){
		    			
		    			this.remoteRackField = value;
		    			RaisePropertyChanged("RemoteRack");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RemoteSlot {
		        get {
		            return this.remoteSlotField ?? "2";
		        }
		        set {
		    		if(this.remoteSlotField != value){
		    			
		    			this.remoteSlotField = value;
		    			RaisePropertyChanged("RemoteSlot");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string BackupDeviceID {
		        get {
		            return this.backupDeviceIDField ?? "0";
		        }
		        set {
		    		if(this.backupDeviceIDField != value){
		    			
		    			this.backupDeviceIDField = value;
		    			RaisePropertyChanged("BackupDeviceID");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string BackupRack {
		        get {
		            return this.backupRackField ?? "2";
		        }
		        set {
		    		if(this.backupRackField != value){
		    			
		    			this.backupRackField = value;
		    			RaisePropertyChanged("BackupRack");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string BackupSlot {
		        get {
		            return this.backupSlotField ?? "0";
		        }
		        set {
		    		
		    		if(this.backupSlotField != value){
		    			
		    			this.backupSlotField = value;
		    			RaisePropertyChanged("BackupSlot");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandS7Group1 {
		        get {
		            return this.expandS7Group1Field;
		        }
		        set {
		            this.expandS7Group1Field = value;
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
		
		[XmlType()]
		public class DriverSettingsStationListStationABStationSettings : INotifyPropertyChanged {
			
			private string plcTypeField;
		    
		    private string cpuSlotField;
		    
		    private string physicalAddressNonBlockingField;
		    
		    private string physicalAddressBlockingField;
		    
		    private string plcStatusPollingTimeField;
		    
		    private string expandEthernetIPGroup1Field;
		    
			/// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PlcType {
		        get {
		            return this.plcTypeField;
		        }
		        set {
		            this.plcTypeField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string CpuSlot {
		        get {
		            return this.cpuSlotField;
		        }
		        set {
		            this.cpuSlotField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PhysicalAddressNonBlocking {
		        get {
		            return this.physicalAddressNonBlockingField;
		        }
		        set {
		            this.physicalAddressNonBlockingField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PhysicalAddressBlocking {
		        get {
		            return this.physicalAddressBlockingField;
		        }
		        set {
		            this.physicalAddressBlockingField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string PLCStatusPollingTime {
		        get {
		            return this.plcStatusPollingTimeField;
		        }
		        set {
		            this.plcStatusPollingTimeField = value;
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ExpandEthernetIPGroup1 {
		        get {
		            return this.expandEthernetIPGroup1Field;
		        }
		        set {
		            this.expandEthernetIPGroup1Field = value;
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
		
				
		public void Serialize(bool Save)
		{ 
			
			if (Save) {
			
				foreach (var driverName in driverListName) {	
					
			    	XmlSerializer serializer = new XmlSerializer(typeof(DriverSettings)); 
			    	XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			    	ns.Add("","");
			    	
			    	using (TextWriter writer = new StreamWriter(Path + driverName.Replace(" ",string.Empty) + ".drvsettings", false, System.Text.Encoding.GetEncoding("ISO-8859-1")))
			    	{	
			    		serializer.Serialize(writer, DriverList[GetDriverIndex(driverName)], ns);
			    	}
		
				}
				
			}
			
			int counter = 0;
			foreach (var driverName in driverListName) {
				DriverList.Remove(DriverList[GetDriverIndex(driverName)-counter]);
				counter++;
			}
	
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

		public void RemoveUnusedItems(List<string> TaskList)
		{
		    
	        if (TaskList.Count != 0){
	        
				for (int i = 0; i < DriverList.Count; i++) {
				
		        	foreach ( string element in TaskList) {
		        	
						DriverList[i].JobList.Remove(GetDriverTask(element,i));
		        		
		        	}
					
				}
		        	
			}
		}
		
		public void RemoveUnusedItems(IEnumerable<string> TaskList)
		{
		    
			if (TaskList == null) return ;
			
			if (TaskList.Count() != 0){
	        
				for (int i = 0; i < DriverList.Count; i++) {
				
		        	foreach ( string element in TaskList) {
		        	
						DriverList[i].JobList.Remove(GetDriverTask(element,i));
		        		
		        	}
					
				}
		        	
			}
		}
	
//#####################################################
//#
//# Function that loads the file that contains the variables
//#
//#####################################################			
		
		public void Load(string Path, List<string> DriverListName)
		{
			this.driverListName = DriverListName;
			this.Path = Path;
					
			foreach (var driverName in driverListName) {
				
				DriverSettings driver = new DriverSettings();
				
				var textReader = new StreamReader(Path + driverName.Replace(" ",string.Empty) + ".drvsettings");
				var deserializer = new XmlSerializer(typeof(DriverSettings));
				driver = (DriverSettings)deserializer.Deserialize(textReader);
				DriverList.Add(driver);
				textReader.Close();
				
			}
		}
		
		public void CreateDriverXML(string Path, string Driver)
		{
			
			if (Driver != "ModbusTCPIP" && Driver != "S7TCP") return;
			
			if(!CheckIfDriverXmlFileExists(Path, Driver)){
				
				var newDriver =	AddDriver(Driver);
				driverListName.Add(Driver);
				
			}

		}
		
		public bool CheckIfDriverXmlFileExists(string Path, string Driver)
		{
			
		 	return File.Exists(Path + Driver + ".drvsettings");
			
		}
		
//#####################################################
//#
//# Function that add a variable element in tree
//#
//#####################################################			
		
		
		public DriverSettings AddDriver(string DriverName)
		{
			switch (DriverName) {
				case "S7TCP" :
					DriverList.Add(new DriverSettings{
				               	Debug = new DriverSettingsDebug{},
				               	GeneralSettings = new DriverSettingsGeneralSettings{},
				               	S7TCPDriverSettings = new DriverSettingsS7TCPDriverSettings{},
				               	StationList =  new ObservableCollection<DriverSettingsStationListStation>()});
					
					break;
					
				case "ModbusTCPIP":
					DriverList.Add(new DriverSettings{
				               	Debug = new DriverSettingsDebug{},
				               	GeneralSettings = new DriverSettingsGeneralSettings{},
				               	ModbusTCPSettings = new DriverSettingsModbusTCPSettings{},
					            StationList =  new ObservableCollection<DriverSettingsStationListStation>()});
					
					break;
					
				case "EtherNetIP":
					DriverList.Add(new DriverSettings{
				               	Debug = new DriverSettingsDebug{},
				               	GeneralSettings = new DriverSettingsGeneralSettings{},
				               	EIPDriverSettings = new DriverSettingsEIPDriverSettings{},
					            StationList =  new ObservableCollection<DriverSettingsStationListStation>()});
					
					break;
					
			}	

			return DriverList.Last();

		}

		public void AddNewStation(string DriverName, string StationName, string ServerAddress, string BackupServerAddress)
		{
		
			int index  = GetDriverIndex(DriverName);

		    switch (DriverName) {
		    		
		    	case "S7TCP":
		  
			    DriverList[index].StationList.Add(new DriverSettingsStationListStation {
			                                      	Name = new DriverSettingsStationListStationName{Value = StationName,
					                                  												StateVariable = StationName + ":StationState"},
			                                      	Server = new DriverSettingsStationListStationServer {ServerAddress = ServerAddress,
			                                      														 ServerPort = "102",
			                                      														 BackupServerAddress = BackupServerAddress},
		    		                                Queue = new DriverSettingsStationListStationQueue{},
		    		                                Timeouts = new DriverSettingsStationListStationTimeouts{},
		    		                                RASSettings = new DriverSettingsStationListStationRASSettings{},
		    		                                DeviceStationSettings = new DriverSettingsStationListStationDeviceStationSettings{}
			                                      	});
		    	break;
		    	
		    	case "ModbusTCPIP":
		    	
		    	DriverList[index].StationList.Add(new DriverSettingsStationListStation {
			                                      	Name = new DriverSettingsStationListStationName{Value = StationName,
		    	                                  													StateVariable = StationName + ":StationState" },
			                                      	Server = new DriverSettingsStationListStationServer {ServerAddress = ServerAddress,
			                                      														 ServerPort = "502",
			                                      														 BackupServerAddress = BackupServerAddress},
			                                      	Queue = new DriverSettingsStationListStationQueue{},
			                                      	Timeouts = new DriverSettingsStationListStationTimeouts{},
			                                      	RASSettings = new DriverSettingsStationListStationRASSettings{},
			                                      	});
		    	 break;
		    	
		   		 case "EtherNetIP":
		    	
		    	 DriverList[index].StationList.Add(new DriverSettingsStationListStation {
			                                      	Name = new DriverSettingsStationListStationName{Value = StationName},
			                                      	Server = new DriverSettingsStationListStationServer {ServerAddress = ServerAddress,
			                                      														 ServerPort = "",
			                                      														 BackupServerAddress = BackupServerAddress},
			                                      	Queue = new DriverSettingsStationListStationQueue{},
			                                      	Timeouts = new DriverSettingsStationListStationTimeouts{},
			                                      	RASSettings = new DriverSettingsStationListStationRASSettings{},
			                                      	ABStationSettings = new DriverSettingsStationListStationABStationSettings{}
			                                      	});
		    	break;
		   	  }

		}
		
		public bool AddNewTask(string DriverName, string StationName, string TaskName, string Variable, string Address, int Type, string ConditionalVariable, string UnitID, int FunctionCode)
		{

		    int index;
		    string sStationName;
		    
		    //if (DriverName != "ModbusTCPIP" && DriverName != "S7TCP") return false;
		    
			if (StationName == ""){
				
				sStationName = "DummyStation";
				
			}
			else{
				
		    	sStationName = StationName;
		    			
			}
		    
		    if(DriverName == null){
		    	
		    	index = 0;
		    	DriverName = GetDriverName(index);
		    	
		    }
		    else{

		    	index = GetDriverIndex(DriverName);
		    }
		    
		    switch (DriverName) {
		    		
		    	case "S7 TCP":
		  				
		    		DriverList[index].JobList.Add(new DriverSettingsJobListJob {Name = new Name {Value = TaskName,
		    		                              												 Station = sStationName,
		    		                              												 Type = Type.ToString(),
																			    		         ConditionalVariable = ConditionalVariable	},
		    		                              								VariableList = new DriverSettingsJobListJobVariableList{V0 = Variable},
		    		                              								DeviceTaskSettings = new DriverSettingsJobListJobDeviceTaskSettings{DeviceAddress = Address}
		    		                              });
						
		    	break;
		    	
		    	case "ModbusTCPIP":

		    		DriverList[index].JobList.Add(new DriverSettingsJobListJob {Name = new Name {Value = TaskName,
	                              												 				 Station = sStationName,
	                              												 				 Type = Type.ToString(),
		    	                              													 ConditionalVariable = ConditionalVariable},
	                              												VariableList = new DriverSettingsJobListJobVariableList{V0 = Variable},
	                              												ModbusTCP = new DriverSettingsJobListJobModbusTCPIP{UnitID = UnitID, 
	                              																									  FunctionCode = FunctionCode.ToString(), 
	                              																									  StartAddress = Address, 
	                              																									  RegisterSize = "2" }
	                              });
		    	

		    	break;
		    	
		   		case "EtherNetIP":
		    	

		    	break;
			}
		    
		    return true;
		}
		
		public int GetDriverIndex(string DriverName)
		{
			Debug.WriteLine(driverListName.FindIndex(p => p == DriverName));
			return driverListName.FindIndex(p => p == DriverName);	
		}
		
		private string GetDriverName(int Index)
		{
			
			return driverListName[Index];
			
		}
		
		public ObservableCollection<DriverSettingsStationListStation> GetStationList(string DriverName)
		{	
			int Index = GetDriverIndex(DriverName);
			return DriverList[Index].StationList;	
		}
		
		public DriverSettingsStationListStation GetStation(string DriverName, string StationName)
		{
			
			
			var DriverList = GetStationList(DriverName);
			
			if (DriverList == null) {
				
				return null;
				
			}
			
			return DriverList.FirstOrDefault(p => p.Name.Value == StationName) ;	
		}
		
		public DriverSettingsStationListStation GetStation(string StationName, int index)
		{	
			return DriverList[index].StationList.FirstOrDefault(p => p.Name.Value == StationName);	
		}
		
		public List<string> GetDriverList()
		{
			
			return driverListName;
			
		}
		
		
		public ObservableCollection<DriverSettingsJobListJob> GetDriverTaskList(string DriverName)
		{	
			int driverIndex = GetDriverIndex(DriverName);			
			return DriverList[driverIndex].JobList;		
		}
		
		public DriverSettingsJobListJob GetDriverTask (string DriverName, string TaskName)
		{		
	  		int driverIndex = GetDriverIndex(DriverName);
			return DriverList[driverIndex].JobList.FirstOrDefault(p => p.Name.Value == TaskName);
		}

		public DriverSettingsJobListJob GetDriverTask (string TaskName, int Index)
		{		
			return DriverList[Index].JobList.FirstOrDefault(p => p.Name.Value == TaskName);
		}
		
		public bool CheckIfStationExist (string StationName, int Index)
		{
			return DriverList[Index].StationList.Any(p => p.Name.Value == StationName);
		}
		
		public bool CheckIfStationExist ( string DriverName, string StationName)
		{
			CheckIfStationListIsNull(DriverName);
			int driverIndex = GetDriverIndex(DriverName);
			return DriverList[driverIndex].StationList.Any(p => p.Name.Value == StationName);	 
		}
		
		public bool CheckIfDriverTaskExist (string DriverName, string TaskName)
		{
			int driverIndex = GetDriverIndex(DriverName);
			return DriverList[driverIndex].JobList.Any(p => p.Name.Value == TaskName);		
		}
		
		public bool CheckIfDriverTaskExist (string TaskName, int Index)
		{
			return DriverList[Index].JobList.Any(p => p.Name.Value == TaskName);	
		}
		
		public bool CheckIfStationListIsNull (string DriverName)
		{
			
			int Index = GetDriverIndex(DriverName);
			Debug.WriteLine(DriverList[Index].StationList.Count());
			return true;
			
		}
		
		public DriverSettingsJobListJob GetDriverTask(string TaskName)
		{
			
			DriverSettingsJobListJob Task = null;
			
			for (int i = 0; i < DriverList.Count; i++) {
				
				Task = GetDriverTask(TaskName, i);
				
				if(Task != null){
					
					return Task;
					
				}
				
			}
			
			return Task;
			
		}
		
		
		public DriverSettingsStationListStation GetStation(string StationName)
		{

			for (int i = 0; i < DriverList.Count; i++) {
				
				if(GetStation(StationName, i) != null){
				
					return GetStation(StationName, i);
					
				}
				
			}
			
			return null;
			
		}
		
		public string GetDriverName(string StationName)
		{
			
			for (int i = 0; i < DriverList.Count; i++) {
				
				if(GetStation(StationName, i) != null){
					
					return GetDriverName(i);
					
				}
				
			}
			
			return null;
			
		}
		
		public void RemoveTask(string TaskName)
		{
			
			int i;
			for (i = 0; i < DriverList.Count; i++) {
				
				if(GetDriverTask(TaskName) != null){
					
					DriverList[i].JobList.Remove(GetDriverTask(TaskName,i));
					
				}
				
			}
			
		}
		
		public void CheckIfStationsExist(string DriverName, List<string> Items)
		{
			
			var StationList = GetStationList(DriverName);
			int index = GetDriverIndex(DriverName);
			
			var Station = (from station in StationList
				            where Items.Any(p => p.Equals(station.Name.Value)) == false
				            select station).ToList();

				foreach (var element in Station) {
				
					DriverList[index].StationList.Remove(element);
				
				}
			
			
		}
		
		
//		private List<string> GetUnusedStations(string DriverName, List<string> StationName)
//		{
//			
//			
//			
//		}
		
	}
	
}
