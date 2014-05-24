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
    public partial class Image : Entities.EntityObject
    {
        #region Partial Methods
    
        //	This partial method gives us a way to update an object before it is added to the system.
        static partial void OnCreating();
    
        //	This partial method gives us a way to access an object after it has been added to the system.
        static partial void OnCreated(Entities.Image image);

        #endregion

    
        #region Constructors & Factories
    
    	//	Internal constructor since it shouldn't be called outside of the API.
    	//: Making constructor public so that entities can be instantiated by MVC/Telerik controls
    	public Image() 
    	{
    		//this.CreatedOn = this.ModifiedOn = DateTime.Parse("1753-01-01 00:00:00.000"); 
    	}
    
    	/// <summary>
    	///		Creates a new instance of a Image.
    	/// </summary>
    	/// <returns>The new Image instance. </returns>
    	public static Entities.Image Factory()
    	{
    		OnCreating();
    		Entities.Image image = new Entities.Image();
    		OnCreated(image);
    		
    		return image;
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
        public virtual Nullable<int> ImageTypeId
        {
            get { return _imageTypeId; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_imageTypeId != value)
                    {
                        if (ImageType != null && ImageType.Id != value)
                        {
                            ImageType = null;
                        }
                        _imageTypeId = value;
                    }
    			}
                finally
                {
                    _settingFK = true;
    			}
            }
        }
        private Nullable<int> _imageTypeId;
    
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
        public virtual string Path
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual Nullable<int> FileSize
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual string FileFormat
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
        public virtual Nullable<bool> IsDeleted
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual bool IsTrackable
        {
            get;
            set;
        }
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual long UserId
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
        private long _userId;

        #endregion

        #region Navigation Properties
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
    	[System.Web.Script.Serialization.ScriptIgnore]
        public virtual ImageType ImageType
        {
            get { return _imageType; }
            set
            {
                if (!ReferenceEquals(_imageType, value))
                {
                    var previousValue = _imageType;
                    _imageType = value;
                    FixupImageType(previousValue);
                }
            }
        }
        private ImageType _imageType;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<Product_Service_Images> Product_Service_Images
        {
            get
            {
                if (_product_Service_Images == null)
                {
                    var newCollection = new FixupCollection<Product_Service_Images>();
                    newCollection.CollectionChanged += FixupProduct_Service_Images;
                    _product_Service_Images = newCollection;
                }
                return _product_Service_Images;
            }
            set
            {
                if (!ReferenceEquals(_product_Service_Images, value))
                {
                    var previousValue = _product_Service_Images as FixupCollection<Product_Service_Images>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupProduct_Service_Images;
                    }
                    _product_Service_Images = value;
                    var newValue = value as FixupCollection<Product_Service_Images>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupProduct_Service_Images;
                    }
                }
            }
        }
        private ICollection<Product_Service_Images> _product_Service_Images;
    
    	/// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public virtual ICollection<ReceiptImage> ReceiptImages
        {
            get
            {
                if (_receiptImages == null)
                {
                    var newCollection = new FixupCollection<ReceiptImage>();
                    newCollection.CollectionChanged += FixupReceiptImages;
                    _receiptImages = newCollection;
                }
                return _receiptImages;
            }
            set
            {
                if (!ReferenceEquals(_receiptImages, value))
                {
                    var previousValue = _receiptImages as FixupCollection<ReceiptImage>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReceiptImages;
                    }
                    _receiptImages = value;
                    var newValue = value as FixupCollection<ReceiptImage>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReceiptImages;
                    }
                }
            }
        }
        private ICollection<ReceiptImage> _receiptImages;
    
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

        #endregion

        #region Association Fixup
    			
    	private bool _settingFK = false; 
    			
        private void FixupImageType(ImageType previousValue)
        {
            if (previousValue != null && previousValue.Images.Contains(this))
            {
                previousValue.Images.Remove(this);
            }
    
            if (ImageType != null)
            {
                if (!ImageType.Images.Contains(this))
                {
                    ImageType.Images.Add(this);
                }
                if (ImageTypeId != ImageType.Id)
                {
                    ImageTypeId = ImageType.Id;
                }
            }
            else if (!_settingFK)
            {
                /* [NOTE] -- 
    			 * I have commented following, as in case of detaching entities from ObjectState it was making EntityId Null into referenced entities,
    			 * which is not desired behavior for us.
    			 */
                //ImageTypeId = null;
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (previousValue != null && previousValue.Images.Contains(this))
            {
                previousValue.Images.Remove(this);
            }
    
            if (User != null)
            {
                if (!User.Images.Contains(this))
                {
                    User.Images.Add(this);
                }
                if (UserId != User.Id)
                {
                    UserId = User.Id;
                }
            }
        }
    
        private void FixupProduct_Service_Images(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Product_Service_Images item in e.NewItems)
                {
                    item.Image = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Product_Service_Images item in e.OldItems)
                {
                    if (ReferenceEquals(item.Image, this))
                    {
                        item.Image = null;
                    }
                }
            }
        }
    
        private void FixupReceiptImages(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ReceiptImage item in e.NewItems)
                {
                    item.Image = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ReceiptImage item in e.OldItems)
                {
                    if (ReferenceEquals(item.Image, this))
                    {
                        item.Image = null;
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
                    item.Image = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (WarrantyCardImage item in e.OldItems)
                {
                    if (ReferenceEquals(item.Image, this))
                    {
                        item.Image = null;
                    }
                }
            }
        }

        #endregion

    }
}
