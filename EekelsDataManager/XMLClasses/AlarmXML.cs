/*
 * Created by SharpDevelop.
 * User: ciprian
 * Date: 3/23/2014
 * Time: 4:08 PM
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
using NetOffice;
using Excel = NetOffice.ExcelApi;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;

namespace EekelsDataManager
{
/// <remarks/>

public class AlarmXML
{
	
private string _Path;

public string Path{
	get { return this._Path;}
	set { this._Path = value;}
}

private Alarms _alarms;

public Alarms xmlAlarms {
	get {return _alarms;}
	set {_alarms = value;}
}

/// <remarks/>
[XmlRoot()]
public partial class Alarms : INotifyPropertyChanged
{
    
	private ObservableCollection<AlarmsAlarmListAlarm> alarmListField;
    
    /// <remarks/>
    [XmlArray("AlarmList")]
    [XmlArrayItem("Alarm")]
    public ObservableCollection<AlarmsAlarmListAlarm> AlarmList {
        get {
            return this.alarmListField;
        }
        set {
            this.alarmListField = value;
            RaisePropertyChanged("AlarmList");
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
public partial class AlarmsAlarmListAlarm : INotifyPropertyChanged
{
    
    private Name nameField;
    
   	private ObservableCollection<AlarmsAlarmListAlarmThresholdListThreshold> thresholdListField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Name", IsNullable=true)]
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
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Threshold", typeof(AlarmsAlarmListAlarmThresholdListThreshold), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public ObservableCollection<AlarmsAlarmListAlarmThresholdListThreshold> ThresholdList {
        get {
            return this.thresholdListField;
        }
        set {
            this.thresholdListField = value;
            RaisePropertyChanged("ThresholdList");
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
public partial class Name : INotifyPropertyChanged {
    
    private string deviceField;
    
    private string variableField;
    
    private string areaField;
    
    private string thresholdExclusiveField;
    
    private string enabledField;
    
    private string onQualityGoodField;
    
    private string variableDurationField;
    
    private string enableVariableField;
    
    private string enableDispMsgField;
    
    private string hysteresisField;
    
    private string titleField;
    
    private string helpField;
    
    private string durationFormatField;
    
    private string readAccessLevelField;
    
    private string writeAccessLevelField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Device {
        get {
            return this.deviceField;
        }
        set {
            this.deviceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Variable {
        get {
            return this.variableField;
        }
        set {
            this.variableField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Area {
        get {
            return this.areaField;
        }
        set {
    		if(this.areaField != value){
    			
    			this.areaField = value;
    			RaisePropertyChanged("Area");
    			
    		}
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ThresholdExclusive {
        get {
            return this.thresholdExclusiveField;
        }
        set {
            this.thresholdExclusiveField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string OnQualityGood {
        get {
            return this.onQualityGoodField;
        }
        set {
            this.onQualityGoodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VariableDuration {
        get {
            return this.variableDurationField;
        }
        set {
            this.variableDurationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EnableVariable {
        get {
            return this.enableVariableField;
        }
        set {
    		if(this.enableVariableField != value){
    			
    			this.enableVariableField = value;
    			RaisePropertyChanged("EnableVariable");
    			
    		}
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EnableDispMsg {
        get {
            return this.enableDispMsgField;
        }
        set {
            this.enableDispMsgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Hysteresis {
        get {
            return this.hysteresisField;
        }
        set {
            this.hysteresisField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Title {
        get {
            return this.titleField;
        }
        set {
    		if(this.titleField != value){
    			
    			this.titleField = value;
    			RaisePropertyChanged("Title");
    			
    		}
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Help {
        get {
            return this.helpField;
        }
        set {
            this.helpField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DurationFormat {
        get {
            return this.durationFormatField;
        }
        set {
            this.durationFormatField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ReadAccessLevel {
        get {
            return this.readAccessLevelField;
        }
        set {
            this.readAccessLevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string WriteAccessLevel {
        get {
            return this.writeAccessLevelField;
        }
        set {
            this.writeAccessLevelField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThreshold : INotifyPropertyChanged {
    
    private string commandsField;
    
    private string commandsAckField;
    
    private string commandsResetField;
    
    private string commandsOffField;
    
    private Name nameField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdExecution executionField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdCommandsOn commandsOnField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdStyle styleField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdRecipient recipientField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendEmail sendEmailField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendVoice sendVoiceField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendSMS sendSMSField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendFax sendFaxField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendAdminAlert sendAdminAlertField;
    
    private AlarmsAlarmListAlarmThresholdListThresholdSendMessenger sendMessengerField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Commands {
        get {
            return this.commandsField;
        }
        set {
            this.commandsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CommandsAck {
        get {
            return this.commandsAckField;
        }
        set {
            this.commandsAckField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CommandsReset {
        get {
            return this.commandsResetField;
        }
        set {
            this.commandsResetField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string CommandsOff {
        get {
            return this.commandsOffField;
        }
        set {
            this.commandsOffField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Name", IsNullable=true)]
    public Name Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Execution", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdExecution Execution {
        get {
            return this.executionField;
        }
        set {
            this.executionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("CommandsOn", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdCommandsOn CommandsOn {
        get {
            return this.commandsOnField;
        }
        set {
            this.commandsOnField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Style", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdStyle Style {
        get {
            return this.styleField;
        }
        set {
            this.styleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Recipient", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdRecipient Recipient {
        get {
            return this.recipientField;
        }
        set {
            this.recipientField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendEmail", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendEmail SendEmail {
        get {
            return this.sendEmailField;
        }
        set {
            this.sendEmailField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendVoice", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendVoice SendVoice {
        get {
            return this.sendVoiceField;
        }
        set {
            this.sendVoiceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendSMS", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendSMS SendSMS {
        get {
            return this.sendSMSField;
        }
        set {
            this.sendSMSField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendFax", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendFax SendFax {
        get {
            return this.sendFaxField;
        }
        set {
            this.sendFaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendAdminAlert", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendAdminAlert SendAdminAlert {
        get {
            return this.sendAdminAlertField;
        }
        set {
            this.sendAdminAlertField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("SendMessenger", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AlarmsAlarmListAlarmThresholdListThresholdSendMessenger SendMessenger {
        get {
            return this.sendMessengerField;
        }
        set {
            this.sendMessengerField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdExecution : INotifyPropertyChanged
{
    
    private string conditionField;
    
    private string thresholdField;
    
    private string thresholdVarField;
    
    private string thresholdLowField;
    
    private string thresholdVarLowField;
    
    private string variableStatusField;
    
    private string severityField;
    
    private string severityVarField;
    
    private string secDelayField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Condition {
        get {
            return this.conditionField;
        }
        set {
            this.conditionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Threshold {
        get {
            return this.thresholdField;
        }
        set {
    		if(this.thresholdField != value){
	    		if(value == "True"){
	    		   this.thresholdField = "1";
	    		}
	    		
	    		else if(value == "False"){
	    			this.thresholdField = "0";
	    		}
	    		else{	
	            this.thresholdField = value;
	    		}
    			RaisePropertyChanged("Threshold");
    		}
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ThresholdVar {
        get {
            return this.thresholdVarField;
        }
        set {
            this.thresholdVarField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ThresholdLow {
        get {
            return this.thresholdLowField;
        }
        set {
            this.thresholdLowField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string ThresholdVarLow {
        get {
            return this.thresholdVarLowField;
        }
        set {
            this.thresholdVarLowField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VariableStatus {
        get {
            return this.variableStatusField;
        }
        set {
            this.variableStatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Severity {
        get {
            return this.severityField;
        }
        set {
            this.severityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SeverityVar {
        get {
            return this.severityVarField;
        }
        set {
            this.severityVarField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SecDelay {
        get {
            return this.secDelayField;
        }
        set {
    		    		    			
    		if (value == "") {
    				
    				value = "0";
    				
    		}
    			
    		if(this.secDelayField != value){

    			this.secDelayField = value;
    			RaisePropertyChanged("SecDelay");
    			    			
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdCommandsOn : INotifyPropertyChanged {
    
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdStyle : INotifyPropertyChanged
{
    
    private string backColorField;
    
    private string textColorField;
    
    private string blinkBackColorField;
    
    private string blinkTextColorField;
    
    private string printField;
    
    private string logField;
    
    private string blinkOnNewAlarmField;
    
    private string varTimeStampField;
    
    private string supportAckField;
    
    private string supportResetField;
    
    private string supportResetConditionOnField;
    
    private string bmpFileField;
    
    private string sndFileField;
    
    private string beepEnabledField;
    
    private string speechEnabledField;
    
    private string repeatSpeechEverySecField;
    
    private string enableSpeechVariableField;
    
    private string playsoundContinuoslyField;
    
    private string commentOnAckField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BackColor {
        get {
            return this.backColorField;
        }
        set {
            this.backColorField = value ?? "4294967295";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string TextColor {
        get {
            return this.textColorField;
        }
        set {
            this.textColorField = value ?? "4294967295";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BlinkBackColor {
        get {
            return this.blinkBackColorField;
        }
        set {
            this.blinkBackColorField = value ?? "4294967295";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BlinkTextColor {
        get {
            return this.blinkTextColorField;
        }
        set {
            this.blinkTextColorField = value ?? "4294967295";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Print {
        get {
            return this.printField;
        }
        set {
            this.printField = value ?? "1";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Log {
        get {
            return this.logField;
        }
        set {
            this.logField = value ?? "1";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BlinkOnNewAlarm {
        get {
            return this.blinkOnNewAlarmField;
        }
        set {
            this.blinkOnNewAlarmField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string VarTimeStamp {
        get {
            return this.varTimeStampField;
        }
        set {
            this.varTimeStampField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SupportAck {
        get {
            return this.supportAckField;
        }
        set {
            this.supportAckField = value ?? "1";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SupportReset {
        get {
            return this.supportResetField;
        }
        set {
            this.supportResetField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SupportResetConditionOn {
        get {
            return this.supportResetConditionOnField;
        }
        set {
            this.supportResetConditionOnField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BmpFile {
        get {
            return this.bmpFileField;
        }
        set {
            this.bmpFileField = value ?? "";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SndFile {
        get {
            return this.sndFileField;
        }
        set {
            this.sndFileField = value ?? "";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string BeepEnabled {
        get {
            return this.beepEnabledField;
        }
        set {
            this.beepEnabledField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SpeechEnabled {
        get {
            return this.speechEnabledField;
        }
        set {
            this.speechEnabledField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RepeatSpeechEverySec {
        get {
            return this.repeatSpeechEverySecField;
        }
        set {
            this.repeatSpeechEverySecField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string EnableSpeechVariable {
        get {
            return this.enableSpeechVariableField;
        }
        set {
            this.enableSpeechVariableField = value ?? "1";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string PlaysoundContinuosly {
        get {
            return this.playsoundContinuoslyField;
        }
        set {
            this.playsoundContinuoslyField = value ?? "0";
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CommentOnAck {
        get {
            return this.commentOnAckField;
        }
        set {
            this.commentOnAckField = value ?? "0";
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdRecipient : INotifyPropertyChanged {
    
    private string attachmentField;
    
    private string dispatchingTextField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string Attachment {
        get {
            return this.attachmentField;
        }
        set {
            this.attachmentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string DispatchingText {
        get {
            return this.dispatchingTextField;
        }
        set {
            this.dispatchingTextField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendEmail : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendVoice : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendSMS : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendFax : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendAdminAlert : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
public partial class AlarmsAlarmListAlarmThresholdListThresholdSendMessenger : INotifyPropertyChanged
{
    
    private string sendONField;
    
    private string sendACKField;
    
    private string sendRESETField;
    
    private string sendOFFField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendON {
        get {
            return this.sendONField;
        }
        set {
            this.sendONField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendACK {
        get {
            return this.sendACKField;
        }
        set {
            this.sendACKField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendRESET {
        get {
            return this.sendRESETField;
        }
        set {
            this.sendRESETField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string SendOFF {
        get {
            return this.sendOFFField;
        }
        set {
            this.sendOFFField = value;
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
		
		public List<string> GetUnusedItemsFromVisu(Dictionary<Row, Dictionary<string,  CellInfo>> Dict, string StructType)
		{
			
			
			List<string> list = (from vrb in xmlAlarms.AlarmList
			                     where Dict.Keys.Any(p => p.Name.Contains(vrb.Name.Value)) == false && vrb.Name.Area.Split('.')[1] == StructType
								select vrb.Name.Value).ToList();	
								
  			return list; 
  			
		}
		
		public List<string> GetUnusedItemsFromVisu(List<string> Items, string StructType)	
		{
			
			List<string> list = new List<string>();
			
			list = (from vrb in xmlAlarms.AlarmList
			                            where Items.Any(p => p.Equals(vrb.Name.Value)) == false
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

		public List<string> RemoveUnusedItems(Dictionary<Row, Dictionary<string,  CellInfo>> Dict, string StructType)
		{
			
			var list = GetUnusedItemsFromVisu(Dict, StructType);
	        
	        if (list.Count != 0){
	        
	        	foreach ( string element in list) {
	        	
					xmlAlarms.AlarmList.Remove(GetItemFromList(element));
	        		
	        	}
	        	
	        }
			
			return list;
			
		}
	
		public void RemoveUnusedItems(IEnumerable<string> Items)
		{

			if (Items == null) return ;			
			
			if (Items.Count() != 0){
	        
	        	foreach ( string element in Items) {
	        	
					xmlAlarms.AlarmList.Remove(GetItemFromList(element));
	        		
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
			Alarms AllAlarmsVisu = new Alarms();
			var textReader = new StreamReader(Path);
			var deserializer = new XmlSerializer(typeof(Alarms));
			xmlAlarms = (Alarms)deserializer.Deserialize(textReader);
			Alarms xmlData = (Alarms)AllAlarmsVisu;

			textReader.Close();
		
		}
		
//#####################################################
//#
//# Function that add a variable element in tree
//#
//#####################################################			
		
	public bool AddAlarm(string TagName, string StructType, string Area, string Description, string Delay, string Condition, string StationName)
		{
		
		if(GetItemFromList(TagName) != null) return false;
		
		string EnableVar = "";
		
		if(StationName == ""){
			
			EnableVar = " And Not CBool([" + StationName + ":StationState])"; 
			
		}
		
		xmlAlarms.AlarmList.Add(
			new AlarmsAlarmListAlarm{
	              Name = new AlarmXML.Name{
	                   Value = TagName, Device = "", Area = Area, Variable = TagName + ":IO", 
	                   ThresholdExclusive = "1", Enabled = "1", OnQualityGood = "0", VariableDuration = "",
	                   EnableVariable =  "Not [" + TagName + ":Enable]" + " And " + " Not [" + TagName + ":GroupDisable]" + EnableVar, EnableDispMsg = "", Hysteresis = "0"},
				  ThresholdList = new ObservableCollection<AlarmXML.AlarmsAlarmListAlarmThresholdListThreshold>{
				  }			  
			});
			
		var AlarmInfo = GetItemFromList(TagName);
			
		switch (StructType) {
					
			case "AIA":
					
				AddTemplateAIAThreshold(AlarmInfo, Delay, Description);
				break;
				
			case "DIA":
				
				AddTemplateDIAThreshold(AlarmInfo, Delay, Condition,Description);
				break;
		}	
			
		return true;
                      		      	
	}
	
	private AlarmsAlarmListAlarm StationAlarm(string TagName, string Area, string Description){
		
			xmlAlarms.AlarmList.Add(
				new AlarmsAlarmListAlarm{
		              Name = new AlarmXML.Name{
		                   Value = TagName, Device = "", Area = Area, Variable = TagName + ":StationState", 
		                   ThresholdExclusive = "1", Enabled = "1", OnQualityGood = "0", VariableDuration = "",
		                   EnableVariable =  "", EnableDispMsg = "", Hysteresis = "0"},
					  ThresholdList = new ObservableCollection<AlarmXML.AlarmsAlarmListAlarmThresholdListThreshold>{
					  }			  
				});
		
		return xmlAlarms.AlarmList.FirstOrDefault(p => p.Name.Value == TagName);
		
	}
	
	public void AddStationAlarm(string TagName, string Area, string Description){
		
		if(GetItemFromList(TagName) != null) return;
		
		var AlarmObject = StationAlarm(TagName, Area, Description);
		
		AddStationAlarmThreshold(AlarmObject, "0", "1", Description);
		
	}
		
	public bool AddThresholdElement(AlarmsAlarmListAlarm alarm, string ThresholdName, string Description, string Delay, 
	                                int Condition,string VarStatus = "", string Threshold = "0", string ThresholdVar = "", string ThresholdVarLow = "")
	{
		alarm.ThresholdList.Add(
			new AlarmsAlarmListAlarmThresholdListThreshold{
				Name = new AlarmXML.Name{
					Area = "",Title = Description, Help ="", DurationFormat ="",
					ReadAccessLevel = "4294901760",WriteAccessLevel = "4294901760",Value = ThresholdName,},
				Execution = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdExecution{
					Condition = Condition.ToString(), Threshold = Threshold, ThresholdVar = ThresholdVar,SecDelay = Delay,
					ThresholdLow = "0",ThresholdVarLow = ThresholdVarLow, VariableStatus = VarStatus},
				Commands = "",
				CommandsOn = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdCommandsOn{},
				CommandsAck = "",
				CommandsReset = "",
				CommandsOff = "",
				Style = new AlarmXML.AlarmsAlarmListAlarmThresholdListThresholdStyle{SupportAck = "1",SupportReset = "0", SupportResetConditionOn = "0"}				
			});
		return true;
	}

		
		public AlarmsAlarmListAlarm GetItemFromList (string Variable)
		{	
			return xmlAlarms.AlarmList.FirstOrDefault(p => p.Name.Value == Variable);	
		}
		
		public AlarmsAlarmListAlarmThresholdListThreshold GetThreshold (List<AlarmsAlarmListAlarmThresholdListThreshold> ThresholdList, string Threshold)
		{
			return	ThresholdList.Where(p => p.Name.Value == Threshold).FirstOrDefault();
		}
		
		public List<AlarmsAlarmListAlarmThresholdListThreshold> GetThresholdList (AlarmsAlarmListAlarm alarm)
		{  
			if(alarm == null) return null;
			return alarm.ThresholdList.ToList();
		}
		
		
		
		public void Serialize()
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(Alarms)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	ns.Add("","");
	    	using (TextWriter writer = new StreamWriter(Path))
	    	{
	        	serializer.Serialize(writer, xmlAlarms, ns); 
	    	} 
		}
		
		public bool AddTemplateAIAThreshold(AlarmsAlarmListAlarm alarm, string Delay, string Description)
		{
			
			bool isModified = false;
			
			
			var ThresholdList = GetThresholdList(alarm);
			
        	if(GetThreshold(ThresholdList,"High") == null){
				isModified = AddThresholdElement(alarm, "High", Description, Delay, (int)Enums.ThresholdCondition.majorEqual,
				                                 alarm.Name.Value + ":HAlarmStatus", "" , alarm.Name.Value + ":HLimit"); //+ "]*[" + alarm.Name.Value + ":Decimals]");
			}
			
			if(GetThreshold(ThresholdList,"HighHigh") == null){
				isModified = AddThresholdElement(alarm, "HighHigh", Description, Delay, (int)Enums.ThresholdCondition.majorEqual, 
				                                 alarm.Name.Value + ":HHAlarmStatus", "", alarm.Name.Value + ":HHLimit");// + "]*[" + alarm.Name.Value + ":Decimals]");
												
			}

			if(GetThreshold(ThresholdList,"Low") == null){
				isModified = AddThresholdElement(alarm, "Low", Description, Delay, (int)Enums.ThresholdCondition.minorEqual, 
				                                 alarm.Name.Value + ":LAlarmStatus", "", alarm.Name.Value + ":LLimit"); //+ "]*[" + alarm.Name.Value + ":Decimals]");
												
			}		        				
		
			if(GetThreshold(ThresholdList,"LowLow") == null){
				isModified = AddThresholdElement(alarm, "LowLow", Description, Delay, (int)Enums.ThresholdCondition.minorEqual, 
				                                 alarm.Name.Value + ":LLAlarmStatus","", alarm.Name.Value + ":LLLimit");// + "]*[" + alarm.Name.Value + ":Decimals]");
												
			}
			
			return isModified;
			
		}
		
		public bool AddTemplateDIAThreshold(AlarmsAlarmListAlarm alarm, string Delay, string Condition, string Description)
		{
			bool isModified = false;
			
			if (alarm == null) return isModified;
			
			var ThresholdList = GetThresholdList(alarm);
			
			if(GetThreshold(ThresholdList,"Digital") == null){
				isModified = AddThresholdElement(alarm, "Digital", Description, Delay, (int)Enums.ThresholdCondition.Equal, 
			                          alarm.Name.Value + ":AlarmStatus", " ", alarm.Name.Value + ":Condition" );
												
			}
			
			return isModified;
			
		}
		
		private void AddStationAlarmThreshold(AlarmsAlarmListAlarm alarm, string Delay, string Condition, string Description)
		{

			var ThresholdList = GetThresholdList(alarm);
			
			if(GetThreshold(ThresholdList,"StationFault") == null){
				AddThresholdElement(alarm, "StationFault", Description + " - StationFault", Delay, (int)Enums.ThresholdCondition.Equal, 
			                          "", "1", "");
												
			}

			
		}
		
	}
}