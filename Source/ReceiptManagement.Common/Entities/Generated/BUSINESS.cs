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
    public partial class BUSINESS : Entities.EntityObject, Helpers.IDataEntity, Helpers.ITrackable
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.BUSINESS bUSINESS);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public BUSINESS() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a BUSINESS.
    	/// </summary>
    	/// <returns>The new BUSINESS instance. </returns>
    	public static Entities.BUSINESS Factory()
    	{
    		OnCreating();
    		Entities.BUSINESS bUSINESS = new Entities.BUSINESS();
    		OnCreated(bUSINESS);
    		
    		return bUSINESS;
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
        public virtual Nullable<System.Guid> SUBSCRIPTION_ID
        {
            get { return _sUBSCRIPTION_ID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_sUBSCRIPTION_ID != value)
                    {
                        if (SUBSCRIPTION != null && SUBSCRIPTION.ID != value)
                        {
                            SUBSCRIPTION = null;
                        }
                        _sUBSCRIPTION_ID = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<System.Guid> _sUBSCRIPTION_ID;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_NAME
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_STREET
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_CITY
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_STATE
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_ZIPCODE
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string BUSINESS_COUNTRY
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual System.DateTime CREATED_ON
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual System.Guid CREATED_BY
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.DateTime> UPDATED_ON
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.Guid> UPDATED_BY
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual SUBSCRIPTION SUBSCRIPTION
        {
            get { return _sUBSCRIPTION; }
            set
            {
                if (!ReferenceEquals(_sUBSCRIPTION, value))
                {
                    var previousValue = _sUBSCRIPTION;
                    _sUBSCRIPTION = value;
                    FixupSUBSCRIPTION(previousValue);
                }
            }
        }
        private SUBSCRIPTION _sUBSCRIPTION;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<USER> USERS
        {
            get
            {
                if (_uSERS == null)
                {
                    var newCollection = new FixupCollection<USER>();
                    newCollection.CollectionChanged += FixupUSERS;
                    _uSERS = newCollection;
                }
                return _uSERS;
            }
            set
            {
                if (!ReferenceEquals(_uSERS, value))
                {
                    var previousValue = _uSERS as FixupCollection<USER>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupUSERS;
                    }
                    _uSERS = value;
                    var newValue = value as FixupCollection<USER>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupUSERS;
                    }
                }
            }
        }
        private ICollection<USER> _uSERS;

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupSUBSCRIPTION(SUBSCRIPTION previousValue)
        {
            if (previousValue != null && previousValue.BUSINESSES.Contains(this))
            {
                previousValue.BUSINESSES.Remove(this);
            }
    
            if (SUBSCRIPTION != null)
            {
                if (!SUBSCRIPTION.BUSINESSES.Contains(this))
                {
                    SUBSCRIPTION.BUSINESSES.Add(this);
                }
                if (SUBSCRIPTION_ID != SUBSCRIPTION.ID)
                {
                    SUBSCRIPTION_ID = SUBSCRIPTION.ID;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //SUBSCRIPTION_ID = null;
            }
        }
    
        private void FixupUSERS(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (USER item in e.NewItems)
                {
                    item.BUSINESS = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (USER item in e.OldItems)
                {
                    if (ReferenceEquals(item.BUSINESS, this))
                    {
                        item.BUSINESS = null;
                    }
                }
            }
        }

        #endregion

    }
}
