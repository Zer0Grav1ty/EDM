using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using NetOffice;
using System.Linq;
using System.Drawing;
using Excel = NetOffice.ExcelApi;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;

namespace EekelsDataManager
{

	
	public class EditData 
	{
		VariableXML variable = new VariableXML();
		AlarmXML alarm = new AlarmXML();
		StructureXML structure = new StructureXML();
		ScalingXML scale = new ScalingXML();
		DriverXml driver = new DriverXml();
		cReadFromExcel xlRead = new cReadFromExcel();
		Enums enums = new Enums();		

		private Dictionary<string, List<Excel.Range>> DataFromExcel;
		
		private Dictionary<string, CellInfo> RowData {get; set;}
		private Excel.Range UsedRange {get; set;}
		private Excel.Range CellInfo {get; set;}
		private string ProjectDirectory {get; set;}
		private string ProjectFileName {get; set;}
		private int RowIndex;
		
		private bool isChanged = false;		
		private string stHeader;
		List<string> Headers;
		
		public struct DynamicSettings
		{
			
			public string DriverName;
			public string StationName;
			public string TaskType;
			public string Address;				
			
		}
		
		public void SaveData(Excel.Worksheet xlSheet)
		{
			
			GetConfigFile(xlSheet.Application.ActiveWorkbook);
			
			var VariableListener = ChangeListener.Create(variable.xmlVariable);
			var AlarmListener = ChangeListener.Create(alarm.xmlAlarms);
			var StructureListener = ChangeListener.Create(structure.xmlStructure);
			var DriverListener = ChangeListener.Create(driver.DriverList);
			var ScaleListner = ChangeListener.Create(scale.xmlScaleElement);
			
			VariableListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			AlarmListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			StructureListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);	
			DriverListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			ScaleListner.PropertyChanged += new PropertyChangedEventHandler( Listener_PropertyChanged);
			
			variable.xmlVariable.VariableList.CollectionChanged += new NotifyCollectionChangedEventHandler(OnAddingNew);
			alarm.xmlAlarms.AlarmList.CollectionChanged += new NotifyCollectionChangedEventHandler(OnAddingNew);
			driver.DriverList.CollectionChanged += new NotifyCollectionChangedEventHandler(OnAddingNew);
			
			var DriverList = driver.GetDriverList();
			
			foreach (var element in DriverList) {
							
				driver.GetDriverTaskList(element).CollectionChanged += new NotifyCollectionChangedEventHandler(OnAddingNew);;
			}
			
			EditNewData(xlSheet);
			
			VariableListener.PropertyChanged -= new PropertyChangedEventHandler(Listener_PropertyChanged);
			AlarmListener.PropertyChanged -= new PropertyChangedEventHandler(Listener_PropertyChanged);
			StructureListener.PropertyChanged -= new PropertyChangedEventHandler(Listener_PropertyChanged);	
			DriverListener.PropertyChanged -= new PropertyChangedEventHandler(Listener_PropertyChanged);
			ScaleListner.PropertyChanged -= new PropertyChangedEventHandler( Listener_PropertyChanged);
			driver.DriverList.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnAddingNew);
			
