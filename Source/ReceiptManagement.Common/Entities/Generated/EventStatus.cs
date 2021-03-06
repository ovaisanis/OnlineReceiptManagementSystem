//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ReceiptManagement.Common.Entities
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class EventStatus : Entities.EntityObject
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.EventStatus eventStatus);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public EventStatus() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a EventStatus.
    	/// </summary>
    	/// <returns>The new EventStatus instance. </returns>
    	public static Entities.EventStatus Factory()
    	{
    		OnCreating();
    		Entities.EventStatus eventStatus = new Entities.EventStatus();
    		OnCreated(eventStatus);
    		
    		return eventStatus;
    	}

        #endregion

    
        #region Primitive Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string EventStatus1
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<EventsInfo> EventsInfoes
        {
            get
            {
                if (_eventsInfoes == null)
                {
                    var newCollection = new FixupCollection<EventsInfo>();
                    newCollection.CollectionChanged += FixupEventsInfoes;
                    _eventsInfoes = newCollection;
                }
                return _eventsInfoes;
            }
            set
            {
                if (!ReferenceEquals(_eventsInfoes, value))
                {
                    var previousValue = _eventsInfoes as FixupCollection<EventsInfo>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupEventsInfoes;
                    }
                    _eventsInfoes = value;
                    var newValue = value as FixupCollection<EventsInfo>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupEventsInfoes;
                    }
                }
            }
        }
        private ICollection<EventsInfo> _eventsInfoes;

        #endregion

        #region Association Fixup
    
        private void FixupEventsInfoes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (EventsInfo item in e.NewItems)
                {
                    item.EventStatus = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (EventsInfo item in e.OldItems)
                {
                    if (ReferenceEquals(item.EventStatus, this))
                    {
                        item.EventStatus = null;
                    }
                }
            }
        }

        #endregion

    }
}
