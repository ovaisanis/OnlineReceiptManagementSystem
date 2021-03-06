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

namespace ResolutionOffice.Common.Entities
{
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SUBSCRIPTION_TYPE : Entities.EntityObject, Helpers.IDataEntity, Helpers.ITrackable
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.SUBSCRIPTION_TYPE sUBSCRIPTION_TYPE);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public SUBSCRIPTION_TYPE() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a SUBSCRIPTION_TYPE.
    	/// </summary>
    	/// <returns>The new SUBSCRIPTION_TYPE instance. </returns>
    	public static Entities.SUBSCRIPTION_TYPE Factory()
    	{
    		OnCreating();
    		Entities.SUBSCRIPTION_TYPE sUBSCRIPTION_TYPE = new Entities.SUBSCRIPTION_TYPE();
    		OnCreated(sUBSCRIPTION_TYPE);
    		
    		return sUBSCRIPTION_TYPE;
    	}

        #endregion

    
        #region Primitive Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual System.Guid ID
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual int TYPE_CODE
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string TYPE_DESC
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<SUBSCRIPTION> SUBSCRIPTIONS
        {
            get
            {
                if (_sUBSCRIPTIONS == null)
                {
                    var newCollection = new FixupCollection<SUBSCRIPTION>();
                    newCollection.CollectionChanged += FixupSUBSCRIPTIONS;
                    _sUBSCRIPTIONS = newCollection;
                }
                return _sUBSCRIPTIONS;
            }
            set
            {
                if (!ReferenceEquals(_sUBSCRIPTIONS, value))
                {
                    var previousValue = _sUBSCRIPTIONS as FixupCollection<SUBSCRIPTION>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSUBSCRIPTIONS;
                    }
                    _sUBSCRIPTIONS = value;
                    var newValue = value as FixupCollection<SUBSCRIPTION>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSUBSCRIPTIONS;
                    }
                }
            }
        }
        private ICollection<SUBSCRIPTION> _sUBSCRIPTIONS;

        #endregion

        #region Association Fixup
    
        private void FixupSUBSCRIPTIONS(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SUBSCRIPTION item in e.NewItems)
                {
                    item.SUBSCRIPTION_TYPE = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SUBSCRIPTION item in e.OldItems)
                {
                    if (ReferenceEquals(item.SUBSCRIPTION_TYPE, this))
                    {
                        item.SUBSCRIPTION_TYPE = null;
                    }
                }
            }
        }

        #endregion

    }
}
