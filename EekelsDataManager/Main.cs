using System;
using System.Drawing;
using System.Reflection;
using ExcelDna.Integration;
using ExcelDna.ComInterop;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using NetOffice;
using NetOffice.ExcelApi;
using Excel = NetOffice.ExcelApi;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;
using NetOffice.ExcelApi.Enums;

//
namespace EekelsDataManager
{
    [ComVisible(false)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class EDM
    {   	

  		public class Initializer : IExcelAddIn 			
	    {
  			
			EditData test = new EditData();
			public Excel.Application xlApp {get; set;}
			private object CellValue {get; set;}
			object[,] _CellValue = new object[100,100]; // Backing store
			cReadFromExcel xlRead = new cReadFromExcel();
			
			public void AutoOpen()
			{	
				
				// Get current application 
				xlApp = new NetOffice.ExcelApi.Application(null, ExcelDnaUtil.Application);
				xlApp.WorkbookBeforeCloseEvent += new Application_WorkbookBeforeCloseEventHandler(xlApp_WorkbookBeforeCloseEvent);
				
				# region Toolbar
				
				// Add toolbar	        	
				Office.CommandBar mdmCommandBar = xlApp.CommandBars.Add("MDM", MsoBarPosition.msoBarTop, System.Type.Missing, true);
				mdmCommandBar.Visible = true;
				
			    // add Save Button
			    Office.CommandBarButton commandSaveBtn = (Office.CommandBarButton)mdmCommandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
			    commandSaveBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
			    commandSaveBtn.FaceId = 643; 
				commandSaveBtn.TooltipText = "Save Current Sheet";	            
			    commandSaveBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEventSaveBtn);
			    
			    // add Save All Button
			    Office.CommandBarButton commandSaveAllBtn = (Office.CommandBarButton)mdmCommandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
			    commandSaveAllBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
			    commandSaveAllBtn.FaceId = 2648;
			    commandSaveAllBtn.TooltipText = "Save All Sheets";	 
			    commandSaveAllBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEventSaveAll);
			    
			    // add Config Button
			    Office.CommandBarButton commandConfigBtn = (Office.CommandBarButton)mdmCommandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
			    commandConfigBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
			    commandConfigBtn.FaceId = 502;
			    commandConfigBtn.TooltipText = "Config";	 
			    //commandConfigBtn.ClickEvent += new NetOffice.OfficeApi.CommandBarButton_ClickEventHandler(commandBarBtn_ClickEventConfig);
			    commandConfigBtn.Visible = false;  
			    		    	    
			}
		
			#endregion

		    public void AutoClose()
		    {
		    }
			
			#region Events
		
		    private void commandBarBtn_ClickEventSaveBtn(NetOffice.OfficeApi.CommandBarButton Ctrl, ref bool CancelDefault)
		    {
		        try
		        {
		        	
		        	Excel.Workbook xlWkBook = xlApp.ActiveWorkbook;
					
					Excel.Worksheet xlSheet = (Excel.Worksheet)xlWkBook.ActiveSheet;
					xlRead.ClearWorksheet(xlSheet);
		        	test.SaveData(xlSheet);

		        	test.Clear();
		        	//xlSheet.Dispose();

		        }
		        catch (Exception exception)
		        {
		            string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
		            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        }
		        
		    }
		
		    private void commandBarBtn_ClickEventSaveAll(NetOffice.OfficeApi.CommandBarButton Ctrl, ref bool CancelDefault)
		    {
		        try
		        {
					
		    		//test.GetConfigFile((Excel.Workbook)xlApp.ActiveWorkbook);
		    		xlRead.ClearWorkbook(xlApp.ActiveWorkbook);
		    		test.SaveAllData(xlApp.ActiveWorkbook);
		        	
		        }
		        catch (Exception exception)
		        {
		            string message = string.Format("An error occured.{0}{0}{1}", Environment.NewLine, exception.Message);
		            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		        }
		    }
		    
		    
		    private void xlApp_WorkbookBeforeCloseEvent(Excel.Workbook Wb, ref bool Cancel)
		    {
		    	
		    	
		    	xlRead.ClearWorkbook(Wb);
		    	
		    	Wb.Save();
		    }
		    
		    private void Clear()
		    {
		    	
		    }

		    #endregion
		    
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
		    
		    #endregion
		    
		    private string GetRowName(Excel.Range xlRange)
		    {
		    	return xlRange.Worksheet.Cells[xlRange.Row,1].Value2.ToString();
		    }
		    
		    private string GetHeaderName(Excel.Range xlRange)
		    {
		    	return xlRange.Worksheet.Cells[1, xlRange.Column].Value2.ToString();
		    }
		    
		    private object GetParameterValue(object src, string propname)
		    {
		    	
		    	return src.GetType().GetProperty(propname).GetValue(src,null);
		    	
		    }
        	
		}
	}
}