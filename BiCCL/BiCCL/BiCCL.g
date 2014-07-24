grammar BiCCL;

options {
   language = CSharp2;
}

@parser::namespace {
	NIST.BiCCL
}

@lexer::namespace {
	NIST.BiCCL
}

@header{

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Text;

using Mbark;
using Mbark.SensorMessages;
using Mbark.Sensors;
using Mbark.Sensors.Builtins;
using Mbark.Sensors.Workflow;
using Mbark.UI;

}

@members{

SensorTaskFactoryCollectionDefinition factories = new SensorTaskFactoryCollectionDefinition();
/*Localizations section*/
LocalizableStringCollectionDefinition messageLibrary = new LocalizableStringCollectionDefinition();
List<LocalizableStringDefinition> lsd = new List<LocalizableStringDefinition>(); //THIS HAS TO BE REMOVED, and the strings added with messageLibrary.Add(LocalizableString)

/*Begin sensors & configs section*/
Dictionary<String, SensorTypeDefinition> sensors = new Dictionary<String, SensorTypeDefinition>();
Dictionary<String, String> sensorNamespaces = new Dictionary<String, String>();
Dictionary<String, SensorConfiguration> configs = new Dictionary<String, SensorConfiguration>();

String sensorSubdirectory = "Sensors";
List<Type> extraSerializableTypes = new List<Type>();

/*Begin conditions and equivalence section*/
//NOTE: This is used to hold both the conditions and the equivalence classes.
ConditionFactoryCollectionDefinition conditionLibrary = new ConditionFactoryCollectionDefinition();
/*End conditions and equivalence section*/

/*Begin tasks section (This is all internal; only used to paste into relevant workflow items.*/
Dictionary<String, Task> tasks = new Dictionary<String, Task>();

/*Begin initial state section */
ConditionCollectionDefinition currentConditions = new ConditionCollectionDefinition();
Collection<ConditionDefinition> conditionArray = new Collection<ConditionDefinition>();

/*Begin workflow section*/
Collection<SensorTaskFactoryDefinition> factoryDefinitions = new Collection<SensorTaskFactoryDefinition>();


/*Begin helper methods */


public E[] concatArray<E>(E[] oldArray, E newItem) {
    E[] temp;
    if(oldArray == null){
        temp = new E[1];
        temp[0] = newItem;
    }
    else {
        temp = new E[oldArray.Length + 1];
        for(int i = 0; i < oldArray.Length; i++) {
		        temp[i] = oldArray[i];
        }
        temp[temp.Length - 1] = newItem;

    }
    return temp;
}
        
public LocalizableStringDefinition createSimpleLocalizableString(String strName, String region, String message) {
	//Create a simple string mapping
	RegionMessagePair theMessage = new RegionMessagePair();
	theMessage.Region = region;
	theMessage.Message = message;
	
	LocalizableStringDefinition tempString = new LocalizableStringDefinition();
	tempString.Name = strName;
	tempString.RegionMessagePairs.Add(theMessage);
	
	return tempString;
}

public ConditionFactoryProxyCollectionDefinition createConditionProxies() {
         
            ConditionFactoryProxyCollectionDefinition prox = new ConditionFactoryProxyCollectionDefinition();
	        //add equivalence classes first
	        for(int i = 0; i < conditionLibrary.EquivalenceClassFactoryDefinitions.Length; i++) {
		        NamedProxy<PredicateFactory> tempName = new NamedProxy<PredicateFactory>();
		        tempName.Name = conditionLibrary.EquivalenceClassFactoryDefinitions[i].Name;
		        prox.EquivalenceClassProxies = concatArray<NamedProxy<PredicateFactory>>(prox.EquivalenceClassProxies, tempName);
	        }
        	
	        //create a proxy for each condition factory.
	        for(int i = 0; i < conditionLibrary.FactoryDefinitions.Length; i++) {
		        NamedProxy<ConditionFactory> tempName = new NamedProxy<ConditionFactory>();
		        tempName.Name = conditionLibrary.FactoryDefinitions[i].FactoryName;
		        prox.ConditionFactoryProxies = concatArray<NamedProxy<ConditionFactory>>(prox.ConditionFactoryProxies, tempName);
	        }
	        return prox;

}

public SensorTaskFactoryDefinition createTaskFactory(String taskName, int taskCount, ConditionFactoryProxyCollectionDefinition prox)
{

	SensorTaskFactoryDefinition factory = new SensorTaskFactoryDefinition();

	//First, find the named task in the HashMap.
	Task tempTask = tasks[taskName];
	if (tempTask == null) Console.WriteLine("Couldn't find task named " + taskName + ", so the workflow won't match the miniconf file.");
	factory.TaskCount = taskCount;
	//format of the SensorType string is libraryFileName+sensorClassName.
	//Look for the config in the HashMap we created earlier.
	//FIXME: This is abysmally inefficient.  Fix it later :-).
	foreach(KeyValuePair<String, SensorTypeDefinition> kvp in sensors)
	{
	//	ISensor tempSensor = SensorTypeDefinition.CreateSensor(kvp.Value);
	//	if(tempSensor == null) throw new ArgumentNullException("Couldn't create an ISensor out of "+kvp.Value.ToString());
	//	BaseSensor asBaseSensor = (BaseSensor)tempSensor;
    //   
	//	if (asBaseSensor.GetType().Equals(tempTask.getSensor()))
	//	{
	//		factory.SensorTypeDefinitionString = Path.GetFileName(asBaseSensor.GetType().Assembly.Location) + "+" + asBaseSensor.GetType().FullName;
	//		break;
	//	}
		Console.WriteLine("Checking task's sensor against list..."+kvp.Value.ClassName+" against "+tempTask.getSensor());
		if(kvp.Value.ClassName == tempTask.getSensor()) {
			Console.WriteLine("Setting sensorType for task "+tempTask+" to "+kvp.Value.ToString());
			factory.SensorTypeDefinitionString = kvp.Value.ToString();
		}
	}

	//set the intended category for this task.
	factory.Category = tempTask.getIntendedCategory();

	//add the collection to the TaskFactory
	if (prox != null) factory.TargetConditionFactoryProxies = prox;

	//FIXME: add the sensor configuration here!
	factory.SensorConfiguration = tempTask.getConfiguration();

	//add the reassignable categories to the TaskFactory.
	SensorTaskCategoryCollectionDefinition categories = new SensorTaskCategoryCollectionDefinition();
	List<SensorTaskCategory> temp_cats = tempTask.getReassignableCategories();
	for (int i = 0; i < temp_cats.Count; i++)
	{
	   categories.TaskCategories.Add(temp_cats[i]);
	}
	factory.ReassignableCategoriesDefinition = categories;

	return factory;
}

//Do a deep copy of the ConditionFactory parameter, but set the initial value to the newInitialValue
//and set the factory name accordingly.
public ConditionFactoryDefinition duplicateConditionFactory(ConditionFactoryDefinition orig, Object newInitialValue)
{
    ConditionFactoryDefinition fact = new ConditionFactoryDefinition();
    fact.ConditionDescriptionString = orig.ConditionDescriptionString;
    fact.ConditionInitialValue = newInitialValue;
    fact.ConditionIsStatic = orig.ConditionIsStatic;
    fact.ConditionName = orig.ConditionName;
    fact.InitializationArgs.AddRange(orig.InitializationArgs);
    fact.FactoryName = orig.ConditionName + "_" + newInitialValue;
    fact.PrerequisiteFactoryDefinition = orig.PrerequisiteFactoryDefinition;
    fact.ConditionType = orig.ConditionType;
    return fact;
}

     public void setConditionDescription(ConditionFactoryDefinition condition, string desc) {
  
	    //set the condition description:
	    //NOTE: The condition description is filled by:
	    // 1. Checking the message library
	    // 2. using the standalone true string if it isn't empty
	    // 3. adding the condition name to the library, which will only produce an en-US localization.
	    bool foundDesc = false;
	    for(int i = 0; (i < lsd.Count) && !foundDesc; i++) {
            if (lsd[i].Name.Equals(desc, System.StringComparison.CurrentCultureIgnoreCase))
            {
				    foundDesc = true;
                    NamedProxy<LocalizableString> descriptionPointer = new NamedProxy<LocalizableString>();
				    descriptionPointer.Name = desc;
				    condition.ConditionDescriptionString = descriptionPointer;
		    }
	    }
	    if(!foundDesc) {
		    //check the first message (the standalone true message) to see if it isn't empty
            NamedProxy<LocalizableString> stMessage = (NamedProxy<LocalizableString>)condition.InitializationArgs[0];
		    if(stMessage.Name.Equals("Empty", System.StringComparison.CurrentCultureIgnoreCase)) {
			    //The standalone true string is empty. Add a new string to the localized library and point to it.
			    lsd.Add(createSimpleLocalizableString(desc, "en-US", desc));

                NamedProxy<LocalizableString> descriptionPointer = new NamedProxy<LocalizableString>();
			    descriptionPointer.Name = desc;
                condition.ConditionDescriptionString = descriptionPointer;
		    }
		    else {
			    //Use the standalone true string as the condition description.
                condition.ConditionDescriptionString = stMessage;
		    }
	    }
    }

	public Stream writeXMLToStream(Stream outstream){
		//NOTE: This specifically allows any generated serialization or file exceptions through.
        outstream.SetLength(0); //truncate the stream
        XmlSerializer serializer = new XmlSerializer(factories.GetType(), extraSerializableTypes.ToArray());
        serializer.Serialize(outstream, factories);
		return outstream;
	}
}

