/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 10.03.2014
 * Time: 14:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using NetOffice;
using Excel = NetOffice.ExcelApi;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;


namespace EekelsDataManager
{
	/// <summary>
	/// Description of ReadFromExcel.
	/// </summary>
	/// 

	
 public class Config
 {
 	
	private string _projectPath;
	private string _projectName;

	public string ProjectPath{
		get {return _projectPath;}
		set {_projectPath = value;}
	}
	
	public string ProjectName{
		get {return _projectName;}
		set {_projectName = value;}
	}
 	
 }	
	
public class Row
{
	
	
	private string _name;

	public string Name{
		get {return _name;}
		set {_name = value;}
	}
	
}

public class CellInfo
{
	
	private Excel.Range _cell;

	public Excel.Range Cell{
		get {return this._cell;}
		set {this._cell = value;}
	}
		
}



public class cReadFromExcel
	{
		
		private Dictionary<string, List<Excel.Range>> ExcelData {get; set;}
		
		public int NumberOfRows {get; set;}
		public int NumberOfColumns{get; set;}
		public List<string> Headers {get; set;}
		public List<string> DataTypes {get; set;}
		
		
		public Dictionary<Row, Dictionary<string,  CellInfo>> GetDataFromExcel(Excel.Range xlRange)
		{
		
			try{
			
			Dictionary<Row, Dictionary<string,  CellInfo>> dictionary = new Dictionary<Row,Dictionary<string,  CellInfo>>();

				for(int r = 2; r <= xlRange.Rows.Count; r++) {
				
					if (xlRange.Cells[r,1].Value2 != null){

					Dictionary<string,  CellInfo> myList = new Dictionary<string,  CellInfo>();
					
							for(int c = 1; c <= xlRange.Columns.Count; c++){
									
								myList.Add( xlRange.Cells[1,c].Value2.ToString(), new CellInfo {
								           	Cell = xlRange.Cells[r,c]
								           });
							
							}

				dictionary.Add(new Row {Name = xlRange.Cells[r,1].Value2.ToString()},
					               myList);
				
				}
			}

			return dictionary;
			}catch(Exception e){
				Debug.WriteLine(e);
				return null;
			}
			
		}
		
		public Dictionary<string, List<Excel.Range>> GetDataFromExcelByHeader(Excel.Worksheet xlSheet)
		{
		
			try{

			Excel.Range xlRange = RealUsedRange(xlSheet);
			NumberOfRows = xlRange.Rows.Count;
			NumberOfColumns = xlRange.Columns.Count;
				
			Dictionary<string, List<Excel.Range>> dictionary = new Dictionary<string, List<Excel.Range>>();
		
				for(int c = 1; c <= NumberOfColumns; c++) {

					List<Excel.Range> myList =new List<Excel.Range>();
					
						for(int r = 2; r <= NumberOfRows; r++){
								
							myList.Add(xlRange.Cells[r,c]);
						
						}

					dictionary.Add(xlRange.Cells[1,c].Value2.ToString(),
					               myList);
			}
			
			ExcelData = dictionary;
			
			return dictionary;
			}catch(Exception e){
				Debug.WriteLine(e);
				return null;
			}
			
		}
		
		public List<string> GetHeaders(Excel.Range xlRange)
		{
			List<string> headers =  new List<string>();
			for (int c = 1; c <= xlRange.Columns.Count; c++) {
				
				headers.Add(xlRange.Cells[1,c].Value2.ToString());
				
			}
			
			this.Headers = headers;
			return headers;
			
		}
		
		public List<string> GetDataTypes(Excel.Range xlRange)
		{
			List<string> dataTypes =  new List<string>();
			for (int c = 1; c <= xlRange.Columns.Count; c++) {
				
				dataTypes.Add(xlRange.Cells[2,c].Value2.ToString());
				
			}
			
			this.DataTypes = dataTypes;
			return DataTypes;
			
		}
		
		public List<Excel.Range> GetDataByHeaderName(string HeaderName)
		{
			List<Excel.Range> Value = new List<Excel.Range>();
			ExcelData.TryGetValue(HeaderName, out Value);
			return Value;
		}
		
		public List<string> GetCellsData(string HeaderName)
		{
			
			List<string> List = new List<string>();
			
			var Datas = GetDataByHeaderName(HeaderName);
			
			if (Datas == null) return null;
			
			foreach (var Data in Datas) {
				
				if (HeaderName == "Tag" || HeaderName ==  "StationName") {
					
					if (Convert.ToString(Data.Value2) != string.Empty){
				
						List.Add(Convert.ToString(Data.Value2));
						
					}
					
				}
				
			}
			
			return List;
			
		}
		
