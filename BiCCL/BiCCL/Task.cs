namespace NIST.BiCCL
{

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;

    using Mbark.Sensors;
    /*
     * A simple container for task info that needs to get placed
     * inline into workflow definitions. 
     */
    public class Task
    {

        private SensorConfiguration configuration;

        private SensorTaskCategory intendedCategory;
        private String name;
        private String sensor;

        private List<SensorTaskCategory> reassignableCategories;


        public Task()
        {
        }

        public Task(String _name)
        {
            name = _name;
        }

        public SensorConfiguration getConfiguration()
        {
            return configuration;
        }

        public void setConfiguration(SensorConfiguration config)
        {
            configuration = config;
        }

        public SensorTaskCategory getIntendedCategory()
        {
            return intendedCategory;
        }

        public void setIntendedCategory(SensorTaskCategory category)
        {
            intendedCategory = category;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String _name)
        {
            name = _name;
        }

        public String getSensor()
        {
            return sensor;
        }

        public void setSensor(String _sensor)
        {
            sensor = _sensor;
        }

        public List<SensorTaskCategory> getReassignableCategories()
        {
            return reassignableCategories;
        }

        public void addReassignableCategory(SensorTaskCategory newCat)
        {
            if (reassignableCategories == null) reassignableCategories = new List<SensorTaskCategory>();
            reassignableCategories.Add(newCat);
        }

        //NOTE: This does a reference assignment, NOT a deep copy.
        public void setReassignableCategories(List<SensorTaskCategory> categories)
        {
            reassignableCategories = categories;
            //System.out.println("Task::setReassignableCategories just set them to "+categories);
        }

        public String to_xml()
        {
            //FIXME: Write this!!
            return "";
        }
    }
}