prog 	

@after{
       //fill the main factory.

        //if there isn't a localized message corresponding to "Empty" in the miniconf, add it.
        bool foundEmptyString = false;
        for (int i = 0; (i < lsd.Count) && !foundEmptyString; i++)
        {
            if (lsd[i].Name.Equals("Empty", System.StringComparison.CurrentCultureIgnoreCase))
                foundEmptyString = true;
        }
        if (!foundEmptyString)
        {
            //add the message to the list of definitions
            lsd.Add(createSimpleLocalizableString("Empty", "en-US", ""));
        }

        //add the completed message library	to the main factories object.
        for (int i = 0; i < lsd.Count; i++) {
            messageLibrary.LocalizableStringDefinitions.Add(lsd[i]);
        }
       
        factories.LocalizableStrings = messageLibrary;

        //add the condition library
        factories.ConditionFactories = conditionLibrary;

        //add the sensor definitions.
        SensorTypeDefinition[] stemp = new SensorTypeDefinition[sensors.Count];
        sensors.Values.CopyTo(stemp,0);
        factories.SensorDefinitions = stemp;

        //fill and add the current conditions.
        //NEW NOTE: We really just need to add these to currentConditions via the ICollection interface.  So, currentConditions.Add or .AddRange(conditionArray)
        currentConditions.FactoryProxies = createConditionProxies();
        for (int i = 0; i < conditionArray.Count; i++)
        {
            currentConditions.Conditions.Add(conditionArray[i]);
        }
        factories.CurrentConditions = currentConditions;

        //add the factory definitions (the workflow)
        for (int i = 0; i < factoryDefinitions.Count; i++)
        {
            factories.FactoryDefinitions.Add(factoryDefinitions[i]);
        }
        
 
}
:	section+;

/** the file is split into several sections.  We may actually want to split these further,
but for now, each section is treated separately. */

