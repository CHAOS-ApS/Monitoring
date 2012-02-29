﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("MonitorLibraryModel", "FK_Plugin_PluginType", "PluginType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CHAOS.Monitoring.Data.Standard.PluginType), "Plugin", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CHAOS.Monitoring.Data.Standard.Plugin), true)]
[assembly: EdmRelationshipAttribute("MonitorLibraryModel", "FK_Plugin_Trigger", "Trigger", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(CHAOS.Monitoring.Data.Standard.Trigger), "Plugin", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(CHAOS.Monitoring.Data.Standard.Plugin), true)]

#endregion

namespace CHAOS.Monitoring.Data.Standard
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MonitorLibraryEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new MonitorLibraryEntities object using the connection string found in the 'MonitorLibraryEntities' section of the application configuration file.
        /// </summary>
        public MonitorLibraryEntities() : base("name=MonitorLibraryEntities", "MonitorLibraryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MonitorLibraryEntities object.
        /// </summary>
        public MonitorLibraryEntities(string connectionString) : base(connectionString, "MonitorLibraryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MonitorLibraryEntities object.
        /// </summary>
        public MonitorLibraryEntities(EntityConnection connection) : base(connection, "MonitorLibraryEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Trigger> Trigger
        {
            get
            {
                if ((_Trigger == null))
                {
                    _Trigger = base.CreateObjectSet<Trigger>("Trigger");
                }
                return _Trigger;
            }
        }
        private ObjectSet<Trigger> _Trigger;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PluginInfo> PluginInfo
        {
            get
            {
                if ((_PluginInfo == null))
                {
                    _PluginInfo = base.CreateObjectSet<PluginInfo>("PluginInfo");
                }
                return _PluginInfo;
            }
        }
        private ObjectSet<PluginInfo> _PluginInfo;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Plugin> Plugin
        {
            get
            {
                if ((_Plugin == null))
                {
                    _Plugin = base.CreateObjectSet<Plugin>("Plugin");
                }
                return _Plugin;
            }
        }
        private ObjectSet<Plugin> _Plugin;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PluginType> PluginType
        {
            get
            {
                if ((_PluginType == null))
                {
                    _PluginType = base.CreateObjectSet<PluginType>("PluginType");
                }
                return _PluginType;
            }
        }
        private ObjectSet<PluginType> _PluginType;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Trigger EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTrigger(Trigger trigger)
        {
            base.AddObject("Trigger", trigger);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PluginInfo EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPluginInfo(PluginInfo pluginInfo)
        {
            base.AddObject("PluginInfo", pluginInfo);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Plugin EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPlugin(Plugin plugin)
        {
            base.AddObject("Plugin", plugin);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PluginType EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPluginType(PluginType pluginType)
        {
            base.AddObject("PluginType", pluginType);
        }

        #endregion
        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectResult<Trigger> Trigger_Get()
        {
            return base.ExecuteFunction<Trigger>("Trigger_Get");
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="mergeOption"></param>
        public ObjectResult<Trigger> Trigger_Get(MergeOption mergeOption)
        {
            return base.ExecuteFunction<Trigger>("Trigger_Get", mergeOption);
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectResult<PluginInfo> PluginInfo_Get()
        {
            return base.ExecuteFunction<PluginInfo>("PluginInfo_Get");
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        /// <param name="mergeOption"></param>
        public ObjectResult<PluginInfo> PluginInfo_Get(MergeOption mergeOption)
        {
            return base.ExecuteFunction<PluginInfo>("PluginInfo_Get", mergeOption);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MonitorLibraryModel", Name="Plugin")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Plugin : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Plugin object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="hostAdress">Initial value of the HostAdress property.</param>
        /// <param name="pluginTypeID">Initial value of the PluginTypeID property.</param>
        /// <param name="triggerID">Initial value of the TriggerID property.</param>
        public static Plugin CreatePlugin(global::System.Int32 id, global::System.String hostAdress, global::System.Int32 pluginTypeID, global::System.Int32 triggerID)
        {
            Plugin plugin = new Plugin();
            plugin.ID = id;
            plugin.HostAdress = hostAdress;
            plugin.PluginTypeID = pluginTypeID;
            plugin.TriggerID = triggerID;
            return plugin;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String HostAdress
        {
            get
            {
                return _HostAdress;
            }
            set
            {
                OnHostAdressChanging(value);
                ReportPropertyChanging("HostAdress");
                _HostAdress = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("HostAdress");
                OnHostAdressChanged();
            }
        }
        private global::System.String _HostAdress;
        partial void OnHostAdressChanging(global::System.String value);
        partial void OnHostAdressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PluginTypeID
        {
            get
            {
                return _PluginTypeID;
            }
            set
            {
                OnPluginTypeIDChanging(value);
                ReportPropertyChanging("PluginTypeID");
                _PluginTypeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PluginTypeID");
                OnPluginTypeIDChanged();
            }
        }
        private global::System.Int32 _PluginTypeID;
        partial void OnPluginTypeIDChanging(global::System.Int32 value);
        partial void OnPluginTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TriggerID
        {
            get
            {
                return _TriggerID;
            }
            set
            {
                OnTriggerIDChanging(value);
                ReportPropertyChanging("TriggerID");
                _TriggerID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TriggerID");
                OnTriggerIDChanged();
            }
        }
        private global::System.Int32 _TriggerID;
        partial void OnTriggerIDChanging(global::System.Int32 value);
        partial void OnTriggerIDChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MonitorLibraryModel", "FK_Plugin_PluginType", "PluginType")]
        public PluginType PluginType
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PluginType>("MonitorLibraryModel.FK_Plugin_PluginType", "PluginType").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PluginType>("MonitorLibraryModel.FK_Plugin_PluginType", "PluginType").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<PluginType> PluginTypeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PluginType>("MonitorLibraryModel.FK_Plugin_PluginType", "PluginType");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<PluginType>("MonitorLibraryModel.FK_Plugin_PluginType", "PluginType", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MonitorLibraryModel", "FK_Plugin_Trigger", "Trigger")]
        public Trigger Trigger
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Trigger>("MonitorLibraryModel.FK_Plugin_Trigger", "Trigger").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Trigger>("MonitorLibraryModel.FK_Plugin_Trigger", "Trigger").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Trigger> TriggerReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Trigger>("MonitorLibraryModel.FK_Plugin_Trigger", "Trigger");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Trigger>("MonitorLibraryModel.FK_Plugin_Trigger", "Trigger", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MonitorLibraryModel", Name="PluginInfo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PluginInfo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PluginInfo object.
        /// </summary>
        /// <param name="pluginID">Initial value of the PluginID property.</param>
        /// <param name="triggerID">Initial value of the TriggerID property.</param>
        /// <param name="hostAdress">Initial value of the HostAdress property.</param>
        /// <param name="classpath">Initial value of the Classpath property.</param>
        /// <param name="pluginTypeID">Initial value of the PluginTypeID property.</param>
        /// <param name="classname">Initial value of the Classname property.</param>
        public static PluginInfo CreatePluginInfo(global::System.Int32 pluginID, global::System.Int32 triggerID, global::System.String hostAdress, global::System.String classpath, global::System.Int32 pluginTypeID, global::System.String classname)
        {
            PluginInfo pluginInfo = new PluginInfo();
            pluginInfo.PluginID = pluginID;
            pluginInfo.TriggerID = triggerID;
            pluginInfo.HostAdress = hostAdress;
            pluginInfo.Classpath = classpath;
            pluginInfo.PluginTypeID = pluginTypeID;
            pluginInfo.Classname = classname;
            return pluginInfo;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PluginID
        {
            get
            {
                return _PluginID;
            }
            set
            {
                if (_PluginID != value)
                {
                    OnPluginIDChanging(value);
                    ReportPropertyChanging("PluginID");
                    _PluginID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PluginID");
                    OnPluginIDChanged();
                }
            }
        }
        private global::System.Int32 _PluginID;
        partial void OnPluginIDChanging(global::System.Int32 value);
        partial void OnPluginIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TriggerID
        {
            get
            {
                return _TriggerID;
            }
            set
            {
                if (_TriggerID != value)
                {
                    OnTriggerIDChanging(value);
                    ReportPropertyChanging("TriggerID");
                    _TriggerID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TriggerID");
                    OnTriggerIDChanged();
                }
            }
        }
        private global::System.Int32 _TriggerID;
        partial void OnTriggerIDChanging(global::System.Int32 value);
        partial void OnTriggerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String HostAdress
        {
            get
            {
                return _HostAdress;
            }
            set
            {
                if (_HostAdress != value)
                {
                    OnHostAdressChanging(value);
                    ReportPropertyChanging("HostAdress");
                    _HostAdress = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("HostAdress");
                    OnHostAdressChanged();
                }
            }
        }
        private global::System.String _HostAdress;
        partial void OnHostAdressChanging(global::System.String value);
        partial void OnHostAdressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Classpath
        {
            get
            {
                return _Classpath;
            }
            set
            {
                if (_Classpath != value)
                {
                    OnClasspathChanging(value);
                    ReportPropertyChanging("Classpath");
                    _Classpath = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Classpath");
                    OnClasspathChanged();
                }
            }
        }
        private global::System.String _Classpath;
        partial void OnClasspathChanging(global::System.String value);
        partial void OnClasspathChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PluginTypeID
        {
            get
            {
                return _PluginTypeID;
            }
            set
            {
                if (_PluginTypeID != value)
                {
                    OnPluginTypeIDChanging(value);
                    ReportPropertyChanging("PluginTypeID");
                    _PluginTypeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PluginTypeID");
                    OnPluginTypeIDChanged();
                }
            }
        }
        private global::System.Int32 _PluginTypeID;
        partial void OnPluginTypeIDChanging(global::System.Int32 value);
        partial void OnPluginTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Classname
        {
            get
            {
                return _Classname;
            }
            set
            {
                if (_Classname != value)
                {
                    OnClassnameChanging(value);
                    ReportPropertyChanging("Classname");
                    _Classname = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Classname");
                    OnClassnameChanged();
                }
            }
        }
        private global::System.String _Classname;
        partial void OnClassnameChanging(global::System.String value);
        partial void OnClassnameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MonitorLibraryModel", Name="PluginType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class PluginType : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new PluginType object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="classpath">Initial value of the Classpath property.</param>
        /// <param name="classname">Initial value of the Classname property.</param>
        public static PluginType CreatePluginType(global::System.Int32 id, global::System.String classpath, global::System.String classname)
        {
            PluginType pluginType = new PluginType();
            pluginType.ID = id;
            pluginType.Classpath = classpath;
            pluginType.Classname = classname;
            return pluginType;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Classpath
        {
            get
            {
                return _Classpath;
            }
            set
            {
                OnClasspathChanging(value);
                ReportPropertyChanging("Classpath");
                _Classpath = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Classpath");
                OnClasspathChanged();
            }
        }
        private global::System.String _Classpath;
        partial void OnClasspathChanging(global::System.String value);
        partial void OnClasspathChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Classname
        {
            get
            {
                return _Classname;
            }
            set
            {
                OnClassnameChanging(value);
                ReportPropertyChanging("Classname");
                _Classname = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Classname");
                OnClassnameChanged();
            }
        }
        private global::System.String _Classname;
        partial void OnClassnameChanging(global::System.String value);
        partial void OnClassnameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MonitorLibraryModel", "FK_Plugin_PluginType", "Plugin")]
        public EntityCollection<Plugin> Plugin
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Plugin>("MonitorLibraryModel.FK_Plugin_PluginType", "Plugin");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Plugin>("MonitorLibraryModel.FK_Plugin_PluginType", "Plugin", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MonitorLibraryModel", Name="Trigger")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Trigger : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Trigger object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="enabled">Initial value of the Enabled property.</param>
        /// <param name="startDateTime">Initial value of the StartDateTime property.</param>
        /// <param name="repetition">Initial value of the Repetition property.</param>
        public static Trigger CreateTrigger(global::System.Int32 id, global::System.Boolean enabled, global::System.DateTime startDateTime, global::System.Int32 repetition)
        {
            Trigger trigger = new Trigger();
            trigger.ID = id;
            trigger.Enabled = enabled;
            trigger.StartDateTime = startDateTime;
            trigger.Repetition = repetition;
            return trigger;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                OnEnabledChanging(value);
                ReportPropertyChanging("Enabled");
                _Enabled = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Enabled");
                OnEnabledChanged();
            }
        }
        private global::System.Boolean _Enabled;
        partial void OnEnabledChanging(global::System.Boolean value);
        partial void OnEnabledChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime StartDateTime
        {
            get
            {
                return _StartDateTime;
            }
            set
            {
                OnStartDateTimeChanging(value);
                ReportPropertyChanging("StartDateTime");
                _StartDateTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StartDateTime");
                OnStartDateTimeChanged();
            }
        }
        private global::System.DateTime _StartDateTime;
        partial void OnStartDateTimeChanging(global::System.DateTime value);
        partial void OnStartDateTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Repetition
        {
            get
            {
                return _Repetition;
            }
            set
            {
                OnRepetitionChanging(value);
                ReportPropertyChanging("Repetition");
                _Repetition = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Repetition");
                OnRepetitionChanged();
            }
        }
        private global::System.Int32 _Repetition;
        partial void OnRepetitionChanging(global::System.Int32 value);
        partial void OnRepetitionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MonitorLibraryModel", "FK_Plugin_Trigger", "Plugin")]
        public EntityCollection<Plugin> Plugin
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Plugin>("MonitorLibraryModel.FK_Plugin_Trigger", "Plugin");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Plugin>("MonitorLibraryModel.FK_Plugin_Trigger", "Plugin", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
