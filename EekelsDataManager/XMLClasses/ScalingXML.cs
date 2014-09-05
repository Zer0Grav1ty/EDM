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


namespace EekelsDataManager
{
	
	public class ScalingXML 
	{
		
		private string _Path;
		
		public string Path{
			get { return this._Path;}
			set { this._Path = value;}
		}
		
		private ListScaling _scaleElement;
		
		public ListScaling xmlScaleElement {
			get { return _scaleElement;}
			set { _scaleElement = value;}
		}
		
		[XmlRoot()]
		public partial class ListScaling : INotifyPropertyChanged {
		    
		    private ObservableCollection<ListScalingScalingListScaling> itemsField;
		    
		    /// <remarks/>
		    /// 
		    [XmlArray("ScalingList")]
    		[XmlArrayItem("Scaling")]	
		    public ObservableCollection<ListScalingScalingListScaling> Items {
		        get {
		            return this.itemsField;
		        }
		        set {
		            this.itemsField = value;
		            RaisePropertyChanged("ListScaling");
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
		
//		/// <remarks/>
//		[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
//		[System.SerializableAttribute()]
//		[System.Diagnostics.DebuggerStepThroughAttribute()]
//		[System.ComponentModel.DesignerCategoryAttribute("code")]
//		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
//		public partial class ListScalingScalingList {
//		    
//		    private ListScalingScalingListScaling[] scalingField;
//		    
//		    /// <remarks/>
//		    [System.Xml.Serialization.XmlElementAttribute("Scaling", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
//		    public ListScalingScalingListScaling[] Scaling {
//		        get {
//		            return this.scalingField;
//		        }
//		        set {
//		            this.scalingField = value;
//		        }
//		    }
//		}
		
		/// <remarks/>

		[XmlType()]
		public partial class ListScalingScalingListScaling : INotifyPropertyChanged {
		    
		    private string listField;
		    
		    private ListScalingScalingListScalingName nameField;
		    
		    /// <remarks/>
		    [XmlAttribute()]
		    public string List {
		        get {
		            return this.listField;
		        }
		        set {
		            this.listField = value;
		            RaisePropertyChanged("Scaling");
		        }
		    }
		    
		    /// <remarks/>
		    [XmlElement("Name")]
		    public ListScalingScalingListScalingName Name {
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
		
		/// <remarks/>

		[XmlType()]
		public partial class ListScalingScalingListScalingName : INotifyPropertyChanged{
		    
		    private string rawVarField;
		    
		    private string scaledVarField;
		    
		    private string deadBandField;
		    
		    private string rawMinField;
		    
		    private string rawMaxField;
		    
		    private string scaledMinField;
		    
		    private string scaledMaxField;
		    
		    private string enabledField;
		    
		    private string valueField;
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string RawVar {
		        get {
		            return this.rawVarField;
		        }
		        set {
		            if(this.rawVarField != value){
		    			
		    		this.rawVarField = value;
		    			
		    		RaisePropertyChanged("RawVar");
		    			
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ScaledVar {
		        get {
		            return this.scaledVarField;
		        }
		        set {
		            if(this.scaledVarField != value){
		    			
		    		this.scaledVarField = value;
		    			
		    		RaisePropertyChanged("ScaledVar");
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string DeadBand {
		        get {
		            return this.deadBandField;
		        }
		        set {
		            if(this.deadBandField != value){
		    			
		    		this.deadBandField = value;
		    			
		    		RaisePropertyChanged("DeadBand");
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
		    			
		    		this.rawMinField = value;
		    			
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
		    			
		    		this.rawMaxField = value;
		    			
		    		RaisePropertyChanged("RawMax");
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ScaledMin {
		        get {
		            return this.scaledMinField;
		        }
		        set {
		            if(this.scaledMinField != value){
		    			
		    		this.scaledMinField = value;
		    			
		    		RaisePropertyChanged("ScaledMin");
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string ScaledMax {
		        get {
		            return this.scaledMaxField;
		        }
		        set {
		            if(this.scaledMaxField != value){
		    			
		    		this.scaledMaxField = value;
		    			
		    		RaisePropertyChanged("ScaledMax");
		    		}
		        }
		    }
		    
		    /// <remarks/>
		    [System.Xml.Serialization.XmlAttributeAttribute()]
		    public string Enabled {
		        get {
		            return this.enabledField;
		        }
		        set {
		            if(this.enabledField != value){
		    			
		    		this.enabledField = value;
		    			
		    		RaisePropertyChanged("Enabled");
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
		
				
		public void Load(string Path)
		{
			this.Path = Path;
			ListScaling data = new ListScaling();
		
			var textReader = new StreamReader(Path);
			var deserializer = new XmlSerializer(typeof(ListScaling));
			xmlScaleElement = (ListScaling)deserializer.Deserialize(textReader);
			ListScaling xmlData = (ListScaling)xmlScaleElement;
			textReader.Close();
			
		}
		
		public void RemoveUnusedItems(IEnumerable<string> ScaleList)
		{
	        
			if (ScaleList == null) return ;
			
			if (ScaleList.Count() != 0){
	        
	        	foreach ( string element in ScaleList) {
	        	
					xmlScaleElement.Items.Remove(GetScaleElementFromList(element));
	        		
	        	}
	        	
	        }
			
		}
		
		public bool AddNormalizer(string Name, string DeadBand, string RawMin, string RawMax, string ScaledMin, string ScaledMax, string Enable)
		{
					
			xmlScaleElement.Items.Add(
				new ListScalingScalingListScaling{Name = new ListScalingScalingListScalingName{
													Value = Name, RawVar = Name + ":Field", ScaledVar = Name + ":IO", DeadBand = DeadBand, RawMin = RawMin, RawMax = RawMax,
													ScaledMin = ScaledMin, ScaledMax = ScaledMax,  Enabled = Enable},
													});
			return true;
		}
		
		public ListScalingScalingListScaling GetScaleElementFromList (string ScaleElement)
		{
			
			return xmlScaleElement.Items.FirstOrDefault(p => p.Name.Value == ScaleElement);
			
		}
		
		
		public void Serialize()
		{ 
	    	XmlSerializer serializer = new XmlSerializer(typeof(ListScaling)); 
	    	XmlSerializerNamespaces ns =new XmlSerializerNamespaces();
	    	ns.Add("","");
	    	using (TextWriter writer = new StreamWriter(Path))
	    	{
	        	serializer.Serialize(writer, xmlScaleElement, ns); 
	    	} 
		}
		
	}

}