section

	: 'localizations' BLOCK_OPEN //COMPLETE
		(loc=localization_def
		{
			lsd.Add($loc.value);
			//System.out.println("Just added "+$loc.value+" to the messages array");
		}
		)+ BLOCK_CLOSE 
	| 'experimentalConditions' BLOCK_OPEN (cond=condition_def)+ BLOCK_CLOSE //COMPLETE
	| 'equivalenceClasses' BLOCK_OPEN //COMPLETE
		(eq=equiv_def
		{
			//Can't ReDim in C#, so we've got to do a deep copy, etc.
		    //NOTE: This has been replaced by the concatArray<> method.
		    //PredicateFactoryDefinition[] temp = new PredicateFactoryDefinition[conditionLibrary.EquivalenceClassFactoryDefinitions.Length + 1];
           // if (conditionLibrary.EquivalenceClassFactoryDefinitions != null) {
            //    for(int i = 0; i < conditionLibrary.EquivalenceClassFactoryDefinitions.Length; i++) {
			//		temp[i] = conditionLibrary.EquivalenceClassFactoryDefinitions[i].DeepCopy();
            //    }
             //   //conditionLibrary.EquivalenceClassFactoryDefinitions.CopyTo(temp, conditionLibrary.EquivalenceClassFactoryDefinitions.Length);
            //}
            //temp[temp.Length - 1] = $eq.value;
            //conditionLibrary.EquivalenceClassFactoryDefinitions = temp;
            
            conditionLibrary.EquivalenceClassFactoryDefinitions = concatArray<PredicateFactoryDefinition>(conditionLibrary.EquivalenceClassFactoryDefinitions, $eq.value);
		}	
		)+ BLOCK_CLOSE
	| 'sensors' BLOCK_OPEN //COMPLETE
		(s=sensor_def 
		{
			sensors.Add($s.name, $s.sensor);
			//System.out.println("Added "+$s.name+" to the sensor array");
		})+ BLOCK_CLOSE
	| 'configurations' BLOCK_OPEN //BASICALLY COMPLETE -- Only allowing block-type assignments, not XML fragments or literal file references.
		(c=config_def
		)+ BLOCK_CLOSE
	| 'tasks' BLOCK_OPEN task_def+ BLOCK_CLOSE // COMPLETE
	| 'initialState' BLOCK_OPEN
	 	(init_state=init_state_def
		{
			currentConditions.Conditions.Add($init_state.value);
		}
		)+ BLOCK_CLOSE
	| 'workflow' BLOCK_OPEN w=workflow_def+ BLOCK_CLOSE
	;
	
/**Localizations section *********************************************************************************************/
localization_def returns[LocalizableStringDefinition value]
	@init {
		LocalizableStringDefinition loc = new LocalizableStringDefinition();
	}
	@after {
		loc.Name = $name.value;
		$value = loc;
	}
	: name=localization_name BLOCK_OPEN 
	(pair=localization_assignment
	{
		loc.RegionMessagePairs.Add($pair.value);
		//System.out.println("Just added "+$pair.value+" to localization named "+$name.value);
	}
	EOL)* BLOCK_CLOSE
	
	;
	
localization_name returns[String value]
	: b=block_id {$value = $b.value;};
	
localization_assignment returns[RegionMessagePair value]
		:	a=string_literal_assignment
		{
		 RegionMessagePair pair = new RegionMessagePair();
		 pair.Region = $a.key; 
		 pair.Message = $a.value;
		 $value = pair;
		 }
	;

/**Conditions section ********************************************************************************************/		

condition_def returns[ConditionFactory value]
	@init{
		ConditionFactoryDefinition condition = new ConditionFactoryDefinition();
		Dictionary<String, List<String>> tempMessages = new Dictionary<String, List<String>>();
		ArrayList initializationArgs = new ArrayList();
		String unmetMessageTemp = "Empty"; //default to pulling the Empty message from the localized message library.
	}
           
	@after {
		//mark the condition as static or not.
		condition.ConditionIsStatic = $sig.isStatic;
		//right now, only set the condition type when the return value
		//is boolean, because we're not dealing with other types yet.
		if($sig.conditionType == "boolean"){
			condition.ConditionType = ConditionType.BooleanCondition;
		}
		
		//organize the messages into the proper order and store them.
		
		//FIXME: Because these are ordering-dependent, things will be incorrect if there are fewer than 3 messages
		//in either standalone- or compoundMessages.
		List<String> results;
		if((results = tempMessages["standaloneMessages"]) != null){		
			for(int i = 0; i < results.Count; i++) {
				NamedProxy<LocalizableString> tempProxy = new NamedProxy<LocalizableString>();
				tempProxy.Name = results[i];
				initializationArgs.Add(tempProxy);
			} 
		}
		else {
			for(int i = 0; i < 3; i++){ 
				NamedProxy<LocalizableString> tempProxy = new NamedProxy<LocalizableString>();
				tempProxy.Name = "Empty";
		        initializationArgs.Add(tempProxy);
			}
		}
		
		if((results = tempMessages["compoundMessages"]) != null){		
			for(int i = 0; i < results.Count; i++) {
				NamedProxy<LocalizableString> tempProxy = new NamedProxy<LocalizableString>();
				tempProxy.Name = results[i];
				initializationArgs.Add(tempProxy);
			} 
		}
		else {
			for(int i = 0; i < 3; i++){ 
				NamedProxy<LocalizableString> tempProxy = new NamedProxy<LocalizableString>();
				tempProxy.Name = "Empty";
		        initializationArgs.Add(tempProxy);
			}
		}
		//System.out.println("Initialization args (condition messages) for "+$name.value+" has length "+initializationArgs.getAnyTypeCount());
		//add the resulting array to the condition factory.
		condition.InitializationArgs.AddRange(initializationArgs);
		
		//If the condition's initial value hasn't been set, set it to false.
		if(condition.ConditionInitialValue == null)
			condition.ConditionInitialValue = false;
		
		//set the name of the factory
		//NOTE: The factory name (NOT the condition name) MUST be unique.
		condition.FactoryName = $name.value + "_" + condition.ConditionInitialValue;
		condition.ConditionName = $name.value;
				
		//set the condition description
		setConditionDescription(condition, $name.value);
		
		//add the UnmetPrerequisiteMessage to the PrerequisiteFactory,
		//then add the factory to the main factory for this condition.
		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
		unmetPointer.Name = unmetMessageTemp;
		condition.PrerequisiteFactoryDefinition.UnmetPrerequisiteMessage = unmetPointer;
		
		//BiCCL only allows boolean condition definitions here, so set the type to match.
		condition.ConditionType = ConditionType.BooleanCondition;

		//add the condition to the proper parent object.
		conditionLibrary.FactoryDefinitions = concatArray<ConditionFactoryDefinition>(conditionLibrary.FactoryDefinitions, condition);

		//System.out.println("Just added condition "+condition.getConditionName()+" to the condition library");
	}
    
	: sig=condition_signature name=condition_name BLOCK_OPEN 
	((a=condition_initval
	{
		condition.ConditionInitialValue = $a.value;
	})
	|(b=condition_message_assignment
	{
		tempMessages.Add($b.type, $b.value);
	})
	|(c=condition_unmet_prereq
	{
		//this is used in the PrerequisiteFactory object.
		unmetMessageTemp = $c.value;
	})
	|(d=condition_requires
	{
		//System.out.println("This condition got a predicate factory: "+$d.value);
		condition.PrerequisiteFactoryDefinition = $d.value;
	}))+
	BLOCK_CLOSE
	
		;

