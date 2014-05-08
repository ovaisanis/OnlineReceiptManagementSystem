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
    public partial class SocialUser : Entities.EntityObject
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.SocialUser socialUser);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public SocialUser() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a SocialUser.
    	/// </summary>
    	/// <returns>The new SocialUser instance. </returns>
    	public static Entities.SocialUser Factory()
    	{
    		OnCreating();
    		Entities.SocialUser socialUser = new Entities.SocialUser();
    		OnCreated(socialUser);
    		
    		return socialUser;
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
        public virtual string Name
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string SocialNetworkName
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string Token
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual System.DateTime CreatedOn
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.DateTime> LastLogin
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<System_Social_UsersAssociation> System_Social_UsersAssociation
        {
            get
            {
                if (_system_Social_UsersAssociation == null)
                {
                    var newCollection = new FixupCollection<System_Social_UsersAssociation>();
                    newCollection.CollectionChanged += FixupSystem_Social_UsersAssociation;
                    _system_Social_UsersAssociation = newCollection;
                }
                return _system_Social_UsersAssociation;
            }
            set
            {
                if (!ReferenceEquals(_system_Social_UsersAssociation, value))
                {
                    var previousValue = _system_Social_UsersAssociation as FixupCollection<System_Social_UsersAssociation>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupSystem_Social_UsersAssociation;
                    }
                    _system_Social_UsersAssociation = value;
                    var newValue = value as FixupCollection<System_Social_UsersAssociation>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupSystem_Social_UsersAssociation;
                    }
                }
            }
        }
        private ICollection<System_Social_UsersAssociation> _system_Social_UsersAssociation;

        #endregion

        #region Association Fixup
    
        private void FixupSystem_Social_UsersAssociation(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (System_Social_UsersAssociation item in e.NewItems)
                {
                    item.SocialUser = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (System_Social_UsersAssociation item in e.OldItems)
                {
                    if (ReferenceEquals(item.SocialUser, this))
                    {
                        item.SocialUser = null;
                    }
                }
            }
        }

        #endregion

    }
}