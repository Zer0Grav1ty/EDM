/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 20.03.2014
 * Time: 16:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Microsoft.Win32;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Threading;
using NetOffice;
using Excel = NetOffice.ExcelApi;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;

namespace EekelsDataManager
{
	/// <summary>
	/// Description of ReadVariableXML.
	/// </summary>
	/// 

public class VariableXML
{
	private string _Path;
	
	public string Path{
		get { return this._Path;}
		set { this._Path = value;}
	}
	
	private RealTimeDB _variable;
	public RealTimeDB xmlVariable {
	get {return _variable;}
	set {_variable = value;}
}
	/// <remarks/>
	[XmlRoot()]
	public class RealTimeDB : INotifyPropertyChanged   {
	
	    private RealTimeDBAreaData areaDataField;
	    
	    private RealTimeDBEnableRetFlags enableRetFlagsField;
	    
	    private RealTimeDBEnableRetInput enableRetInputField;
	    
	    private RealTimeDBEnableRetOutput enableRetOutputField;
	    
	    private RealTimeDBEnableOPCServer enableOPCServerField;
	    
	    private RealTimeDBEnableOPXServer enableOPXServerField;
	    
	    private RealTimeDBEnableNTSecurityOPCServerTag enableNTSecurityOPCServerTagField;
	    
	    private RealTimeDBSzTraceDBSettings szTraceDBSettingsField;
	    
	    private RealTimeDBRealTimeODBCSettings realTimeODBCSettingsField;
	    
	    private ObservableCollection<RealTimeDBVariableListVariable> variableListField;
	    
	    private ObservableCollection<RealTimeDBDriverListVariable> driverListField;
	    
	    //private string renamedVariablesField;
	    
