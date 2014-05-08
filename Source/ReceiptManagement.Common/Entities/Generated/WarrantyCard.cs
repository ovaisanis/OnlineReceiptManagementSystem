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
    public partial class WarrantyCard : Entities.EntityObject
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.WarrantyCard warrantyCard);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public WarrantyCard() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a WarrantyCard.
    	/// </summary>
    	/// <returns>The new WarrantyCard instance. </returns>
    	public static Entities.WarrantyCard Factory()
    	{
    		OnCreating();
    		Entities.WarrantyCard warrantyCard = new Entities.WarrantyCard();
    		OnCreated(warrantyCard);
    		
    		return warrantyCard;
    	}

        #endregion

    
        #region Primitive Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual long Id
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.DateTime> WarrantyExpireOn
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<long> UserId
        {
            get { return _userId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_userId != value)
                    {
                        if (User != null && User.Id != value)
                        {
                            User = null;
                        }
                        _userId = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<long> _userId;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<bool> IsDeleted
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<My_Products_Services> My_Products_Services
        {
            get
            {
                if (_my_Products_Services == null)
                {
                    var newCollection = new FixupCollection<My_Products_Services>();
                    newCollection.CollectionChanged += FixupMy_Products_Services;
                    _my_Products_Services = newCollection;
                }
                return _my_Products_Services;
            }
            set
            {
                if (!ReferenceEquals(_my_Products_Services, value))
                {
                    var previousValue = _my_Products_Services as FixupCollection<My_Products_Services>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupMy_Products_Services;
                    }
                    _my_Products_Services = value;
                    var newValue = value as FixupCollection<My_Products_Services>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupMy_Products_Services;
                    }
                }
            }
        }
        private ICollection<My_Products_Services> _my_Products_Services;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
                    _user = value;
                    FixupUser(previousValue);
                }
            }
        }
        private User _user;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<WarrantyCardImage> WarrantyCardImages
        {
            get
            {
                if (_warrantyCardImages == null)
                {
                    var newCollection = new FixupCollection<WarrantyCardImage>();
                    newCollection.CollectionChanged += FixupWarrantyCardImages;
                    _warrantyCardImages = newCollection;
                }
                return _warrantyCardImages;
            }
            set
            {
                if (!ReferenceEquals(_warrantyCardImages, value))
                {
                    var previousValue = _warrantyCardImages as FixupCollection<WarrantyCardImage>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupWarrantyCardImages;
                    }
                    _warrantyCardImages = value;
                    var newValue = value as FixupCollection<WarrantyCardImage>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupWarrantyCardImages;
                    }
                }
            }
        }
        private ICollection<WarrantyCardImage> _warrantyCardImages;

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.WarrantyCards.Contains(this))
            {
                previousValue.WarrantyCards.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.WarrantyCards.Contains(this))
                {
                    User.WarrantyCards.Add(this);
                }
                if (UserId != User.Id)
                {
                    UserId = User.Id;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //UserId = null;
            }
        }
    
        private void FixupMy_Products_Services(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (My_Products_Services item in e.NewItems)
                {
                    item.WarrantyCard = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (My_Products_Services item in e.OldItems)
                {
                    if (ReferenceEquals(item.WarrantyCard, this))
                    {
                        item.WarrantyCard = null;
                    }
                }
            }
        }
    
        private void FixupWarrantyCardImages(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (WarrantyCardImage item in e.NewItems)
                {
                    item.WarrantyCard = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarrantyCardImage item in e.OldItems)
                {
                    if (ReferenceEquals(item.WarrantyCard, this))
                    {
                        item.WarrantyCard = null;
                    }
                }
            }
        }

        #endregion

    }
}
