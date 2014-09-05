/*
 * Created by SharpDevelop.
 * User: 3duser
 * Date: 05.09.2014
 * Time: 9:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

//		public bool AddRealTimeDBStructurePrototype(string StructureName)
//		{
//			Enums enums = new Enums();
//			
//			if (GetStructurePrototypeFromList(StructureName) == null) {
//			
//			xmlVariable.StructureList.Add(
//				new RealTimeDBStructureListVariable{
//					Name = new VariableXML.RealTimeDBStructureListVariableName{
//						Description = "", Value = StructureName
//					},
//					MemberList = new List<VariableXML.RealTimeDBStructureListVariableMemberList>{}
//			
//				});
//				
//			}
//			
//			var StructurePrototype = GetStructurePrototypeFromList(StructureName);
//			
//			switch (StructureName) {
//					
//					case "AIA":
//
//						for(int i =0; i<= enums.AIAStructMembers.Length/2 - 1; i++){
//		
//							if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.AIAStructMembers[i,0]) == null) {
//							
//								AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.AIAStructMembers[i,1], enums.AIAStructMembers[i,0]);
//						    	
//							}
//							
//						}
//					break;
//					
//					case "DIA":
//					
//						for(int i =0; i<= enums.DIAStructMembers.Length/2 - 1; i++){
//		
//							if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DIAStructMembers[i,0]) == null) {
//							
//								AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DIAStructMembers[i,1], enums.DIAStructMembers[i,0]);
//						    	
//							}
//							
//						}
//					break;
//				
//					case "DI":
//					
//						for(int i =0; i<= enums.DIStructMembers.Length/2 - 1; i++){
//		
//							if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DIStructMembers[i,0]) == null) {
//							
//								AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DIStructMembers[i,1], enums.DIStructMembers[i,0]);
//						    	
//							}
//							
//						}
//					break;
//
//					case "AI":
//					
//						for(int i =0; i<= enums.AIStructMembers.Length/2 - 1; i++){
//		
//							if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.AIStructMembers[i,0]) == null) {
//							
//								AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.AIStructMembers[i,1], enums.AIStructMembers[i,0]);
//						    	
//							}
//							
//						}
//					break;
//
//					case "DO":
//						
//						for(int i =0; i<= enums.DOStructMembers.Length/2 - 1; i++){
//		
//							if (GetStructurePrototypeMemberFromList(StructurePrototype, enums.DOStructMembers[i,0]) == null) {
//							
//								AddRealTimeDBStructurePrototypeMember(StructurePrototype, enums.DOStructMembers[i,1], enums.DOStructMembers[i,0]);
//						    	
//							}
//							
//						}
//					break;
//					
//				}
//			
//			return true;
//
//		}
//		
//		public bool AddRealTimeDBStructurePrototypeMember(RealTimeDBStructureListVariable StructurePrototype, string StructurePrototypeMemberType, string StructurePrototypeMemberName)
//		{
//			
//			StructurePrototype.MemberList.Add(
//				new RealTimeDBStructureListVariableMemberList{
//					Name = new RealTimeDBStructureListVariableMemberListName{
//						Type = StructurePrototypeMemberType, Value = StructurePrototypeMemberName
//					}
//				});
//			
//			return true;
//			
//		}
//		
//		public void AddStructurePrototype(string StructurePrototypeName, List<string> StructurePrototypeMembers, List<string> StructurePrototypeMembersDataType)
//		{
//			
//			if (GetStructurePrototypeFromList(StructurePrototypeName) == null) {
//				
//				xmlVariable.StructureList.Add(
//					new RealTimeDBStructureListVariable{
//						Name = new VariableXML.RealTimeDBStructureListVariableName{
//							Description = "", Value = StructurePrototypeName
//						},
//						MemberList = new List<VariableXML.RealTimeDBStructureListVariableMemberList>{}
//				
//				});		
//				
//			}
//			
//			var StructurePrototype = GetStructurePrototypeFromList(StructurePrototypeName);
//			
//			int i = StructurePrototypeMembers.Count;
//			
//			for (i = 0; i < StructurePrototypeMembers.Count; i++){
//				
//				if (GetStructurePrototypeMemberFromList(StructurePrototype, StructurePrototypeMembers.ElementAt(i)) == null) {
//				
//					AddStructurePrototypeMember(StructurePrototype, StructurePrototypeMembers.ElementAt(i), StructurePrototypeMembersDataType.ElementAt(i));
//					
//				}
//					
//			}
//								
//		}
//		
//		public void AddStructurePrototypeMember(RealTimeDBStructureListVariable StructurePrototype, string StructurePrototypeMemberName, string StructurePrototypeMemberType){
//			
//			StructurePrototype.MemberList.Add(
//				new RealTimeDBStructureListVariableMemberList{
//					Name = new RealTimeDBStructureListVariableMemberListName{
//						Type = StructurePrototypeMemberType.ToLower(), Value = StructurePrototypeMemberName
//					}
//			});
//			
//		}


//			public readonly string[,] AIAStructMembers ={{"Enable", "0"},{"Forced", "0"},{"GroupDisable", "0"},{"HAlarmStatus", "2"},{"HHAlarmStatus", "2"},
//											{"LAlarmStatus", "2"},{"LLAlarmStatus", "2"},{"HThresholdValue", "7"},{"HHThresholdValue", "7"},
//											{"LThresholdValue", "7"},{"LLThresholdValue", "7"}, {"IO", "7"}, {"Field", "3"},{"DisableTask","0"},{"DataFormat","9"},{"Quality", "2"},{"BlockGroup","2"}};
//	
//			public readonly string[,] AIStructMembers ={{"Enable", "0"},{"Forced", "0"}, {"IO","7"},{"Field", "3"},{"DisableTask","0"},{"DataFormat","9"},{"Quality", "2"}};
//		
//			public readonly string[,] DIAStructMembers ={{"Enable", "0"},{"Forced", "0"},{"GroupDisable", "0"},{"AlarmStatus", "2"}, 
//									{"IO","0"},{"DisableTask","0"},{"Quality", "2"},{"BlockGroup","2"}};
//	
//			public readonly string[,] DIStructMembers ={{"Enable", "0"},{"Forced", "0"},{"IO","0"},{"DisableTask","0"},{"Quality", "2"}};
//			
//			public readonly string[,] DOStructMembers ={{"Enable", "0"},{"Forced", "0"},{"IO","0"},{"DisableTask","0"},{"Quality", "2"}};