condition_signature returns[bool isStatic, String conditionType]
	: a='static'? b=RETURN_TYPE
	{
		$isStatic = ($a != null);
		$conditionType = $b.text;
	}
	;	

condition_name returns[String value]
	: b=block_id {$value = $b.value;};	

condition_initval returns[Object value] //this return value is intentionally vague at the moment to allow for different condition types.
	:'initialValue' '=' a=boolean EOL {$value = $a.value;}
	;
	
condition_message_assignment returns[String type, List<String> value]
	@init {
		List<String> messages = new List<String>();
	}
	:mtype=condition_message_type BLOCK_OPEN 
	(loc=condition_localization_assignment
	{
		//NOTE: Currently, this is stored in an array that
		//infers which message is which based on ordering.
		//Therefore, we're ignoring the message id stored in
		//the key field
		messages.Add($loc.value); 
	}
	EOL)+ BLOCK_CLOSE
	{
		$value = messages;
		$type = $mtype.text;
	}
	;
	
condition_unmet_prereq returns[String value]
	: 'unmetPrerequisiteMessage' '=' a=unmet_prereq_message EOL {$value = $a.value;}
	;
	
condition_requires returns[PredicateFactoryDefinition value]
	: 'requires' BLOCK_OPEN a=predicate_factory EOL? BLOCK_CLOSE 
	{
		$value = $a.value;
		//System.out.println("Trying to build a predicate factory out of: "+$a.text);
	}
	;
	
condition_message_type
	:	'standaloneMessages'|'compoundMessages';

unmet_prereq_message returns[String value]
	:	a=name_or_string {$value=$a.value;};


/**Equivalence section ***********************************************************************************************/

equiv_def returns [PredicateFactoryDefinition value]
	: name=block_id BLOCK_OPEN p=predicate_factory EOL? BLOCK_CLOSE EOL?
	{
		//Each of these creates an "EquivalenceClasses" element of type PredicateFactory
		//set the name of the (possibly compound) predicate to the name specified for this equivalence class.
		$p.value.Name = $name.value;
		$value = $p.value;
	}
	;
	
	
/**Sensors section ***************************************************************************************************/

sensor_def returns[String name, SensorTypeDefinition sensor]
	: id=sensor_name BLOCK_OPEN
		plugin=sensor_plugin
		snamespace=sensor_namespace
		sclass=sensor_class	
		conf=sensor_conf_class
	  BLOCK_CLOSE
	  {
		  
          SensorTypeDefinition s = new SensorTypeDefinition();
          s.ClassName = $snamespace.value + "." + $sclass.value;
          s.LibraryFileName = $plugin.value;
          s.HasConfigurationClass = true; //this is always true, we're requiring it.
          //s.ConfigurationClassName = sensorConfigurationNamespace + $conf.value;
          s.ConfigurationClassName = $snamespace.value + "." + $conf.value;
          $sensor = s;
          $name = $id.value;
          sensorNamespaces.Add($name,$snamespace.value);
	 }
	;
	
sensor_name returns[String value] : block=block_id {$value = $block.value;};
sensor_plugin returns[String value]
	: 'libraryFileName' '=' plugin=name_or_string EOL
	{$value = $plugin.value;}
	;
sensor_namespace returns[String value]
	: 'sensorNamespace' '=' ns=name_or_string EOL
	{$value = $ns.value;}
	;
sensor_class returns[String value]
	: 'sensorClassName' '=' conf=name_or_string EOL
	{$value = $conf.value;}
	;
	
sensor_conf_class returns[String value]
	: 'configurationClassName' '=' conf=name_or_string EOL
	{$value = $conf.value;}
	;


/**Configurations section ********************************************************************************************/

config_def
	@init{
	  object sensorConfig;
      Type typeOfSensorConfig;
	}
	: config_literal EOL
	| 'xml' config_type config_name BLOCK_OPEN
	  //FIXME: SOMETHING HERE :-)
	   BLOCK_CLOSE
	 | type=config_type
		{
			try {
                /*First, figure out if we have a sensor of this type defined already.*/
                SensorTypeDefinition foundSensor = null;
                foreach(KeyValuePair<String,SensorTypeDefinition> kvp in sensors){
					String sName = kvp.Key;
					SensorTypeDefinition s = kvp.Value;
					String sNamespace = sensorNamespaces[sName]+".";
                    Console.WriteLine("Looking for a config class matching "+ sNamespace + $type.value);
                    if(s.ConfigurationClassName.Equals(sNamespace + $type.value)) {
                        foundSensor = s;
                        break;
                    }
                }
                if(foundSensor == null) throw new InvalidDataException("No sensor defined that provides the requested configuration class "+$type.value);
                        
                //at this point, we know there is a sensor of the proper type defined.  Load its DLL and attempt to instantiate a matching SensorConfiguration.
                Assembly assem;
                String currentPath = AppDomain.CurrentDomain.BaseDirectory;
                try {
					Console.WriteLine("Looking for sensor dlls in "+currentPath);
					assem = Assembly.LoadFile(currentPath + foundSensor.LibraryFileName);
				}
				catch(Exception e) {
					//look in the 'Sensors' subdir, then fail if the DLL isn't there either.
					Console.WriteLine("Looking for the following DLL: \n"+currentPath + "Sensors"+Path.DirectorySeparatorChar + foundSensor.LibraryFileName);
					assem = Assembly.LoadFile(currentPath + "Sensors"+Path.DirectorySeparatorChar + foundSensor.LibraryFileName);
					
				}
                //typeOfSensorConfig = Type.GetType(foundSensor.ConfigurationClassName);
                //NOTE: DO NOT Prepend the sensorNamespace onto the configuration class -- this is done when the configurationClassName is first set in the Sensor definition.
                sensorConfig = assem.CreateInstance(foundSensor.ConfigurationClassName);
                typeOfSensorConfig = sensorConfig.GetType();
                //add this to the list of additional types so that the serializer can use them later.
                extraSerializableTypes.Add(typeOfSensorConfig);
  				Console.WriteLine("created sensor configuration "+sensorConfig);
			}
			catch(Exception e) {
				Console.WriteLine("Couldn't find or instantiate config class "+$type.value+", using default sensor type.\n"+e.Message);
				sensorConfig = new SensorConfiguration();
                typeOfSensorConfig = Type.GetType("SensorConfiguration");
			}
		} 
		name=config_name BLOCK_OPEN
		(pair=assignment
		 {
	
			//Fill all sensor values via reflection.
			try {
				//try to get the type of the field we're about to set
				Type newType;
				try {
					newType = typeOfSensorConfig.InvokeMember($pair.key, BindingFlags.GetField | BindingFlags.GetProperty ,null,sensorConfig,null).GetType();
				}catch(Exception te){
					//check the base class as well, and fail if it isn't there either.
					newType = typeOfSensorConfig.BaseType.InvokeMember($pair.key, BindingFlags.GetField  | BindingFlags.GetProperty ,null,sensorConfig,null).GetType();
				}
				object[] assignedVal = new object[1];
				//if necessary, try to coerce the thing we've got into the format we need.
				if(newType != $pair.value.GetType()) {
					Console.WriteLine("Attempting to coerce "+$pair.value.GetType()+" into "+newType+" for field "+$pair.key);
					assignedVal[0] = Convert.ChangeType($pair.value, newType);
				}
				else {
					assignedVal[0] = $pair.value;
				}
                typeOfSensorConfig.InvokeMember($pair.key, BindingFlags.SetField  | BindingFlags.SetProperty ,null,sensorConfig,assignedVal);
			}
			catch(Exception e) {
				Console.WriteLine("Param "+$pair.key+" seems not to exist in "+typeOfSensorConfig.ToString()+", so we can't add the value to the sensor config.");
				Console.WriteLine("Error: "+e);
			}

		 }
		 EOL)* 
		 {
			//Add the filled config object to configs.
		 	//C# NOTE: THIS MAY RESULT IN AN UNUSABLE VERSION OF SENSORCONFIG -- WE MAY NEED TO ACTUALLY CAST TO THE RIGHT SUBTYPE.
		 	configs.Add($name.value, (SensorConfiguration)sensorConfig);
		 } BLOCK_CLOSE//allow this to be empty  
	  ;
	
