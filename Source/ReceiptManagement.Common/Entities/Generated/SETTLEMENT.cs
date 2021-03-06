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
    public partial class SETTLEMENT : Entities.EntityObject, Helpers.IDataEntity, Helpers.ITrackable
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.SETTLEMENT sETTLEMENT);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public SETTLEMENT() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a SETTLEMENT.
    	/// </summary>
    	/// <returns>The new SETTLEMENT instance. </returns>
    	public static Entities.SETTLEMENT Factory()
    	{
    		OnCreating();
    		Entities.SETTLEMENT sETTLEMENT = new Entities.SETTLEMENT();
    		OnCreated(sETTLEMENT);
    		
    		return sETTLEMENT;
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
        public virtual Nullable<System.Guid> SETTLEMENT_TYPE_ID
        {
            get { return _sETTLEMENT_TYPE_ID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_sETTLEMENT_TYPE_ID != value)
                    {
                        if (SETTLEMENT_TYPE != null && SETTLEMENT_TYPE.ID != value)
                        {
                            SETTLEMENT_TYPE = null;
                        }
                        _sETTLEMENT_TYPE_ID = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<System.Guid> _sETTLEMENT_TYPE_ID;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string SETTLEMENT_DETAIL
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual decimal AMOUNT
        {
            get { return _aMOUNT; }
            set { _aMOUNT = value; }
        }
        private decimal _aMOUNT = 0m;
    
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
        public virtual SETTLEMENT_TYPE SETTLEMENT_TYPE
        {
            get { return _sETTLEMENT_TYPE; }
            set
            {
                if (!ReferenceEquals(_sETTLEMENT_TYPE, value))
                {
                    var previousValue = _sETTLEMENT_TYPE;
                    _sETTLEMENT_TYPE = value;
                    FixupSETTLEMENT_TYPE(previousValue);
                }
            }
        }
        private SETTLEMENT_TYPE _sETTLEMENT_TYPE;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<INCIDENT> INCIDENTS
        {
            get
            {
                if (_iNCIDENTS == null)
                {
                    var newCollection = new FixupCollection<INCIDENT>();
                    newCollection.CollectionChanged += FixupINCIDENTS;
                    _iNCIDENTS = newCollection;
                }
                return _iNCIDENTS;
            }
            set
            {
                if (!ReferenceEquals(_iNCIDENTS, value))
                {
                    var previousValue = _iNCIDENTS as FixupCollection<INCIDENT>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupINCIDENTS;
                    }
                    _iNCIDENTS = value;
                    var newValue = value as FixupCollection<INCIDENT>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupINCIDENTS;
                    }
                }
            }
        }
        private ICollection<INCIDENT> _iNCIDENTS;

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupSETTLEMENT_TYPE(SETTLEMENT_TYPE previousValue)
        {
            if (previousValue != null && previousValue.SETTLEMENTS.Contains(this))
            {
                previousValue.SETTLEMENTS.Remove(this);
            }
    
            if (SETTLEMENT_TYPE != null)
            {
                if (!SETTLEMENT_TYPE.SETTLEMENTS.Contains(this))
                {
                    SETTLEMENT_TYPE.SETTLEMENTS.Add(this);
                }
                if (SETTLEMENT_TYPE_ID != SETTLEMENT_TYPE.ID)
                {
                    SETTLEMENT_TYPE_ID = SETTLEMENT_TYPE.ID;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //SETTLEMENT_TYPE_ID = null;
            }
        }
    
        private void FixupINCIDENTS(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (INCIDENT item in e.NewItems)
                {
                    item.SETTLEMENT = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (INCIDENT item in e.OldItems)
                {
                    if (ReferenceEquals(item.SETTLEMENT, this))
                    {
                        item.SETTLEMENT = null;
                    }
                }
            }
        }

        #endregion

    }
}
