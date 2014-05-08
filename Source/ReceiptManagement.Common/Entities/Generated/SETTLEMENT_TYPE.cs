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
    public partial class SETTLEMENT_TYPE : Entities.EntityObject, Helpers.IDataEntity, Helpers.ITrackable
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.SETTLEMENT_TYPE sETTLEMENT_TYPE);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public SETTLEMENT_TYPE() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a SETTLEMENT_TYPE.
    	/// </summary>
    	/// <returns>The new SETTLEMENT_TYPE instance. </returns>
    	public static Entities.SETTLEMENT_TYPE Factory()
    	{
    		OnCreating();
    		Entities.SETTLEMENT_TYPE sETTLEMENT_TYPE = new Entities.SETTLEMENT_TYPE();
    		OnCreated(sETTLEMENT_TYPE);
    		
    		return sETTLEMENT_TYPE;
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
        public virtual ICollection<SETTLEMENT> SETTLEMENTS
        {
            get
            {
                if (_sETTLEMENTS == null)
                {
                    var newCollection = new FixupCollection<SETTLEMENT>();
                    newCollection.CollectionChanged += FixupSETTLEMENTS;
                    _sETTLEMENTS = newCollection;
                }
                return _sETTLEMENTS;
            }
            set
            {
                if (!ReferenceEquals(_sETTLEMENTS, value))
                {
                    var previousValue = _sETTLEMENTS as FixupCollection<SETTLEMENT>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSETTLEMENTS;
                    }
                    _sETTLEMENTS = value;
                    var newValue = value as FixupCollection<SETTLEMENT>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSETTLEMENTS;
                    }
                }
            }
        }
        private ICollection<SETTLEMENT> _sETTLEMENTS;

        #endregion

        #region Association Fixup
    
        private void FixupSETTLEMENTS(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (SETTLEMENT item in e.NewItems)
                {
                    item.SETTLEMENT_TYPE = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (SETTLEMENT item in e.OldItems)
                {
                    if (ReferenceEquals(item.SETTLEMENT_TYPE, this))
                    {
                        item.SETTLEMENT_TYPE = null;
                    }
                }
            }
        }

        #endregion

    }
}