			variable.xmlVariable.VariableList.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnAddingNew);
			alarm.xmlAlarms.AlarmList.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnAddingNew);
			driver.DriverList.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnAddingNew);
			
			foreach (var element in DriverList) {
							
				driver.GetDriverTaskList(element).CollectionChanged -= new NotifyCollectionChangedEventHandler(OnAddingNew);;
			}
			
			Save();
			
		}
		
		public void SaveAllData(Excel.Workbook xlWorkbook)
		{
			GetConfigFile(xlWorkbook);
			
			var VariableListener = ChangeListener.Create(variable.xmlVariable);
			var AlarmListener = ChangeListener.Create(alarm.xmlAlarms);
			var StructureListener = ChangeListener.Create(structure.xmlStructure);
			var DriverListener = ChangeListener.Create(driver.DriverList);
			var ScaleListner = ChangeListener.Create(scale.xmlScaleElement);
			VariableListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			AlarmListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			StructureListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);	
			DriverListener.PropertyChanged += new PropertyChangedEventHandler(Listener_PropertyChanged);
			ScaleListner.PropertyChanged += new PropertyChangedEventHandler( Listener_PropertyChanged);
			//driver.DriverList.CollectionChanged += new NotifyCollectionChangedEventHandler(OnAddingNew);
			
			foreach (Excel.Worksheet xlSheet in xlWorkbook.Sheets) {

	        	EditNewData(xlSheet);

    		}
			
			Save();
			
		}
		
				
		
	    private void EditNewData(Excel.Worksheet xlSheet)
	    {
	    	
	        bool ExitInnerLoop;
			UsedRange = xlRead.RealUsedRange(xlSheet);
			DataFromExcel = xlRead.GetDataFromExcelByHeader(xlSheet);
			Headers = xlRead.GetHeaders(UsedRange);
			
			isChanged = false;
			
				
			var Variables = xlRead.GetCellsData("Tag");
			
		    var RemovedVariable = variable.RemoveUnusedItems(Variables, xlSheet.Name);
		    alarm.RemoveUnusedItems(RemovedVariable);
		    structure.RemoveUnusedItems(RemovedVariable);
		    driver.RemoveUnusedItems(RemovedVariable);
		    scale.RemoveUnusedItems(RemovedVariable);
		    
		    		    
			if (Variables != null) {

		    for (RowIndex = 0; RowIndex < xlRead.NumberOfRows - 1; RowIndex++) {
		    	
		    	if(GetValuesByColumn("Tag") != ""){
		    	
		    	
		    	var AlarmInfo = alarm.GetItemFromList(GetValuesByColumn("Tag"));
		    	var VariableInfo = variable.GetVariableFromList(GetValuesByColumn("Tag"));
		    	var StructureInfo = structure.GetVariableMemberFromList(GetValuesByColumn("Tag"));
		    	var TaskInfo = driver.GetDriverTask(GetValuesByColumn("Tag"));
		    	var ScaleElementInfo = scale.GetScaleElementFromList(GetValuesByColumn("Tag"));
		    	var ThresholdList = alarm.GetThresholdList(AlarmInfo);

		    	ExitInnerLoop = false;
				
		    	foreach (var header in Headers){	

				stHeader = header;
				
		    	structure.EditInitialValueForMembers(GetValuesByColumn("Tag"), GetValuesByColumn(header), header);
		    	
		    	switch(header){							
				
					case "Tag":
								
						if(VariableInfo == null){
									
		    				ExitInnerLoop = variable.AddVariable(GetValuesByColumn("Tag"), xlSheet.Name, GetValuesByColumn("Name"), GetValuesByColumn("Area"));
		    				
						}
		    					
		    			if(xlSheet.Name == "AIA" || xlSheet.Name == "DIA"){
																		
							ExitInnerLoop = alarm.AddAlarm(GetValuesByColumn("Tag"), xlSheet.Name, GetValuesByColumn("Area"), GetValuesByColumn("Name"),
		    					                               GetValuesByColumn("Delay"), GetValuesByColumn("Condition"), GetValuesByColumn("StationName"));
		    						
		    			}
		    			
	    				else if (xlSheet.Name ==  "ModbusTCPIP" || xlSheet.Name ==  "S7TCP") {
		    					
	    					alarm.AddStationAlarm(GetValuesByColumn("Tag"), GetValuesByColumn("Area"), GetValuesByColumn("Name"));
	    					
	    				}
		    				
		    			if(xlSheet.Name == "AIA" || xlSheet.Name == "AI"){
		    				
			    			if(ScaleElementInfo == null){
			    			
			    					scale.AddNormalizer(GetValuesByColumn("Tag"), "-1", GetValuesByColumn("RawMin"), GetValuesByColumn("RawMax"), GetValuesByColumn("MinRange"),GetValuesByColumn("MaxRange"), "1");
			    					
		    				}
		    					
		    			}
		    					
							var ProtoStructMembersName = variable.GetStructurePrototypeNameList(xlSheet.Name);
							var ProtoStructMembersType = variable.GetStructurePrototypeTypeList(xlSheet.Name);
							var MembersInitialValues = GetRowData(RowIndex);  
							
							structure.EnableMemberProperties(GetValuesByColumn("Tag"), ProtoStructMembersName, ProtoStructMembersType, MembersInitialValues, Headers);
					
							if(	GetValuesByColumn("StationName") != ""){
									
								if (TaskInfo == null) {
							
									string DriverName = driver.GetDriverName(GetValuesByColumn("StationName"));
									string taskVarName = "Tag";
									int FunctionCode = 2;
									int Type = 1;
									
									if(xlSheet.Name == "AIA" || xlSheet.Name == "AI"){
	
										taskVarName = GetValuesByColumn("Tag") + ":Field";
										
										if (DriverName == "ModbusTCPIP") {
											
											FunctionCode = (int)Enums.ModbusFunctionCode.SingleRegister;
											
										}
										
										Type = (int)Enums.TaskType.Input;
										
									}
										
									else if(xlSheet.Name == "DI" || xlSheet.Name == "DIA") {
											
										taskVarName = GetValuesByColumn("Tag") + ":IO";	
										
										if (DriverName == "ModbusTCPIP") {
											
											FunctionCode = (int)Enums.ModbusFunctionCode.SingleRegister;
																						
										}	
										
										Type = (int)Enums.TaskType.Input;									
											
									}
									
									else if(xlSheet.Name == "DO") {
											
										taskVarName = GetValuesByColumn("Tag") + ":IO";	
										
										if (DriverName == "ModbusTCPIP") {
											
											FunctionCode = (int)Enums.ModbusFunctionCode.SingleRegister;
																						
										}
										
										Type = (int)Enums.TaskType.UnconditionalOutput;									
											
									}
										
									ExitInnerLoop = driver.AddNewTask(DriverName, GetValuesByColumn("StationName"), GetValuesByColumn("Tag"), taskVarName , GetValuesByColumn("Address"), Type,  GetValuesByColumn("Tag") + ":Forced", GetValuesByColumn("UnitID"),FunctionCode);
	
								}		
								
							}

 				        				
		    			break;
		
		    		case "Name":
				
		    				VariableInfo.Name.Description = GetValuesByColumn("Name");
		    				
		    				if (xlSheet.Name == "AIA") {
		    					
		    					alarm.GetThreshold(ThresholdList,"High").Name.Title = GetValuesByColumn("Name");
								alarm.GetThreshold(ThresholdList,"HighHigh").Name.Title = GetValuesByColumn("Name");
								alarm.GetThreshold(ThresholdList,"Low").Name.Title = GetValuesByColumn("Name");
								alarm.GetThreshold(ThresholdList,"LowLow").Name.Title = GetValuesByColumn("Name");
		    					
		    				}
		    				
		    				else if(xlSheet.Name == "DIA") {
		    					
		    					alarm.GetThreshold(ThresholdList,"Digital").Name.Title = GetValuesByColumn("Name");
		    					
		    				}

		    			break;
					
		    		case "Area":
		    			
						VariableInfo.Name.Group = GetValuesByColumn("Area") + "." + xlSheet.Name;
						
						if(xlSheet.Name == "AIA" || xlSheet.Name == "DIA"){
						
							AlarmInfo.Name.Area = GetValuesByColumn("Area");
		    			
						}
						
						break;										
						
					case "EU":
						
						structure.GetMemberFromList(StructureInfo, "IO").Name.EU = GetValuesByColumn("EU");
						
						break;
													
					case "RawMin":
						
						ScaleElementInfo.Name.RawMin = GetValuesByColumn("RawMin");
						
						break;
						
					case "RawMax":
						
						ScaleElementInfo.Name.RawMax = GetValuesByColumn("RawMax");
						
						break;
						
					case "MaxRange":
						
						ScaleElementInfo.Name.ScaledMax = GetValuesByColumn("MaxRange"); 
						break;
						
					case "MinRange":
						
						ScaleElementInfo.Name.ScaledMin = GetValuesByColumn("MinRange"); 
						
						break;
													
					case "Delay":
						
						if(xlSheet.Name == "AIA"){
							
							alarm.GetThreshold(ThresholdList,"High").Execution.SecDelay = GetValuesByColumn("Delay");
							alarm.GetThreshold(ThresholdList,"HighHigh").Execution.SecDelay = GetValuesByColumn("Delay");
							alarm.GetThreshold(ThresholdList,"Low").Execution.SecDelay = GetValuesByColumn("Delay");
							alarm.GetThreshold(ThresholdList,"LowLow").Execution.SecDelay = GetValuesByColumn("Delay");
							
						}
						
						else if(xlSheet.Name == "DIA") {
							
							alarm.GetThreshold(ThresholdList,"Digital").Execution.SecDelay = GetValuesByColumn("Delay");
							
						}
						break;
											
					case "UnitID":
					
						if(	GetValuesByColumn("StationName") != ""){
							
							if(driver.GetDriverName(GetValuesByColumn("StationName")) == "ModbusTCPIP") {
						
								TaskInfo.ModbusTCP.UnitID = GetValuesByColumn("UnitID");
							
							}
						
						}
						
						break;
						
					case "StationName":
						
						if(	GetValuesByColumn("StationName") != ""){
							
							TaskInfo.Name.Station = GetValuesByColumn("StationName");
							AlarmInfo.Name.EnableVariable = "Not [" + GetValuesByColumn("Tag") + ":Enable]" + " And " + " Not [" + GetValuesByColumn("Tag") 
															+ ":GroupDisable]" + " And Not CBool([" + GetValuesByColumn("StationName") + ":StationState])";
						}
						
						else {
							
								AlarmInfo.Name.EnableVariable = "Not [" + GetValuesByColumn("Tag") + ":Enable]" + " And " + " Not [" + GetValuesByColumn("Tag")	+ ":GroupDisable]" ;
	
						}

						break;
						
					case "Address":
						
						if(	GetValuesByColumn("StationName") != ""){
							
							switch(driver.GetDriverName(GetValuesByColumn("StationName"))) {
									
								case "S7TCP":
							
									TaskInfo.DeviceTaskSettings.DeviceAddress = GetValuesByColumn("Address");
									
									break;
									
								case "ModbusTCPIP":
									
									TaskInfo.ModbusTCP.StartAddress = GetValuesByColumn("Address");
									
									break;	
							}
						}

						break;
					}
		    		
				if(ExitInnerLoop) break;
		    }
    	

		}
		    	
	}
}
		    

if (xlSheet.Name ==  "ModbusTCPIP" || xlSheet.Name ==  "S7TCP"){

	driver.CreateDriverXML(ProjectDirectory + @"\" + "RESOURCES" + @"\" + ProjectFileName.ToUpper() + @"\", xlSheet.Name);
	variable.AddDriver(xlSheet.Name);

	for (RowIndex = 0; RowIndex < xlRead.NumberOfRows - 1; RowIndex++) {
		
		foreach (var header in Headers){
			
			stHeader = header;
			
			switch (header) {
				
				case "Tag":
				
					if(driver.GetStation(xlSheet.Name, GetValuesByColumn("Tag")) == null){
					
						driver.AddNewStation(xlSheet.Name,GetValuesByColumn("Tag"), GetValuesByColumn("ServerAddress"),
						                      GetValuesByColumn("BackupServerAddress"));
						

					 }
					
					 driver.CheckIfStationsExist(xlSheet.Name,xlRead.GetCellsData("Tag"));
				
					break;
					
				case "ServerAddress":
					Debug.WriteLine(driver.GetStation(xlSheet.Name, GetValuesByColumn("Tag")).Name);
					driver.GetStation(xlSheet.Name, GetValuesByColumn("Tag")).Server.ServerAddress = GetValuesByColumn("ServerAddress");
					break;
					
				case "BackupServerAddress":
					
					driver.GetStation(xlSheet.Name, GetValuesByColumn("Tag")).Server.BackupServerAddress = GetValuesByColumn("BackupServerAddress");
					break;
				
				}
			}
		}
	}
 }
	    
	    public void Clear()
	    {
	    	DataFromExcel = null;
	    }
	    	    
	
	    
	    private void GetConfigFile(Excel.Workbook xlBook)
	    {
	        var config = xlRead.GetConfig(xlBook);
			
	        ProjectDirectory = config[0].ProjectPath;
	        ProjectFileName = config[0].ProjectName;

			variable.Load(ProjectDirectory + @"\" + ProjectFileName + ".movrealtimedb");
			alarm.Load(ProjectDirectory + @"\" + ProjectFileName + ".movalr");
			structure.Load(ProjectDirectory + @"\" + ProjectFileName + ".movrtmembers");
			scale.Load(ProjectDirectory + @"\" + ProjectFileName + ".movscl");
			
			var driverList = variable.GetDriversList();

			driver.Load(ProjectDirectory + @"\" + "RESOURCES" + @"\" + ProjectFileName + @"\", driverList);


	    }
	    
	    	    
		public void Save()
		{
			if (isChanged) {
				
			variable.Serialize();
			alarm.Serialize();
			structure.Serialize();
			scale.Serialize();
			driver.Serialize(isChanged);
			
			}
			
			
		}
		

		
		void Listener_PropertyChanged(object sendder, PropertyChangedEventArgs e)
	    {

			double difference;
			
			Debug.WriteLine(" - " + stHeader +  " - " + e.PropertyName + " value: " + GetValuesByColumn(stHeader));

    		for (int i = 1; i <= UsedRange.Columns.Count; i++) {
				
				difference = Convert.ToDouble(UsedRange.Cells[RowIndex+2, i].Interior.Color) - ToDouble(Color.Yellow);
				
				if(difference != 0){
    			
    				UsedRange.Cells[RowIndex+2, i].Interior.Color = ToDouble(Color.Yellow);
    				
				}
    		}

		isChanged = true;			
			
		}
		    

	    private void OnAddingNew(object Sender, NotifyCollectionChangedEventArgs e)
	    {
	    	if(e.Action == NotifyCollectionChangedAction.Add){
		    	                                                	
	    		for (int i = 1; i <= UsedRange.Columns.Count; i++) {
	    			
	    			UsedRange.Cells[RowIndex+2, i].Interior.Color = ToDouble(Color.Orange);
	    		
	    			
	    		}
	    		
	    	foreach (var element in e.NewItems) {
	    		Debug.WriteLine(element );
	    	}
	    		
	    	isChanged = true;	
			}
	    	
	    	if(e.Action == NotifyCollectionChangedAction.Remove){
	    		
	    	foreach (var element in e.OldItems) {
	    		Debug.WriteLine(element);
	    	}
	    		isChanged = true;	
	    		
	    	}

//	    	
	    
	    }
	    
	    private string AppendNewComment(string NewComment, string OldComment)
	    {
	    	
	    	if(!NewComment.Contains(OldComment)){
	    	
	    		return OldComment + "       " + NewComment;
	    		
	    	}
	    	
	    	return " ";
	    	
	    }
	    
	    
	    private void DeleteComment(Excel.Range Cell)
	    {
	    	
			if(Cell.Comment != null){
				
				Cell.Comment.Delete();
				
			}
	    	
	    }
	    
	    private void Error(string ErrorString, int RowIndex, int ColumnIndex)
	    {
			for (int i = 1; i <= UsedRange.Columns.Count; i++) {
				
				UsedRange.Cells[RowIndex + 2, i].Interior.Color = ToDouble(Color.PaleVioletRed);
				
			}
	    	
	    	if(UsedRange.Cells[RowIndex+2, ColumnIndex+1].Comment != null){
	    		UsedRange.Cells[RowIndex+2, ColumnIndex+1].Comment.Delete();
	    		UsedRange.Cells[RowIndex+2, ColumnIndex+1].AddComment(ErrorString);
	    	}
	    	else{
	    		UsedRange.Cells[RowIndex+2, ColumnIndex+1].AddComment(ErrorString);
	    	}	    	
	    	
	    }
	    
	    private void AddNewData()
	    {
	    	
	    }
	    	    
	    
    	#region Helper
	    
	    private static double ToDouble(System.Drawing.Color color)
	    {
	        uint returnValue = color.B;
	        returnValue = returnValue << 8;
	        returnValue += color.G;
	        returnValue = returnValue << 8;
	        returnValue += color.R;
	        return returnValue;
	    }
	    
	    private string GetKeyValue(string key)
		{
			
			CellInfo list = new CellInfo();
			RowData.TryGetValue(key, out list);
			if(list == null) return "";
			return Convert.ToString(list.Cell.Value2);
		}
		
	    private IEnumerable<Excel.Range> GetRowData(string key)
	    {
	    	
	    	List<Excel.Range> list = new List<Excel.Range>();
			DataFromExcel.TryGetValue(key, out list);
			return list;
	    	
	    }
	    
	    private Excel.Range GetCellInfo(string key)
	    {
	    	CellInfo list = new CellInfo();
			RowData.TryGetValue(key, out list);
			return list.Cell;
	    }
	    
	    private List<string> GetRowData(int index){
	    	
	    	List<string> list = new List<string>();
	    	
	    	for(int i = 0; i<Headers.Count;i++){	
	    			    		
	    		list.Add(Convert.ToString(DataFromExcel.ElementAt(i).Value.ElementAt(index).Value2));
	    		
	    	}
	    	    	
	    	return list;
	    		
	    }
	    
	    private string GetValuesByColumn(string ColumnName)
	    {
	    	if(xlRead.GetDataByHeaderName(ColumnName) == null){
	    		return string.Empty;
	    	}
	    	return Convert.ToString(xlRead.GetDataByHeaderName(ColumnName).ElementAt(RowIndex).Value2);
	    	
	    }
	    

			
			

	    	

	    	
	    #endregion
	                                    
    
	}
	

}