	    private List<RealTimeDBStructureListVariable> structureListField;
	    
	    
	    /// <remarks/>
	    [XmlElement("AreaData")]
	    public RealTimeDBAreaData AreaData {
	        get {
	            return this.areaDataField;
	        }
	        set {
	            this.areaDataField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableRetFlags")]
	    public RealTimeDBEnableRetFlags EnableRetFlags {
	        get {
	            return this.enableRetFlagsField;
	        }
	        set {
	            this.enableRetFlagsField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableRetInput")]
	    public RealTimeDBEnableRetInput EnableRetInput {
	        get {
	            return this.enableRetInputField;
	        }
	        set {
	            this.enableRetInputField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableRetOutput")]
	    public RealTimeDBEnableRetOutput EnableRetOutput {
	        get {
	            return this.enableRetOutputField;
	        }
	        set {
	            this.enableRetOutputField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableOPCServer")]
	    public RealTimeDBEnableOPCServer EnableOPCServer {
	        get {
	            return this.enableOPCServerField;
	        }
	        set {
	            this.enableOPCServerField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableOPXServer")]
	    public RealTimeDBEnableOPXServer EnableOPXServer {
	        get {
	            return this.enableOPXServerField;
	        }
	        set {
	            this.enableOPXServerField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("EnableNTSecurityOPCServerTag")]
	    public RealTimeDBEnableNTSecurityOPCServerTag EnableNTSecurityOPCServerTag {
	        get {
	            return this.enableNTSecurityOPCServerTagField;
	        }
	        set {
	            this.enableNTSecurityOPCServerTagField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("szTraceDBSettings")]
	    public RealTimeDBSzTraceDBSettings szTraceDBSettings {
	        get {
	            return this.szTraceDBSettingsField;
	        }
	        set {
	            this.szTraceDBSettingsField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlElement("RealTimeODBCSettings")]
	    public RealTimeDBRealTimeODBCSettings RealTimeODBCSettings {
	        get {
	            return this.realTimeODBCSettingsField;
	        }
	        set {
	            this.realTimeODBCSettingsField = value;
	        }
	    }
	    
	    /// <remarks/>
	    
	    [XmlArray("VariableList")]
	    [XmlArrayItem("Variable")]
	    public ObservableCollection<RealTimeDBVariableListVariable> VariableList {
	        get {
	            return this.variableListField;
	        }
	        set {
	    		if(this.variableListField != value){
	    			
	    			this.variableListField = value;
	    			RaisePropertyChanged("VariableList");
	    			
	    		}
	        }
	    }
	    
	     /// <remarks/>
	    [XmlArray("DriverList")]
	    [XmlArrayItem("Driver")]
	    public ObservableCollection<RealTimeDBDriverListVariable> DriverList {
	        get {
	            return this.driverListField;
	        }
	        set {
	            this.driverListField = value;
	            RaisePropertyChanged("DriverList");
	        }
	    }
	    
	    /// <remarks/>
	//    [XmlElement()]
	//    public string RenamedVariables {
	//        get {
	//            return this.renamedVariablesField;
	//        }
	//        set {
	//            this.renamedVariablesField = value;
	//        }
	//    }
	    
	    /// <remarks/>
	    [XmlArray("StructureList")]
	    [XmlArrayItem("Structure")]
	    public List<RealTimeDBStructureListVariable> StructureList {
	        get {
	            return this.structureListField;
	        }
	        set {
	            this.structureListField = value;
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
	public class RealTimeDBAreaData : INotifyPropertyChanged {
	    
	    private string numInputField;
	    
	    private string numOutputField;
	    
	    private string numFlagField;
	    
	    private string useSharedMemoryField;
	    
	    private string enableInUseVarMngField;
	    
	    private string enableTimeStampNotifyingField;
	    
	    private string useSharedDynTagField;
	    
	    private string useInputImageField;
	    
	    private string useOutputImageField;
	    
	    private string purgeDynTagTimerField;
	    
	    private string retWriteDelayField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string NumInput {
	        get {
	            return this.numInputField;
	        }
	        set {
	            this.numInputField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string NumOutput {
	        get {
	            return this.numOutputField;
	        }
	        set {
	            this.numOutputField = value;
	            RaisePropertyChanged("NumOutput");
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string NumFlag {
	        get {
	            return this.numFlagField;
	        }
	        set {
	            this.numFlagField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UseSharedMemory {
	        get {
	            return this.useSharedMemoryField;
	        }
	        set {
	            this.useSharedMemoryField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string EnableInUseVarMng {
	        get {
	            return this.enableInUseVarMngField;
	        }
	        set {
	            this.enableInUseVarMngField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string EnableTimeStampNotifying {
	        get {
	            return this.enableTimeStampNotifyingField;
	        }
	        set {
	            this.enableTimeStampNotifyingField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UseSharedDynTag {
	        get {
	            return this.useSharedDynTagField;
	        }
	        set {
	            this.useSharedDynTagField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UseInputImage {
	        get {
	            return this.useInputImageField;
	        }
	        set {
	            this.useInputImageField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UseOutputImage {
	        get {
	            return this.useOutputImageField;
	        }
	        set {
	            this.useOutputImageField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string PurgeDynTagTimer {
	        get {
	            return this.purgeDynTagTimerField;
	        }
	        set {
	            this.purgeDynTagTimerField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetWriteDelay {
	        get {
	            return this.retWriteDelayField;
	        }
	        set {
	            this.retWriteDelayField = value;
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
	public  class RealTimeDBEnableRetFlags : INotifyPropertyChanged {
	    
	    private string retFlagFromField;
	    
	    private string retFlagToField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetFlagFrom {
	        get {
	            return this.retFlagFromField;
	        }
	        set {
	            this.retFlagFromField = value;
	            RaisePropertyChanged("RetFlagFrom");
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetFlagTo {
	        get {
	            return this.retFlagToField;
	        }
	        set {
	            this.retFlagToField = value;
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
	public  class RealTimeDBEnableRetInput : INotifyPropertyChanged {
	    
	    private string retInputFromField;
	    
	    private string retInputToField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetInputFrom {
	        get {
	            return this.retInputFromField;
	        }
	        set {
	            this.retInputFromField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetInputTo {
	        get {
	            return this.retInputToField;
	        }
	        set {
	            this.retInputToField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlText()]
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
	public  class RealTimeDBEnableRetOutput : INotifyPropertyChanged {
	    
	    private string retOutputFromField;
	    
	    private string retOutputToField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetOutputFrom {
	        get {
	            return this.retOutputFromField;
	        }
	        set {
	            this.retOutputFromField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RetOutputTo {
	        get {
	            return this.retOutputToField;
	        }
	        set {
	            this.retOutputToField = value;
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
	public  class RealTimeDBEnableOPCServer : INotifyPropertyChanged {
	    
	    private string oPCServerNameField;
	    
	    private string oPCServerDescriptionField;
	    
	    private string enableOPCServerAEField;
	    
	    private string enableOPCServerDynTagField;
	    
	    private string oPCServerDebugEventsField;
	    
	    private string oPCServerAutoShutdownField;
	    
	    private string oPCServerAutoUnregisterField;
	    
	    private string oPCServerAutoRegisterField;
	    
	    private string oPCServerRefreshRateField;
	    
	    private string oPCServerShutdownClientsTimeoutField;
	    
	    private string oPCServerEnableAEAckField;
	    
	    private string oPCServerThreadingModeField;
	    
	    private string sINGLE_PATH_SEPARATORField;
	    
	    private string dOUBLE_PATH_SEPARATORField;
	    
	    private string oPX_PATH_SEPARATORField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerName {
	        get {
	            return this.oPCServerNameField;
	        }
	        set {
	            this.oPCServerNameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerDescription {
	        get {
	            return this.oPCServerDescriptionField;
	        }
	        set {
	            this.oPCServerDescriptionField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string EnableOPCServerAE {
	        get {
	            return this.enableOPCServerAEField;
	        }
	        set {
	            this.enableOPCServerAEField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string EnableOPCServerDynTag {
	        get {
	            return this.enableOPCServerDynTagField;
	        }
	        set {
	            this.enableOPCServerDynTagField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerDebugEvents {
	        get {
	            return this.oPCServerDebugEventsField;
	        }
	        set {
	            this.oPCServerDebugEventsField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerAutoShutdown {
	        get {
	            return this.oPCServerAutoShutdownField;
	        }
	        set {
	            this.oPCServerAutoShutdownField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerAutoUnregister {
	        get {
	            return this.oPCServerAutoUnregisterField;
	        }
	        set {
	            this.oPCServerAutoUnregisterField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerAutoRegister {
	        get {
	            return this.oPCServerAutoRegisterField;
	        }
	        set {
	            this.oPCServerAutoRegisterField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerRefreshRate {
	        get {
	            return this.oPCServerRefreshRateField;
	        }
	        set {
	            this.oPCServerRefreshRateField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerShutdownClientsTimeout {
	        get {
	            return this.oPCServerShutdownClientsTimeoutField;
	        }
	        set {
	            this.oPCServerShutdownClientsTimeoutField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerEnableAEAck {
	        get {
	            return this.oPCServerEnableAEAckField;
	        }
	        set {
	            this.oPCServerEnableAEAckField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerThreadingMode {
	        get {
	            return this.oPCServerThreadingModeField;
	        }
	        set {
	            this.oPCServerThreadingModeField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string SINGLE_PATH_SEPARATOR {
	        get {
	            return this.sINGLE_PATH_SEPARATORField;
	        }
	        set {
	            this.sINGLE_PATH_SEPARATORField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string DOUBLE_PATH_SEPARATOR {
	        get {
	            return this.dOUBLE_PATH_SEPARATORField;
	        }
	        set {
	            this.dOUBLE_PATH_SEPARATORField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPX_PATH_SEPARATOR {
	        get {
	            return this.oPX_PATH_SEPARATORField;
	        }
	        set {
	            this.oPX_PATH_SEPARATORField = value;
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
	public  class RealTimeDBEnableOPXServer : INotifyPropertyChanged {
	    
	    private string transportField;
	    
	    private string portField;
	    
	    private string accepterThreadsField;
	    
	    private string minThreadPoolField;
	    
	    private string maxThreadPoolField;
	    
	    private string requestBacklogField;
	    
	    private string requestTimeoutField;
	    
	    private string requestBuffersizeField;
	    
	    private string keepAliveField;
	    
	    private string vendorInfoField;
	    
	    private string enableSecurityField;
	    
	    private string minAccLevelField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Transport {
	        get {
	            return this.transportField;
	        }
	        set {
	            this.transportField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Port {
	        get {
	            return this.portField;
	        }
	        set {
	            this.portField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string AccepterThreads {
	        get {
	            return this.accepterThreadsField;
	        }
	        set {
	            this.accepterThreadsField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MinThreadPool {
	        get {
	            return this.minThreadPoolField;
	        }
	        set {
	            this.minThreadPoolField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxThreadPool {
	        get {
	            return this.maxThreadPoolField;
	        }
	        set {
	            this.maxThreadPoolField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RequestBacklog {
	        get {
	            return this.requestBacklogField;
	        }
	        set {
	            this.requestBacklogField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RequestTimeout {
	        get {
	            return this.requestTimeoutField;
	        }
	        set {
	            this.requestTimeoutField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RequestBuffersize {
	        get {
	            return this.requestBuffersizeField;
	        }
	        set {
	            this.requestBuffersizeField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string KeepAlive {
	        get {
	            return this.keepAliveField;
	        }
	        set {
	            this.keepAliveField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string VendorInfo {
	        get {
	            return this.vendorInfoField;
	        }
	        set {
	            this.vendorInfoField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string EnableSecurity {
	        get {
	            return this.enableSecurityField;
	        }
	        set {
	            this.enableSecurityField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MinAccLevel {
	        get {
	            return this.minAccLevelField;
	        }
	        set {
	            this.minAccLevelField = value;
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
	public  class RealTimeDBEnableNTSecurityOPCServerTag : INotifyPropertyChanged {
	    
	    private string oPCServerMinImpersonationLevelField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string OPCServerMinImpersonationLevel {
	        get {
	            return this.oPCServerMinImpersonationLevelField;
	        }
	        set {
	            this.oPCServerMinImpersonationLevelField = value;
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
	public  class RealTimeDBSzTraceDBSettings : INotifyPropertyChanged {
	    
	    private string recycleDBConnectionField;
	    
	    private string sendAdministrativeAlertField;
	    
	    private string maxErrorField;
	    
	    private string maxNumberTransField;
	    
	    private string dsnField;
	    
	    private string userField;
	    
	    private string timeColField;
	    
	    private string mSecColField;
	    
	    private string localTimeColField;
	    
	    private string userColField;
	    
	    private string changerColField;
	    
	    private string valueBeforeColField;
	    
	    private string valueAfterColField;
	    
	    private string valueColField;
	    
	    private string qualityColField;
	    
	    private string timeStampColField;
	    
	    private string varNameColField;
	    
	    private string varGroupNameColField;
	    
	    private string varDescriptionColField;
	    
	    private string maxCacheBeforeFlushField;
	    
	    private string defVarCharPrecisionField;
	    
	    private string useInMemoryDBField;
	    
	    private string iMDBSharedTableField;
	    
	    private string iMDBSaveColumnNameField;
	    
	    private string iMDBExportXMLTableField;
	    
	    private string iMDBExportCSVTableField;
	    
	    private string iMDBCryptFileField;
	    
	    private string secWriteBehindDelayField;
	    
	    private string maxRecordsNumberField;
	    
	    private string cIMDBDelimiterField;
	    
	    private string cIMDBEndOfLineField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RecycleDBConnection {
	        get {
	            return this.recycleDBConnectionField;
	        }
	        set {
	            this.recycleDBConnectionField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string SendAdministrativeAlert {
	        get {
	            return this.sendAdministrativeAlertField;
	        }
	        set {
	            this.sendAdministrativeAlertField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxError {
	        get {
	            return this.maxErrorField;
	        }
	        set {
	            this.maxErrorField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxNumberTrans {
	        get {
	            return this.maxNumberTransField;
	        }
	        set {
	            this.maxNumberTransField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Dsn {
	        get {
	            return this.dsnField;
	        }
	        set {
	            this.dsnField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string User {
	        get {
	            return this.userField;
	        }
	        set {
	            this.userField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string TimeCol {
	        get {
	            return this.timeColField;
	        }
	        set {
	            this.timeColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MSecCol {
	        get {
	            return this.mSecColField;
	        }
	        set {
	            this.mSecColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string LocalTimeCol {
	        get {
	            return this.localTimeColField;
	        }
	        set {
	            this.localTimeColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UserCol {
	        get {
	            return this.userColField;
	        }
	        set {
	            this.userColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string ChangerCol {
	        get {
	            return this.changerColField;
	        }
	        set {
	            this.changerColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string ValueBeforeCol {
	        get {
	            return this.valueBeforeColField;
	        }
	        set {
	            this.valueBeforeColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string ValueAfterCol {
	        get {
	            return this.valueAfterColField;
	        }
	        set {
	            this.valueAfterColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string ValueCol {
	        get {
	            return this.valueColField;
	        }
	        set {
	            this.valueColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string QualityCol {
	        get {
	            return this.qualityColField;
	        }
	        set {
	            this.qualityColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string TimeStampCol {
	        get {
	            return this.timeStampColField;
	        }
	        set {
	            this.timeStampColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string VarNameCol {
	        get {
	            return this.varNameColField;
	        }
	        set {
	            this.varNameColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string VarGroupNameCol {
	        get {
	            return this.varGroupNameColField;
	        }
	        set {
	            this.varGroupNameColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string VarDescriptionCol {
	        get {
	            return this.varDescriptionColField;
	        }
	        set {
	            this.varDescriptionColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxCacheBeforeFlush {
	        get {
	            return this.maxCacheBeforeFlushField;
	        }
	        set {
	            this.maxCacheBeforeFlushField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string DefVarCharPrecision {
	        get {
	            return this.defVarCharPrecisionField;
	        }
	        set {
	            this.defVarCharPrecisionField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string UseInMemoryDB {
	        get {
	            return this.useInMemoryDBField;
	        }
	        set {
	            this.useInMemoryDBField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string IMDBSharedTable {
	        get {
	            return this.iMDBSharedTableField;
	        }
	        set {
	            this.iMDBSharedTableField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string IMDBSaveColumnName {
	        get {
	            return this.iMDBSaveColumnNameField;
	        }
	        set {
	            this.iMDBSaveColumnNameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string IMDBExportXMLTable {
	        get {
	            return this.iMDBExportXMLTableField;
	        }
	        set {
	            this.iMDBExportXMLTableField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string IMDBExportCSVTable {
	        get {
	            return this.iMDBExportCSVTableField;
	        }
	        set {
	            this.iMDBExportCSVTableField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string IMDBCryptFile {
	        get {
	            return this.iMDBCryptFileField;
	        }
	        set {
	            this.iMDBCryptFileField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string SecWriteBehindDelay {
	        get {
	            return this.secWriteBehindDelayField;
	        }
	        set {
	            this.secWriteBehindDelayField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxRecordsNumber {
	        get {
	            return this.maxRecordsNumberField;
	        }
	        set {
	            this.maxRecordsNumberField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string cIMDBDelimiter {
	        get {
	            return this.cIMDBDelimiterField;
	        }
	        set {
	            this.cIMDBDelimiterField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string cIMDBEndOfLine {
	        get {
	            return this.cIMDBEndOfLineField;
	        }
	        set {
	            this.cIMDBEndOfLineField = value;
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
	public  class RealTimeDBRealTimeODBCSettings : INotifyPropertyChanged {
	    
	    private string recycleDBConnectionField;
	    
	    private string sendAdministrativeAlertField;
	    
	    private string maxErrorField;
	    
	    private string maxNumberTransField;
	    
	    private string dsnField;
	    
	    private string userField;
	    
	    private string defVarCharPrecisionField;
	    
	    private string tableNameField;
	    
	    private string nameColField;
	    
	    private string valueColField;
	    
	    private string minValueColField;
	    
	    private string maxValueColField;
	    
	    private string aveValueColField;
	    
	    private string totalTimeColField;
	    
	    private string lastTimeOnColField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string RecycleDBConnection {
	        get {
	            return this.recycleDBConnectionField;
	        }
	        set {
	            this.recycleDBConnectionField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string SendAdministrativeAlert {
	        get {
	            return this.sendAdministrativeAlertField;
	        }
	        set {
	            this.sendAdministrativeAlertField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxError {
	        get {
	            return this.maxErrorField;
	        }
	        set {
	            this.maxErrorField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxNumberTrans {
	        get {
	            return this.maxNumberTransField;
	        }
	        set {
	            this.maxNumberTransField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Dsn {
	        get {
	            return this.dsnField;
	        }
	        set {
	            this.dsnField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string User {
	        get {
	            return this.userField;
	        }
	        set {
	            this.userField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string DefVarCharPrecision {
	        get {
	            return this.defVarCharPrecisionField;
	        }
	        set {
	            this.defVarCharPrecisionField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string TableName {
	        get {
	            return this.tableNameField;
	        }
	        set {
	            this.tableNameField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string NameCol {
	        get {
	            return this.nameColField;
	        }
	        set {
	            this.nameColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string ValueCol {
	        get {
	            return this.valueColField;
	        }
	        set {
	            this.valueColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MinValueCol {
	        get {
	            return this.minValueColField;
	        }
	        set {
	            this.minValueColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string MaxValueCol {
	        get {
	            return this.maxValueColField;
	        }
	        set {
	    		if(this.maxValueColField != value){
	    			this.maxValueColField = value;
	    			RaisePropertyChanged("MaxValueCol");
	    		}
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string AveValueCol {
	        get {
	            return this.aveValueColField;
	        }
	        set {
	            this.aveValueColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string TotalTimeCol {
	        get {
	            return this.totalTimeColField;
	        }
	        set {
	            this.totalTimeColField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string LastTimeOnCol {
	        get {
	            return this.lastTimeOnColField;
	        }
	        set {
	            this.lastTimeOnColField = value;
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
	public  class RealTimeDBVariableListVariable : INotifyPropertyChanged
	{
	    
	    private string enableOPCServerField;
	    
	    private string enableNetworkClientField;
	    
	    private string enableMapRealTimeToDBField;
	    
	    private RealTimeDBVariableListVariableName nameField;
	    
	    private RealTimeDBVariableListVariableEnableTrace enableTraceField;
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("EnableOPCServer",Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public string EnableOPCServer {
	        get {
	            return this.enableOPCServerField ?? "0";
	        }
	        set {
	    		
	             if(this.enableOPCServerField != value){
	    			
	    			enableOPCServerField= value;
	    			RaisePropertyChanged("EnableOPCServer");
	    			
	    		}
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("EnableNetworkClient",Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public string EnableNetworkClient {
	        get {
	            return this.enableNetworkClientField ?? "0";
	        }
	        set {
	            this.enableNetworkClientField = value ?? "0";
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("EnableMapRealTimeToDB",Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
	    public string EnableMapRealTimeToDB {
	        get {
	            return this.enableMapRealTimeToDBField ?? "0";
	        }
	        set {
	            this.enableMapRealTimeToDBField = value ?? "0";
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElement("Name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
	    public RealTimeDBVariableListVariableName Name {
	        get {
	            return this.nameField;
	        }
	        set {
	    		if(this.nameField != value){
	    			
	    			nameField= value;
	    			//Name.PropertyChanged += (s, e) => RaisePropertyChanged("Name");
	    			RaisePropertyChanged("Name");
	    			
	    		}
	        }
	    }
	    
	    /// <remarks/>
	    [System.Xml.Serialization.XmlElementAttribute("EnableTrace", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
	    public RealTimeDBVariableListVariableEnableTrace EnableTrace {
	        get {
	            return this.enableTraceField;
	        }
	        set {
	            this.enableTraceField = value;
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
	public class RealTimeDBVariableListVariableName : INotifyPropertyChanged 
	
	{
	    
	    private string typeField;
	    
	    private string structTypeField;
	    
	    private string areaTypeField;
	    
	    private string addressField;
	    
	    private string bitField;
	    
	    private string descriptionField;
	    
	    private string groupField;
	    
	    private string sharedField;
	    
	    private string retentiveField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Type {
	        get {
	            return this.typeField;
	        }
	        set {
	            this.typeField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string StructType {
	        get {
	            return this.structTypeField;
	        }
	        set {
	    		if(this.structTypeField != value){
	    			
	    			this.structTypeField = value;
	    			RaisePropertyChanged("StructType");
	    		}
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string AreaType {
	        get {
	            return this.areaTypeField;
	        }
	        set {
	            this.areaTypeField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Address {
	        get {
	            return this.addressField;
	        }
	        set {
	            this.addressField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Bit {
	        get {
	            return this.bitField;
	        }
	        set {
	            this.bitField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Description {
	        get {
	            return this.descriptionField;
	        }
	        set {
	    		if(this.descriptionField != value){
	    			
	    			this.descriptionField = value;
	    			RaisePropertyChanged("Description");
	    			
	    		}
	        }
	    }
	    
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Group {
	        get {
	            return this.groupField;
	        }
	        set {
	    		if(this.groupField != value){
	    			
	    			this.groupField = value;
	    			RaisePropertyChanged("Group");
	    			
	    		}
	    
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Shared {
	        get {
	            return this.sharedField;
	        }
	        set {
	            this.sharedField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string Retentive {
	        get {
	            return this.retentiveField;
	        }
	        set {
	            this.retentiveField = value;
	        }
	    }
	    
	    /// <remarks/>
	    [XmlText()]
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
	public class RealTimeDBVariableListVariableEnableTrace
	
	{
	    
	    private string durationDaysField;
	    
	    private string valueField;
	    
	    /// <remarks/>
	    [XmlAttribute()]
	    public string DurationDays {
	        get {
	            return this.durationDaysField ?? "730";
	        }
	        set {
	            this.durationDaysField = value ?? "730";
	        }
	    }
	    
	    /// <remarks/>
	    [XmlText()]
	    public string Value {
	        get {
	            return this.valueField ?? "0";
	        }
	        set {
	            this.valueField = value ?? "0";
	        }
	    }
	}
	
	[XmlType()]
	public  class RealTimeDBDriverListVariable : INotifyPropertyChanged
	{
		
		private RealTimeDBDriverListVariableName nameField;
		
		[XmlElement("Name")]
		public RealTimeDBDriverListVariableName Name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
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
	public  class RealTimeDBDriverListVariableName : INotifyPropertyChanged
	{
		
		private string fileNameField;
		
		private string valueField;
		
		[XmlAttribute()]
		public string FileName {
			get {
				return this.fileNameField;
			}
			set {
				this.fileNameField = value;
			}
		}
		
		[XmlText()]
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
	
	[XmlType()]
	public  class RealTimeDBStructureListVariable  : INotifyPropertyChanged  {
		
		private RealTimeDBStructureListVariableName nameField;
		
		private List<RealTimeDBStructureListVariableMemberList> memberListField;
		
		[XmlElement("Name")]
	    public RealTimeDBStructureListVariableName Name {
	        get {
	            return this.nameField;
	        }
	        set {
	            if(this.nameField != value){
	    			
	    			this.nameField = value;
	    			RaisePropertyChanged("Name");
	    			
	    		}
	        }
	    }
		
		[XmlArray("MemberList")]
		[XmlArrayItem("Member")]
		public List<RealTimeDBStructureListVariableMemberList> MemberList {
		        get {
		            return this.memberListField;
		        }
		        set {
					if(this.memberListField != value){
	    			
		    			this.memberListField = value;
		    			RaisePropertyChanged("MemberList");
	    			
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
	
	[XmlType()]
	public  class RealTimeDBStructureListVariableName  : INotifyPropertyChanged {
		
		private string descriptionField;
		private string valueField;
		
		[XmlAttribute()]
	    public string Description {
	        get {
	            return this.descriptionField;
	        }
	        set {
				if(this.descriptionField != value){
    			
	    			this.descriptionField = value;
	    			RaisePropertyChanged("Description");
    			
    			}
	        }
	    }
		
		[XmlText()]
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
		
	
	[XmlType()]	
	public  class RealTimeDBStructureListVariableMemberList  : INotifyPropertyChanged {
		
		private RealTimeDBStructureListVariableMemberListName nameField;
		
		[System.Xml.Serialization.XmlElement("Name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
	    public RealTimeDBStructureListVariableMemberListName Name {
	        get {
	            return this.nameField;
	        }
	        set {
	            if(this.nameField != value){
    			
	    			this.nameField = value;
	    			RaisePropertyChanged("Name");
    			
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
	
	
	[XmlType()]
	public  class RealTimeDBStructureListVariableMemberListName  : INotifyPropertyChanged {
		
		private string typeField;
		private string valueField;
		
		
		[XmlAttribute()]
	    public string Type {
	        get {
								
				switch (this.typeField) {
						
				case "bool":
						
						this.typeField = "0";	
						break;
						
					case "sbyte":
						
						this.typeField = "1";	
						break;
						
					case "byte":
						
						this.typeField = "2";	
						break;
						
					case "sword":
						
						this.typeField = "3";	
						break;
						
					case "word":
						
						this.typeField = "4";	
						break;
						
					case "sdWord":
						
						this.typeField = "5";	
						break;
						
					case "dword":
						
						this.typeField = "6";	
						break;
						
					case "float":
						
						this.typeField = "7";	
						break;
						
					case "double":
						
						this.typeField = "8";	
						break;
						
					case "string":
						
						this.typeField = "9";	
						break;					
												
				}
				
				return this.typeField;
				
			}
			
	        set {
				
	            if(this.typeField != value){
    			
	    			this.typeField = value;
				
					switch(value){
						
						case "bool":
							
							this.typeField = "0";	
							break;
							
						case "sbyte":
							
							this.typeField = "1";	
							break;
							
						case "byte":
							
							this.typeField = "2";	
							break;
							
						case "sword":
							
							this.typeField = "3";	
							break;
							
						case "word":
							
							this.typeField = "4";	
							break;
							
						case "sdWord":
							
							this.typeField = "5";	
							break;
							
						case "dword":
							
							this.typeField = "6";	
							break;
							
						case "float":
							
							this.typeField = "7";	
							break;
							
						case "double":
							
							this.typeField = "8";	
							break;
							
						case "string":
							
							this.typeField = "9";	
							break;
							
						case "0":
							
							this.typeField = "bool";
							break;						
													
						case "1":
							
							this.typeField = "sbyte";		
							break;
													
						case "2":
							
							this.typeField = "byte";
							break;							
													
						case "3":
							
							this.typeField = "sword";
							break;						
													
						case "4":
							
							this.typeField = "word";
							break;						
													
						case "5":
							
							this.typeField = "sdword";	
							break;
													
						case "6":
							
							this.typeField = "dword";	
							break;
													
						case "7":
							
							this.typeField = "float";	
							break;
													
						case "8":
							
							this.typeField = "double";	
							break;
													
						case "9":
							
							this.typeField = "string";	
							break;	
					}
	    			
	    			RaisePropertyChanged("Name");
    			
    			}
				
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
			
	
//#####################################################
//#
//# Function that returns a list<string> that contains all  
//# the variables that are in Visu+ and are not in Excel
//#
//# Remarks: The variables that are returned are filtered by 
//# their Struct Type with GetVariablesFromVisu()
//#
//#####################################################
		
 
		
		public List<string> GetUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  CellInfo>>  Dict, string StructureType)
		{


			List<string> list = (from vrb in xmlVariable.VariableList
								where Dict.Keys.Any(p => p.Name.Equals(vrb.Name.Value)) == false && vrb.Name.StructType == StructureType
								select vrb.Name.Value).ToList();	
								
  			return list;  
				
		}
		
		public List<string> GetUnusedItemsFromVisu(List<string> Items, string StructureType)	
		{
			
			List<string> list = (from vrb in xmlVariable.VariableList
			                            where Items.Any(p => p.Equals(vrb.Name.Value)) == false && vrb.Name.StructType == StructureType
			                            select vrb.Name.Value).ToList();
			
			return list;
			
			
		}
		
		public List<string> DataToBeAdded(List<Excel.Range> Items)
		{
			
			List<string> list = (from vrb in Items
			                     where !xmlVariable.VariableList.Any(p => p.Name.Value.Equals(vrb.Value2)) 
			                     select Convert.ToString(vrb.Value2)).ToList();
			
			return list;
			
		}
		
		public void TestSomething(List<string> Items, string StructName)
		{
			
			var ItemsList = SelectItemsBasedOnStructName(StructName);
			
			
			
			for (int i = 0; i < Items.Count; i++) {
				
				if (!ItemsList.Contains(Items[i])) {
					
				    	Debug.WriteLine("0" + "     " + Items[i]);
				    	 	
				}
					
				
			}
			
			for (int i = 0; i < ItemsList.Count; i++) {
				
				if(!Items.Contains(ItemsList[i])){
				   	
				   	Debug.WriteLine("1" + "     " + ItemsList[i]);
				   	
				   }
				
				
			}
			
			
		}
		
		public List<string> SelectItemsBasedOnStructName(string StructName)
		{
			
			List<string> list = (from vrb in xmlVariable.VariableList
	                            where vrb.Name.StructType == StructName
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

		public List<string> RemoveUnusedItems(Dictionary<Row, Dictionary<string,  CellInfo>> Dict, string StructureType)
		{
			
			var list = GetUnusedItemsFromVisu(Dict,StructureType);
	        
	        if (list.Count != 0){
	        
	        	foreach ( string element in list) {
	        	
	        	xmlVariable.VariableList.Remove(GetVariableFromList(element));
	        		
	        	}
	        	
	        }
			
			return list;
		
		}
		
		public IEnumerable<string> RemoveUnusedItems(List<string> Items, string StructureType)
		{
			if (Items == null) return null;
			
			var list = GetUnusedItemsFromVisu(Items,StructureType);
	        
			if (list.Count() != 0){
	        
	        	foreach ( string element in list) {
	        	
	        		xmlVariable.VariableList.Remove(GetVariableFromList(element));

	        	}
	        	
	        }
			
			return list;
			
		}
	
//#####################################################
//#
//# Function that loads the file that contains the variables
//#
//#####################################################			
		
		public void Load(string Path)
		{
			this.Path = Path;
			
			RealTimeDB data = new RealTimeDB();	
			var textReader = new StreamReader(Path);
			var deserializer = new XmlSerializer(typeof(RealTimeDB));
			xmlVariable = (RealTimeDB)deserializer.Deserialize(textReader);
			RealTimeDB xmlData = (RealTimeDB)xmlVariable;
			textReader.Close();
			
		}
		
//#####################################################
//#
//# Function that add a variable element in tree
//#
//#####################################################			
		
		
		public bool AddVariable(string TagName = "", string StructType = "", string Description = "", string Area = "")
		{
					
			xmlVariable.VariableList.Add(
				new RealTimeDBVariableListVariable{Name = new RealTimeDBVariableListVariableName{
									      		   Value = TagName, StructType = StructType, Type = "11", AreaType = "0", Address = "0",
									      		   Bit = "0", Description = Description, Group = Area + "." + StructType, Shared = "0",
									      		   Retentive = "1"},
									      		   EnableTrace = new RealTimeDBVariableListVariableEnableTrace{}});
			return true;
		}
		
		
		public void AddDriver(string DriverName)
		{
			
			if (DriverName != "ModbusTCPIP" && DriverName != "S7TCP") return;
			
			if(GetDriver(DriverName) == null){
			
				xmlVariable.DriverList.Add(new RealTimeDBDriverListVariable{
				                           	Name = new RealTimeDBDriverListVariableName{
				                           		FileName = DriverName.Replace(" ",string.Empty) + ".dll",
							                    Value = DriverName
				                           	}});
			}
						
		}
		
		public RealTimeDBStructureListVariable GetStructurePrototypeFromList(string StructureName)
		{
			
			return xmlVariable.StructureList.Find(p => p.Name.Value == StructureName);
			
		}
		
		public RealTimeDBStructureListVariableMemberList GetStructurePrototypeMemberFromList(RealTimeDBStructureListVariable StructurePrototype, string StructurePrototypeMemberName)
		{
			
			return StructurePrototype.MemberList.Find(p => p.Name.Value == StructurePrototypeMemberName);
			
		}
					
		public List<string> GetDriversList()
		{
			
			return xmlVariable.DriverList.Select(p =>p.Name.Value.Replace(" ", "")).ToList();
			
		}
		
		public List<string> GetStructurePrototypeNameList(string StructureName){
			
						
			return xmlVariable.StructureList.FirstOrDefault(p => p.Name.Value == StructureName).MemberList.Select(x => x.Name.Value).ToList();
			
		}
		
		public List<string> GetStructurePrototypeTypeList(string StructureName){
			
						
			return xmlVariable.StructureList.FirstOrDefault(p => p.Name.Value == StructureName).MemberList.Select(x => x.Name.Type).ToList();
			
		}
		
		public RealTimeDBVariableListVariable GetVariableFromList (string Variable)
		{
				
			return xmlVariable.VariableList.FirstOrDefault(p => p.Name.Value == Variable);
			
		}
		
		private RealTimeDBDriverListVariable GetDriver(string DriverName)
		{
			
			return xmlVariable.DriverList.FirstOrDefault(p => p.Name.Value == DriverName);
			
		}
		
		
		public void Serialize()
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(RealTimeDB)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	
	    	ns.Add("","");
	    	
	    	using (StreamWriter writer = new StreamWriter(Path, false,Encoding.Unicode))
	    	{
	        	serializer.Serialize(writer, xmlVariable, ns); 
	    	} 
		}		
						
	}
}