config_literal : string_literal_assignment;
config_type returns[String value]:	b=block_id {$value = $b.value;};
config_name returns[String value]:	b=block_id {$value = $b.value;};


/** Tasks section ****************************************************************************************************/

task_def
	: name=task_name
 	BLOCK_OPEN
	sensor=task_sensor 
	conf=task_conf
	intended=task_primary_cat
	others=task_reassignable_cat
	//any other relevant assignments would go here.
	//NOTE: Nothing else allowed at the moment.
	//(assignment EOL)*
	BLOCK_CLOSE
	{
      	//create the Task object
        Task tempTask = new Task($name.value);
		
        //check to make sure that the declared sensor actually exists, add it if it does,
        // and complain if not.
        bool foundSensor = false;
		// foreach(SensorTypeDefinition tempSensor in sensors.Values) {  
		//	  if(tempSensor.ClassName.Equals(sensorNamespace+$sensor.value)) {
		//      foundSensor = true;
		//      tempTask.setSensor(sensorNamespace+$sensor.value);
		 // }
		//}
      
		if(sensors.ContainsKey($sensor.value)){
			foundSensor = true;
			tempTask.setSensor(sensors[$sensor.value].ClassName);
		}
        else {
	        Console.WriteLine("Tried to use sensor "+$sensor.value+" in task "+$name.value+", but no sensor with that name is defined");
        }
	
        //which sensor configuration will this task use?
        tempTask.setConfiguration($conf.value);

        //add the intended submodality
        if (Enum.IsDefined(typeof(SensorTaskCategory), $intended.value)){
            SensorTaskCategory intendedCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),$intended.value);
            tempTask.setIntendedCategory(intendedCat);
        }
        else{
            Console.WriteLine("Tried to mark task "+$name.value+" as having intended submodality "+$intended.value+", which isn't one of the valid task submodalities.");
        }
        
        //Gather and add the reassignable submodalities
        List<SensorTaskCategory> reassignableList = new List<SensorTaskCategory>();
        foreach(String tc in $others.value) {
            if (Enum.IsDefined(typeof(SensorTaskCategory),tc)){
                SensorTaskCategory reassignableCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),tc);
                reassignableList.Add(reassignableCat);
            }
            else{
                Console.WriteLine("Tried to mark task "+$name.value+" as having rassignable submodality "+tc+", which isn't one of the valid task submodalities.");
            }
        }
        tempTask.setReassignableCategories(reassignableList);
        
        //add the task to our Dictionary for later reference.
        tasks.Add($name.value, tempTask);
	}
	;


task_name returns[String value] :	b=block_id {$value = $b.value;};
task_sensor returns[String value]  : 'sensor' '=' a=name_or_string EOL {$value = $a.value;};
task_conf returns[SensorConfiguration value]:	'configuration' '=' a=name_or_string EOL {$value = configs[$a.value];};
task_primary_cat returns[String value]: 'intendedSubmodality' '=' a=name_or_string EOL {$value = $a.value;};	
task_reassignable_cat  returns[List<String> value]:	'reassignableSubmodalities' '=' a=set_of_strings EOL {$value = $a.value;};


/** Initial state section ********************************************************************************************/

//This is where the CurrentConditions are generated.  At the moment, this takes advantage of the fact that
//only boolean conditions exist, but could be expanded later to include other condition types.

