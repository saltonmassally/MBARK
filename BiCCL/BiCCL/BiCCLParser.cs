// $ANTLR 3.1.3 Mar 17, 2009 19:23:44 C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g 2009-06-02 14:49:03

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162



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



using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


namespace 
	NIST.BiCCL

{
public partial class BiCCLParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"BLOCK_OPEN", 
		"BLOCK_CLOSE", 
		"EOL", 
		"RETURN_TYPE", 
		"INT", 
		"NAME", 
		"OR_OP", 
		"AND_OP", 
		"NOT_OP", 
		"MATH_OP", 
		"BOOLEAN", 
		"STRING", 
		"FLOAT", 
		"SL_COMMENT", 
		"ML_COMMENT", 
		"WS", 
		"NL", 
		"'localizations'", 
		"'experimentalConditions'", 
		"'equivalenceClasses'", 
		"'sensors'", 
		"'configurations'", 
		"'tasks'", 
		"'initialState'", 
		"'workflow'", 
		"'static'", 
		"'initialValue'", 
		"'='", 
		"'unmetPrerequisiteMessage'", 
		"'requires'", 
		"'standaloneMessages'", 
		"'compoundMessages'", 
		"'libraryFileName'", 
		"'sensorNamespace'", 
		"'sensorClassName'", 
		"'configurationClassName'", 
		"'xml'", 
		"'sensor'", 
		"'configuration'", 
		"'intendedSubmodality'", 
		"'reassignableSubmodalities'", 
		"'if'", 
		"'('", 
		"')'", 
		"'else'", 
		"'perform'", 
		"'with'", 
		"'=='", 
		"'in'", 
		"'trueMessage'", 
		"'falseMessage'", 
		"'invalidMessage'", 
		"','", 
		"'modality'", 
		"'submodality'", 
		"'none'"
    };

    public const int T__29 = 29;
    public const int T__28 = 28;
    public const int T__27 = 27;
    public const int T__26 = 26;
    public const int T__25 = 25;
    public const int T__24 = 24;
    public const int T__23 = 23;
    public const int T__22 = 22;
    public const int T__21 = 21;
    public const int FLOAT = 16;
    public const int MATH_OP = 13;
    public const int EOF = -1;
    public const int T__55 = 55;
    public const int ML_COMMENT = 18;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int NAME = 9;
    public const int T__58 = 58;
    public const int BOOLEAN = 14;
    public const int EOL = 6;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int T__54 = 54;
    public const int T__59 = 59;
    public const int NL = 20;
    public const int T__50 = 50;
    public const int NOT_OP = 12;
    public const int RETURN_TYPE = 7;
    public const int T__42 = 42;
    public const int OR_OP = 10;
    public const int T__43 = 43;
    public const int BLOCK_OPEN = 4;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int T__46 = 46;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int INT = 8;
    public const int AND_OP = 11;
    public const int T__30 = 30;
    public const int T__31 = 31;
    public const int T__32 = 32;
    public const int WS = 19;
    public const int BLOCK_CLOSE = 5;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int SL_COMMENT = 17;
    public const int STRING = 15;

    // delegates
    // delegators



        public BiCCLParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public BiCCLParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        

    override public string[] TokenNames {
		get { return BiCCLParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g"; }
    }



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



    // $ANTLR start "prog"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:229:1: prog : ( section )+ ;
    public void prog() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:279:1: ( ( section )+ )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:279:3: ( section )+
            {
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:279:3: ( section )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= 21 && LA1_0 <= 28)) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:279:3: section
            			    {
            			    	PushFollow(FOLLOW_section_in_prog60);
            			    	section();
            			    	state.followingStackPointer--;


            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            }


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
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "prog"


    // $ANTLR start "section"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:281:1: section : ( 'localizations' BLOCK_OPEN (loc= localization_def )+ BLOCK_CLOSE | 'experimentalConditions' BLOCK_OPEN (cond= condition_def )+ BLOCK_CLOSE | 'equivalenceClasses' BLOCK_OPEN (eq= equiv_def )+ BLOCK_CLOSE | 'sensors' BLOCK_OPEN (s= sensor_def )+ BLOCK_CLOSE | 'configurations' BLOCK_OPEN (c= config_def )+ BLOCK_CLOSE | 'tasks' BLOCK_OPEN ( task_def )+ BLOCK_CLOSE | 'initialState' BLOCK_OPEN (init_state= init_state_def )+ BLOCK_CLOSE | 'workflow' BLOCK_OPEN (w= workflow_def )+ BLOCK_CLOSE );
    public void section() // throws RecognitionException [1]
    {   
        LocalizableStringDefinition loc = default(LocalizableStringDefinition);

        ConditionFactory cond = default(ConditionFactory);

        PredicateFactoryDefinition eq = default(PredicateFactoryDefinition);

        BiCCLParser.sensor_def_return s = default(BiCCLParser.sensor_def_return);

        BooleanConditionDefinition init_state = default(BooleanConditionDefinition);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:286:2: ( 'localizations' BLOCK_OPEN (loc= localization_def )+ BLOCK_CLOSE | 'experimentalConditions' BLOCK_OPEN (cond= condition_def )+ BLOCK_CLOSE | 'equivalenceClasses' BLOCK_OPEN (eq= equiv_def )+ BLOCK_CLOSE | 'sensors' BLOCK_OPEN (s= sensor_def )+ BLOCK_CLOSE | 'configurations' BLOCK_OPEN (c= config_def )+ BLOCK_CLOSE | 'tasks' BLOCK_OPEN ( task_def )+ BLOCK_CLOSE | 'initialState' BLOCK_OPEN (init_state= init_state_def )+ BLOCK_CLOSE | 'workflow' BLOCK_OPEN (w= workflow_def )+ BLOCK_CLOSE )
            int alt10 = 8;
            switch ( input.LA(1) ) 
            {
            case 21:
            	{
                alt10 = 1;
                }
                break;
            case 22:
            	{
                alt10 = 2;
                }
                break;
            case 23:
            	{
                alt10 = 3;
                }
                break;
            case 24:
            	{
                alt10 = 4;
                }
                break;
            case 25:
            	{
                alt10 = 5;
                }
                break;
            case 26:
            	{
                alt10 = 6;
                }
                break;
            case 27:
            	{
                alt10 = 7;
                }
                break;
            case 28:
            	{
                alt10 = 8;
                }
                break;
            	default:
            	    NoViableAltException nvae_d10s0 =
            	        new NoViableAltException("", 10, 0, input);

            	    throw nvae_d10s0;
            }

            switch (alt10) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:286:4: 'localizations' BLOCK_OPEN (loc= localization_def )+ BLOCK_CLOSE
                    {
                    	Match(input,21,FOLLOW_21_in_section74); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section76); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:287:3: (loc= localization_def )+
                    	int cnt2 = 0;
                    	do 
                    	{
                    	    int alt2 = 2;
                    	    int LA2_0 = input.LA(1);

                    	    if ( (LA2_0 == NAME) )
                    	    {
                    	        alt2 = 1;
                    	    }


                    	    switch (alt2) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:287:4: loc= localization_def
                    			    {
                    			    	PushFollow(FOLLOW_localization_def_in_section84);
                    			    	loc = localization_def();
                    			    	state.followingStackPointer--;


                    			    				lsd.Add(loc);
                    			    				//System.out.println("Just added "+loc+" to the messages array");
                    			    			

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt2 >= 1 ) goto loop2;
                    		            EarlyExitException eee2 =
                    		                new EarlyExitException(2, input);
                    		            throw eee2;
                    	    }
                    	    cnt2++;
                    	} while (true);

                    	loop2:
                    		;	// Stops C# compiler whining that label 'loop2' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section95); 

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:293:4: 'experimentalConditions' BLOCK_OPEN (cond= condition_def )+ BLOCK_CLOSE
                    {
                    	Match(input,22,FOLLOW_22_in_section101); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section103); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:293:40: (cond= condition_def )+
                    	int cnt3 = 0;
                    	do 
                    	{
                    	    int alt3 = 2;
                    	    int LA3_0 = input.LA(1);

                    	    if ( (LA3_0 == RETURN_TYPE || LA3_0 == 29) )
                    	    {
                    	        alt3 = 1;
                    	    }


                    	    switch (alt3) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:293:41: cond= condition_def
                    			    {
                    			    	PushFollow(FOLLOW_condition_def_in_section108);
                    			    	cond = condition_def();
                    			    	state.followingStackPointer--;


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt3 >= 1 ) goto loop3;
                    		            EarlyExitException eee3 =
                    		                new EarlyExitException(3, input);
                    		            throw eee3;
                    	    }
                    	    cnt3++;
                    	} while (true);

                    	loop3:
                    		;	// Stops C# compiler whining that label 'loop3' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section112); 

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:294:4: 'equivalenceClasses' BLOCK_OPEN (eq= equiv_def )+ BLOCK_CLOSE
                    {
                    	Match(input,23,FOLLOW_23_in_section118); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section120); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:295:3: (eq= equiv_def )+
                    	int cnt4 = 0;
                    	do 
                    	{
                    	    int alt4 = 2;
                    	    int LA4_0 = input.LA(1);

                    	    if ( (LA4_0 == NAME) )
                    	    {
                    	        alt4 = 1;
                    	    }


                    	    switch (alt4) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:295:4: eq= equiv_def
                    			    {
                    			    	PushFollow(FOLLOW_equiv_def_in_section128);
                    			    	eq = equiv_def();
                    			    	state.followingStackPointer--;


                    			    				//Can't ReDim in C#, so we've got to do a deep copy, etc.
                    			    			    //NOTE: This has been replaced by the concatArray<> method.
                    			    			    //PredicateFactoryDefinition[] temp = new PredicateFactoryDefinition[conditionLibrary.EquivalenceClassFactoryDefinitions.Length + 1];
                    			    	           // if (conditionLibrary.EquivalenceClassFactoryDefinitions != null) {
                    			    	            //    for(int i = 0; i < conditionLibrary.EquivalenceClassFactoryDefinitions.Length; i++) {
                    			    				//		temp[i] = conditionLibrary.EquivalenceClassFactoryDefinitions[i].DeepCopy();
                    			    	            //    }
                    			    	             //   //conditionLibrary.EquivalenceClassFactoryDefinitions.CopyTo(temp, conditionLibrary.EquivalenceClassFactoryDefinitions.Length);
                    			    	            //}
                    			    	            //temp[temp.Length - 1] = eq;
                    			    	            //conditionLibrary.EquivalenceClassFactoryDefinitions = temp;
                    			    	            
                    			    	            conditionLibrary.EquivalenceClassFactoryDefinitions = concatArray<PredicateFactoryDefinition>(conditionLibrary.EquivalenceClassFactoryDefinitions, eq);
                    			    			

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt4 >= 1 ) goto loop4;
                    		            EarlyExitException eee4 =
                    		                new EarlyExitException(4, input);
                    		            throw eee4;
                    	    }
                    	    cnt4++;
                    	} while (true);

                    	loop4:
                    		;	// Stops C# compiler whining that label 'loop4' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section140); 

                    }
                    break;
                case 4 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:312:4: 'sensors' BLOCK_OPEN (s= sensor_def )+ BLOCK_CLOSE
                    {
                    	Match(input,24,FOLLOW_24_in_section145); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section147); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:313:3: (s= sensor_def )+
                    	int cnt5 = 0;
                    	do 
                    	{
                    	    int alt5 = 2;
                    	    int LA5_0 = input.LA(1);

                    	    if ( (LA5_0 == NAME) )
                    	    {
                    	        alt5 = 1;
                    	    }


                    	    switch (alt5) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:313:4: s= sensor_def
                    			    {
                    			    	PushFollow(FOLLOW_sensor_def_in_section155);
                    			    	s = sensor_def();
                    			    	state.followingStackPointer--;


                    			    				sensors.Add(((s != null) ? s.name : default(String)), ((s != null) ? s.sensor : default(SensorTypeDefinition)));
                    			    				//System.out.println("Added "+((s != null) ? s.name : default(String))+" to the sensor array");
                    			    			

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt5 >= 1 ) goto loop5;
                    		            EarlyExitException eee5 =
                    		                new EarlyExitException(5, input);
                    		            throw eee5;
                    	    }
                    	    cnt5++;
                    	} while (true);

                    	loop5:
                    		;	// Stops C# compiler whining that label 'loop5' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section164); 

                    }
                    break;
                case 5 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:318:4: 'configurations' BLOCK_OPEN (c= config_def )+ BLOCK_CLOSE
                    {
                    	Match(input,25,FOLLOW_25_in_section169); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section171); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:319:3: (c= config_def )+
                    	int cnt6 = 0;
                    	do 
                    	{
                    	    int alt6 = 2;
                    	    int LA6_0 = input.LA(1);

                    	    if ( (LA6_0 == NAME || LA6_0 == 40) )
                    	    {
                    	        alt6 = 1;
                    	    }


                    	    switch (alt6) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:319:4: c= config_def
                    			    {
                    			    	PushFollow(FOLLOW_config_def_in_section179);
                    			    	config_def();
                    			    	state.followingStackPointer--;


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt6 >= 1 ) goto loop6;
                    		            EarlyExitException eee6 =
                    		                new EarlyExitException(6, input);
                    		            throw eee6;
                    	    }
                    	    cnt6++;
                    	} while (true);

                    	loop6:
                    		;	// Stops C# compiler whining that label 'loop6' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section186); 

                    }
                    break;
                case 6 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:321:4: 'tasks' BLOCK_OPEN ( task_def )+ BLOCK_CLOSE
                    {
                    	Match(input,26,FOLLOW_26_in_section191); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section193); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:321:23: ( task_def )+
                    	int cnt7 = 0;
                    	do 
                    	{
                    	    int alt7 = 2;
                    	    int LA7_0 = input.LA(1);

                    	    if ( (LA7_0 == NAME) )
                    	    {
                    	        alt7 = 1;
                    	    }


                    	    switch (alt7) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:321:23: task_def
                    			    {
                    			    	PushFollow(FOLLOW_task_def_in_section195);
                    			    	task_def();
                    			    	state.followingStackPointer--;


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt7 >= 1 ) goto loop7;
                    		            EarlyExitException eee7 =
                    		                new EarlyExitException(7, input);
                    		            throw eee7;
                    	    }
                    	    cnt7++;
                    	} while (true);

                    	loop7:
                    		;	// Stops C# compiler whining that label 'loop7' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section198); 

                    }
                    break;
                case 7 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:322:4: 'initialState' BLOCK_OPEN (init_state= init_state_def )+ BLOCK_CLOSE
                    {
                    	Match(input,27,FOLLOW_27_in_section204); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section206); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:323:4: (init_state= init_state_def )+
                    	int cnt8 = 0;
                    	do 
                    	{
                    	    int alt8 = 2;
                    	    int LA8_0 = input.LA(1);

                    	    if ( (LA8_0 == NAME) )
                    	    {
                    	        alt8 = 1;
                    	    }


                    	    switch (alt8) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:323:5: init_state= init_state_def
                    			    {
                    			    	PushFollow(FOLLOW_init_state_def_in_section214);
                    			    	init_state = init_state_def();
                    			    	state.followingStackPointer--;


                    			    				currentConditions.Conditions.Add(init_state);
                    			    			

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt8 >= 1 ) goto loop8;
                    		            EarlyExitException eee8 =
                    		                new EarlyExitException(8, input);
                    		            throw eee8;
                    	    }
                    	    cnt8++;
                    	} while (true);

                    	loop8:
                    		;	// Stops C# compiler whining that label 'loop8' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section225); 

                    }
                    break;
                case 8 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:328:4: 'workflow' BLOCK_OPEN (w= workflow_def )+ BLOCK_CLOSE
                    {
                    	Match(input,28,FOLLOW_28_in_section230); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_section232); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:328:27: (w= workflow_def )+
                    	int cnt9 = 0;
                    	do 
                    	{
                    	    int alt9 = 2;
                    	    int LA9_0 = input.LA(1);

                    	    if ( (LA9_0 == 45 || LA9_0 == 49) )
                    	    {
                    	        alt9 = 1;
                    	    }


                    	    switch (alt9) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:328:27: w= workflow_def
                    			    {
                    			    	PushFollow(FOLLOW_workflow_def_in_section236);
                    			    	workflow_def();
                    			    	state.followingStackPointer--;


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt9 >= 1 ) goto loop9;
                    		            EarlyExitException eee9 =
                    		                new EarlyExitException(9, input);
                    		            throw eee9;
                    	    }
                    	    cnt9++;
                    	} while (true);

                    	loop9:
                    		;	// Stops C# compiler whining that label 'loop9' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_section239); 

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "section"


    // $ANTLR start "localization_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:331:1: localization_def returns [LocalizableStringDefinition value] : name= localization_name BLOCK_OPEN (pair= localization_assignment EOL )* BLOCK_CLOSE ;
    public LocalizableStringDefinition localization_def() // throws RecognitionException [1]
    {   
        LocalizableStringDefinition value = default(LocalizableStringDefinition);

        String name = default(String);

        RegionMessagePair pair = default(RegionMessagePair);



        		LocalizableStringDefinition loc = new LocalizableStringDefinition();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:340:2: (name= localization_name BLOCK_OPEN (pair= localization_assignment EOL )* BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:340:4: name= localization_name BLOCK_OPEN (pair= localization_assignment EOL )* BLOCK_CLOSE
            {
            	PushFollow(FOLLOW_localization_name_in_localization_def270);
            	name = localization_name();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_localization_def272); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:341:2: (pair= localization_assignment EOL )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( (LA11_0 == NAME) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:341:3: pair= localization_assignment EOL
            			    {
            			    	PushFollow(FOLLOW_localization_assignment_in_localization_def279);
            			    	pair = localization_assignment();
            			    	state.followingStackPointer--;


            			    			loc.RegionMessagePairs.Add(pair);
            			    			//System.out.println("Just added "+pair+" to localization named "+name);
            			    		
            			    	Match(input,EOL,FOLLOW_EOL_in_localization_def285); 

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_localization_def289); 

            }


            		loc.Name = name;
            		value =  loc;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "localization_def"


    // $ANTLR start "localization_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:350:1: localization_name returns [String value] : b= block_id ;
    public String localization_name() // throws RecognitionException [1]
    {   
        String value = default(String);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:351:2: (b= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:351:4: b= block_id
            {
            	PushFollow(FOLLOW_block_id_in_localization_name308);
            	b = block_id();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "localization_name"


    // $ANTLR start "localization_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:353:1: localization_assignment returns [RegionMessagePair value] : a= string_literal_assignment ;
    public RegionMessagePair localization_assignment() // throws RecognitionException [1]
    {   
        RegionMessagePair value = default(RegionMessagePair);

        BiCCLParser.string_literal_assignment_return a = default(BiCCLParser.string_literal_assignment_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:354:3: (a= string_literal_assignment )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:354:5: a= string_literal_assignment
            {
            	PushFollow(FOLLOW_string_literal_assignment_in_localization_assignment326);
            	a = string_literal_assignment();
            	state.followingStackPointer--;


            			 RegionMessagePair pair = new RegionMessagePair();
            			 pair.Region = ((a != null) ? a.key : default(String)); 
            			 pair.Message = ((a != null) ? a.value : default(String));
            			 value =  pair;
            			 

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "localization_assignment"


    // $ANTLR start "condition_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:363:1: condition_def returns [ConditionFactory value] : sig= condition_signature name= condition_name BLOCK_OPEN ( (a= condition_initval ) | (b= condition_message_assignment ) | (c= condition_unmet_prereq ) | (d= condition_requires ) )+ BLOCK_CLOSE ;
    public ConditionFactory condition_def() // throws RecognitionException [1]
    {   
        ConditionFactory value = default(ConditionFactory);

        BiCCLParser.condition_signature_return sig = default(BiCCLParser.condition_signature_return);

        String name = default(String);

        Object a = default(Object);

        BiCCLParser.condition_message_assignment_return b = default(BiCCLParser.condition_message_assignment_return);

        String c = default(String);

        PredicateFactoryDefinition d = default(PredicateFactoryDefinition);



        		ConditionFactoryDefinition condition = new ConditionFactoryDefinition();
        		Dictionary<String, List<String>> tempMessages = new Dictionary<String, List<String>>();
        		ArrayList initializationArgs = new ArrayList();
        		String unmetMessageTemp = "Empty"; //default to pulling the Empty message from the localized message library.
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:447:2: (sig= condition_signature name= condition_name BLOCK_OPEN ( (a= condition_initval ) | (b= condition_message_assignment ) | (c= condition_unmet_prereq ) | (d= condition_requires ) )+ BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:447:4: sig= condition_signature name= condition_name BLOCK_OPEN ( (a= condition_initval ) | (b= condition_message_assignment ) | (c= condition_unmet_prereq ) | (d= condition_requires ) )+ BLOCK_CLOSE
            {
            	PushFollow(FOLLOW_condition_signature_in_condition_def379);
            	sig = condition_signature();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_condition_name_in_condition_def383);
            	name = condition_name();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_condition_def385); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:448:2: ( (a= condition_initval ) | (b= condition_message_assignment ) | (c= condition_unmet_prereq ) | (d= condition_requires ) )+
            	int cnt12 = 0;
            	do 
            	{
            	    int alt12 = 5;
            	    switch ( input.LA(1) ) 
            	    {
            	    case 30:
            	    	{
            	        alt12 = 1;
            	        }
            	        break;
            	    case 34:
            	    case 35:
            	    	{
            	        alt12 = 2;
            	        }
            	        break;
            	    case 32:
            	    	{
            	        alt12 = 3;
            	        }
            	        break;
            	    case 33:
            	    	{
            	        alt12 = 4;
            	        }
            	        break;

            	    }

            	    switch (alt12) 
            		{
            			case 1 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:448:3: (a= condition_initval )
            			    {
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:448:3: (a= condition_initval )
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:448:4: a= condition_initval
            			    	{
            			    		PushFollow(FOLLOW_condition_initval_in_condition_def393);
            			    		a = condition_initval();
            			    		state.followingStackPointer--;


            			    				condition.ConditionInitialValue = a;
            			    			

            			    	}


            			    }
            			    break;
            			case 2 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:452:3: (b= condition_message_assignment )
            			    {
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:452:3: (b= condition_message_assignment )
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:452:4: b= condition_message_assignment
            			    	{
            			    		PushFollow(FOLLOW_condition_message_assignment_in_condition_def404);
            			    		b = condition_message_assignment();
            			    		state.followingStackPointer--;


            			    				tempMessages.Add(((b != null) ? b.type : default(String)), ((b != null) ? b.value : default(List<String>)));
            			    			

            			    	}


            			    }
            			    break;
            			case 3 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:456:3: (c= condition_unmet_prereq )
            			    {
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:456:3: (c= condition_unmet_prereq )
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:456:4: c= condition_unmet_prereq
            			    	{
            			    		PushFollow(FOLLOW_condition_unmet_prereq_in_condition_def415);
            			    		c = condition_unmet_prereq();
            			    		state.followingStackPointer--;


            			    				//this is used in the PrerequisiteFactory object.
            			    				unmetMessageTemp = c;
            			    			

            			    	}


            			    }
            			    break;
            			case 4 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:461:3: (d= condition_requires )
            			    {
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:461:3: (d= condition_requires )
            			    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:461:4: d= condition_requires
            			    	{
            			    		PushFollow(FOLLOW_condition_requires_in_condition_def426);
            			    		d = condition_requires();
            			    		state.followingStackPointer--;


            			    				//System.out.println("This condition got a predicate factory: "+d);
            			    				condition.PrerequisiteFactoryDefinition = d;
            			    			

            			    	}


            			    }
            			    break;

            			default:
            			    if ( cnt12 >= 1 ) goto loop12;
            		            EarlyExitException eee12 =
            		                new EarlyExitException(12, input);
            		            throw eee12;
            	    }
            	    cnt12++;
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_condition_def435); 

            }


            		//mark the condition as static or not.
            		condition.ConditionIsStatic = ((sig != null) ? sig.isStatic : default(bool));
            		//right now, only set the condition type when the return value
            		//is boolean, because we're not dealing with other types yet.
            		if(((sig != null) ? sig.conditionType : default(String)) == "boolean"){
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
            		//System.out.println("Initialization args (condition messages) for "+name+" has length "+initializationArgs.getAnyTypeCount());
            		//add the resulting array to the condition factory.
            		condition.InitializationArgs.AddRange(initializationArgs);
            		
            		//If the condition's initial value hasn't been set, set it to false.
            		if(condition.ConditionInitialValue == null)
            			condition.ConditionInitialValue = false;
            		
            		//set the name of the factory
            		//NOTE: The factory name (NOT the condition name) MUST be unique.
            		condition.FactoryName = name + "_" + condition.ConditionInitialValue;
            		condition.ConditionName = name;
            				
            		//set the condition description
            		setConditionDescription(condition, name);
            		
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
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "condition_def"

    public class condition_signature_return : ParserRuleReturnScope
    {
        public bool isStatic;
        public String conditionType;
    };

    // $ANTLR start "condition_signature"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:470:1: condition_signature returns [bool isStatic, String conditionType] : (a= 'static' )? b= RETURN_TYPE ;
    public BiCCLParser.condition_signature_return condition_signature() // throws RecognitionException [1]
    {   
        BiCCLParser.condition_signature_return retval = new BiCCLParser.condition_signature_return();
        retval.Start = input.LT(1);

        IToken a = null;
        IToken b = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:471:2: ( (a= 'static' )? b= RETURN_TYPE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:471:4: (a= 'static' )? b= RETURN_TYPE
            {
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:471:5: (a= 'static' )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( (LA13_0 == 29) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:471:5: a= 'static'
            	        {
            	        	a=(IToken)Match(input,29,FOLLOW_29_in_condition_signature454); 

            	        }
            	        break;

            	}

            	b=(IToken)Match(input,RETURN_TYPE,FOLLOW_RETURN_TYPE_in_condition_signature459); 

            			retval.isStatic =  (a != null);
            			retval.conditionType =  ((b != null) ? b.Text : null);
            		

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "condition_signature"


    // $ANTLR start "condition_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:478:1: condition_name returns [String value] : b= block_id ;
    public String condition_name() // throws RecognitionException [1]
    {   
        String value = default(String);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:479:2: (b= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:479:4: b= block_id
            {
            	PushFollow(FOLLOW_block_id_in_condition_name479);
            	b = block_id();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "condition_name"


    // $ANTLR start "condition_initval"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:481:1: condition_initval returns [Object value] : 'initialValue' '=' a= boolean EOL ;
    public Object condition_initval() // throws RecognitionException [1]
    {   
        Object value = default(Object);

        bool a = default(bool);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:482:2: ( 'initialValue' '=' a= boolean EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:482:3: 'initialValue' '=' a= boolean EOL
            {
            	Match(input,30,FOLLOW_30_in_condition_initval494); 
            	Match(input,31,FOLLOW_31_in_condition_initval496); 
            	PushFollow(FOLLOW_boolean_in_condition_initval500);
            	a = boolean();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_condition_initval502); 
            	value =  a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "condition_initval"

    public class condition_message_assignment_return : ParserRuleReturnScope
    {
        public String type;
        public List<String> value;
    };

    // $ANTLR start "condition_message_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:485:1: condition_message_assignment returns [String type, List<String> value] : mtype= condition_message_type BLOCK_OPEN (loc= condition_localization_assignment EOL )+ BLOCK_CLOSE ;
    public BiCCLParser.condition_message_assignment_return condition_message_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.condition_message_assignment_return retval = new BiCCLParser.condition_message_assignment_return();
        retval.Start = input.LT(1);

        BiCCLParser.condition_message_type_return mtype = default(BiCCLParser.condition_message_type_return);

        BiCCLParser.condition_localization_assignment_return loc = default(BiCCLParser.condition_localization_assignment_return);



        		List<String> messages = new List<String>();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:489:2: (mtype= condition_message_type BLOCK_OPEN (loc= condition_localization_assignment EOL )+ BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:489:3: mtype= condition_message_type BLOCK_OPEN (loc= condition_localization_assignment EOL )+ BLOCK_CLOSE
            {
            	PushFollow(FOLLOW_condition_message_type_in_condition_message_assignment526);
            	mtype = condition_message_type();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_condition_message_assignment528); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:490:2: (loc= condition_localization_assignment EOL )+
            	int cnt14 = 0;
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( ((LA14_0 >= 53 && LA14_0 <= 55)) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:490:3: loc= condition_localization_assignment EOL
            			    {
            			    	PushFollow(FOLLOW_condition_localization_assignment_in_condition_message_assignment535);
            			    	loc = condition_localization_assignment();
            			    	state.followingStackPointer--;


            			    			//NOTE: Currently, this is stored in an array that
            			    			//infers which message is which based on ordering.
            			    			//Therefore, we're ignoring the message id stored in
            			    			//the key field
            			    			messages.Add(((loc != null) ? loc.value : default(String))); 
            			    		
            			    	Match(input,EOL,FOLLOW_EOL_in_condition_message_assignment541); 

            			    }
            			    break;

            			default:
            			    if ( cnt14 >= 1 ) goto loop14;
            		            EarlyExitException eee14 =
            		                new EarlyExitException(14, input);
            		            throw eee14;
            	    }
            	    cnt14++;
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whining that label 'loop14' has no statements

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_condition_message_assignment545); 

            			retval.value =  messages;
            			retval.type =  ((mtype != null) ? input.ToString((IToken)(mtype.Start),(IToken)(mtype.Stop)) : null);
            		

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "condition_message_assignment"


    // $ANTLR start "condition_unmet_prereq"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:505:1: condition_unmet_prereq returns [String value] : 'unmetPrerequisiteMessage' '=' a= unmet_prereq_message EOL ;
    public String condition_unmet_prereq() // throws RecognitionException [1]
    {   
        String value = default(String);

        String a = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:506:2: ( 'unmetPrerequisiteMessage' '=' a= unmet_prereq_message EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:506:4: 'unmetPrerequisiteMessage' '=' a= unmet_prereq_message EOL
            {
            	Match(input,32,FOLLOW_32_in_condition_unmet_prereq563); 
            	Match(input,31,FOLLOW_31_in_condition_unmet_prereq565); 
            	PushFollow(FOLLOW_unmet_prereq_message_in_condition_unmet_prereq569);
            	a = unmet_prereq_message();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_condition_unmet_prereq571); 
            	value =  a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "condition_unmet_prereq"


    // $ANTLR start "condition_requires"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:509:1: condition_requires returns [PredicateFactoryDefinition value] : 'requires' BLOCK_OPEN a= predicate_factory ( EOL )? BLOCK_CLOSE ;
    public PredicateFactoryDefinition condition_requires() // throws RecognitionException [1]
    {   
        PredicateFactoryDefinition value = default(PredicateFactoryDefinition);

        BiCCLParser.predicate_factory_return a = default(BiCCLParser.predicate_factory_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:510:2: ( 'requires' BLOCK_OPEN a= predicate_factory ( EOL )? BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:510:4: 'requires' BLOCK_OPEN a= predicate_factory ( EOL )? BLOCK_CLOSE
            {
            	Match(input,33,FOLLOW_33_in_condition_requires588); 
            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_condition_requires590); 
            	PushFollow(FOLLOW_predicate_factory_in_condition_requires594);
            	a = predicate_factory();
            	state.followingStackPointer--;

            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:510:46: ( EOL )?
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);

            	if ( (LA15_0 == EOL) )
            	{
            	    alt15 = 1;
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:510:46: EOL
            	        {
            	        	Match(input,EOL,FOLLOW_EOL_in_condition_requires596); 

            	        }
            	        break;

            	}

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_condition_requires599); 

            			value =  ((a != null) ? a.value : default(PredicateFactoryDefinition));
            			//System.out.println("Trying to build a predicate factory out of: "+((a != null) ? input.ToString((IToken)(a.Start),(IToken)(a.Stop)) : null));
            		

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "condition_requires"

    public class condition_message_type_return : ParserRuleReturnScope
    {
    };

    // $ANTLR start "condition_message_type"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:517:1: condition_message_type : ( 'standaloneMessages' | 'compoundMessages' );
    public BiCCLParser.condition_message_type_return condition_message_type() // throws RecognitionException [1]
    {   
        BiCCLParser.condition_message_type_return retval = new BiCCLParser.condition_message_type_return();
        retval.Start = input.LT(1);

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:518:2: ( 'standaloneMessages' | 'compoundMessages' )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:
            {
            	if ( (input.LA(1) >= 34 && input.LA(1) <= 35) ) 
            	{
            	    input.Consume();
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "condition_message_type"


    // $ANTLR start "unmet_prereq_message"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:520:1: unmet_prereq_message returns [String value] : a= name_or_string ;
    public String unmet_prereq_message() // throws RecognitionException [1]
    {   
        String value = default(String);

        String a = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:521:2: (a= name_or_string )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:521:4: a= name_or_string
            {
            	PushFollow(FOLLOW_name_or_string_in_unmet_prereq_message631);
            	a = name_or_string();
            	state.followingStackPointer--;

            	value = a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "unmet_prereq_message"


    // $ANTLR start "equiv_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:524:1: equiv_def returns [PredicateFactoryDefinition value] : name= block_id BLOCK_OPEN p= predicate_factory ( EOL )? BLOCK_CLOSE ( EOL )? ;
    public PredicateFactoryDefinition equiv_def() // throws RecognitionException [1]
    {   
        PredicateFactoryDefinition value = default(PredicateFactoryDefinition);

        String name = default(String);

        BiCCLParser.predicate_factory_return p = default(BiCCLParser.predicate_factory_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:2: (name= block_id BLOCK_OPEN p= predicate_factory ( EOL )? BLOCK_CLOSE ( EOL )? )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:4: name= block_id BLOCK_OPEN p= predicate_factory ( EOL )? BLOCK_CLOSE ( EOL )?
            {
            	PushFollow(FOLLOW_block_id_in_equiv_def652);
            	name = block_id();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_equiv_def654); 
            	PushFollow(FOLLOW_predicate_factory_in_equiv_def658);
            	p = predicate_factory();
            	state.followingStackPointer--;

            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:49: ( EOL )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);

            	if ( (LA16_0 == EOL) )
            	{
            	    alt16 = 1;
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:49: EOL
            	        {
            	        	Match(input,EOL,FOLLOW_EOL_in_equiv_def660); 

            	        }
            	        break;

            	}

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_equiv_def663); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:66: ( EOL )?
            	int alt17 = 2;
            	int LA17_0 = input.LA(1);

            	if ( (LA17_0 == EOL) )
            	{
            	    alt17 = 1;
            	}
            	switch (alt17) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:527:66: EOL
            	        {
            	        	Match(input,EOL,FOLLOW_EOL_in_equiv_def665); 

            	        }
            	        break;

            	}


            			//Each of these creates an "EquivalenceClasses" element of type PredicateFactory
            			//set the name of the (possibly compound) predicate to the name specified for this equivalence class.
            			((p != null) ? p.value : default(PredicateFactoryDefinition)).Name = name;
            			value =  ((p != null) ? p.value : default(PredicateFactoryDefinition));
            		

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "equiv_def"

    public class sensor_def_return : ParserRuleReturnScope
    {
        public String name;
        public SensorTypeDefinition sensor;
    };

    // $ANTLR start "sensor_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:537:1: sensor_def returns [String name, SensorTypeDefinition sensor] : id= sensor_name BLOCK_OPEN plugin= sensor_plugin snamespace= sensor_namespace sclass= sensor_class conf= sensor_conf_class BLOCK_CLOSE ;
    public BiCCLParser.sensor_def_return sensor_def() // throws RecognitionException [1]
    {   
        BiCCLParser.sensor_def_return retval = new BiCCLParser.sensor_def_return();
        retval.Start = input.LT(1);

        String id = default(String);

        String plugin = default(String);

        String snamespace = default(String);

        String sclass = default(String);

        String conf = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:540:2: (id= sensor_name BLOCK_OPEN plugin= sensor_plugin snamespace= sensor_namespace sclass= sensor_class conf= sensor_conf_class BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:540:4: id= sensor_name BLOCK_OPEN plugin= sensor_plugin snamespace= sensor_namespace sclass= sensor_class conf= sensor_conf_class BLOCK_CLOSE
            {
            	PushFollow(FOLLOW_sensor_name_in_sensor_def691);
            	id = sensor_name();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_sensor_def693); 
            	PushFollow(FOLLOW_sensor_plugin_in_sensor_def699);
            	plugin = sensor_plugin();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_sensor_namespace_in_sensor_def705);
            	snamespace = sensor_namespace();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_sensor_class_in_sensor_def711);
            	sclass = sensor_class();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_sensor_conf_class_in_sensor_def718);
            	conf = sensor_conf_class();
            	state.followingStackPointer--;

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_sensor_def723); 

            			  
            	          SensorTypeDefinition s = new SensorTypeDefinition();
            	          s.ClassName = snamespace + "." + sclass;
            	          s.LibraryFileName = plugin;
            	          s.HasConfigurationClass = true; //this is always true, we're requiring it.
            	          //s.ConfigurationClassName = sensorConfigurationNamespace + conf;
            	          s.ConfigurationClassName = snamespace + "." + conf;
            	          retval.sensor =  s;
            	          retval.name =  id;
            	          sensorNamespaces.Add(retval.name,snamespace);
            		 

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "sensor_def"


    // $ANTLR start "sensor_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:560:1: sensor_name returns [String value] : block= block_id ;
    public String sensor_name() // throws RecognitionException [1]
    {   
        String value = default(String);

        String block = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:560:35: (block= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:560:37: block= block_id
            {
            	PushFollow(FOLLOW_block_id_in_sensor_name744);
            	block = block_id();
            	state.followingStackPointer--;

            	value =  block;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "sensor_name"


    // $ANTLR start "sensor_plugin"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:561:1: sensor_plugin returns [String value] : 'libraryFileName' '=' plugin= name_or_string EOL ;
    public String sensor_plugin() // throws RecognitionException [1]
    {   
        String value = default(String);

        String plugin = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:562:2: ( 'libraryFileName' '=' plugin= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:562:4: 'libraryFileName' '=' plugin= name_or_string EOL
            {
            	Match(input,36,FOLLOW_36_in_sensor_plugin757); 
            	Match(input,31,FOLLOW_31_in_sensor_plugin759); 
            	PushFollow(FOLLOW_name_or_string_in_sensor_plugin763);
            	plugin = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_sensor_plugin765); 
            	value =  plugin;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "sensor_plugin"


    // $ANTLR start "sensor_namespace"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:565:1: sensor_namespace returns [String value] : 'sensorNamespace' '=' ns= name_or_string EOL ;
    public String sensor_namespace() // throws RecognitionException [1]
    {   
        String value = default(String);

        String ns = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:566:2: ( 'sensorNamespace' '=' ns= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:566:4: 'sensorNamespace' '=' ns= name_or_string EOL
            {
            	Match(input,37,FOLLOW_37_in_sensor_namespace781); 
            	Match(input,31,FOLLOW_31_in_sensor_namespace783); 
            	PushFollow(FOLLOW_name_or_string_in_sensor_namespace787);
            	ns = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_sensor_namespace789); 
            	value =  ns;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "sensor_namespace"


    // $ANTLR start "sensor_class"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:569:1: sensor_class returns [String value] : 'sensorClassName' '=' conf= name_or_string EOL ;
    public String sensor_class() // throws RecognitionException [1]
    {   
        String value = default(String);

        String conf = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:570:2: ( 'sensorClassName' '=' conf= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:570:4: 'sensorClassName' '=' conf= name_or_string EOL
            {
            	Match(input,38,FOLLOW_38_in_sensor_class805); 
            	Match(input,31,FOLLOW_31_in_sensor_class807); 
            	PushFollow(FOLLOW_name_or_string_in_sensor_class811);
            	conf = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_sensor_class813); 
            	value =  conf;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "sensor_class"


    // $ANTLR start "sensor_conf_class"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:574:1: sensor_conf_class returns [String value] : 'configurationClassName' '=' conf= name_or_string EOL ;
    public String sensor_conf_class() // throws RecognitionException [1]
    {   
        String value = default(String);

        String conf = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:575:2: ( 'configurationClassName' '=' conf= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:575:4: 'configurationClassName' '=' conf= name_or_string EOL
            {
            	Match(input,39,FOLLOW_39_in_sensor_conf_class831); 
            	Match(input,31,FOLLOW_31_in_sensor_conf_class833); 
            	PushFollow(FOLLOW_name_or_string_in_sensor_conf_class837);
            	conf = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_sensor_conf_class839); 
            	value =  conf;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "sensor_conf_class"


    // $ANTLR start "config_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:580:1: config_def : ( config_literal EOL | 'xml' config_type config_name BLOCK_OPEN BLOCK_CLOSE | type= config_type name= config_name BLOCK_OPEN (pair= assignment EOL )* BLOCK_CLOSE );
    public void config_def() // throws RecognitionException [1]
    {   
        String type = default(String);

        String name = default(String);

        BiCCLParser.assignment_return pair = default(BiCCLParser.assignment_return);



        	  object sensorConfig;
              Type typeOfSensorConfig;
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:587:2: ( config_literal EOL | 'xml' config_type config_name BLOCK_OPEN BLOCK_CLOSE | type= config_type name= config_name BLOCK_OPEN (pair= assignment EOL )* BLOCK_CLOSE )
            int alt19 = 3;
            int LA19_0 = input.LA(1);

            if ( (LA19_0 == NAME) )
            {
                int LA19_1 = input.LA(2);

                if ( (LA19_1 == 31) )
                {
                    alt19 = 1;
                }
                else if ( (LA19_1 == NAME) )
                {
                    alt19 = 3;
                }
                else 
                {
                    NoViableAltException nvae_d19s1 =
                        new NoViableAltException("", 19, 1, input);

                    throw nvae_d19s1;
                }
            }
            else if ( (LA19_0 == 40) )
            {
                alt19 = 2;
            }
            else 
            {
                NoViableAltException nvae_d19s0 =
                    new NoViableAltException("", 19, 0, input);

                throw nvae_d19s0;
            }
            switch (alt19) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:587:4: config_literal EOL
                    {
                    	PushFollow(FOLLOW_config_literal_in_config_def862);
                    	config_literal();
                    	state.followingStackPointer--;

                    	Match(input,EOL,FOLLOW_EOL_in_config_def864); 

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:588:4: 'xml' config_type config_name BLOCK_OPEN BLOCK_CLOSE
                    {
                    	Match(input,40,FOLLOW_40_in_config_def869); 
                    	PushFollow(FOLLOW_config_type_in_config_def871);
                    	config_type();
                    	state.followingStackPointer--;

                    	PushFollow(FOLLOW_config_name_in_config_def873);
                    	config_name();
                    	state.followingStackPointer--;

                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_config_def875); 
                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_config_def885); 

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:591:5: type= config_type name= config_name BLOCK_OPEN (pair= assignment EOL )* BLOCK_CLOSE
                    {
                    	PushFollow(FOLLOW_config_type_in_config_def893);
                    	type = config_type();
                    	state.followingStackPointer--;


                    				try {
                    	                /*First, figure out if we have a sensor of this type defined already.*/
                    	                SensorTypeDefinition foundSensor = null;
                    	                foreach(KeyValuePair<String,SensorTypeDefinition> kvp in sensors){
                    						String sName = kvp.Key;
                    						SensorTypeDefinition s = kvp.Value;
                    						String sNamespace = sensorNamespaces[sName]+".";
                    	                    Console.WriteLine("Looking for a config class matching "+ sNamespace + type);
                    	                    if(s.ConfigurationClassName.Equals(sNamespace + type)) {
                    	                        foundSensor = s;
                    	                        break;
                    	                    }
                    	                }
                    	                if(foundSensor == null) throw new InvalidDataException("No sensor defined that provides the requested configuration class "+type);
                    	                        
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
                    					Console.WriteLine("Couldn't find or instantiate config class "+type+", using default sensor type.\n"+e.Message);
                    					sensorConfig = new SensorConfiguration();
                    	                typeOfSensorConfig = Type.GetType("SensorConfiguration");
                    				}
                    			
                    	PushFollow(FOLLOW_config_name_in_config_def904);
                    	name = config_name();
                    	state.followingStackPointer--;

                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_config_def906); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:636:3: (pair= assignment EOL )*
                    	do 
                    	{
                    	    int alt18 = 2;
                    	    int LA18_0 = input.LA(1);

                    	    if ( (LA18_0 == NAME || (LA18_0 >= 53 && LA18_0 <= 55)) )
                    	    {
                    	        alt18 = 1;
                    	    }


                    	    switch (alt18) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:636:4: pair= assignment EOL
                    			    {
                    			    	PushFollow(FOLLOW_assignment_in_config_def913);
                    			    	pair = assignment();
                    			    	state.followingStackPointer--;


                    			    		
                    			    				//Fill all sensor values via reflection.
                    			    				try {
                    			    					//try to get the type of the field we're about to set
                    			    					Type newType;
                    			    					try {
                    			    						newType = typeOfSensorConfig.InvokeMember(((pair != null) ? pair.key : default(String)), BindingFlags.GetField | BindingFlags.GetProperty ,null,sensorConfig,null).GetType();
                    			    					}catch(Exception te){
                    			    						//check the base class as well, and fail if it isn't there either.
                    			    						newType = typeOfSensorConfig.BaseType.InvokeMember(((pair != null) ? pair.key : default(String)), BindingFlags.GetField  | BindingFlags.GetProperty ,null,sensorConfig,null).GetType();
                    			    					}
                    			    					object[] assignedVal = new object[1];
                    			    					//if necessary, try to coerce the thing we've got into the format we need.
                    			    					if(newType != ((pair != null) ? pair.value : default(object)).GetType()) {
                    			    						Console.WriteLine("Attempting to coerce "+((pair != null) ? pair.value : default(object)).GetType()+" into "+newType+" for field "+((pair != null) ? pair.key : default(String)));
                    			    						assignedVal[0] = Convert.ChangeType(((pair != null) ? pair.value : default(object)), newType);
                    			    					}
                    			    					else {
                    			    						assignedVal[0] = ((pair != null) ? pair.value : default(object));
                    			    					}
                    			    	                typeOfSensorConfig.InvokeMember(((pair != null) ? pair.key : default(String)), BindingFlags.SetField  | BindingFlags.SetProperty ,null,sensorConfig,assignedVal);
                    			    				}
                    			    				catch(Exception e) {
                    			    					Console.WriteLine("Param "+((pair != null) ? pair.key : default(String))+" seems not to exist in "+typeOfSensorConfig.ToString()+", so we can't add the value to the sensor config.");
                    			    					Console.WriteLine("Error: "+e);
                    			    				}

                    			    			 
                    			    	Match(input,EOL,FOLLOW_EOL_in_config_def923); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop18;
                    	    }
                    	} while (true);

                    	loop18:
                    		;	// Stops C# compiler whining that label 'loop18' has no statements


                    				//Add the filled config object to configs.
                    			 	//C# NOTE: THIS MAY RESULT IN AN UNUSABLE VERSION OF SENSORCONFIG -- WE MAY NEED TO ACTUALLY CAST TO THE RIGHT SUBTYPE.
                    			 	configs.Add(name, (SensorConfiguration)sensorConfig);
                    			 
                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_config_def933); 

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "config_def"


    // $ANTLR start "config_literal"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:674:1: config_literal : string_literal_assignment ;
    public void config_literal() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:674:16: ( string_literal_assignment )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:674:18: string_literal_assignment
            {
            	PushFollow(FOLLOW_string_literal_assignment_in_config_literal946);
            	string_literal_assignment();
            	state.followingStackPointer--;


            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "config_literal"


    // $ANTLR start "config_type"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:675:1: config_type returns [String value] : b= block_id ;
    public String config_type() // throws RecognitionException [1]
    {   
        String value = default(String);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:675:34: (b= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:675:36: b= block_id
            {
            	PushFollow(FOLLOW_block_id_in_config_type957);
            	b = block_id();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "config_type"


    // $ANTLR start "config_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:676:1: config_name returns [String value] : b= block_id ;
    public String config_name() // throws RecognitionException [1]
    {   
        String value = default(String);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:676:34: (b= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:676:36: b= block_id
            {
            	PushFollow(FOLLOW_block_id_in_config_name970);
            	b = block_id();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "config_name"


    // $ANTLR start "task_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:679:1: task_def : name= task_name BLOCK_OPEN sensor= task_sensor conf= task_conf intended= task_primary_cat others= task_reassignable_cat BLOCK_CLOSE ;
    public void task_def() // throws RecognitionException [1]
    {   
        String name = default(String);

        String sensor = default(String);

        SensorConfiguration conf = default(SensorConfiguration);

        String intended = default(String);

        List<String> others = default(List<String>);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:682:2: (name= task_name BLOCK_OPEN sensor= task_sensor conf= task_conf intended= task_primary_cat others= task_reassignable_cat BLOCK_CLOSE )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:682:4: name= task_name BLOCK_OPEN sensor= task_sensor conf= task_conf intended= task_primary_cat others= task_reassignable_cat BLOCK_CLOSE
            {
            	PushFollow(FOLLOW_task_name_in_task_def987);
            	name = task_name();
            	state.followingStackPointer--;

            	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_task_def991); 
            	PushFollow(FOLLOW_task_sensor_in_task_def996);
            	sensor = task_sensor();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_task_conf_in_task_def1002);
            	conf = task_conf();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_task_primary_cat_in_task_def1007);
            	intended = task_primary_cat();
            	state.followingStackPointer--;

            	PushFollow(FOLLOW_task_reassignable_cat_in_task_def1012);
            	others = task_reassignable_cat();
            	state.followingStackPointer--;

            	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_task_def1021); 

            	      	//create the Task object
            	        Task tempTask = new Task(name);
            			
            	        //check to make sure that the declared sensor actually exists, add it if it does,
            	        // and complain if not.
            	        bool foundSensor = false;
            			// foreach(SensorTypeDefinition tempSensor in sensors.Values) {  
            			//	  if(tempSensor.ClassName.Equals(sensorNamespace+sensor)) {
            			//      foundSensor = true;
            			//      tempTask.setSensor(sensorNamespace+sensor);
            			 // }
            			//}
            	      
            			if(sensors.ContainsKey(sensor)){
            				foundSensor = true;
            				tempTask.setSensor(sensors[sensor].ClassName);
            			}
            	        else {
            		        Console.WriteLine("Tried to use sensor "+sensor+" in task "+name+", but no sensor with that name is defined");
            	        }
            		
            	        //which sensor configuration will this task use?
            	        tempTask.setConfiguration(conf);

            	        //add the intended submodality
            	        if (Enum.IsDefined(typeof(SensorTaskCategory), intended)){
            	            SensorTaskCategory intendedCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),intended);
            	            tempTask.setIntendedCategory(intendedCat);
            	        }
            	        else{
            	            Console.WriteLine("Tried to mark task "+name+" as having intended submodality "+intended+", which isn't one of the valid task submodalities.");
            	        }
            	        
            	        //Gather and add the reassignable submodalities
            	        List<SensorTaskCategory> reassignableList = new List<SensorTaskCategory>();
            	        foreach(String tc in others) {
            	            if (Enum.IsDefined(typeof(SensorTaskCategory),tc)){
            	                SensorTaskCategory reassignableCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),tc);
            	                reassignableList.Add(reassignableCat);
            	            }
            	            else{
            	                Console.WriteLine("Tried to mark task "+name+" as having rassignable submodality "+tc+", which isn't one of the valid task submodalities.");
            	            }
            	        }
            	        tempTask.setReassignableCategories(reassignableList);
            	        
            	        //add the task to our Dictionary for later reference.
            	        tasks.Add(name, tempTask);
            		

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "task_def"


    // $ANTLR start "task_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:745:1: task_name returns [String value] : b= block_id ;
    public String task_name() // throws RecognitionException [1]
    {   
        String value = default(String);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:745:33: (b= block_id )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:745:35: b= block_id
            {
            	PushFollow(FOLLOW_block_id_in_task_name1040);
            	b = block_id();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "task_name"


    // $ANTLR start "task_sensor"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:746:1: task_sensor returns [String value] : 'sensor' '=' a= name_or_string EOL ;
    public String task_sensor() // throws RecognitionException [1]
    {   
        String value = default(String);

        String a = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:746:36: ( 'sensor' '=' a= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:746:38: 'sensor' '=' a= name_or_string EOL
            {
            	Match(input,41,FOLLOW_41_in_task_sensor1053); 
            	Match(input,31,FOLLOW_31_in_task_sensor1055); 
            	PushFollow(FOLLOW_name_or_string_in_task_sensor1059);
            	a = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_task_sensor1061); 
            	value =  a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "task_sensor"


    // $ANTLR start "task_conf"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:747:1: task_conf returns [SensorConfiguration value] : 'configuration' '=' a= name_or_string EOL ;
    public SensorConfiguration task_conf() // throws RecognitionException [1]
    {   
        SensorConfiguration value = default(SensorConfiguration);

        String a = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:747:45: ( 'configuration' '=' a= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:747:47: 'configuration' '=' a= name_or_string EOL
            {
            	Match(input,42,FOLLOW_42_in_task_conf1072); 
            	Match(input,31,FOLLOW_31_in_task_conf1074); 
            	PushFollow(FOLLOW_name_or_string_in_task_conf1078);
            	a = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_task_conf1080); 
            	value =  configs[a];

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "task_conf"


    // $ANTLR start "task_primary_cat"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:748:1: task_primary_cat returns [String value] : 'intendedSubmodality' '=' a= name_or_string EOL ;
    public String task_primary_cat() // throws RecognitionException [1]
    {   
        String value = default(String);

        String a = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:748:39: ( 'intendedSubmodality' '=' a= name_or_string EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:748:41: 'intendedSubmodality' '=' a= name_or_string EOL
            {
            	Match(input,43,FOLLOW_43_in_task_primary_cat1091); 
            	Match(input,31,FOLLOW_31_in_task_primary_cat1093); 
            	PushFollow(FOLLOW_name_or_string_in_task_primary_cat1097);
            	a = name_or_string();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_task_primary_cat1099); 
            	value =  a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "task_primary_cat"


    // $ANTLR start "task_reassignable_cat"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:749:1: task_reassignable_cat returns [List<String> value] : 'reassignableSubmodalities' '=' a= set_of_strings EOL ;
    public List<String> task_reassignable_cat() // throws RecognitionException [1]
    {   
        List<String> value = default(List<String>);

        List<String> a = default(List<String>);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:749:51: ( 'reassignableSubmodalities' '=' a= set_of_strings EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:749:53: 'reassignableSubmodalities' '=' a= set_of_strings EOL
            {
            	Match(input,44,FOLLOW_44_in_task_reassignable_cat1112); 
            	Match(input,31,FOLLOW_31_in_task_reassignable_cat1114); 
            	PushFollow(FOLLOW_set_of_strings_in_task_reassignable_cat1118);
            	a = set_of_strings();
            	state.followingStackPointer--;

            	Match(input,EOL,FOLLOW_EOL_in_task_reassignable_cat1120); 
            	value =  a;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "task_reassignable_cat"


    // $ANTLR start "init_state_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:752:1: init_state_def returns [BooleanConditionDefinition value] : a= boolean_assignment EOL ;
    public BooleanConditionDefinition init_state_def() // throws RecognitionException [1]
    {   
        BooleanConditionDefinition value = default(BooleanConditionDefinition);

        BiCCLParser.boolean_assignment_return a = default(BiCCLParser.boolean_assignment_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:760:2: (a= boolean_assignment EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:760:4: a= boolean_assignment EOL
            {
            	PushFollow(FOLLOW_boolean_assignment_in_init_state_def1145);
            	a = boolean_assignment();
            	state.followingStackPointer--;


            	  		BooleanConditionDefinition cond = new BooleanConditionDefinition();
            			cond.OriginatingFactory = ((a != null) ? a.key : default(String)) + "_" + ((a != null) ? a.value : default(bool));
            			cond.BooleanValue = ((a != null) ? a.value : default(bool));
            			//set messages based on the matching factory in the condition library.
            			bool foundFactory = false;
            			for(int i = 0; (i < conditionLibrary.FactoryDefinitions.Length) && !foundFactory; i++) {
            				if(conditionLibrary.FactoryDefinitions[i].ConditionName.Equals(((a != null) ? a.key : default(String)), System.StringComparison.CurrentCultureIgnoreCase)) {
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
            			value =  cond;
            		
            	Match(input,EOL,FOLLOW_EOL_in_init_state_def1153); 

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "init_state_def"


    // $ANTLR start "workflow_def"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:787:1: workflow_def : (w= workflow_statement | 'if' '(' a= predicate_factory ')' BLOCK_OPEN (b= workflow_statement )+ BLOCK_CLOSE ( 'else' BLOCK_OPEN (c= workflow_statement )+ BLOCK_CLOSE )? );
    public void workflow_def() // throws RecognitionException [1]
    {   
        BiCCLParser.workflow_statement_return w = default(BiCCLParser.workflow_statement_return);

        BiCCLParser.predicate_factory_return a = default(BiCCLParser.predicate_factory_return);

        BiCCLParser.workflow_statement_return b = default(BiCCLParser.workflow_statement_return);

        BiCCLParser.workflow_statement_return c = default(BiCCLParser.workflow_statement_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:792:2: (w= workflow_statement | 'if' '(' a= predicate_factory ')' BLOCK_OPEN (b= workflow_statement )+ BLOCK_CLOSE ( 'else' BLOCK_OPEN (c= workflow_statement )+ BLOCK_CLOSE )? )
            int alt23 = 2;
            int LA23_0 = input.LA(1);

            if ( (LA23_0 == 49) )
            {
                alt23 = 1;
            }
            else if ( (LA23_0 == 45) )
            {
                alt23 = 2;
            }
            else 
            {
                NoViableAltException nvae_d23s0 =
                    new NoViableAltException("", 23, 0, input);

                throw nvae_d23s0;
            }
            switch (alt23) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:792:4: w= workflow_statement
                    {
                    	PushFollow(FOLLOW_workflow_statement_in_workflow_def1172);
                    	w = workflow_statement();
                    	state.followingStackPointer--;


                    			factoryDefinitions.Add(createTaskFactory(((w != null) ? w.taskName : default(String)), ((w != null) ? w.count : default(int)), ((w != null) ? w.prox : default(ConditionFactoryProxyCollectionDefinition))));
                    		

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:795:4: 'if' '(' a= predicate_factory ')' BLOCK_OPEN (b= workflow_statement )+ BLOCK_CLOSE ( 'else' BLOCK_OPEN (c= workflow_statement )+ BLOCK_CLOSE )?
                    {
                    	Match(input,45,FOLLOW_45_in_workflow_def1179); 
                    	Match(input,46,FOLLOW_46_in_workflow_def1181); 
                    	PushFollow(FOLLOW_predicate_factory_in_workflow_def1185);
                    	a = predicate_factory();
                    	state.followingStackPointer--;

                    	Match(input,47,FOLLOW_47_in_workflow_def1187); 
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_workflow_def1189); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:796:3: (b= workflow_statement )+
                    	int cnt20 = 0;
                    	do 
                    	{
                    	    int alt20 = 2;
                    	    int LA20_0 = input.LA(1);

                    	    if ( (LA20_0 == 49) )
                    	    {
                    	        alt20 = 1;
                    	    }


                    	    switch (alt20) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:796:4: b= workflow_statement
                    			    {
                    			    	PushFollow(FOLLOW_workflow_statement_in_workflow_def1197);
                    			    	b = workflow_statement();
                    			    	state.followingStackPointer--;


                    			    				SensorTaskFactoryDefinition toAdd = createTaskFactory(((b != null) ? b.taskName : default(String)), ((b != null) ? b.count : default(int)), ((b != null) ? b.prox : default(ConditionFactoryProxyCollectionDefinition)));
                    			    				//add a TaskPrerequisite (which is a PredicateFactoryDefinition object) to the factory
                    			    				toAdd.PrerequisiteDefinition = ((a != null) ? a.value : default(PredicateFactoryDefinition));
                    			    				factoryDefinitions.Add(toAdd);
                    			    				
                    			    			

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt20 >= 1 ) goto loop20;
                    		            EarlyExitException eee20 =
                    		                new EarlyExitException(20, input);
                    		            throw eee20;
                    	    }
                    	    cnt20++;
                    	} while (true);

                    	loop20:
                    		;	// Stops C# compiler whining that label 'loop20' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_workflow_def1205); 
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:804:3: ( 'else' BLOCK_OPEN (c= workflow_statement )+ BLOCK_CLOSE )?
                    	int alt22 = 2;
                    	int LA22_0 = input.LA(1);

                    	if ( (LA22_0 == 48) )
                    	{
                    	    alt22 = 1;
                    	}
                    	switch (alt22) 
                    	{
                    	    case 1 :
                    	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:804:4: 'else' BLOCK_OPEN (c= workflow_statement )+ BLOCK_CLOSE
                    	        {
                    	        	Match(input,48,FOLLOW_48_in_workflow_def1210); 
                    	        	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_workflow_def1212); 
                    	        	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:805:3: (c= workflow_statement )+
                    	        	int cnt21 = 0;
                    	        	do 
                    	        	{
                    	        	    int alt21 = 2;
                    	        	    int LA21_0 = input.LA(1);

                    	        	    if ( (LA21_0 == 49) )
                    	        	    {
                    	        	        alt21 = 1;
                    	        	    }


                    	        	    switch (alt21) 
                    	        		{
                    	        			case 1 :
                    	        			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:805:4: c= workflow_statement
                    	        			    {
                    	        			    	PushFollow(FOLLOW_workflow_statement_in_workflow_def1220);
                    	        			    	c = workflow_statement();
                    	        			    	state.followingStackPointer--;


                    	        			    				
                    	        			    				SensorTaskFactoryDefinition toAdd = createTaskFactory(((c != null) ? c.taskName : default(String)), ((c != null) ? c.count : default(int)), ((c != null) ? c.prox : default(ConditionFactoryProxyCollectionDefinition)));
                    	        			    				//Add a TaskPrerequisite (which is a PredicateFactory object) to the factory.
                    	        			    				//This predicate has to be the negated version of the one used in the "if" clause.
                    	        			    				PredicateFactoryDefinition np = new PredicateFactoryDefinition();
                    	        			    				np.PredicateType = PredicateType.NotPredicate;
                    	        			    				//add the if-statement's factory here; it is negated by this not-predicate.
                    	        			    				np.FactoryArgDefinitions = concatArray<object>(np.FactoryArgDefinitions, ((a != null) ? a.value : default(PredicateFactoryDefinition)));
                    	        			    				
                    	        			    				//get the unmet prereq string from the predicate we're negating.  Add it to this predicate.
                    	        			    				np.UnmetPrerequisiteMessage = (((a != null) ? a.value : default(PredicateFactoryDefinition))).UnmetPrerequisiteMessage;
                    	        			    				
                    	        			    				//add the task factory to the main factory definitions.
                    	        			    				toAdd.PrerequisiteDefinition = np;
                    	        			    				factoryDefinitions.Add(toAdd);
                    	        			    			

                    	        			    }
                    	        			    break;

                    	        			default:
                    	        			    if ( cnt21 >= 1 ) goto loop21;
                    	        		            EarlyExitException eee21 =
                    	        		                new EarlyExitException(21, input);
                    	        		            throw eee21;
                    	        	    }
                    	        	    cnt21++;
                    	        	} while (true);

                    	        	loop21:
                    	        		;	// Stops C# compiler whining that label 'loop21' has no statements

                    	        	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_workflow_def1228); 

                    	        }
                    	        break;

                    	}


                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "workflow_def"

    public class workflow_statement_return : ParserRuleReturnScope
    {
        public String taskName;
        public int count;
        public ConditionFactoryProxyCollectionDefinition prox;
    };

    // $ANTLR start "workflow_statement"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:825:1: workflow_statement returns [String taskName, int count, ConditionFactoryProxyCollectionDefinition prox] : 'perform' a= INT b= NAME (c= with_state )? EOL ;
    public BiCCLParser.workflow_statement_return workflow_statement() // throws RecognitionException [1]
    {   
        BiCCLParser.workflow_statement_return retval = new BiCCLParser.workflow_statement_return();
        retval.Start = input.LT(1);

        IToken a = null;
        IToken b = null;
        ConditionFactoryProxyCollectionDefinition c = default(ConditionFactoryProxyCollectionDefinition);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:826:2: ( 'perform' a= INT b= NAME (c= with_state )? EOL )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:826:4: 'perform' a= INT b= NAME (c= with_state )? EOL
            {
            	Match(input,49,FOLLOW_49_in_workflow_statement1245); 
            	a=(IToken)Match(input,INT,FOLLOW_INT_in_workflow_statement1249); 
            	b=(IToken)Match(input,NAME,FOLLOW_NAME_in_workflow_statement1253); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:826:27: (c= with_state )?
            	int alt24 = 2;
            	int LA24_0 = input.LA(1);

            	if ( (LA24_0 == 50) )
            	{
            	    alt24 = 1;
            	}
            	switch (alt24) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:826:28: c= with_state
            	        {
            	        	PushFollow(FOLLOW_with_state_in_workflow_statement1258);
            	        	c = with_state();
            	        	state.followingStackPointer--;

            	        	retval.prox =  c;

            	        }
            	        break;

            	}

            	Match(input,EOL,FOLLOW_EOL_in_workflow_statement1264); 
            	retval.count =  Int32.Parse(((a != null) ? a.Text : null)); retval.taskName =  ((b != null) ? b.Text : null);

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "workflow_statement"


    // $ANTLR start "with_state"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:831:1: with_state returns [ConditionFactoryProxyCollectionDefinition value] : 'with' a= set_of_assignments ;
    public ConditionFactoryProxyCollectionDefinition with_state() // throws RecognitionException [1]
    {   
        ConditionFactoryProxyCollectionDefinition value = default(ConditionFactoryProxyCollectionDefinition);

        Dictionary<String, object> a = default(Dictionary<String, object>);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:832:2: ( 'with' a= set_of_assignments )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:832:4: 'with' a= set_of_assignments
            {
            	Match(input,50,FOLLOW_50_in_with_state1282); 
            	PushFollow(FOLLOW_set_of_assignments_in_with_state1286);
            	a = set_of_assignments();
            	state.followingStackPointer--;


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
            			foreach(KeyValuePair<String, object> kvp in a) {
            				
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
            			
            			value =  prox;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "with_state"

    public class predicate_factory_return : ParserRuleReturnScope
    {
        public PredicateFactoryDefinition value;
    };

    // $ANTLR start "predicate_factory"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:890:1: predicate_factory returns [PredicateFactoryDefinition value] : a= predicate_factory_compoundAnd ( OR_OP b= predicate_factory )? ;
    public BiCCLParser.predicate_factory_return predicate_factory() // throws RecognitionException [1]
    {   
        BiCCLParser.predicate_factory_return retval = new BiCCLParser.predicate_factory_return();
        retval.Start = input.LT(1);

        PredicateFactoryDefinition a = default(PredicateFactoryDefinition);

        BiCCLParser.predicate_factory_return b = default(BiCCLParser.predicate_factory_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:916:2: (a= predicate_factory_compoundAnd ( OR_OP b= predicate_factory )? )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:916:4: a= predicate_factory_compoundAnd ( OR_OP b= predicate_factory )?
            {
            	PushFollow(FOLLOW_predicate_factory_compoundAnd_in_predicate_factory1328);
            	a = predicate_factory_compoundAnd();
            	state.followingStackPointer--;

            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:916:36: ( OR_OP b= predicate_factory )?
            	int alt25 = 2;
            	int LA25_0 = input.LA(1);

            	if ( (LA25_0 == OR_OP) )
            	{
            	    alt25 = 1;
            	}
            	switch (alt25) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:916:37: OR_OP b= predicate_factory
            	        {
            	        	Match(input,OR_OP,FOLLOW_OR_OP_in_predicate_factory1331); 
            	        	PushFollow(FOLLOW_predicate_factory_in_predicate_factory1335);
            	        	b = predicate_factory();
            	        	state.followingStackPointer--;


            	        }
            	        break;

            	}


            			if(b == null) {
            				retval.value =  a;
            			}
            			else {
            				PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
            				pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, a);
            				pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, ((b != null) ? b.value : default(PredicateFactoryDefinition)));
            				pfact.PredicateType = PredicateType.CompoundOrPredicate;
            				retval.value =  pfact;
            			}
            		

            }

            retval.Stop = input.LT(-1);


            		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
            		//as it is required by all Predicates.
            		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
            		unmetPointer.Name = "Empty";
            		retval.value.UnmetPrerequisiteMessage = unmetPointer;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "predicate_factory"


    // $ANTLR start "predicate_factory_compoundAnd"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:931:1: predicate_factory_compoundAnd returns [PredicateFactoryDefinition value] : a= predicate_factory_atom ( AND_OP b= predicate_factory_compoundAnd )? ;
    public PredicateFactoryDefinition predicate_factory_compoundAnd() // throws RecognitionException [1]
    {   
        PredicateFactoryDefinition value = default(PredicateFactoryDefinition);

        PredicateFactoryDefinition a = default(PredicateFactoryDefinition);

        PredicateFactoryDefinition b = default(PredicateFactoryDefinition);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:939:2: (a= predicate_factory_atom ( AND_OP b= predicate_factory_compoundAnd )? )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:939:4: a= predicate_factory_atom ( AND_OP b= predicate_factory_compoundAnd )?
            {
            	PushFollow(FOLLOW_predicate_factory_atom_in_predicate_factory_compoundAnd1361);
            	a = predicate_factory_atom();
            	state.followingStackPointer--;

            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:939:29: ( AND_OP b= predicate_factory_compoundAnd )?
            	int alt26 = 2;
            	int LA26_0 = input.LA(1);

            	if ( (LA26_0 == AND_OP) )
            	{
            	    alt26 = 1;
            	}
            	switch (alt26) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:939:30: AND_OP b= predicate_factory_compoundAnd
            	        {
            	        	Match(input,AND_OP,FOLLOW_AND_OP_in_predicate_factory_compoundAnd1364); 
            	        	PushFollow(FOLLOW_predicate_factory_compoundAnd_in_predicate_factory_compoundAnd1368);
            	        	b = predicate_factory_compoundAnd();
            	        	state.followingStackPointer--;


            	        }
            	        break;

            	}


            			if(b == null) {
            				value =  a;
            			}
            			else {
            				PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
            				pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, a);
            				pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, b);
            				pfact.PredicateType = PredicateType.CompoundAndPredicate;
            				value =  pfact;
            			}
            		

            }


            		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
            		//as it is required by all Predicates.
            		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
            		unmetPointer.Name = "Empty";
            		value.UnmetPrerequisiteMessage = unmetPointer;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "predicate_factory_compoundAnd"


    // $ANTLR start "predicate_factory_atom"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:954:1: predicate_factory_atom returns [PredicateFactoryDefinition value] : (p= predicate_factory_atom_base | (notop= NOT_OP )? '(' pred= predicate_factory ')' );
    public PredicateFactoryDefinition predicate_factory_atom() // throws RecognitionException [1]
    {   
        PredicateFactoryDefinition value = default(PredicateFactoryDefinition);

        IToken notop = null;
        PredicateFactoryDefinition p = default(PredicateFactoryDefinition);

        BiCCLParser.predicate_factory_return pred = default(BiCCLParser.predicate_factory_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:962:2: (p= predicate_factory_atom_base | (notop= NOT_OP )? '(' pred= predicate_factory ')' )
            int alt28 = 2;
            switch ( input.LA(1) ) 
            {
            case NAME:
            case BOOLEAN:
            case 57:
            case 58:
            	{
                alt28 = 1;
                }
                break;
            case NOT_OP:
            	{
                int LA28_2 = input.LA(2);

                if ( (LA28_2 == 46) )
                {
                    alt28 = 2;
                }
                else if ( (LA28_2 == NAME) )
                {
                    alt28 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d28s2 =
                        new NoViableAltException("", 28, 2, input);

                    throw nvae_d28s2;
                }
                }
                break;
            case 46:
            	{
                alt28 = 2;
                }
                break;
            	default:
            	    NoViableAltException nvae_d28s0 =
            	        new NoViableAltException("", 28, 0, input);

            	    throw nvae_d28s0;
            }

            switch (alt28) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:962:4: p= predicate_factory_atom_base
                    {
                    	PushFollow(FOLLOW_predicate_factory_atom_base_in_predicate_factory_atom1395);
                    	p = predicate_factory_atom_base();
                    	state.followingStackPointer--;


                    			value =  p;
                    		

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:966:4: (notop= NOT_OP )? '(' pred= predicate_factory ')'
                    {
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:966:9: (notop= NOT_OP )?
                    	int alt27 = 2;
                    	int LA27_0 = input.LA(1);

                    	if ( (LA27_0 == NOT_OP) )
                    	{
                    	    alt27 = 1;
                    	}
                    	switch (alt27) 
                    	{
                    	    case 1 :
                    	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:966:9: notop= NOT_OP
                    	        {
                    	        	notop=(IToken)Match(input,NOT_OP,FOLLOW_NOT_OP_in_predicate_factory_atom1406); 

                    	        }
                    	        break;

                    	}

                    	Match(input,46,FOLLOW_46_in_predicate_factory_atom1409); 
                    	PushFollow(FOLLOW_predicate_factory_in_predicate_factory_atom1413);
                    	pred = predicate_factory();
                    	state.followingStackPointer--;

                    	Match(input,47,FOLLOW_47_in_predicate_factory_atom1415); 

                    			if(notop != null) {
                    				PredicateFactoryDefinition pfact = new PredicateFactoryDefinition();
                    				pfact.PredicateType = PredicateType.NotPredicate;
                    				pfact.FactoryArgDefinitions = concatArray<object>(pfact.FactoryArgDefinitions, ((pred != null) ? pred.value : default(PredicateFactoryDefinition)));
                    				value =  pfact;
                    			}
                    			else
                    				value =  ((pred != null) ? pred.value : default(PredicateFactoryDefinition));
                    		

                    }
                    break;

            }

            		//Set the UnmetPrerequisiteMessageString to "Empty" by default,
            		//as it is required by all Predicates.
            		NamedProxy<LocalizableString> unmetPointer = new NamedProxy<LocalizableString>();
            		unmetPointer.Name = "Empty";
            		value.UnmetPrerequisiteMessage = unmetPointer;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "predicate_factory_atom"


    // $ANTLR start "predicate_factory_atom_base"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:979:1: predicate_factory_atom_base returns [PredicateFactoryDefinition value] : (pb= pred_boolean | prsing= pred_reserved_single | prset= pred_reserved_set | pno= pred_numerical_other | pe= pred_evaluation | pes= pred_evaluation_short );
    public PredicateFactoryDefinition predicate_factory_atom_base() // throws RecognitionException [1]
    {   
        PredicateFactoryDefinition value = default(PredicateFactoryDefinition);

        bool pb = default(bool);

        BiCCLParser.pred_reserved_single_return prsing = default(BiCCLParser.pred_reserved_single_return);

        BiCCLParser.pred_reserved_set_return prset = default(BiCCLParser.pred_reserved_set_return);

        BiCCLParser.pred_numerical_other_return pno = default(BiCCLParser.pred_numerical_other_return);

        BiCCLParser.pred_evaluation_return pe = default(BiCCLParser.pred_evaluation_return);

        BiCCLParser.pred_evaluation_short_return pes = default(BiCCLParser.pred_evaluation_short_return);



        		PredicateFactoryDefinition pred = new PredicateFactoryDefinition();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:986:2: (pb= pred_boolean | prsing= pred_reserved_single | prset= pred_reserved_set | pno= pred_numerical_other | pe= pred_evaluation | pes= pred_evaluation_short )
            int alt29 = 6;
            switch ( input.LA(1) ) 
            {
            case BOOLEAN:
            	{
                alt29 = 1;
                }
                break;
            case 57:
            case 58:
            	{
                int LA29_2 = input.LA(2);

                if ( (LA29_2 == 52) )
                {
                    alt29 = 3;
                }
                else if ( (LA29_2 == 51) )
                {
                    alt29 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d29s2 =
                        new NoViableAltException("", 29, 2, input);

                    throw nvae_d29s2;
                }
                }
                break;
            case NAME:
            	{
                switch ( input.LA(2) ) 
                {
                case MATH_OP:
                	{
                    alt29 = 4;
                    }
                    break;
                case 51:
                	{
                    alt29 = 5;
                    }
                    break;
                case BLOCK_CLOSE:
                case EOL:
                case OR_OP:
                case AND_OP:
                case 47:
                	{
                    alt29 = 6;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d29s3 =
                	        new NoViableAltException("", 29, 3, input);

                	    throw nvae_d29s3;
                }

                }
                break;
            case NOT_OP:
            	{
                alt29 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d29s0 =
            	        new NoViableAltException("", 29, 0, input);

            	    throw nvae_d29s0;
            }

            switch (alt29) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:986:4: pb= pred_boolean
                    {
                    	PushFollow(FOLLOW_pred_boolean_in_predicate_factory_atom_base1445);
                    	pb = pred_boolean();
                    	state.followingStackPointer--;


                    			pred.PredicateType = PredicateType.LiteralPredicate;
                    			pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, pb);
                    		

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:991:4: prsing= pred_reserved_single
                    {
                    	PushFollow(FOLLOW_pred_reserved_single_in_predicate_factory_atom_base1456);
                    	prsing = pred_reserved_single();
                    	state.followingStackPointer--;


                    			//FIXME, SORT OF: Because of what appears to be a bug in Castor, when the SensorModality object is
                    			//marshalled as part of a FactoryArgument, the toString() method is never called, so the value isn't inserted.
                    			//Instead, we'll just put in the value and put it into a FactoryArgument in the transformation stylesheet at the end.

                    	        //C# note: reverting to the proper structure.
                    			if(((prsing != null) ? prsing.key : default(String)).Equals("submodality",System.StringComparison.CurrentCultureIgnoreCase)){
                    				pred.PredicateType = PredicateType.CategoryEqualsLiteralPredicate;
                    	            if (Enum.IsDefined(typeof(SensorTaskCategory), ((prsing != null) ? prsing.value : default(String)))){
                    	                SensorTaskCategory predCat = (SensorTaskCategory) Enum.Parse(typeof(SensorTaskCategory),((prsing != null) ? prsing.value : default(String)));
                    	                pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, predCat);
                    	            }
                    	            else{
                    	                Console.WriteLine("Sensor task submodality "+((prsing != null) ? prsing.value : default(String))+" doesn't exist.");
                    	            }
                    			}
                    			else if (((prsing != null) ? prsing.key : default(String)).Equals("modality", System.StringComparison.CurrentCultureIgnoreCase)){
                    				pred.PredicateType = PredicateType.SensorModalityEqualsLiteralPredicate;
                    				
                    	            if (Enum.IsDefined(typeof(SensorModality), ((prsing != null) ? prsing.value : default(String)))){
                    	                SensorModality predCat = (SensorModality) Enum.Parse(typeof(SensorModality),((prsing != null) ? prsing.value : default(String)));
                    	                pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, predCat);
                    	            }
                    	            else{
                    	                Console.WriteLine("Sensor task modality "+((prsing != null) ? prsing.value : default(String))+" doesn't exist.");
                    	            }
                    			}
                    		

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1020:4: prset= pred_reserved_set
                    {
                    	PushFollow(FOLLOW_pred_reserved_set_in_predicate_factory_atom_base1467);
                    	prset = pred_reserved_set();
                    	state.followingStackPointer--;


                    			if(((prset != null) ? prset.key : default(String)).Equals("submodality", System.StringComparison.CurrentCultureIgnoreCase)){
                    				pred.PredicateType = PredicateType.CategoryContainedInSetPredicate;

                    				System.Collections.ObjectModel.Collection<SensorTaskCategory> validSubmodalities = new System.Collections.ObjectModel.Collection<SensorTaskCategory>();
                    				foreach(String category in ((prset != null) ? prset.value : default(List<String>))) {
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
                    			 else if(((prset != null) ? prset.key : default(String)).Equals("modality", System.StringComparison.CurrentCultureIgnoreCase)){
                    			 	Console.WriteLine("The 'modality in {}' construct is not yet available to use.");
                    			 }

                    		

                    }
                    break;
                case 4 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1044:4: pno= pred_numerical_other
                    {
                    	PushFollow(FOLLOW_pred_numerical_other_in_predicate_factory_atom_base1479);
                    	pno = pred_numerical_other();
                    	state.followingStackPointer--;


                    			pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
                    	        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pno != null) ? pno.key : default(String)));
                    	        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pno != null) ? pno.value : default(double)));
                    		

                    }
                    break;
                case 5 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1050:4: pe= pred_evaluation
                    {
                    	PushFollow(FOLLOW_pred_evaluation_in_predicate_factory_atom_base1490);
                    	pe = pred_evaluation();
                    	state.followingStackPointer--;


                    	        pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
                    	        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pe != null) ? pe.key : default(String)));
                    	        pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pe != null) ? pe.value : default(object)));
                    		

                    }
                    break;
                case 6 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1056:4: pes= pred_evaluation_short
                    {
                    	PushFollow(FOLLOW_pred_evaluation_short_in_predicate_factory_atom_base1501);
                    	pes = pred_evaluation_short();
                    	state.followingStackPointer--;


                    	      pred.PredicateType = PredicateType.ConditionEqualsLiteralPredicate;
                    	      pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pes != null) ? pes.key : default(String)));
                    	      pred.FactoryArgDefinitions = concatArray<object>(pred.FactoryArgDefinitions, ((pes != null) ? pes.value : default(bool)));
                    		

                    }
                    break;

            }

            		value =  pred;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "predicate_factory_atom_base"


    // $ANTLR start "pred_boolean"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1064:1: pred_boolean returns [bool value] : b= boolean ;
    public bool pred_boolean() // throws RecognitionException [1]
    {   
        bool value = default(bool);

        bool b = default(bool);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1064:34: (b= boolean )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1064:36: b= boolean
            {
            	PushFollow(FOLLOW_boolean_in_pred_boolean1520);
            	b = boolean();
            	state.followingStackPointer--;

            	value =  b;

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "pred_boolean"

    public class pred_reserved_single_return : ParserRuleReturnScope
    {
        public String key;
        public String value;
    };

    // $ANTLR start "pred_reserved_single"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1065:1: pred_reserved_single returns [String key, String value] : a= reserved_word '==' b= name_or_string ;
    public BiCCLParser.pred_reserved_single_return pred_reserved_single() // throws RecognitionException [1]
    {   
        BiCCLParser.pred_reserved_single_return retval = new BiCCLParser.pred_reserved_single_return();
        retval.Start = input.LT(1);

        BiCCLParser.reserved_word_return a = default(BiCCLParser.reserved_word_return);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1065:56: (a= reserved_word '==' b= name_or_string )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1065:58: a= reserved_word '==' b= name_or_string
            {
            	PushFollow(FOLLOW_reserved_word_in_pred_reserved_single1534);
            	a = reserved_word();
            	state.followingStackPointer--;

            	Match(input,51,FOLLOW_51_in_pred_reserved_single1536); 
            	PushFollow(FOLLOW_name_or_string_in_pred_reserved_single1540);
            	b = name_or_string();
            	state.followingStackPointer--;

            	retval.key =  ((a != null) ? input.ToString((IToken)(a.Start),(IToken)(a.Stop)) : null); retval.value =  b;

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pred_reserved_single"

    public class pred_reserved_set_return : ParserRuleReturnScope
    {
        public String key;
        public List<String> value;
    };

    // $ANTLR start "pred_reserved_set"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1066:1: pred_reserved_set returns [String key, List<String> value] : a= reserved_word 'in' b= set_of_strings ;
    public BiCCLParser.pred_reserved_set_return pred_reserved_set() // throws RecognitionException [1]
    {   
        BiCCLParser.pred_reserved_set_return retval = new BiCCLParser.pred_reserved_set_return();
        retval.Start = input.LT(1);

        BiCCLParser.reserved_word_return a = default(BiCCLParser.reserved_word_return);

        List<String> b = default(List<String>);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1066:59: (a= reserved_word 'in' b= set_of_strings )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1066:61: a= reserved_word 'in' b= set_of_strings
            {
            	PushFollow(FOLLOW_reserved_word_in_pred_reserved_set1554);
            	a = reserved_word();
            	state.followingStackPointer--;

            	Match(input,52,FOLLOW_52_in_pred_reserved_set1556); 
            	PushFollow(FOLLOW_set_of_strings_in_pred_reserved_set1560);
            	b = set_of_strings();
            	state.followingStackPointer--;

            	retval.key =  ((a != null) ? input.ToString((IToken)(a.Start),(IToken)(a.Stop)) : null); retval.value =  b;

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pred_reserved_set"

    public class pred_numerical_other_return : ParserRuleReturnScope
    {
        public String key;
        public String op;
        public double value;
    };

    // $ANTLR start "pred_numerical_other"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1067:1: pred_numerical_other returns [String key, String op, double value] : a= NAME b= MATH_OP c= number ;
    public BiCCLParser.pred_numerical_other_return pred_numerical_other() // throws RecognitionException [1]
    {   
        BiCCLParser.pred_numerical_other_return retval = new BiCCLParser.pred_numerical_other_return();
        retval.Start = input.LT(1);

        IToken a = null;
        IToken b = null;
        double c = default(double);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1067:67: (a= NAME b= MATH_OP c= number )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1067:69: a= NAME b= MATH_OP c= number
            {
            	a=(IToken)Match(input,NAME,FOLLOW_NAME_in_pred_numerical_other1574); 
            	b=(IToken)Match(input,MATH_OP,FOLLOW_MATH_OP_in_pred_numerical_other1578); 
            	PushFollow(FOLLOW_number_in_pred_numerical_other1582);
            	c = number();
            	state.followingStackPointer--;

            	retval.key =  ((a != null) ? a.Text : null); retval.op =  ((b != null) ? b.Text : null); retval.value =  c;

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pred_numerical_other"

    public class pred_evaluation_return : ParserRuleReturnScope
    {
        public String key;
        public object value;
    };

    // $ANTLR start "pred_evaluation"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1069:1: pred_evaluation returns [String key, object value] : a= NAME '==' (b= boolean | c= number | d= name_or_string ) ;
    public BiCCLParser.pred_evaluation_return pred_evaluation() // throws RecognitionException [1]
    {   
        BiCCLParser.pred_evaluation_return retval = new BiCCLParser.pred_evaluation_return();
        retval.Start = input.LT(1);

        IToken a = null;
        bool b = default(bool);

        double c = default(double);

        String d = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1070:2: (a= NAME '==' (b= boolean | c= number | d= name_or_string ) )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1070:4: a= NAME '==' (b= boolean | c= number | d= name_or_string )
            {
            	a=(IToken)Match(input,NAME,FOLLOW_NAME_in_pred_evaluation1598); 
            	retval.key =  ((a != null) ? a.Text : null);
            	Match(input,51,FOLLOW_51_in_pred_evaluation1602); 
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1071:2: (b= boolean | c= number | d= name_or_string )
            	int alt30 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case BOOLEAN:
            		{
            	    alt30 = 1;
            	    }
            	    break;
            	case INT:
            	case FLOAT:
            		{
            	    alt30 = 2;
            	    }
            	    break;
            	case NAME:
            	case STRING:
            	case 59:
            		{
            	    alt30 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d30s0 =
            		        new NoViableAltException("", 30, 0, input);

            		    throw nvae_d30s0;
            	}

            	switch (alt30) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1071:3: b= boolean
            	        {
            	        	PushFollow(FOLLOW_boolean_in_pred_evaluation1609);
            	        	b = boolean();
            	        	state.followingStackPointer--;

            	        	retval.value =  b;

            	        }
            	        break;
            	    case 2 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1072:3: c= number
            	        {
            	        	PushFollow(FOLLOW_number_in_pred_evaluation1617);
            	        	c = number();
            	        	state.followingStackPointer--;

            	        	retval.value =  c;

            	        }
            	        break;
            	    case 3 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1073:3: d= name_or_string
            	        {
            	        	PushFollow(FOLLOW_name_or_string_in_pred_evaluation1625);
            	        	d = name_or_string();
            	        	state.followingStackPointer--;

            	        	retval.value =  d;

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pred_evaluation"

    public class pred_evaluation_short_return : ParserRuleReturnScope
    {
        public String key;
        public bool value;
    };

    // $ANTLR start "pred_evaluation_short"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1076:1: pred_evaluation_short returns [String key, bool value] : a= negatable_name ;
    public BiCCLParser.pred_evaluation_short_return pred_evaluation_short() // throws RecognitionException [1]
    {   
        BiCCLParser.pred_evaluation_short_return retval = new BiCCLParser.pred_evaluation_short_return();
        retval.Start = input.LT(1);

        BiCCLParser.negatable_name_return a = default(BiCCLParser.negatable_name_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1076:55: (a= negatable_name )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1076:57: a= negatable_name
            {
            	PushFollow(FOLLOW_negatable_name_in_pred_evaluation_short1643);
            	a = negatable_name();
            	state.followingStackPointer--;

            	retval.key =  ((a != null) ? a.value : default(String)); retval.value =  (!(((a != null) ? a.isNegated : default(bool))));

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "pred_evaluation_short"

    public class assignment_return : ParserRuleReturnScope
    {
        public String key;
        public object value;
    };

    // $ANTLR start "assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1079:1: assignment returns [String key, object value] : (a= condition_localization_assignment | b= string_literal_assignment | c= boolean_assignment | d= int_assignment );
    public BiCCLParser.assignment_return assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.assignment_return retval = new BiCCLParser.assignment_return();
        retval.Start = input.LT(1);

        BiCCLParser.condition_localization_assignment_return a = default(BiCCLParser.condition_localization_assignment_return);

        BiCCLParser.string_literal_assignment_return b = default(BiCCLParser.string_literal_assignment_return);

        BiCCLParser.boolean_assignment_return c = default(BiCCLParser.boolean_assignment_return);

        BiCCLParser.int_assignment_return d = default(BiCCLParser.int_assignment_return);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1082:2: (a= condition_localization_assignment | b= string_literal_assignment | c= boolean_assignment | d= int_assignment )
            int alt31 = 4;
            int LA31_0 = input.LA(1);

            if ( ((LA31_0 >= 53 && LA31_0 <= 55)) )
            {
                alt31 = 1;
            }
            else if ( (LA31_0 == NAME) )
            {
                int LA31_2 = input.LA(2);

                if ( (LA31_2 == 31) )
                {
                    switch ( input.LA(3) ) 
                    {
                    case INT:
                    	{
                        alt31 = 4;
                        }
                        break;
                    case NAME:
                    case STRING:
                    case 59:
                    	{
                        alt31 = 2;
                        }
                        break;
                    case BOOLEAN:
                    	{
                        alt31 = 3;
                        }
                        break;
                    	default:
                    	    NoViableAltException nvae_d31s3 =
                    	        new NoViableAltException("", 31, 3, input);

                    	    throw nvae_d31s3;
                    }

                }
                else 
                {
                    NoViableAltException nvae_d31s2 =
                        new NoViableAltException("", 31, 2, input);

                    throw nvae_d31s2;
                }
            }
            else 
            {
                NoViableAltException nvae_d31s0 =
                    new NoViableAltException("", 31, 0, input);

                throw nvae_d31s0;
            }
            switch (alt31) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1082:4: a= condition_localization_assignment
                    {
                    	PushFollow(FOLLOW_condition_localization_assignment_in_assignment1663);
                    	a = condition_localization_assignment();
                    	state.followingStackPointer--;

                    	retval.key =  ((a != null) ? a.key : default(String));retval.value =  ((a != null) ? a.value : default(String));

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1083:3: b= string_literal_assignment
                    {
                    	PushFollow(FOLLOW_string_literal_assignment_in_assignment1671);
                    	b = string_literal_assignment();
                    	state.followingStackPointer--;

                    	retval.key =  ((b != null) ? b.key : default(String));retval.value =  ((b != null) ? b.value : default(String));

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1084:3: c= boolean_assignment
                    {
                    	PushFollow(FOLLOW_boolean_assignment_in_assignment1679);
                    	c = boolean_assignment();
                    	state.followingStackPointer--;

                    	retval.key =  ((c != null) ? c.key : default(String));retval.value =  ((c != null) ? c.value : default(bool));

                    }
                    break;
                case 4 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1085:3: d= int_assignment
                    {
                    	PushFollow(FOLLOW_int_assignment_in_assignment1687);
                    	d = int_assignment();
                    	state.followingStackPointer--;

                    	retval.key =  ((d != null) ? d.key : default(String));retval.value =  ((d != null) ? d.value : default(int));

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "assignment"

    public class boolean_assignment_return : ParserRuleReturnScope
    {
        public String key;
        public bool value;
    };

    // $ANTLR start "boolean_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1089:1: boolean_assignment returns [String key, bool value] : NAME '=' a= boolean ;
    public BiCCLParser.boolean_assignment_return boolean_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.boolean_assignment_return retval = new BiCCLParser.boolean_assignment_return();
        retval.Start = input.LT(1);

        IToken NAME1 = null;
        bool a = default(bool);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1089:53: ( NAME '=' a= boolean )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1089:55: NAME '=' a= boolean
            {
            	NAME1=(IToken)Match(input,NAME,FOLLOW_NAME_in_boolean_assignment1705); 
            	Match(input,31,FOLLOW_31_in_boolean_assignment1707); 
            	PushFollow(FOLLOW_boolean_in_boolean_assignment1711);
            	a = boolean();
            	state.followingStackPointer--;

            	retval.key =  ((NAME1 != null) ? NAME1.Text : null); retval.value =  a;

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "boolean_assignment"

    public class condition_localization_assignment_return : ParserRuleReturnScope
    {
        public String key;
        public String value;
    };

    // $ANTLR start "condition_localization_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1091:1: condition_localization_assignment returns [String key, String value] : a= condition_localization_type '=' b= name_or_string ;
    public BiCCLParser.condition_localization_assignment_return condition_localization_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.condition_localization_assignment_return retval = new BiCCLParser.condition_localization_assignment_return();
        retval.Start = input.LT(1);

        BiCCLParser.condition_localization_type_return a = default(BiCCLParser.condition_localization_type_return);

        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1092:2: (a= condition_localization_type '=' b= name_or_string )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1092:4: a= condition_localization_type '=' b= name_or_string
            {
            	PushFollow(FOLLOW_condition_localization_type_in_condition_localization_assignment1728);
            	a = condition_localization_type();
            	state.followingStackPointer--;

            	Match(input,31,FOLLOW_31_in_condition_localization_assignment1730); 
            	PushFollow(FOLLOW_name_or_string_in_condition_localization_assignment1734);
            	b = name_or_string();
            	state.followingStackPointer--;


            			retval.key =  ((a != null) ? input.ToString((IToken)(a.Start),(IToken)(a.Stop)) : null);
            			retval.value =  b;
            		

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "condition_localization_assignment"

    public class condition_localization_type_return : ParserRuleReturnScope
    {
    };

    // $ANTLR start "condition_localization_type"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1098:1: condition_localization_type : ( 'trueMessage' | 'falseMessage' | 'invalidMessage' );
    public BiCCLParser.condition_localization_type_return condition_localization_type() // throws RecognitionException [1]
    {   
        BiCCLParser.condition_localization_type_return retval = new BiCCLParser.condition_localization_type_return();
        retval.Start = input.LT(1);

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1098:29: ( 'trueMessage' | 'falseMessage' | 'invalidMessage' )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:
            {
            	if ( (input.LA(1) >= 53 && input.LA(1) <= 55) ) 
            	{
            	    input.Consume();
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "condition_localization_type"

    public class int_assignment_return : ParserRuleReturnScope
    {
        public String key;
        public int value;
    };

    // $ANTLR start "int_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1100:1: int_assignment returns [String key, int value] : NAME '=' INT ;
    public BiCCLParser.int_assignment_return int_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.int_assignment_return retval = new BiCCLParser.int_assignment_return();
        retval.Start = input.LT(1);

        IToken NAME2 = null;
        IToken INT3 = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1100:48: ( NAME '=' INT )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1100:50: NAME '=' INT
            {
            	NAME2=(IToken)Match(input,NAME,FOLLOW_NAME_in_int_assignment1762); 
            	Match(input,31,FOLLOW_31_in_int_assignment1764); 
            	INT3=(IToken)Match(input,INT,FOLLOW_INT_in_int_assignment1766); 
            	retval.key =  ((NAME2 != null) ? NAME2.Text : null); retval.value =  int.Parse(((INT3 != null) ? INT3.Text : null));

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "int_assignment"

    public class string_literal_assignment_return : ParserRuleReturnScope
    {
        public String key;
        public String value;
    };

    // $ANTLR start "string_literal_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1101:1: string_literal_assignment returns [String key, String value] : a= NAME '=' b= name_or_string ;
    public BiCCLParser.string_literal_assignment_return string_literal_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.string_literal_assignment_return retval = new BiCCLParser.string_literal_assignment_return();
        retval.Start = input.LT(1);

        IToken a = null;
        String b = default(String);


        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1101:61: (a= NAME '=' b= name_or_string )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1101:63: a= NAME '=' b= name_or_string
            {
            	a=(IToken)Match(input,NAME,FOLLOW_NAME_in_string_literal_assignment1780); 
            	Match(input,31,FOLLOW_31_in_string_literal_assignment1782); 
            	PushFollow(FOLLOW_name_or_string_in_string_literal_assignment1786);
            	b = name_or_string();
            	state.followingStackPointer--;

            	retval.key =  ((a != null) ? a.Text : null); retval.value =  b;

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "string_literal_assignment"

    public class variable_assignment_return : ParserRuleReturnScope
    {
        public String key;
        public String value;
    };

    // $ANTLR start "variable_assignment"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1102:1: variable_assignment returns [String key, String value] : a= NAME '=' b= NAME ;
    public BiCCLParser.variable_assignment_return variable_assignment() // throws RecognitionException [1]
    {   
        BiCCLParser.variable_assignment_return retval = new BiCCLParser.variable_assignment_return();
        retval.Start = input.LT(1);

        IToken a = null;
        IToken b = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1102:56: (a= NAME '=' b= NAME )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1102:58: a= NAME '=' b= NAME
            {
            	a=(IToken)Match(input,NAME,FOLLOW_NAME_in_variable_assignment1801); 
            	Match(input,31,FOLLOW_31_in_variable_assignment1803); 
            	b=(IToken)Match(input,NAME,FOLLOW_NAME_in_variable_assignment1807); 
            	retval.key =  ((a != null) ? a.Text : null); retval.value =  ((b != null) ? b.Text : null);

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "variable_assignment"


    // $ANTLR start "set_of_names"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1106:1: set_of_names returns [List<String> value] : ( null_term | BLOCK_OPEN a= negatable_name BLOCK_CLOSE | BLOCK_OPEN b= negatable_name ( ',' c= negatable_name )+ BLOCK_CLOSE );
    public List<String> set_of_names() // throws RecognitionException [1]
    {   
        List<String> value = default(List<String>);

        BiCCLParser.negatable_name_return a = default(BiCCLParser.negatable_name_return);

        BiCCLParser.negatable_name_return b = default(BiCCLParser.negatable_name_return);

        BiCCLParser.negatable_name_return c = default(BiCCLParser.negatable_name_return);



        	List<String> results = new List<String>();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1113:2: ( null_term | BLOCK_OPEN a= negatable_name BLOCK_CLOSE | BLOCK_OPEN b= negatable_name ( ',' c= negatable_name )+ BLOCK_CLOSE )
            int alt33 = 3;
            int LA33_0 = input.LA(1);

            if ( (LA33_0 == 59) )
            {
                alt33 = 1;
            }
            else if ( (LA33_0 == BLOCK_OPEN) )
            {
                int LA33_2 = input.LA(2);

                if ( (LA33_2 == NOT_OP) )
                {
                    int LA33_3 = input.LA(3);

                    if ( (LA33_3 == NAME) )
                    {
                        int LA33_4 = input.LA(4);

                        if ( (LA33_4 == BLOCK_CLOSE) )
                        {
                            alt33 = 2;
                        }
                        else if ( (LA33_4 == 56) )
                        {
                            alt33 = 3;
                        }
                        else 
                        {
                            NoViableAltException nvae_d33s4 =
                                new NoViableAltException("", 33, 4, input);

                            throw nvae_d33s4;
                        }
                    }
                    else 
                    {
                        NoViableAltException nvae_d33s3 =
                            new NoViableAltException("", 33, 3, input);

                        throw nvae_d33s3;
                    }
                }
                else if ( (LA33_2 == NAME) )
                {
                    int LA33_4 = input.LA(3);

                    if ( (LA33_4 == BLOCK_CLOSE) )
                    {
                        alt33 = 2;
                    }
                    else if ( (LA33_4 == 56) )
                    {
                        alt33 = 3;
                    }
                    else 
                    {
                        NoViableAltException nvae_d33s4 =
                            new NoViableAltException("", 33, 4, input);

                        throw nvae_d33s4;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d33s2 =
                        new NoViableAltException("", 33, 2, input);

                    throw nvae_d33s2;
                }
            }
            else 
            {
                NoViableAltException nvae_d33s0 =
                    new NoViableAltException("", 33, 0, input);

                throw nvae_d33s0;
            }
            switch (alt33) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1113:4: null_term
                    {
                    	PushFollow(FOLLOW_null_term_in_set_of_names1835);
                    	null_term();
                    	state.followingStackPointer--;


                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1114:4: BLOCK_OPEN a= negatable_name BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_names1840); 
                    	PushFollow(FOLLOW_negatable_name_in_set_of_names1844);
                    	a = negatable_name();
                    	state.followingStackPointer--;

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_names1846); 
                    	results.Add(((a != null) ? a.value : default(String)));

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1115:4: BLOCK_OPEN b= negatable_name ( ',' c= negatable_name )+ BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_names1853); 
                    	PushFollow(FOLLOW_negatable_name_in_set_of_names1857);
                    	b = negatable_name();
                    	state.followingStackPointer--;

                    	results.Add(((b != null) ? b.value : default(String)));
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1116:3: ( ',' c= negatable_name )+
                    	int cnt32 = 0;
                    	do 
                    	{
                    	    int alt32 = 2;
                    	    int LA32_0 = input.LA(1);

                    	    if ( (LA32_0 == 56) )
                    	    {
                    	        alt32 = 1;
                    	    }


                    	    switch (alt32) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1116:4: ',' c= negatable_name
                    			    {
                    			    	Match(input,56,FOLLOW_56_in_set_of_names1865); 
                    			    	PushFollow(FOLLOW_negatable_name_in_set_of_names1869);
                    			    	c = negatable_name();
                    			    	state.followingStackPointer--;

                    			    	results.Add(((c != null) ? c.value : default(String)));

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt32 >= 1 ) goto loop32;
                    		            EarlyExitException eee32 =
                    		                new EarlyExitException(32, input);
                    		            throw eee32;
                    	    }
                    	    cnt32++;
                    	} while (true);

                    	loop32:
                    		;	// Stops C# compiler whining that label 'loop32' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_names1875); 

                    }
                    break;

            }
              
            		value =  results;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "set_of_names"


    // $ANTLR start "set_of_strings"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1119:1: set_of_strings returns [List<String> value] : ( null_term | BLOCK_OPEN a= name_or_string BLOCK_CLOSE | BLOCK_OPEN b= name_or_string ( ',' c= name_or_string )+ BLOCK_CLOSE );
    public List<String> set_of_strings() // throws RecognitionException [1]
    {   
        List<String> value = default(List<String>);

        String a = default(String);

        String b = default(String);

        String c = default(String);



        		List<String> results = new List<String>();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1126:2: ( null_term | BLOCK_OPEN a= name_or_string BLOCK_CLOSE | BLOCK_OPEN b= name_or_string ( ',' c= name_or_string )+ BLOCK_CLOSE )
            int alt35 = 3;
            int LA35_0 = input.LA(1);

            if ( (LA35_0 == 59) )
            {
                alt35 = 1;
            }
            else if ( (LA35_0 == BLOCK_OPEN) )
            {
                switch ( input.LA(2) ) 
                {
                case 59:
                	{
                    int LA35_3 = input.LA(3);

                    if ( (LA35_3 == 56) )
                    {
                        alt35 = 3;
                    }
                    else if ( (LA35_3 == BLOCK_CLOSE) )
                    {
                        alt35 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d35s3 =
                            new NoViableAltException("", 35, 3, input);

                        throw nvae_d35s3;
                    }
                    }
                    break;
                case NAME:
                	{
                    int LA35_4 = input.LA(3);

                    if ( (LA35_4 == 56) )
                    {
                        alt35 = 3;
                    }
                    else if ( (LA35_4 == BLOCK_CLOSE) )
                    {
                        alt35 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d35s4 =
                            new NoViableAltException("", 35, 4, input);

                        throw nvae_d35s4;
                    }
                    }
                    break;
                case STRING:
                	{
                    int LA35_5 = input.LA(3);

                    if ( (LA35_5 == BLOCK_CLOSE) )
                    {
                        alt35 = 2;
                    }
                    else if ( (LA35_5 == 56) )
                    {
                        alt35 = 3;
                    }
                    else 
                    {
                        NoViableAltException nvae_d35s5 =
                            new NoViableAltException("", 35, 5, input);

                        throw nvae_d35s5;
                    }
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d35s2 =
                	        new NoViableAltException("", 35, 2, input);

                	    throw nvae_d35s2;
                }

            }
            else 
            {
                NoViableAltException nvae_d35s0 =
                    new NoViableAltException("", 35, 0, input);

                throw nvae_d35s0;
            }
            switch (alt35) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1126:4: null_term
                    {
                    	PushFollow(FOLLOW_null_term_in_set_of_strings1902);
                    	null_term();
                    	state.followingStackPointer--;


                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1127:4: BLOCK_OPEN a= name_or_string BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_strings1907); 
                    	PushFollow(FOLLOW_name_or_string_in_set_of_strings1911);
                    	a = name_or_string();
                    	state.followingStackPointer--;

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_strings1913); 
                    	results.Add(a);

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1128:4: BLOCK_OPEN b= name_or_string ( ',' c= name_or_string )+ BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_strings1920); 
                    	PushFollow(FOLLOW_name_or_string_in_set_of_strings1924);
                    	b = name_or_string();
                    	state.followingStackPointer--;

                    	results.Add(b);
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1129:3: ( ',' c= name_or_string )+
                    	int cnt34 = 0;
                    	do 
                    	{
                    	    int alt34 = 2;
                    	    int LA34_0 = input.LA(1);

                    	    if ( (LA34_0 == 56) )
                    	    {
                    	        alt34 = 1;
                    	    }


                    	    switch (alt34) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1129:4: ',' c= name_or_string
                    			    {
                    			    	Match(input,56,FOLLOW_56_in_set_of_strings1932); 
                    			    	PushFollow(FOLLOW_name_or_string_in_set_of_strings1936);
                    			    	c = name_or_string();
                    			    	state.followingStackPointer--;

                    			    	results.Add(c);

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt34 >= 1 ) goto loop34;
                    		            EarlyExitException eee34 =
                    		                new EarlyExitException(34, input);
                    		            throw eee34;
                    	    }
                    	    cnt34++;
                    	} while (true);

                    	loop34:
                    		;	// Stops C# compiler whining that label 'loop34' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_strings1942); 

                    }
                    break;

            }
              
            		value =  results;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "set_of_strings"


    // $ANTLR start "set_of_assignments"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1132:1: set_of_assignments returns [Dictionary<String, object> value] : ( null_term | BLOCK_OPEN a= assignment BLOCK_CLOSE | BLOCK_OPEN b= assignment ( ',' c= assignment )+ BLOCK_CLOSE );
    public Dictionary<String, object> set_of_assignments() // throws RecognitionException [1]
    {   
        Dictionary<String, object> value = default(Dictionary<String, object>);

        BiCCLParser.assignment_return a = default(BiCCLParser.assignment_return);

        BiCCLParser.assignment_return b = default(BiCCLParser.assignment_return);

        BiCCLParser.assignment_return c = default(BiCCLParser.assignment_return);



        		Dictionary<String, object> results = new Dictionary<String, object>();
        	
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1139:2: ( null_term | BLOCK_OPEN a= assignment BLOCK_CLOSE | BLOCK_OPEN b= assignment ( ',' c= assignment )+ BLOCK_CLOSE )
            int alt37 = 3;
            alt37 = dfa37.Predict(input);
            switch (alt37) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1139:4: null_term
                    {
                    	PushFollow(FOLLOW_null_term_in_set_of_assignments1967);
                    	null_term();
                    	state.followingStackPointer--;


                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1140:4: BLOCK_OPEN a= assignment BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_assignments1972); 
                    	PushFollow(FOLLOW_assignment_in_set_of_assignments1976);
                    	a = assignment();
                    	state.followingStackPointer--;

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_assignments1978); 
                    	results.Add(((a != null) ? a.key : default(String)), ((a != null) ? a.value : default(object)));

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1141:4: BLOCK_OPEN b= assignment ( ',' c= assignment )+ BLOCK_CLOSE
                    {
                    	Match(input,BLOCK_OPEN,FOLLOW_BLOCK_OPEN_in_set_of_assignments1985); 
                    	PushFollow(FOLLOW_assignment_in_set_of_assignments1989);
                    	b = assignment();
                    	state.followingStackPointer--;

                    	results.Add(((b != null) ? b.key : default(String)), ((b != null) ? b.value : default(object)));
                    	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1142:3: ( ',' c= assignment )+
                    	int cnt36 = 0;
                    	do 
                    	{
                    	    int alt36 = 2;
                    	    int LA36_0 = input.LA(1);

                    	    if ( (LA36_0 == 56) )
                    	    {
                    	        alt36 = 1;
                    	    }


                    	    switch (alt36) 
                    		{
                    			case 1 :
                    			    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1142:4: ',' c= assignment
                    			    {
                    			    	Match(input,56,FOLLOW_56_in_set_of_assignments1997); 
                    			    	PushFollow(FOLLOW_assignment_in_set_of_assignments2001);
                    			    	c = assignment();
                    			    	state.followingStackPointer--;

                    			    	results.Add(((c != null) ? c.key : default(String)), ((c != null) ? c.value : default(object)));

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt36 >= 1 ) goto loop36;
                    		            EarlyExitException eee36 =
                    		                new EarlyExitException(36, input);
                    		            throw eee36;
                    	    }
                    	    cnt36++;
                    	} while (true);

                    	loop36:
                    		;	// Stops C# compiler whining that label 'loop36' has no statements

                    	Match(input,BLOCK_CLOSE,FOLLOW_BLOCK_CLOSE_in_set_of_assignments2006); 

                    }
                    break;

            }
              
            		value =  results;
            	
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "set_of_assignments"

    public class reserved_word_return : ParserRuleReturnScope
    {
    };

    // $ANTLR start "reserved_word"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1146:1: reserved_word : ( 'modality' | 'submodality' );
    public BiCCLParser.reserved_word_return reserved_word() // throws RecognitionException [1]
    {   
        BiCCLParser.reserved_word_return retval = new BiCCLParser.reserved_word_return();
        retval.Start = input.LT(1);

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1148:15: ( 'modality' | 'submodality' )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:
            {
            	if ( (input.LA(1) >= 57 && input.LA(1) <= 58) ) 
            	{
            	    input.Consume();
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "reserved_word"


    // $ANTLR start "block_id"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1150:1: block_id returns [String value] : id= NAME ;
    public String block_id() // throws RecognitionException [1]
    {   
        String value = default(String);

        IToken id = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1150:32: (id= NAME )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1150:34: id= NAME
            {
            	id=(IToken)Match(input,NAME,FOLLOW_NAME_in_block_id2035); 
            	value =  ((id != null) ? id.Text : null);

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "block_id"


    // $ANTLR start "boolean"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1152:1: boolean returns [bool value] : b= BOOLEAN ;
    public bool boolean() // throws RecognitionException [1]
    {   
        bool value = default(bool);

        IToken b = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1152:28: (b= BOOLEAN )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1152:30: b= BOOLEAN
            {
            	b=(IToken)Match(input,BOOLEAN,FOLLOW_BOOLEAN_in_boolean2051); 
            	value =  bool.Parse(((b != null) ? b.Text : null));

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "boolean"


    // $ANTLR start "rvalue"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:1: rvalue : ( null_term | boolean | number | name_or_string );
    public void rvalue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:8: ( null_term | boolean | number | name_or_string )
            int alt38 = 4;
            switch ( input.LA(1) ) 
            {
            case 59:
            	{
                alt38 = 1;
                }
                break;
            case BOOLEAN:
            	{
                alt38 = 2;
                }
                break;
            case INT:
            case FLOAT:
            	{
                alt38 = 3;
                }
                break;
            case NAME:
            case STRING:
            	{
                alt38 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d38s0 =
            	        new NoViableAltException("", 38, 0, input);

            	    throw nvae_d38s0;
            }

            switch (alt38) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:10: null_term
                    {
                    	PushFollow(FOLLOW_null_term_in_rvalue2060);
                    	null_term();
                    	state.followingStackPointer--;


                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:20: boolean
                    {
                    	PushFollow(FOLLOW_boolean_in_rvalue2062);
                    	boolean();
                    	state.followingStackPointer--;


                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:28: number
                    {
                    	PushFollow(FOLLOW_number_in_rvalue2064);
                    	number();
                    	state.followingStackPointer--;


                    }
                    break;
                case 4 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1153:35: name_or_string
                    {
                    	PushFollow(FOLLOW_name_or_string_in_rvalue2066);
                    	name_or_string();
                    	state.followingStackPointer--;


                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "rvalue"


    // $ANTLR start "name_or_string"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1155:1: name_or_string returns [String value] : ( null_term | a= NAME | b= STRING );
    public String name_or_string() // throws RecognitionException [1]
    {   
        String value = default(String);

        IToken a = null;
        IToken b = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1156:2: ( null_term | a= NAME | b= STRING )
            int alt39 = 3;
            switch ( input.LA(1) ) 
            {
            case 59:
            	{
                alt39 = 1;
                }
                break;
            case NAME:
            	{
                alt39 = 2;
                }
                break;
            case STRING:
            	{
                alt39 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d39s0 =
            	        new NoViableAltException("", 39, 0, input);

            	    throw nvae_d39s0;
            }

            switch (alt39) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1156:4: null_term
                    {
                    	PushFollow(FOLLOW_null_term_in_name_or_string2078);
                    	null_term();
                    	state.followingStackPointer--;

                    	value = "Empty";

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1157:4: a= NAME
                    {
                    	a=(IToken)Match(input,NAME,FOLLOW_NAME_in_name_or_string2086); 
                    	value = ((a != null) ? a.Text : null);

                    }
                    break;
                case 3 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1158:4: b= STRING
                    {
                    	b=(IToken)Match(input,STRING,FOLLOW_STRING_in_name_or_string2094); 
                    	value = ((b != null) ? b.Text : null).Substring(1,((b != null) ? b.Text : null).Length-2);

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "name_or_string"


    // $ANTLR start "number"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1162:1: number returns [double value] : ( INT | FLOAT );
    public double number() // throws RecognitionException [1]
    {   
        double value = default(double);

        IToken INT4 = null;
        IToken FLOAT5 = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1163:2: ( INT | FLOAT )
            int alt40 = 2;
            int LA40_0 = input.LA(1);

            if ( (LA40_0 == INT) )
            {
                alt40 = 1;
            }
            else if ( (LA40_0 == FLOAT) )
            {
                alt40 = 2;
            }
            else 
            {
                NoViableAltException nvae_d40s0 =
                    new NoViableAltException("", 40, 0, input);

                throw nvae_d40s0;
            }
            switch (alt40) 
            {
                case 1 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1163:4: INT
                    {
                    	INT4=(IToken)Match(input,INT,FOLLOW_INT_in_number2111); 
                    	value =  double.Parse(((INT4 != null) ? INT4.Text : null));

                    }
                    break;
                case 2 :
                    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1164:4: FLOAT
                    {
                    	FLOAT5=(IToken)Match(input,FLOAT,FOLLOW_FLOAT_in_number2118); 
                    	value =  double.Parse(((FLOAT5 != null) ? FLOAT5.Text : null));

                    }
                    break;

            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return value;
    }
    // $ANTLR end "number"

    public class negatable_name_return : ParserRuleReturnScope
    {
        public String value;
        public bool isNegated;
    };

    // $ANTLR start "negatable_name"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1167:1: negatable_name returns [String value, bool isNegated] : (a= NOT_OP )? b= NAME ;
    public BiCCLParser.negatable_name_return negatable_name() // throws RecognitionException [1]
    {   
        BiCCLParser.negatable_name_return retval = new BiCCLParser.negatable_name_return();
        retval.Start = input.LT(1);

        IToken a = null;
        IToken b = null;

        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1168:2: ( (a= NOT_OP )? b= NAME )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1168:4: (a= NOT_OP )? b= NAME
            {
            	// C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1168:5: (a= NOT_OP )?
            	int alt41 = 2;
            	int LA41_0 = input.LA(1);

            	if ( (LA41_0 == NOT_OP) )
            	{
            	    alt41 = 1;
            	}
            	switch (alt41) 
            	{
            	    case 1 :
            	        // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1168:5: a= NOT_OP
            	        {
            	        	a=(IToken)Match(input,NOT_OP,FOLLOW_NOT_OP_in_negatable_name2136); 

            	        }
            	        break;

            	}

            	b=(IToken)Match(input,NAME,FOLLOW_NAME_in_negatable_name2141); 

            			if(a != null) retval.isNegated = true;
            			retval.value =  ((b != null) ? b.Text : null);
            		

            }

            retval.Stop = input.LT(-1);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "negatable_name"


    // $ANTLR start "null_term"
    // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1175:1: null_term : 'none' ;
    public void null_term() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1175:11: ( 'none' )
            // C:\\MBARK\\BiCCL\\BiCCL\\BiCCL.g:1175:13: 'none'
            {
            	Match(input,59,FOLLOW_59_in_null_term2155); 

            }

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end "null_term"

    // Delegated rules


   	protected DFA37 dfa37;
	private void InitializeCyclicDFAs()
	{
    	this.dfa37 = new DFA37(this);
	}

    const string DFA37_eotS =
        "\x11\uffff";
    const string DFA37_eofS =
        "\x11\uffff";
    const string DFA37_minS =
        "\x01\x04\x01\uffff\x01\x09\x02\x1f\x01\x09\x01\x08\x08\x05\x02"+
        "\uffff";
    const string DFA37_maxS =
        "\x01\x3b\x01\uffff\x01\x37\x02\x1f\x02\x3b\x08\x38\x02\uffff";
    const string DFA37_acceptS =
        "\x01\uffff\x01\x01\x0d\uffff\x01\x02\x01\x03";
    const string DFA37_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA37_transitionS = {
            "\x01\x02\x36\uffff\x01\x01",
            "",
            "\x01\x04\x2b\uffff\x03\x03",
            "\x01\x05",
            "\x01\x06",
            "\x01\x08\x05\uffff\x01\x09\x2b\uffff\x01\x07",
            "\x01\x0a\x01\x0d\x04\uffff\x01\x0b\x01\x0e\x2b\uffff\x01\x0c",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "\x01\x0f\x32\uffff\x01\x10",
            "",
            ""
    };

    static readonly short[] DFA37_eot = DFA.UnpackEncodedString(DFA37_eotS);
    static readonly short[] DFA37_eof = DFA.UnpackEncodedString(DFA37_eofS);
    static readonly char[] DFA37_min = DFA.UnpackEncodedStringToUnsignedChars(DFA37_minS);
    static readonly char[] DFA37_max = DFA.UnpackEncodedStringToUnsignedChars(DFA37_maxS);
    static readonly short[] DFA37_accept = DFA.UnpackEncodedString(DFA37_acceptS);
    static readonly short[] DFA37_special = DFA.UnpackEncodedString(DFA37_specialS);
    static readonly short[][] DFA37_transition = DFA.UnpackEncodedStringArray(DFA37_transitionS);

    protected class DFA37 : DFA
    {
        public DFA37(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 37;
            this.eot = DFA37_eot;
            this.eof = DFA37_eof;
            this.min = DFA37_min;
            this.max = DFA37_max;
            this.accept = DFA37_accept;
            this.special = DFA37_special;
            this.transition = DFA37_transition;

        }

        override public string Description
        {
            get { return "1132:1: set_of_assignments returns [Dictionary<String, object> value] : ( null_term | BLOCK_OPEN a= assignment BLOCK_CLOSE | BLOCK_OPEN b= assignment ( ',' c= assignment )+ BLOCK_CLOSE );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_section_in_prog60 = new BitSet(new ulong[]{0x000000001FE00002UL});
    public static readonly BitSet FOLLOW_21_in_section74 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section76 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_localization_def_in_section84 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section95 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_22_in_section101 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section103 = new BitSet(new ulong[]{0x0000000020000080UL});
    public static readonly BitSet FOLLOW_condition_def_in_section108 = new BitSet(new ulong[]{0x00000000200000A0UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_23_in_section118 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section120 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_equiv_def_in_section128 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section140 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_24_in_section145 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section147 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_sensor_def_in_section155 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section164 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_25_in_section169 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section171 = new BitSet(new ulong[]{0x0000010000000200UL});
    public static readonly BitSet FOLLOW_config_def_in_section179 = new BitSet(new ulong[]{0x0000010000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section186 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_26_in_section191 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section193 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_task_def_in_section195 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section198 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_27_in_section204 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section206 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_init_state_def_in_section214 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section225 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_28_in_section230 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_section232 = new BitSet(new ulong[]{0x0002200000000000UL});
    public static readonly BitSet FOLLOW_workflow_def_in_section236 = new BitSet(new ulong[]{0x0002200000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_section239 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_localization_name_in_localization_def270 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_localization_def272 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_localization_assignment_in_localization_def279 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_localization_def285 = new BitSet(new ulong[]{0x0000000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_localization_def289 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_localization_name308 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_literal_assignment_in_localization_assignment326 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_condition_signature_in_condition_def379 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_condition_name_in_condition_def383 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_condition_def385 = new BitSet(new ulong[]{0x0000000F40000000UL});
    public static readonly BitSet FOLLOW_condition_initval_in_condition_def393 = new BitSet(new ulong[]{0x0000000F40000020UL});
    public static readonly BitSet FOLLOW_condition_message_assignment_in_condition_def404 = new BitSet(new ulong[]{0x0000000F40000020UL});
    public static readonly BitSet FOLLOW_condition_unmet_prereq_in_condition_def415 = new BitSet(new ulong[]{0x0000000F40000020UL});
    public static readonly BitSet FOLLOW_condition_requires_in_condition_def426 = new BitSet(new ulong[]{0x0000000F40000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_condition_def435 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_29_in_condition_signature454 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_RETURN_TYPE_in_condition_signature459 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_condition_name479 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_condition_initval494 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_condition_initval496 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_boolean_in_condition_initval500 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_condition_initval502 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_condition_message_type_in_condition_message_assignment526 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_condition_message_assignment528 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_condition_localization_assignment_in_condition_message_assignment535 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_condition_message_assignment541 = new BitSet(new ulong[]{0x00E0000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_condition_message_assignment545 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_condition_unmet_prereq563 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_condition_unmet_prereq565 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_unmet_prereq_message_in_condition_unmet_prereq569 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_condition_unmet_prereq571 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_33_in_condition_requires588 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_condition_requires590 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_in_condition_requires594 = new BitSet(new ulong[]{0x0000000000000060UL});
    public static readonly BitSet FOLLOW_EOL_in_condition_requires596 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_condition_requires599 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_condition_message_type0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_name_or_string_in_unmet_prereq_message631 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_equiv_def652 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_equiv_def654 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_in_equiv_def658 = new BitSet(new ulong[]{0x0000000000000060UL});
    public static readonly BitSet FOLLOW_EOL_in_equiv_def660 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_equiv_def663 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_EOL_in_equiv_def665 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sensor_name_in_sensor_def691 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_sensor_def693 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_sensor_plugin_in_sensor_def699 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_sensor_namespace_in_sensor_def705 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_sensor_class_in_sensor_def711 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_sensor_conf_class_in_sensor_def718 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_sensor_def723 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_sensor_name744 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_sensor_plugin757 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_sensor_plugin759 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_sensor_plugin763 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_sensor_plugin765 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_sensor_namespace781 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_sensor_namespace783 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_sensor_namespace787 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_sensor_namespace789 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_38_in_sensor_class805 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_sensor_class807 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_sensor_class811 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_sensor_class813 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_sensor_conf_class831 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_sensor_conf_class833 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_sensor_conf_class837 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_sensor_conf_class839 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_config_literal_in_config_def862 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_config_def864 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_config_def869 = new BitSet(new ulong[]{0x0000010000000200UL});
    public static readonly BitSet FOLLOW_config_type_in_config_def871 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_config_name_in_config_def873 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_config_def875 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_config_def885 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_config_type_in_config_def893 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_config_name_in_config_def904 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_config_def906 = new BitSet(new ulong[]{0x00E0000000000220UL});
    public static readonly BitSet FOLLOW_assignment_in_config_def913 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_config_def923 = new BitSet(new ulong[]{0x00E0000000000220UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_config_def933 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_literal_assignment_in_config_literal946 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_config_type957 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_config_name970 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_task_name_in_task_def987 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_task_def991 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_task_sensor_in_task_def996 = new BitSet(new ulong[]{0x0000040000000000UL});
    public static readonly BitSet FOLLOW_task_conf_in_task_def1002 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_task_primary_cat_in_task_def1007 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_task_reassignable_cat_in_task_def1012 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_task_def1021 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_block_id_in_task_name1040 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_41_in_task_sensor1053 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_task_sensor1055 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_task_sensor1059 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_task_sensor1061 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_task_conf1072 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_task_conf1074 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_task_conf1078 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_task_conf1080 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_43_in_task_primary_cat1091 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_task_primary_cat1093 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_task_primary_cat1097 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_task_primary_cat1099 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_task_reassignable_cat1112 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_task_reassignable_cat1114 = new BitSet(new ulong[]{0x0800000000000010UL});
    public static readonly BitSet FOLLOW_set_of_strings_in_task_reassignable_cat1118 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_task_reassignable_cat1120 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_boolean_assignment_in_init_state_def1145 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_init_state_def1153 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_workflow_statement_in_workflow_def1172 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_workflow_def1179 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_46_in_workflow_def1181 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_in_workflow_def1185 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_workflow_def1187 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_workflow_def1189 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_workflow_statement_in_workflow_def1197 = new BitSet(new ulong[]{0x0002000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_workflow_def1205 = new BitSet(new ulong[]{0x0001000000000002UL});
    public static readonly BitSet FOLLOW_48_in_workflow_def1210 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_workflow_def1212 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_workflow_statement_in_workflow_def1220 = new BitSet(new ulong[]{0x0002000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_workflow_def1228 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_49_in_workflow_statement1245 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_INT_in_workflow_statement1249 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_NAME_in_workflow_statement1253 = new BitSet(new ulong[]{0x0004000000000040UL});
    public static readonly BitSet FOLLOW_with_state_in_workflow_statement1258 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_EOL_in_workflow_statement1264 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_50_in_with_state1282 = new BitSet(new ulong[]{0x0800000000000010UL});
    public static readonly BitSet FOLLOW_set_of_assignments_in_with_state1286 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_predicate_factory_compoundAnd_in_predicate_factory1328 = new BitSet(new ulong[]{0x0000000000000402UL});
    public static readonly BitSet FOLLOW_OR_OP_in_predicate_factory1331 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_in_predicate_factory1335 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_predicate_factory_atom_in_predicate_factory_compoundAnd1361 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_AND_OP_in_predicate_factory_compoundAnd1364 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_compoundAnd_in_predicate_factory_compoundAnd1368 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_predicate_factory_atom_base_in_predicate_factory_atom1395 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NOT_OP_in_predicate_factory_atom1406 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_46_in_predicate_factory_atom1409 = new BitSet(new ulong[]{0x0600400000005200UL});
    public static readonly BitSet FOLLOW_predicate_factory_in_predicate_factory_atom1413 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_predicate_factory_atom1415 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_boolean_in_predicate_factory_atom_base1445 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_reserved_single_in_predicate_factory_atom_base1456 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_reserved_set_in_predicate_factory_atom_base1467 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_numerical_other_in_predicate_factory_atom_base1479 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_evaluation_in_predicate_factory_atom_base1490 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pred_evaluation_short_in_predicate_factory_atom_base1501 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_boolean_in_pred_boolean1520 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_reserved_word_in_pred_reserved_single1534 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_pred_reserved_single1536 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_pred_reserved_single1540 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_reserved_word_in_pred_reserved_set1554 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_52_in_pred_reserved_set1556 = new BitSet(new ulong[]{0x0800000000000010UL});
    public static readonly BitSet FOLLOW_set_of_strings_in_pred_reserved_set1560 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_pred_numerical_other1574 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_MATH_OP_in_pred_numerical_other1578 = new BitSet(new ulong[]{0x0000000000010100UL});
    public static readonly BitSet FOLLOW_number_in_pred_numerical_other1582 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_pred_evaluation1598 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_pred_evaluation1602 = new BitSet(new ulong[]{0x080000000001C300UL});
    public static readonly BitSet FOLLOW_boolean_in_pred_evaluation1609 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_pred_evaluation1617 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_name_or_string_in_pred_evaluation1625 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negatable_name_in_pred_evaluation_short1643 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_condition_localization_assignment_in_assignment1663 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_literal_assignment_in_assignment1671 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_boolean_assignment_in_assignment1679 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_int_assignment_in_assignment1687 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_boolean_assignment1705 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_boolean_assignment1707 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_boolean_in_boolean_assignment1711 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_condition_localization_type_in_condition_localization_assignment1728 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_condition_localization_assignment1730 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_condition_localization_assignment1734 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_condition_localization_type0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_int_assignment1762 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_int_assignment1764 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_INT_in_int_assignment1766 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_string_literal_assignment1780 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_string_literal_assignment1782 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_string_literal_assignment1786 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_variable_assignment1801 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_variable_assignment1803 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_NAME_in_variable_assignment1807 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_term_in_set_of_names1835 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_names1840 = new BitSet(new ulong[]{0x0600000000005200UL});
    public static readonly BitSet FOLLOW_negatable_name_in_set_of_names1844 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_names1846 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_names1853 = new BitSet(new ulong[]{0x0600000000005200UL});
    public static readonly BitSet FOLLOW_negatable_name_in_set_of_names1857 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_56_in_set_of_names1865 = new BitSet(new ulong[]{0x0600000000005200UL});
    public static readonly BitSet FOLLOW_negatable_name_in_set_of_names1869 = new BitSet(new ulong[]{0x0100000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_names1875 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_term_in_set_of_strings1902 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_strings1907 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_set_of_strings1911 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_strings1913 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_strings1920 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_set_of_strings1924 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_56_in_set_of_strings1932 = new BitSet(new ulong[]{0x0800000000008200UL});
    public static readonly BitSet FOLLOW_name_or_string_in_set_of_strings1936 = new BitSet(new ulong[]{0x0100000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_strings1942 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_term_in_set_of_assignments1967 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_assignments1972 = new BitSet(new ulong[]{0x00E0000000000200UL});
    public static readonly BitSet FOLLOW_assignment_in_set_of_assignments1976 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_assignments1978 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BLOCK_OPEN_in_set_of_assignments1985 = new BitSet(new ulong[]{0x00E0000000000200UL});
    public static readonly BitSet FOLLOW_assignment_in_set_of_assignments1989 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_56_in_set_of_assignments1997 = new BitSet(new ulong[]{0x00E0000000000200UL});
    public static readonly BitSet FOLLOW_assignment_in_set_of_assignments2001 = new BitSet(new ulong[]{0x0100000000000020UL});
    public static readonly BitSet FOLLOW_BLOCK_CLOSE_in_set_of_assignments2006 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_reserved_word0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_block_id2035 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BOOLEAN_in_boolean2051 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_term_in_rvalue2060 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_boolean_in_rvalue2062 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_rvalue2064 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_name_or_string_in_rvalue2066 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_null_term_in_name_or_string2078 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_name_or_string2086 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_in_name_or_string2094 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_number2111 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOAT_in_number2118 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NOT_OP_in_negatable_name2136 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_NAME_in_negatable_name2141 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_null_term2155 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}