		public Dictionary<Row, Dictionary<string,  CellInfo>> CommSettings(Excel.Workbook xlWb)
		{
		
		try {
					
			Dictionary<Row, Dictionary<string,  CellInfo>> CommSettings = new Dictionary<Row, Dictionary<string,  CellInfo>>();
			
			Excel.Worksheet xlComm = (Excel.Worksheet)xlWb.Worksheets["ComSettings"];
			
			Excel.Range xlCommRange = RealUsedRange(xlComm);
			
			for(int r = 2; r <= xlCommRange.Rows.Count; r++) {
			
				if (xlCommRange.Cells[r,1].Value2 != null){

					Dictionary<string,  CellInfo> myList = new Dictionary<string,  CellInfo>();
					
							for(int c = 1; c <= xlCommRange.Columns.Count; c++){
									
								myList.Add( xlCommRange.Cells[1,c].Value2.ToString(), new CellInfo {
								           	Cell = xlCommRange.Cells[r,c]
								           });
							
							}

				CommSettings.Add(new Row {Name = xlCommRange.Cells[r,1].Value2.ToString()},
					               myList);
				
				}
			}
			
			return CommSettings;
			
			} catch (Exception) {
			
	            throw new Exception("Configuration sheet not found");
			}
			
		}
		
		public List<Config> GetConfig(Excel.Workbook xlWb)
		{
		
		try {
					
			List<Config> config = new List<Config>();
			
			Excel.Worksheet xlConfigSheet = (Excel.Worksheet)xlWb.Worksheets["Config"];
			
			Excel.Range xlConfigRange = RealUsedRange(xlConfigSheet);
			
			for (int r = 2; r <= xlConfigRange.Rows.Count; r++){

					config.Add(new Config {ProjectPath = xlConfigRange.Cells[r,1].Value2.ToString(),
				           				   ProjectName = xlConfigRange.Cells[r,2].Value2.ToString()});
				
			}
			
			return config;
			
			} catch (Exception) {
			
	            throw new Exception("Configuration sheet not found");
		}
			
		}
		
		public int GetHeaderIndex(string HeaderName)
		{
			
			return Headers.FindIndex(p => p.Equals(HeaderName));
			
		}

		public Excel.Range RealUsedRange(Excel.Worksheet xlWorksheet)  
		{
			
			
		long FirstRow;     
	    long LastRow;     
	    int FirstColumn;
	    int LastColumn;

		    try{
		   	
			FirstRow = xlWorksheet.Cells.Find("*",xlWorksheet.Range("IV65536"),Excel.Enums.XlFindLookIn.xlValues,
	    	                                              Excel.Enums.XlLookAt.xlPart,Excel.Enums.XlSearchOrder.xlByRows,Excel.Enums.XlSearchDirection.xlNext).Row;
		     
			FirstColumn = xlWorksheet.Cells.Find("*", xlWorksheet.Range("IV65536"), Excel.Enums.XlFindLookIn.xlValues,
	    	                                              Excel.Enums.XlLookAt.xlPart,Excel.Enums.XlSearchOrder.xlByColumns,Excel.Enums.XlSearchDirection.xlNext).Column;
		     
			LastRow = xlWorksheet.Cells.Find("*", xlWorksheet.Range("A1"), Excel.Enums.XlFindLookIn.xlValues,
	    	                                             Excel.Enums.XlLookAt.xlPart,Excel.Enums.XlSearchOrder.xlByRows,Excel.Enums.XlSearchDirection.xlPrevious).Row;
		     
			LastColumn = xlWorksheet.Cells.Find("*", xlWorksheet.Range("A1"), Excel.Enums.XlFindLookIn.xlValues,
	    	                                              Excel.Enums.XlLookAt.xlPart,Excel.Enums.XlSearchOrder.xlByColumns,Excel.Enums.XlSearchDirection.xlPrevious).Column;
			
			return xlWorksheet.Range(xlWorksheet.Cells[FirstRow, FirstColumn], xlWorksheet.Cells[LastRow, LastColumn]);
				
	    	}catch(Exception e){
			
	    		throw new Exception("Sheet is empty", e);
	    		
	    		
		    }

		}
		
		public void ClearWorkbook(Excel.Workbook xlWorkbook)
		{
			
			foreach (Excel.Worksheet xlSheet in xlWorkbook.Worksheets) {
		    		
		    	Excel.Range UsedRange =	RealUsedRange(xlSheet);
		    		
				foreach (Excel.Range xlCell in UsedRange.Cells) {
						
	    			if(xlCell.Comment != null){
	    			
	    				xlCell.Comment.Delete();	
	    			}	
	    			xlCell.Interior.ColorIndex = NetOffice.OfficeApi.Enums.XlColorIndex.xlColorIndexNone;
				}
		    }
		}
		
		public void ClearWorksheet(Excel.Worksheet xlSheet)
		{
	
	    	Excel.Range UsedRange =	RealUsedRange(xlSheet);
	    		
			foreach (Excel.Range xlCell in UsedRange.Cells) {
					
    			if(xlCell.Comment != null){
    			
    				xlCell.Comment.Delete();	
    			}	
    			xlCell.Interior.ColorIndex = NetOffice.OfficeApi.Enums.XlColorIndex.xlColorIndexNone;
			}
		    
		}
		
    }
			
}