//NOTE: This intentionally leaves out the Prerequisite subelement, which is a Predicate object, because we can't generate it from here.
//MBARK itself will insert the object based on the predicate factories we give it.
init_state_def returns[BooleanConditionDefinition value]
	: a=boolean_assignment 
	{
  		BooleanConditionDefinition cond = new BooleanConditionDefinition();
		cond.OriginatingFactory = $a.key + "_" + $a.value;
		cond.BooleanValue = $a.value;
		//set messages based on the matching factory in the condition library.
		bool foundFactory = false;
		for(int i = 0; (i < conditionLibrary.FactoryDefinitions.Length) && !foundFactory; i++) {
			if(conditionLibrary.FactoryDefinitions[i].ConditionName.Equals($a.key, System.StringComparison.CurrentCultureIgnoreCase)) {
				//we've found a matching factory object.  Set the localized messages for this condition,
				//then hop out of the loop.
				ArrayList messages = conditionLibrary.FactoryDefinitions[i].InitializationArgs;
				cond.StandaloneTrueString = ((NamedProxy<LocalizableString>) messages[0]);
				cond.StandaloneFalseString = ((NamedProxy<LocalizableString>) messages[1]);
				cond.StandaloneInvalidString = ((NamedProxy<LocalizableString>) messages[2]);
				cond.CompoundTrueString = ((NamedProxy<LocalizableString>) messages[3]);
				cond.CompoundFalseString = ((NamedProxy<LocalizableString>) messages[4]);
				cond.CompoundInvalidString = ((NamedProxy<LocalizableString>) messages[5]);
				foundFactory = true;
			}
		}
		$value = cond;
	} 
	EOL
	;


/**Workflow section **************************************************************************************************/

//FIXME: We want this to be nestable, but if so, we NEEEED to track the current condition tree (every if test that passed or failed),
//because the FULL state is saved.
workflow_def
	: w=workflow_statement {
		factoryDefinitions.Add(createTaskFactory($w.taskName, $w.count, $w.prox));
	}
	| 'if' '(' a=predicate_factory ')' BLOCK_OPEN 
		(b=workflow_statement
		{
			SensorTaskFactoryDefinition toAdd = createTaskFactory($b.taskName, $b.count, $b.prox);
			//add a TaskPrerequisite (which is a PredicateFactoryDefinition object) to the factory
			toAdd.PrerequisiteDefinition = $a.value;
			factoryDefinitions.Add(toAdd);
			
		})+ BLOCK_CLOSE
		('else' BLOCK_OPEN 
		(c=workflow_statement
		{
			
			SensorTaskFactoryDefinition toAdd = createTaskFactory($c.taskName, $c.count, $c.prox);
			//Add a TaskPrerequisite (which is a PredicateFactory object) to the factory.
			//This predicate has to be the negated version of the one used in the "if" clause.
			PredicateFactoryDefinition np = new PredicateFactoryDefinition();
			np.PredicateType = PredicateType.NotPredicate;
			//add the if-statement's factory here; it is negated by this not-predicate.
			np.FactoryArgDefinitions = concatArray<object>(np.FactoryArgDefinitions, $a.value);
			
			//get the unmet prereq string from the predicate we're negating.  Add it to this predicate.
			np.UnmetPrerequisiteMessage = ($a.value).UnmetPrerequisiteMessage;
			
			//add the task factory to the main factory definitions.
			toAdd.PrerequisiteDefinition = np;
			factoryDefinitions.Add(toAdd);
		})+ BLOCK_CLOSE)?
	;

workflow_statement returns [String taskName, int count, ConditionFactoryProxyCollectionDefinition prox]
	: 'perform' a=INT b=NAME (c=with_state {$prox = $c.value;})? EOL {$count = Int32.Parse($a.text); $taskName = $b.text;}
	;

//FIXME: This needs to hold values as well (temperature = 90)	
//NOTE: This will modify the condition library if the conditions mentioned here don't already exist.
with_state returns[ConditionFactoryProxyCollectionDefinition value]
	: 'with' a=set_of_assignments {
		ConditionFactoryProxyCollectionDefinition prox = new ConditionFactoryProxyCollectionDefinition();
		//add equivalence classes first
		for(int i = 0; i < conditionLibrary.EquivalenceClassFactoryDefinitions.Length; i++) {
			NamedProxy<PredicateFactory> tempName = new NamedProxy<PredicateFactory>();
			tempName.Name = conditionLibrary.EquivalenceClassFactoryDefinitions[i].Name;
			prox.EquivalenceClassProxies = concatArray<NamedProxy<PredicateFactory>>(prox.EquivalenceClassProxies, tempName);
		}
		
		//then, add conditions.

		//Check each assignment to see if it's in the condition library already.
		//If so, create a proxy and add that to the return object.  Otherwise,
		//create a new ConditionFactory for it, add that to the condition library,
		//THEN create a proxy and add that to the return object.
		foreach(KeyValuePair<String, object> kvp in $a.value) {
			
			//System.out.println("\nGot a with clause item... "+entry.getKey()+":"+entry.getValue());	
			NamedProxy<ConditionFactory> tempName = new NamedProxy<ConditionFactory>();
			int foundNameIndex = -1;
			int foundConditionIndex = -1;	
	
			for(int i = 0; i < conditionLibrary.FactoryDefinitions.Length && foundConditionIndex < 0; i++) {
				ConditionFactoryDefinition checkedCondition = conditionLibrary.FactoryDefinitions[i];
				//System.out.println("Checking new entry name "+entry.getKey()+" against condition named "+checkedCondition.getConditionName());
				
				if(kvp.Key.Equals(checkedCondition.ConditionName, System.StringComparison.CurrentCultureIgnoreCase)){
					foundNameIndex = i;
					//then we've got a match.  Check the initial value.
					//If it matches, just create a proxy.
					if (kvp.Value.Equals(checkedCondition.ConditionInitialValue)) {
						foundConditionIndex = i;
						tempName.Name = checkedCondition.FactoryName;
						prox.ConditionFactoryProxies = concatArray<NamedProxy<ConditionFactory>>(prox.ConditionFactoryProxies, tempName);
					}
				}
			}	
			if(foundNameIndex >= 0 && foundConditionIndex < 0) {
				//we found a condition with the same condition name as one in the library, but a different
				//initial value.  Create a new condition and a proxy to point to it.
				/*System.out.println(entry.getKey()+":"+entry.getValue()+" doesn't match "+
									conditionLibrary.getFactory(foundNameIndex).getConditionName()+
									":"+conditionLibrary.getFactory(foundNameIndex).getConditionInitialValue()+
									", creating factory and proxy");*/
				ConditionFactoryDefinition newFactory = duplicateConditionFactory(conditionLibrary.FactoryDefinitions[foundNameIndex], kvp.Value); //do a deep copy
				conditionLibrary.FactoryDefinitions = concatArray<ConditionFactoryDefinition>(conditionLibrary.FactoryDefinitions,newFactory); //add the factory to the library
				tempName.Name = newFactory.FactoryName; //set the proxy to point to the new factory.
				prox.ConditionFactoryProxies = concatArray<NamedProxy<ConditionFactory>>(prox.ConditionFactoryProxies, tempName);	//add the proxy
			}
			//if we didn't find a match, complain.
			else if(foundNameIndex < 0) {
				Console.WriteLine("WARNING: Couldn't use the 'with' condition "+kvp.Key+" because it didn't match any existing condition.");
			}
		}
		
		$value = prox;}
	;

