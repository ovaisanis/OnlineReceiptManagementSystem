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
    public partial class INCIDENT_ATTACHMENT : Entities.EntityObject, Helpers.IDataEntity, Helpers.ITrackable
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.INCIDENT_ATTACHMENT iNCIDENT_ATTACHMENT);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public INCIDENT_ATTACHMENT() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a INCIDENT_ATTACHMENT.
    	/// </summary>
    	/// <returns>The new INCIDENT_ATTACHMENT instance. </returns>
    	public static Entities.INCIDENT_ATTACHMENT Factory()
    	{
    		OnCreating();
    		Entities.INCIDENT_ATTACHMENT iNCIDENT_ATTACHMENT = new Entities.INCIDENT_ATTACHMENT();
    		OnCreated(iNCIDENT_ATTACHMENT);
    		
    		return iNCIDENT_ATTACHMENT;
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
        public virtual Nullable<System.Guid> INCIDENT_ID
        {
            get { return _iNCIDENT_ID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_iNCIDENT_ID != value)
                    {
                        if (INCIDENT != null && INCIDENT.ID != value)
                        {
                            INCIDENT = null;
                        }
                        _iNCIDENT_ID = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<System.Guid> _iNCIDENT_ID;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<System.Guid> FILE_ID
        {
            get { return _fILE_ID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_fILE_ID != value)
                    {
                        if (ATTACHMENT != null && ATTACHMENT.ID != value)
                        {
                            ATTACHMENT = null;
                        }
                        _fILE_ID = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<System.Guid> _fILE_ID;

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual INCIDENT INCIDENT
        {
            get { return _iNCIDENT; }
            set
            {
                if (!ReferenceEquals(_iNCIDENT, value))
                {
                    var previousValue = _iNCIDENT;
                    _iNCIDENT = value;
                    FixupINCIDENT(previousValue);
                }
            }
        }
        private INCIDENT _iNCIDENT;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual ATTACHMENT ATTACHMENT
        {
            get { return _aTTACHMENT; }
            set
            {
                if (!ReferenceEquals(_aTTACHMENT, value))
                {
                    var previousValue = _aTTACHMENT;
                    _aTTACHMENT = value;
                    FixupATTACHMENT(previousValue);
                }
            }
        }
        private ATTACHMENT _aTTACHMENT;

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupINCIDENT(INCIDENT previousValue)
        {
            if (previousValue != null && previousValue.INCIDENT_ATTACHMENT.Contains(this))
            {
                previousValue.INCIDENT_ATTACHMENT.Remove(this);
            }
    
            if (INCIDENT != null)
            {
                if (!INCIDENT.INCIDENT_ATTACHMENT.Contains(this))
                {
                    INCIDENT.INCIDENT_ATTACHMENT.Add(this);
                }
                if (INCIDENT_ID != INCIDENT.ID)
                {
                    INCIDENT_ID = INCIDENT.ID;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //INCIDENT_ID = null;
            }
        }
    
        private void FixupATTACHMENT(ATTACHMENT previousValue)
        {
            if (previousValue != null && previousValue.INCIDENT_ATTACHMENT.Contains(this))
            {
                previousValue.INCIDENT_ATTACHMENT.Remove(this);
            }
    
            if (ATTACHMENT != null)
            {
                if (!ATTACHMENT.INCIDENT_ATTACHMENT.Contains(this))
                {
                    ATTACHMENT.INCIDENT_ATTACHMENT.Add(this);
                }
                if (FILE_ID != ATTACHMENT.ID)
                {
                    FILE_ID = ATTACHMENT.ID;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //FILE_ID = null;
            }
        }

        #endregion

    }
}
