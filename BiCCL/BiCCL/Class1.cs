using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

using Mbark;
using Mbark.SensorMessages;
using Mbark.Sensors;
using Mbark.Sensors.Builtins;
using Mbark.Sensors.Workflow;
using Mbark.UI;

namespace NIST.BiCCL
{
    public class Class1
    {
        
//        public void doThing()
//        {
//            String str = "";
//            LocalizableStringDefinition tempString = new LocalizableStringDefinition();
//            tempString.Name = str;

//        }
//        /*Begin helper methods */
//        public String makeConditionFactoryName(Object basePart, Object uniquePart)
//        {
//            return basePart + "_" + uniquePart;
//        }
//        public LocalizableStringDefinition createSimpleLocalizableString(String strName, String region, String message)
//        {
//            //Create a simple string mapping
//            RegionMessagePair theMessage = new RegionMessagePair();
//            theMessage.Region = region;
//            theMessage.Message = message;

//            LocalizableStringDefinition tempString = new LocalizableStringDefinition();
//            tempString.Name = strName;
//            tempString.RegionMessagePairs.Add(theMessage);

//            return tempString;
//        }

        public E[] concatArray<E>(E[] oldArray, E newItem)
        {
            E[] temp;
            if (oldArray == null)
            {
                temp = new E[1];
                temp[1] = newItem;
            }
            else
            {
                temp = new E[oldArray.Length + 1];
                for (int i = 0; i < oldArray.Length; i++)
                {
                    temp[i] = oldArray[i];
                }
                temp[temp.Length - 1] = newItem;

            }
            
            return temp;
        }

//        //Do a deep copy of the ConditionFactory parameter, but set the initial value to the newInitialValue
////and set the factory name accordingly.
//public ConditionFactoryDefinition duplicateConditionFactory(ConditionFactoryDefinition orig, Object newInitialValue)
//{
//    ConditionFactoryDefinition fact = new ConditionFactoryDefinition();
//    fact.ConditionDescriptionString = orig.ConditionDescriptionString;
//    fact.ConditionInitialValue = newInitialValue;
//    fact.ConditionIsStatic = orig.ConditionIsStatic;
//    fact.ConditionName = orig.ConditionName;
//    fact.InitializationArgs.AddRange(orig.InitializationArgs);
//    fact.FactoryName = orig.ConditionName + "_" + newInitialValue;
//    fact.PrerequisiteFactoryDefinition = orig.PrerequisiteFactoryDefinition;
//    fact.ConditionType = orig.ConditionType;
//    return fact;
//}

        public void mainAfter()
        {
            /* REMOVE ME */
            SensorTaskFactoryCollectionDefinition factories = new SensorTaskFactoryCollectionDefinition();
            /*Localizations section*/
            LocalizableStringCollectionDefinition messageLibrary = new LocalizableStringCollectionDefinition();
            List<LocalizableStringDefinition> lsd = new List<LocalizableStringDefinition>(); //THIS HAS TO BE REMOVED, and the strings added with messageLibrary.Add(LocalizableString)

            /*Begin sensors & configs section*/
            Dictionary<String, SensorTypeDefinition> sensors = new Dictionary<String, SensorTypeDefinition>();
            Dictionary<String, SensorConfiguration> configs = new Dictionary<String, SensorConfiguration>();
            String sensorNamespace = "Mbark.Sensors.";

            /*Begin conditions and equivalence section*/
            //NOTE: This is used to hold both the conditions and the equivalence classes.
            ConditionFactoryCollectionDefinition conditionLibrary = new ConditionFactoryCollectionDefinition();
            /*End conditions and equivalence section*/

            /*Begin tasks section (This is all internal; only used to paste into relevant workflow items.*/
            Dictionary<String, Task> tasks = new Dictionary<String, Task>();

            /*Begin initial state section */
            ConditionCollection currentConditions = new ConditionCollection();
            Collection<ConditionDefinition> conditionArray = new Collection<ConditionDefinition>();

            /*Begin workflow section*/
            Collection<SensorTaskFactoryDefinition> factoryDefinitions = new Collection<SensorTaskFactoryDefinition>();

            /*END REMOVE ME*/

        }
    }
}