/** Begin Predicate factory definition. ******************************************************************************/

// Predicate definition, lifted in part from:
// http://www.cs.man.ac.uk/~pjj/cs2121/ho/node4.html

//So...
// pred -> pred_CA, pred || pred_CA
// pred_CA -> atom, pred_CA && atom
// atom -> stuff, '(' pred ')'

//HOWEVER, that's a left-recursive grammar, which
//isn't available to us, so this is right-recursive,
//and has a couple of other tweaks to allow ANTLR to
//succesfully build it.

//C# NOTE:
//These aren't PredicateFactory objects, they need to be PredicateFactoryDefinitions

predicate_factory returns[PredicateFactoryDefinition value]
	@after{
		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
		//as it is required by all Predicates.
		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
		unmetPointer.Name = "Empty";
		$value.UnmetPrerequisiteMessage = unmetPointer;
	}
	: a=predicate_factory_compoundAnd (OR_OP b=predicate_factory)?
	{
		if(b == null) {
			$value = $a.value;
		}
		else {
			PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
			pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, $a.value);
			pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, $b.value);
			pfact.PredicateType = PredicateType.CompoundOrPredicate;
			$value = pfact;
		}
	}
	;

predicate_factory_compoundAnd returns[PredicateFactoryDefinition value]
	@after{
		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
		//as it is required by all Predicates.
		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
		unmetPointer.Name = "Empty";
		$value.UnmetPrerequisiteMessage = unmetPointer;
	}
	: a=predicate_factory_atom (AND_OP b=predicate_factory_compoundAnd)?
	{
		if(b == null) {
			$value = $a.value;
		}
		else {
			PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
			pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, $a.value);
			pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, $b.value);
			pfact.PredicateType = PredicateType.CompoundAndPredicate;
			$value = pfact;
		}
	}
	;

predicate_factory_atom returns[PredicateFactoryDefinition value]
	@after{
		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
		//as it is required by all Predicates.
		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
		unmetPointer.Name = "Empty";
		$value.UnmetPrerequisiteMessage = unmetPointer;
	}	
	: p=predicate_factory_atom_base 
	{
		$value = $p.value;
	}
	| notop=NOT_OP? '(' pred=predicate_factory ')' 
	{
		if($notop != null) {
			PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
			pfact.PredicateType = PredicateType.NotPredicate;
			pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, $pred.value);
			$value = pfact;
		}
		else
			$value = $pred.value;
	}
	;

predicate_factory_atom_base returns[PredicateFactoryDefinition value]
	@init{
		PredicateFactoryDefinition pred = new PredicateFactoryDefinition();
	}
	@after{
		$value = pred;
	}
	: pb=pred_boolean //A literal boolean value
	{
		pred.PredicateType = PredicateType.LiteralPredicate;
		pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pb.value);
	}
	| prsing=pred_reserved_single //An assignment of a single value to one of the reserved words.
	{
		//FIXME, SORT OF: Because of what appears to be a bug in Castor, when the SensorModality object is
		//marshalled as part of a FactoryArgument, the toString() method is never called, so the value isn't inserted.
		//Instead, we'll just put in the value and put it into a FactoryArgument in the transformation stylesheet at the end.

        //C# note: reverting to the proper structure.
		if($prsing.key.Equals("submodality",System.StringComparison.CurrentCultureIgnoreCase)){
			pred.PredicateType = PredicateType.CategoryEqualsLiteralPredicate;
            if (Enum.IsDefined(typeof(SensorTaskCategory), $prsing.value)){
                SensorTaskCategory predCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),$prsing.value);
                pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, predCat);
            }
            else{
                Console.WriteLine("Sensor task submodality "+$prsing.value+" doesn't exist.");
            }
		}
		else if ($prsing.key.Equals("modality", System.StringComparison.CurrentCultureIgnoreCase)){
			pred.PredicateType = PredicateType.SensorModalityEqualsLiteralPredicate;
			
            if (Enum.IsDefined(typeof(SensorModality), $prsing.value)){
                SensorModality predCat = (SensorModality) Enum.Parse(typeof(SensorModality),$prsing.value);
                pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, predCat);
            }
            else{
                Console.WriteLine("Sensor task modality "+$prsing.value+" doesn't exist.");
            }
		}
	}
	| prset=pred_reserved_set //An assignment of a set to one of the reserved words.
	{
		if($prset.key.Equals("submodality", System.StringComparison.CurrentCultureIgnoreCase)){
			pred.PredicateType = PredicateType.CategoryContainedInSetPredicate;

			System.Collections.ObjectModel.Collection<SensorTaskCategory> validSubmodalities = new System.Collections.ObjectModel.Collection<SensorTaskCategory>();
			foreach(String category in $prset.value) {
				 if (Enum.IsDefined(typeof(SensorTaskCategory), category)){
                     SensorTaskCategory predCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),category);
                     validSubmodalities.Add(predCat);
                     //NOTE: This is actually an array of a single collection because of the way it's processed by MBARK.
                     pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, validSubmodalities);
                 }
                 else{
                     Console.WriteLine("Sensor task submodality array contains a submodality ("+category+") that doesn't exist, and which will be ignored.");
                 }
			 }
		 }
		 else if($prset.key.Equals("modality", System.StringComparison.CurrentCultureIgnoreCase)){
		 	Console.WriteLine("The 'modality in {}' construct is not yet available to use.");
		 }

	}

	| pno=pred_numerical_other //A numerical assignment
	{
		pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pno.key);
        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pno.value);
	}
	| pe=pred_evaluation //Any other type of assignment
	{
        pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pe.key);
        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pe.value);
	}
	| pes=pred_evaluation_short //A short-form boolean assignment (either someVariable or ~someVariable)
	{
      pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
      pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pes.key);
      pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, $pes.value);
	}
	;

pred_boolean returns[bool value] :	b=boolean {$value = $b.value;};
pred_reserved_single returns[String key, String value] : a=reserved_word '==' b=name_or_string {$key = $a.text; $value = $b.value;};
pred_reserved_set returns[String key, List<String> value] : a=reserved_word 'in' b=set_of_strings {$key = $a.text; $value = $b.value;};
pred_numerical_other returns[String key, String op, double value] :	a=NAME b=MATH_OP c=number {$key = $a.text; $op = $b.text; $value = $c.value;};

pred_evaluation returns[String key, object value]
	: a=NAME {$key = $a.text;} '==' 
	(b=boolean {$value = $b.value;}
	|c=number {$value = $c.value;}
	|d=name_or_string {$value = $d.value;})
	;

pred_evaluation_short returns[String key, bool value] : a=negatable_name {$key = $a.value; $value = (!($a.isNegated));};


/**The different types of basic assignments we allow *****************************************************************/

assignment returns[String key, object value]
	: a=condition_localization_assignment {$key = $a.key;$value = $a.value;}
	|b=string_literal_assignment {$key = $b.key;$value = $b.value;}
	|c=boolean_assignment {$key = $c.key;$value = $c.value;}
	|d=int_assignment {$key = $d.key;$value = $d.value;}
	//|e=variable_assignment {$key = $e.key;$value = $e.value;}
	;

boolean_assignment returns [String key, bool value]	: NAME '=' a=boolean {$key = $NAME.text; $value = $a.value;};

condition_localization_assignment returns[String key, String value] 
	: a=condition_localization_type '=' b=name_or_string
	{
		$key = $a.text;
		$value = $b.value;
	}
	;
condition_localization_type :	'trueMessage'|'falseMessage'|'invalidMessage';

int_assignment returns [String key, int value] :	NAME '=' INT {$key = $NAME.text; $value = int.Parse($INT.text);};
string_literal_assignment returns [String key, String value]: a=NAME '=' b=name_or_string {$key = $a.text; $value = $b.value;};
variable_assignment returns [String key, String value] :	a=NAME '=' b=NAME {$key = $a.text; $value = $b.text;};
	

//FIXME: Sets should be parameterized, not a set of rules!!
set_of_names returns [List<String> value]
	@init{
	List<String> results = new List<String>();
	}
	@after{  
		$value = results;
	}
	: null_term
	| BLOCK_OPEN a=negatable_name BLOCK_CLOSE {results.Add($a.value);}
	| BLOCK_OPEN b=negatable_name {results.Add($b.value);} 
		(',' c=negatable_name {results.Add($c.value);})+ BLOCK_CLOSE 
	;
	
set_of_strings returns [List<String> value]
	@init{
		List<String> results = new List<String>();
	}
	@after{  
		$value = results;
	}
	: null_term
	| BLOCK_OPEN a=name_or_string BLOCK_CLOSE {results.Add($a.value);}
	| BLOCK_OPEN b=name_or_string {results.Add($b.value);} 
		(',' c=name_or_string {results.Add($c.value);})+ BLOCK_CLOSE 
	;

set_of_assignments returns[Dictionary<String, object> value]
	@init{
		Dictionary<String, object> results = new Dictionary<String, object>();
	}
	@after{  
		$value = results;
	}
	: null_term
	| BLOCK_OPEN a=assignment BLOCK_CLOSE {results.Add($a.key, $a.value);}
	| BLOCK_OPEN b=assignment {results.Add($b.key, $b.value);} 
		(',' c=assignment{results.Add($c.key, $c.value);})+ BLOCK_CLOSE
	;


/**Miscellaneous lower-level grammar productions *********************************************************************/

reserved_word	: 'modality'|'submodality';

block_id  returns[String value]: id=NAME {$value = $id.text;} ; //used to identify a symbol, task name, anything that is followed by a block but isn't a function def.

boolean returns[bool value]:	b=BOOLEAN {$value = bool.Parse($b.text);};
rvalue	:	null_term|boolean|number|name_or_string;

name_or_string returns[String value]
	: null_term{$value="Empty";}
	| a=NAME{$value=$a.text;}
	| b=STRING{$value=$b.text.Substring(1,$b.text.Length-2);}
	;
	
//C# NOTE: We don't have a general-purpose Number class, so parse everything as a double for now.
number	returns[double value]
	: INT {$value = double.Parse($INT.text);}
	| FLOAT {$value = double.Parse($FLOAT.text);}
	;

negatable_name returns[String value, bool isNegated]
	: a=NOT_OP? b=NAME 
	{
		if($a != null) $isNegated=true;
		$value = $b.text;
	}
	;

null_term :	'none';
	
/** LEXICAL RULES ****************************************************************************************************/

BOOLEAN :	'true' | 'false';
	
INT : ('0'..'9')+ ;
FLOAT	:	INT '.' INT;
MATH_OP	:	'>='|'<='|'!=';
RETURN_TYPE :	('boolean'|'string'|'int'); //allowed return types for conditions, etc.
//at least one letter followed by 0 or more letters or numbers, allowing underscores as well.
NAME	:	('a'..'z'|'A'..'Z'|'_')('a'..'z'|'A'..'Z'|'_'|'-'|'0'..'9')*; 
NOT_OP	:	'~';
AND_OP	:	'&&';
OR_OP	:	'||';
BLOCK_OPEN :	'{';
BLOCK_CLOSE :	'}';
EOL	:	';'; //the end-of-line marker
//NOTE: newlines are optional here because of a bug in the way that ANTLR Java grammars
//handle the input text.
SL_COMMENT :	'//'
		(~('\n'|'\r'))* ('\n'|'\r'('\n')?)?
		{$channel=HIDDEN;}
	;
ML_COMMENT
    :   '/*' (options {greedy=false;} : .)* '*/' {$channel=HIDDEN;}
    ;
    	    
//anything enclosed in quotes.
STRING: '\'' ( ~'\'' )+ '\'' 
       |'"'( ~'"' )+ '"'
       ;     

WS    : (' ' |'\t' )+	{ $channel = HIDDEN; } ;
NL    : '\r' ? '\n'	{ $channel = HIDDEN; /*mynewlineaction();*/ };
